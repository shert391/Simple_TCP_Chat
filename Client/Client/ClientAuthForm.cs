using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientAuthForm : Form
    {
        private readonly ServerСommunication _server;

        public ClientAuthForm(bool serverStop = false)
        {
            Thread.CurrentThread.Name = "Форма авторизации";

            _server = new ServerСommunication();

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            if (serverStop)
                MessageBox.Show("Сервер выключился :-(", "Упс...");

            ResetFocus();

            _server.ConnectServer(new ServerData(ip: "127.0.0.1", port: 7000), new TcpClient(), this);
        }

        public void SetStyle(bool connection)
        {
            if (connection)
            {
                Status.Text = "Online";
                Status.ForeColor = Color.Green;
                NameTextBox.Enabled = true;
                LoginChatButton.Enabled = true;
            }
            else
            {
                Status.Text = "Offline";
                Status.ForeColor = Color.Red;
                NameTextBox.Enabled = false;
                LoginChatButton.Enabled = false;
            }
        }

        public void ResetFocus() => this.ActiveControl = StatusInfo;

        private void LoginChatButton_Click(object sender, EventArgs e)
        {
            ResetFocus();

            string name = NameTextBox.Text;

            if(name.Length == 0) /*Нет смысла проверять на серваке, так как при попытке отправки пакета размером ноль байт, будет краш клиента */
            {
                ShowError("Имя не может быть пустым!");
                return;
            }

            string answer = _server.SendName(NameTextBox.Text);

            if (answer != "ок")
            {
                ShowError(answer);
            }
            else
            {
                _server.CloseThreadConnectServer();
                this.Close();
                new Thread(() =>
                {
                    Application.Run(new ClientMainForm(_server, name));
                })
                {
                    Name = "Главная форма"
                }.Start();
            }
        }

        private void ShowError(string textError)
        {
            MessageBox.Show(textError, "Ошибка :-(", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
