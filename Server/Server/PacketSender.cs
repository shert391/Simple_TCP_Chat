internal class PacketSender
{
    public void SubmitListAllUsers(NetworkStream stream, List<Client> clients)
    {
        StringBuilder stringBuffer = new();

        for (int i = 0; i < clients.Count; i++)
        {
            for (int j = 0; j < clients[i].Name.Length; j++)
                stringBuffer.Append(clients[i].Name[j]);

            if (clients.Count != 1 && i != clients.Count - 1)
                stringBuffer.Append(',');
        }

        byte[] buffer = Encoding.UTF8.GetBytes(stringBuffer.ToString());
        stream.Write(buffer, 0, buffer.Length);
    }

    public void DeleteUser(Client currentClient, List<Client> clients)
    {
        for (int i = 0; i < clients.Count; i++)
        {
            if (clients[i].ID != currentClient.ID)
            {
                List<byte> bufferList = new()
                {
                    (byte)ClientCommand.CLOSE_CONNECTION
                };
                bufferList.AddRange(Encoding.UTF8.GetBytes(currentClient.Name));
                byte[] buffer = bufferList.ToArray();
                clients[i].Stream.Write(buffer, 0, buffer.Length);
            }
        }
    }

    public void SendCommand(NetworkStream stream, ClientCommand command, byte[] data)
    {
        List<byte> bufferList = new()
        {
            (byte)command
        };
        bufferList.AddRange(data);
        byte[] buffer = bufferList.ToArray();
        stream.Write(buffer, 0, buffer.Length);
    }

    public void SendCommand(NetworkStream stream, ClientCommand command)
    {
        byte[] buffer = new byte[1];
        buffer[0] = (byte)command;
        stream.Write(buffer, 0, buffer.Length);
    }
}

