namespace cliente
{
    partial class Partida
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
            this.Chat = new System.Windows.Forms.Label();
            this.MensajeBox = new System.Windows.Forms.TextBox();
            this.btn_chat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Chat.Location = new System.Drawing.Point(505, 239);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(247, 99);
            this.Chat.TabIndex = 26;
    
            // 
            // MensajeBox
            // 
            this.MensajeBox.Location = new System.Drawing.Point(580, 355);
            this.MensajeBox.Name = "MensajeBox";
            this.MensajeBox.Size = new System.Drawing.Size(172, 20);
            this.MensajeBox.TabIndex = 27;
            // 
            // btn_chat
            // 
            this.btn_chat.Location = new System.Drawing.Point(677, 415);
            this.btn_chat.Name = "btn_chat";
            this.btn_chat.Size = new System.Drawing.Size(75, 23);
            this.btn_chat.TabIndex = 28;
            this.btn_chat.Text = "Enviar";
            this.btn_chat.UseVisualStyleBackColor = true;
            this.btn_chat.Click += new System.EventHandler(this.btn_chat_Click);
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_chat);
            this.Controls.Add(this.MensajeBox);
            this.Controls.Add(this.Chat);
            this.Name = "Partida";
            this.Text = "Partida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Chat;
        private System.Windows.Forms.TextBox MensajeBox;
        private System.Windows.Forms.Button btn_chat;
    }
}