internal class PacketReceiver
{
    private readonly NameValidator _nameValidator = new();

    private string GetString(int lenghtByteBuffer, NetworkStream stream)
    {
        byte[] buffer = new byte[lenghtByteBuffer];
        int lenght = stream.Read(buffer, 0, buffer.Length);
        return Encoding.UTF8.GetString(buffer, 0, lenght);
    }

    public string? GetName(NetworkStream stream, List<Client> _clients)
    {
        string name = GetString(100, stream);
        string answer = _nameValidator.Valid(name, _clients);
        byte[] buffer = Encoding.UTF8.GetBytes(answer);
        stream.Write(buffer, 0, buffer.Length);
        if (answer == "ок")
        {
            stream.Write(buffer, 0, 1); /* Костыль - для уничтожения потока на клиенте :-) */
            return name;
        }
        else
        {
            return null;
        }
    }

    public void ProcessСommand(NetworkStream stream, PacketSender packetSender, List<Client> clients, Client currentClient)
    {
        try
        {
            bool performance = true;
            while (performance)
            {
                byte[] buffer = new byte[10124];
                int lenght = stream.Read(buffer, 0, buffer.Length);
                ClientCommand command = (ClientCommand)buffer[0];
                string stringData = Encoding.UTF8.GetString(buffer, 1, lenght - 1);
                switch (command)
                {
                    case ClientCommand.DISCONNECT_ME:
                        stream.Close();
                        clients.Remove(currentClient);
                        performance = false;
                        ConsoleStyle.AlertConsole(currentClient.Name, "покинул чат!");
                        packetSender.DeleteUser(currentClient, clients);
                        break;
                    case ClientCommand.NEW_MESSAGE:
                        Console.WriteLine($"{currentClient.Name}: {stringData}");
                        byte[] sendByte = Encoding.UTF8.GetBytes($"{currentClient.Name}: {stringData}");
                        for (int i = 0; i < clients.Count; i++)
                        {
                            packetSender.SendCommand(clients[i].Stream, command, sendByte);
                        }
                        break;
                }
            }
        }
        catch
        {
            ConsoleStyle.AlertConsole(currentClient.Name, "покинул чат!");
            packetSender.DeleteUser(currentClient, clients);
            clients.Remove(currentClient);
        }
    }
}

