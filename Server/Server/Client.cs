internal class Client
{
    public NetworkStream Stream { get; }
    public string ID { get; }
    public string Name { get; }

    public Client(string name, NetworkStream stream)
    {
        Name = name;
        Stream = stream;
        ID = Guid.NewGuid().ToString();
    }

}
