using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public partial class ServerСommunication
    {
        public List<string> GetListAllUsers()
        {
            byte[] buffer = new byte[1024];
            int lenght = _stream.Read(buffer, 0, buffer.Length);
            List<string> result = Encoding.UTF8.GetString(buffer, 1, lenght - 1).Split(',').ToList();
            return result;
        }

        public void ListenServer(object clientMainFormObject)
        {
            ClientMainForm clientMainForm = (ClientMainForm)clientMainFormObject;
            string stringData;
            ServerCommand command;
            byte[] buffer;

            while (true)
            {
                buffer = new byte[10124];
                try
                {
                    int lenght = _stream.Read(buffer, 0, buffer.Length);
                    command = (ServerCommand)buffer[0];
                    stringData = Encoding.UTF8.GetString(buffer, 1, lenght - 1);
                }
                catch
                {
                    return;
                }
                string message;
                switch (command)
                {              
                    case (ServerCommand.NEW_CONNECTION):    
                        message = $"Server: {stringData} присоединился к чату";
                        if (clientMainForm.DisconnectButton.InvokeRequired)
                        {
                            clientMainForm.DisconnectButton.Invoke(new Action<string>(clientMainForm.AddListUser), stringData);
                            clientMainForm.DisconnectButton.Invoke(new Action<string>(clientMainForm.ServerMessage), message);
                        }
                        else
                        {
                            clientMainForm.AddListUser(stringData);
                            clientMainForm.ServerMessage(message);
                        }
                        break;
                    case (ServerCommand.CLOSE_CONNECTION):
                        message = $"Server: {stringData} покинул чат!";
                        if (clientMainForm.DisconnectButton.InvokeRequired)
                        {
                            clientMainForm.DisconnectButton.Invoke(new Action<string>(clientMainForm.RemoveListUser), stringData);
                            clientMainForm.DisconnectButton.Invoke(new Action<string>(clientMainForm.ServerMessage), message);
                        }
                        else
                        {
                            clientMainForm.RemoveListUser(stringData);
                            clientMainForm.ServerMessage(message);
                        }
                        break;
                    case (ServerCommand.NEW_MESSAGE):
                        if (clientMainForm.DisconnectButton.InvokeRequired)
                        {
                            clientMainForm.DisconnectButton.Invoke(new Action<string>(clientMainForm.ServerMessage), stringData);
                        }
                        else
                        {
                            clientMainForm.ServerMessage(stringData);
                        }
                        break;
                    case (ServerCommand.CLOSE_SERVER):
                        if (clientMainForm.DisconnectButton.InvokeRequired)
                        {
                            clientMainForm.DisconnectButton.Invoke(new Action<bool>(clientMainForm.CloseThread), true);
                            return;
                        }
                        else
                        {
                            clientMainForm.CloseThread(true);
                        }
                        break;
                }
            }
        }
    }
}
