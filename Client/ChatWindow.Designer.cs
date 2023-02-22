using System;

namespace Client {
    partial class ChatWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            messageRichTextBox = new System.Windows.Forms.RichTextBox();
            onlineUserRichTextBox = new System.Windows.Forms.RichTextBox();
            messagesLabel = new System.Windows.Forms.Label();
            onlineUsersLabel = new System.Windows.Forms.Label();
            sendMessageTextBox = new System.Windows.Forms.TextBox();
            sendButton = new System.Windows.Forms.Button();
            usernameLabel = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // messageRichTextBox
            // 
            messageRichTextBox.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            messageRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            messageRichTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            messageRichTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            messageRichTextBox.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            messageRichTextBox.Location = new System.Drawing.Point(17, 33);
            messageRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            messageRichTextBox.Name = "messageRichTextBox";
            messageRichTextBox.ReadOnly = true;
            messageRichTextBox.Size = new System.Drawing.Size(569, 339);
            messageRichTextBox.TabIndex = 0;
            messageRichTextBox.TabStop = false;
            messageRichTextBox.Text = "";
            // 
            // onlineUserRichTextBox
            // 
            onlineUserRichTextBox.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            onlineUserRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            onlineUserRichTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            onlineUserRichTextBox.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            onlineUserRichTextBox.Location = new System.Drawing.Point(605, 33);
            onlineUserRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            onlineUserRichTextBox.Name = "onlineUserRichTextBox";
            onlineUserRichTextBox.ReadOnly = true;
            onlineUserRichTextBox.Size = new System.Drawing.Size(153, 292);
            onlineUserRichTextBox.TabIndex = 1;
            onlineUserRichTextBox.TabStop = false;
            onlineUserRichTextBox.Text = "";
            // 
            // messagesLabel
            // 
            messagesLabel.AutoSize = true;
            messagesLabel.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            messagesLabel.ForeColor = System.Drawing.Color.Silver;
            messagesLabel.Location = new System.Drawing.Point(13, 1);
            messagesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            messagesLabel.Name = "messagesLabel";
            messagesLabel.Size = new System.Drawing.Size(120, 32);
            messagesLabel.TabIndex = 2;
            messagesLabel.Text = "Messages";
            // 
            // onlineUsersLabel
            // 
            onlineUsersLabel.AutoSize = true;
            onlineUsersLabel.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            onlineUsersLabel.ForeColor = System.Drawing.Color.Silver;
            onlineUsersLabel.Location = new System.Drawing.Point(600, 1);
            onlineUsersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            onlineUsersLabel.Name = "onlineUsersLabel";
            onlineUsersLabel.Size = new System.Drawing.Size(142, 32);
            onlineUsersLabel.TabIndex = 3;
            onlineUsersLabel.Text = "Online User";
            // 
            // sendMessageTextBox
            // 
            sendMessageTextBox.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            sendMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sendMessageTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            sendMessageTextBox.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            sendMessageTextBox.Location = new System.Drawing.Point(17, 406);
            sendMessageTextBox.Margin = new System.Windows.Forms.Padding(2);
            sendMessageTextBox.Name = "sendMessageTextBox";
            sendMessageTextBox.Size = new System.Drawing.Size(569, 27);
            sendMessageTextBox.TabIndex = 4;
            // 
            // sendButton
            // 
            sendButton.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            sendButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            sendButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            sendButton.Location = new System.Drawing.Point(605, 402);
            sendButton.Margin = new System.Windows.Forms.Padding(2);
            sendButton.Name = "sendButton";
            sendButton.Size = new System.Drawing.Size(153, 35);
            sendButton.TabIndex = 5;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += SendButton_Click;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            usernameLabel.ForeColor = System.Drawing.Color.Silver;
            usernameLabel.Location = new System.Drawing.Point(13, 373);
            usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(131, 32);
            usernameLabel.TabIndex = 6;
            usernameLabel.Text = "Username:";
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button1.Location = new System.Drawing.Point(605, 337);
            button1.Margin = new System.Windows.Forms.Padding(2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(154, 35);
            button1.TabIndex = 5;
            button1.Text = "Log Off";
            button1.UseVisualStyleBackColor = false;
            button1.Click += LogOffButton_Click;
            // 
            // ChatWindow
            // 
            AcceptButton = sendButton;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(772, 448);
            Controls.Add(usernameLabel);
            Controls.Add(button1);
            Controls.Add(sendButton);
            Controls.Add(sendMessageTextBox);
            Controls.Add(onlineUsersLabel);
            Controls.Add(messagesLabel);
            Controls.Add(onlineUserRichTextBox);
            Controls.Add(messageRichTextBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2);
            MaximizeBox = false;
            Name = "ChatWindow";
            Text = "Chat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.RichTextBox onlineUserRichTextBox;
        private System.Windows.Forms.Label messagesLabel;
        private System.Windows.Forms.Label onlineUsersLabel;
        private System.Windows.Forms.TextBox sendMessageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button button1;
    }
}