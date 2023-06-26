using System;

namespace Client
{
    partial class ChatWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            messageRichTextBox = new System.Windows.Forms.RichTextBox();
            onlineUserRichTextBox = new System.Windows.Forms.RichTextBox();
            messagesLabel = new System.Windows.Forms.Label();
            onlineUsersLabel = new System.Windows.Forms.Label();
            sendMessageTextBox = new System.Windows.Forms.TextBox();
            sendButton = new System.Windows.Forms.Button();
            usernameLabel = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button2 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // messageRichTextBox
            // 
            messageRichTextBox.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            messageRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            messageRichTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            messageRichTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            messageRichTextBox.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            messageRichTextBox.Location = new System.Drawing.Point(19, 40);
            messageRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            messageRichTextBox.Name = "messageRichTextBox";
            messageRichTextBox.ReadOnly = true;
            messageRichTextBox.Size = new System.Drawing.Size(640, 424);
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
            onlineUserRichTextBox.Location = new System.Drawing.Point(681, 41);
            onlineUserRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            onlineUserRichTextBox.Name = "onlineUserRichTextBox";
            onlineUserRichTextBox.ReadOnly = true;
            onlineUserRichTextBox.Size = new System.Drawing.Size(172, 365);
            onlineUserRichTextBox.TabIndex = 1;
            onlineUserRichTextBox.TabStop = false;
            onlineUserRichTextBox.Text = "";
            // 
            // messagesLabel
            // 
            messagesLabel.AutoSize = true;
            messagesLabel.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            messagesLabel.ForeColor = System.Drawing.Color.Silver;
            messagesLabel.Location = new System.Drawing.Point(15, 1);
            messagesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            messagesLabel.Name = "messagesLabel";
            messagesLabel.Size = new System.Drawing.Size(141, 37);
            messagesLabel.TabIndex = 2;
            messagesLabel.Text = "Messages";
            // 
            // onlineUsersLabel
            // 
            onlineUsersLabel.AutoSize = true;
            onlineUsersLabel.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            onlineUsersLabel.ForeColor = System.Drawing.Color.Silver;
            onlineUsersLabel.Location = new System.Drawing.Point(675, 1);
            onlineUsersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            onlineUsersLabel.Name = "onlineUsersLabel";
            onlineUsersLabel.Size = new System.Drawing.Size(164, 37);
            onlineUsersLabel.TabIndex = 3;
            onlineUsersLabel.Text = "Online User";
            // 
            // sendMessageTextBox
            // 
            sendMessageTextBox.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            sendMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sendMessageTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            sendMessageTextBox.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            sendMessageTextBox.Location = new System.Drawing.Point(19, 508);
            sendMessageTextBox.Margin = new System.Windows.Forms.Padding(2);
            sendMessageTextBox.Name = "sendMessageTextBox";
            sendMessageTextBox.Size = new System.Drawing.Size(640, 32);
            sendMessageTextBox.TabIndex = 4;
            // 
            // sendButton
            // 
            sendButton.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            sendButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            sendButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            sendButton.Location = new System.Drawing.Point(681, 502);
            sendButton.Margin = new System.Windows.Forms.Padding(2);
            sendButton.Name = "sendButton";
            sendButton.Size = new System.Drawing.Size(172, 44);
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
            usernameLabel.Location = new System.Drawing.Point(15, 466);
            usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(152, 37);
            usernameLabel.TabIndex = 6;
            usernameLabel.Text = "Username:";
            usernameLabel.Click += usernameLabel_Click;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button1.Location = new System.Drawing.Point(681, 421);
            button1.Margin = new System.Windows.Forms.Padding(2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(173, 44);
            button1.TabIndex = 5;
            button1.Text = "Log Off";
            button1.UseVisualStyleBackColor = false;
            button1.Click += LogOffButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            richTextBox1.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            richTextBox1.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            richTextBox1.Location = new System.Drawing.Point(19, 616);
            richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new System.Drawing.Size(644, 277);
            richTextBox1.TabIndex = 0;
            richTextBox1.TabStop = false;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Silver;
            label1.Location = new System.Drawing.Point(19, 562);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(141, 37);
            label1.TabIndex = 2;
            label1.Text = "Messages";
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F);
            textBox1.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            textBox1.Location = new System.Drawing.Point(15, 937);
            textBox1.Margin = new System.Windows.Forms.Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(640, 32);
            textBox1.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button2.Location = new System.Drawing.Point(682, 931);
            button2.Margin = new System.Windows.Forms.Padding(2);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(172, 44);
            button2.TabIndex = 5;
            button2.Text = "Send";
            button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Silver;
            label2.Location = new System.Drawing.Point(11, 895);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(152, 37);
            label2.TabIndex = 6;
            label2.Text = "Username:";
            // 
            // ChatWindow
            // 
            AcceptButton = sendButton;
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(871, 562);
            Controls.Add(label2);
            Controls.Add(usernameLabel);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(sendButton);
            Controls.Add(textBox1);
            Controls.Add(sendMessageTextBox);
            Controls.Add(onlineUsersLabel);
            Controls.Add(label1);
            Controls.Add(messagesLabel);
            Controls.Add(onlineUserRichTextBox);
            Controls.Add(richTextBox1);
            Controls.Add(messageRichTextBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2);
            MaximizeBox = false;
            Name = "ChatWindow";
            Text = "Chat";
            Load += ChatWindow_Load;
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
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}