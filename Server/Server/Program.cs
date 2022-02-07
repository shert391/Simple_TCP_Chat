ServerObject server = new();
PacketSender sender = new();

server.StartServer(port: 7000);

AppDomain.CurrentDomain.ProcessExit += Exit;

void Exit(object? one, EventArgs two) => server.CloseServer();