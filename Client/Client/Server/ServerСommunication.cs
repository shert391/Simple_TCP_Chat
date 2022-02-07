using System;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class ServerСommunication
    {
        private NetworkStream _stream;

        private Thread _threadConnectServer;

        public void ConnectServer(ServerData serverData, TcpClient client, ClientAuthForm form)
        {
            _threadConnectServer = new Thread(delegate ()
            {
                while (true)
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        try
                        {
                            client.Connect(serverData.IP, serverData.Port);
                            CheckFlowSetStyle(form, connection: true);
                            break;
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    while (true)
                    {
                        _stream = client.GetStream();

                        byte[] buffer = new byte[0];

                        try
                        {
                            _stream.Read(buffer, 0, 0);
                        }
                        catch (System.IO.IOException)
                        {
                            CheckFlowSetStyle(form, connection: false);
                            client.Close();
                            client = new TcpClient();
                            break;
                        }

                    }
                }
            })
            {
                Name = "Смотрящий за статусом сервера :-)",
                IsBackground = true
            };
            _threadConnectServer.Start();
        }

        public void CloseThreadConnectServer()
        {
            _threadConnectServer.Abort();
        }

        private void CheckFlowSetStyle(ClientAuthForm form, bool connection)
        {
            if (form.StatusInfo.InvokeRequired)
            {
                form.StatusInfo.Invoke(new Action(form.ResetFocus));
                form.StatusInfo.Invoke(new Action<bool>(form.SetStyle), connection);
            }
            else
            {
                form.ResetFocus();
                form.SetStyle(connection);
            }
        }

        public void Disconnect()
        {
            SendCommand(ServerCommand.DISCONNECT_ME);
            _stream.Close();
        }
    }
}
