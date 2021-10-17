namespace Version_1
{
    partial class iniciar_Sesion
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
            this.components = new System.ComponentModel.Container();
            this.btnIniciar_sesion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.ContrBox = new System.Windows.Forms.TextBox();
            this.btnRegistrarte = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciar_sesion
            // 
            this.btnIniciar_sesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar_sesion.Location = new System.Drawing.Point(57, 237);
            this.btnIniciar_sesion.Name = "btnIniciar_sesion";
            this.btnIniciar_sesion.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar_sesion.TabIndex = 0;
            this.btnIniciar_sesion.Text = "Iniciar Sesión";
            this.btnIniciar_sesion.UseVisualStyleBackColor = true;
            this.btnIniciar_sesion.Click += new System.EventHandler(this.btnIniciar_sesion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            // 
            // NombreBox
            // 
            this.NombreBox.Location = new System.Drawing.Point(149, 81);
            this.NombreBox.MaxLength = 50;
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(100, 20);
            this.NombreBox.TabIndex = 3;
            this.NombreBox.TextChanged += new System.EventHandler(this.NombreBox_TextChanged);
            // 
            // ContrBox
            // 
            this.ContrBox.Location = new System.Drawing.Point(149, 144);
            this.ContrBox.MaxLength = 50;
            this.ContrBox.Name = "ContrBox";
            this.ContrBox.Size = new System.Drawing.Size(100, 20);
            this.ContrBox.TabIndex = 4;
            this.ContrBox.UseSystemPasswordChar = true;
            this.ContrBox.TextChanged += new System.EventHandler(this.ContrBox_TextChanged);
            // 
            // btnRegistrarte
            // 
            this.btnRegistrarte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarte.Location = new System.Drawing.Point(174, 237);
            this.btnRegistrarte.Name = "btnRegistrarte";
            this.btnRegistrarte.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrarte.TabIndex = 5;
            this.btnRegistrarte.Text = "Registrarte";
            this.btnRegistrarte.UseVisualStyleBackColor = true;
            this.btnRegistrarte.Click += new System.EventHandler(this.btnRegistrarte_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // iniciar_Sesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 303);
            this.Controls.Add(this.btnRegistrarte);
            this.Controls.Add(this.ContrBox);
            this.Controls.Add(this.NombreBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIniciar_sesion);
            this.Name = "iniciar_Sesion";
            this.Text = "Iniciar Sesion";
            this.Load += new System.EventHandler(this.iniciar_Sesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar_sesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NombreBox;
        private System.Windows.Forms.TextBox ContrBox;
        private System.Windows.Forms.Button btnRegistrarte;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}