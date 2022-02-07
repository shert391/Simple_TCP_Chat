internal class ServerObject
{
    private readonly PacketReceiver _packetReceiver = new();
    private readonly PacketSender _packetSender = new();

    private readonly List<Client> _clients = new();

    public void StartServer(int port)
    {
        TcpListener serverSocket = new(IPAddress.Any, port);
        serverSocket.Start();

        ConsoleStyle.WriteConsoleColor("Сервер запущен, ожидаем подключений!", ConsoleColor.Green, true);

        Thread connectionHandler = new(new ParameterizedThreadStart(ConnectionHandler));
        connectionHandler.Name = "Обработчик подключений";
        connectionHandler.Start(serverSocket);
    }

    public void ConnectionHandler(object? serverSocketObject)
    {
        if (serverSocketObject != null)
        {
            TcpListener serverSocket = (TcpListener)serverSocketObject;

            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                Thread clientListener = new(new ParameterizedThreadStart(ClientListener));
                clientListener.Name = "Неизвестное подключение";
                clientListener.Start(clientSocket);
            }
        }
    }

    public void ClientListener(object? clientSocketObject)
    {
        if (clientSocketObject != null)
        {
            TcpClient clientSocket = (TcpClient)clientSocketObject;
            NetworkStream stream = clientSocket.GetStream();
            string? name = null;

            while (name == null)
            {
                try
                {
                    name = _packetReceiver.GetName(stream, _clients);
                }
                catch
                {
                    return;
                }
            }

            Thread.CurrentThread.Name = name;

            ConsoleStyle.AlertConsole(name, "зашёл в чат!");       

            Client client = new(name, stream);

            _clients.Add(client);

            _packetSender.SubmitListAllUsers(stream, _clients);

            for (int i = 0; i < _clients.Count; i++)
            {
                if (client.ID != _clients[i].ID)
                {
                    _packetSender.SendCommand(_clients[i].Stream, ClientCommand.NEW_CONNECTION, Encoding.UTF8.GetBytes(name));           
                }
            }

            _packetReceiver.ProcessСommand(stream, _packetSender, _clients, client);
        }
    }
    public void CloseServer()
    {
        for(int i = 0; i < _clients.Count; i++)
            _packetSender.SendCommand(_clients[i].Stream, ClientCommand.SERVER_CLOSE);
    }
}