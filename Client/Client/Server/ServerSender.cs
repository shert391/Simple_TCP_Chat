using System.Collections.Generic;
using System.Text;

namespace Client
{
    public partial class ServerСommunication
    {
        public string SendName(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            _stream.Write(buffer, 0, buffer.Length);
            buffer = new byte[100];
            int lenght = _stream.Read(buffer, 0, buffer.Length);
            string answer = Encoding.UTF8.GetString(buffer, 0, lenght);
            return answer;
        }

        private void SendCommand(ServerCommand command)
        {
            byte[] buffer = new byte[1] { (byte)command };
            _stream.Write(buffer, 0, buffer.Length);
        }

        public void SendCommand(ServerCommand command, byte[] data)
        {
            List<byte> bufferList = new List<byte>
            {
                (byte)command
            };
            bufferList.AddRange(data);
            byte[] buffer = bufferList.ToArray();
            _stream.Write(buffer, 0, buffer.Length);
        }
    }
}
