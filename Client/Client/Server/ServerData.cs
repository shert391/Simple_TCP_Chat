namespace Client
{
    public class ServerData
    {
        public int Port { get; }
        public string IP { get; }

        public ServerData(int port, string ip)
        {
            Port = port;
            IP = ip;
        }
    }
}
