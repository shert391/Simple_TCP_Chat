namespace Client
{
    partial class ClientMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainForm));
            this.ClientsListBox = new System.Windows.Forms.ListBox();
            this.ServerCommandListBox = new System.Windows.Forms.ListBox();
            this.TextBoxMessage = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.PanelStyle = new System.Windows.Forms.Panel();
            this.ConnectionsListLabel = new System.Windows.Forms.Label();
            this.PanelStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientsListBox
            // 
            this.ClientsListBox.FormattingEnabled = true;
            this.ClientsListBox.HorizontalScrollbar = true;
            this.ClientsListBox.Location = new System.Drawing.Point(457, 139);
            this.ClientsListBox.Name = "ClientsListBox";
            this.ClientsListBox.ScrollAlwaysVisible = true;
            this.ClientsListBox.Size = new System.Drawing.Size(147, 277);
            this.ClientsListBox.TabIndex = 0;
            // 
            // ServerCommandListBox
            // 
            this.ServerCommandListBox.BackColor = System.Drawing.SystemColors.Window;
            this.ServerCommandListBox.FormattingEnabled = true;
            this.ServerCommandListBox.HorizontalScrollbar = true;
            this.ServerCommandListBox.Location = new System.Drawing.Point(12, 5);
            this.ServerCommandListBox.Name = "ServerCommandListBox";
            this.ServerCommandListBox.ScrollAlwaysVisible = true;
            this.ServerCommandListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ServerCommandListBox.Size = new System.Drawing.Size(439, 303);
            this.ServerCommandListBox.TabIndex = 1;
            // 
            // TextBoxMessage
            // 
            this.TextBoxMessage.Location = new System.Drawing.Point(12, 314);
            this.TextBoxMessage.Multiline = true;
            this.TextBoxMessage.Name = "TextBoxMessage";
            this.TextBoxMessage.Size = new System.Drawing.Size(351, 102);
            this.TextBoxMessage.TabIndex = 2;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(369, 314);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(82, 48);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(369, 368);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(82, 48);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(457, 5);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(147, 102);
            this.DisconnectButton.TabIndex = 5;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // PanelStyle
            // 
            this.PanelStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelStyle.Controls.Add(this.ConnectionsListLabel);
            this.PanelStyle.Location = new System.Drawing.Point(457, 113);
            this.PanelStyle.Name = "PanelStyle";
            this.PanelStyle.Size = new System.Drawing.Size(147, 24);
            this.PanelStyle.TabIndex = 6;
            // 
            // ConnectionsListLabel
            // 
            this.ConnectionsListLabel.AutoSize = true;
            this.ConnectionsListLabel.Location = new System.Drawing.Point(31, 5);
            this.ConnectionsListLabel.Name = "ConnectionsListLabel";
            this.ConnectionsListLabel.Size = new System.Drawing.Size(85, 13);
            this.ConnectionsListLabel.TabIndex = 0;
            this.ConnectionsListLabel.Text = "CONNECTIONS";
            this.ConnectionsListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 426);
            this.Controls.Add(this.PanelStyle);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.TextBoxMessage);
            this.Controls.Add(this.ServerCommandListBox);
            this.Controls.Add(this.ClientsListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.PanelStyle.ResumeLayout(false);
            this.PanelStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ClientsListBox;
        private System.Windows.Forms.ListBox ServerCommandListBox;
        private System.Windows.Forms.TextBox TextBoxMessage;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel PanelStyle;
        private System.Windows.Forms.Label ConnectionsListLabel;
        public System.Windows.Forms.Button DisconnectButton;
    }
}