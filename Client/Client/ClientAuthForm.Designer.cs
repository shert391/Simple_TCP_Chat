namespace Client
{
    partial class ClientAuthForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientAuthForm));
            this.StatusInfo = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.LoginChatButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StatusInfo
            // 
            this.StatusInfo.AutoSize = true;
            this.StatusInfo.Location = new System.Drawing.Point(9, 9);
            this.StatusInfo.Name = "StatusInfo";
            this.StatusInfo.Size = new System.Drawing.Size(89, 13);
            this.StatusInfo.TabIndex = 0;
            this.StatusInfo.Text = "Статус сервера:";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.ForeColor = System.Drawing.Color.Red;
            this.Status.Location = new System.Drawing.Point(95, 9);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(37, 13);
            this.Status.TabIndex = 1;
            this.Status.Text = "Offline";
            // 
            // LoginChatButton
            // 
            this.LoginChatButton.Enabled = false;
            this.LoginChatButton.Location = new System.Drawing.Point(12, 60);
            this.LoginChatButton.Name = "LoginChatButton";
            this.LoginChatButton.Size = new System.Drawing.Size(289, 23);
            this.LoginChatButton.TabIndex = 2;
            this.LoginChatButton.Text = "Войти в чат";
            this.LoginChatButton.UseVisualStyleBackColor = true;
            this.LoginChatButton.Click += new System.EventHandler(this.LoginChatButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Enabled = false;
            this.NameTextBox.Location = new System.Drawing.Point(41, 34);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(260, 20);
            this.NameTextBox.TabIndex = 3;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(9, 37);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(32, 13);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Имя:";
            // 
            // ClientAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 92);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.LoginChatButton);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.StatusInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientAuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NameLabel;
        protected System.Windows.Forms.Label Status;
        protected System.Windows.Forms.Button LoginChatButton;
        protected System.Windows.Forms.TextBox NameTextBox;
        public System.Windows.Forms.Label StatusInfo;
    }
}

