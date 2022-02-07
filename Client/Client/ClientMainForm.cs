using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientMainForm : Form
    {
        private readonly ServerСommunication _server;
        private readonly string _myName;

        public ClientMainForm(ServerСommunication server, string name)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            _myName = name;
            _server = server;

            List<string> usersList = _server.GetListAllUsers();

            ClientsListBox.Items.AddRange(usersList.ToArray());

            for(int i = 0; i < ClientsListBox.Items.Count; i++)
            {
                if(ClientsListBox.Items[i].ToString() == _myName)
                {
                    ClientsListBox.Items[i] = _myName + " [Я]";
                }
            }

            new Thread(new ParameterizedThreadStart(_server.ListenServer)) { Name = "Обработчик сообщений сервера", IsBackground = true }.Start(this);
        }

        private void ClearButton_Click(object sender, EventArgs e) => TextBoxMessage.Text = "";

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            _server.Disconnect();
            CloseThread();
        }

        public void CloseThread(bool serverStop = false)
        {         
            new Thread(() => Application.Run(new ClientAuthForm(serverStop))).Start();
            this.Close();
        }

        public void AddListUser(string name) => ClientsListBox.Items.Add(name);
        public void RemoveListUser(string name) => ClientsListBox.Items.RemoveAt(ClientsListBox.Items.IndexOf(name));
        public void ServerMessage(string message) => ServerCommandListBox.Items.Add(message);
        private void SendButton_Click(object sender, EventArgs e) => _server.SendCommand(ServerCommand.NEW_MESSAGE, Encoding.UTF8.GetBytes(TextBoxMessage.Text));

        /*public void ResetFocus() => this.ActiveControl = StatusInfo;*/
    }
}
