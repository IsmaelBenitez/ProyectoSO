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
            this.Chat.Location = new System.Drawing.Point(727, 188);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(247, 99);
            this.Chat.TabIndex = 26;
            // 
            // MensajeBox
            // 
            this.MensajeBox.Location = new System.Drawing.Point(802, 317);
            this.MensajeBox.Name = "MensajeBox";
            this.MensajeBox.Size = new System.Drawing.Size(172, 20);
            this.MensajeBox.TabIndex = 27;
            this.MensajeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MensajeBox_KeyPress);
            // 
            // btn_chat
            // 
            this.btn_chat.Location = new System.Drawing.Point(899, 376);
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
            this.ClientSize = new System.Drawing.Size(996, 423);
            this.Controls.Add(this.btn_chat);
            this.Controls.Add(this.MensajeBox);
            this.Controls.Add(this.Chat);
            this.Name = "Partida";
            this.Text = "Partida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Partida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Chat;
        private System.Windows.Forms.TextBox MensajeBox;
        private System.Windows.Forms.Button btn_chat;
    }
}