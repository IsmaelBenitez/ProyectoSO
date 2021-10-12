namespace Version_1
{
    partial class Registrarse
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
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.ContraBox = new System.Windows.Forms.TextBox();
            this.ComContraBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(191, 53);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(100, 20);
            this.nombreBox.TabIndex = 0;
            this.nombreBox.TextChanged += new System.EventHandler(this.nombreBox_TextChanged);
            // 
            // ContraBox
            // 
            this.ContraBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ContraBox.Location = new System.Drawing.Point(191, 106);
            this.ContraBox.Name = "ContraBox";
            this.ContraBox.Size = new System.Drawing.Size(100, 20);
            this.ContraBox.TabIndex = 1;
            this.ContraBox.UseSystemPasswordChar = true;
            this.ContraBox.TextChanged += new System.EventHandler(this.ContraBox_TextChanged);
            // 
            // ComContraBox
            // 
            this.ComContraBox.Location = new System.Drawing.Point(191, 154);
            this.ComContraBox.Name = "ComContraBox";
            this.ComContraBox.Size = new System.Drawing.Size(100, 20);
            this.ComContraBox.TabIndex = 2;
            this.ComContraBox.UseSystemPasswordChar = true;
            this.ComContraBox.TextChanged += new System.EventHandler(this.ComContraBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre de usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirmar contraseña:";
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarse.Location = new System.Drawing.Point(134, 239);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrarse.TabIndex = 6;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Registrarse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 299);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComContraBox);
            this.Controls.Add(this.ContraBox);
            this.Controls.Add(this.nombreBox);
            this.Name = "Registrarse";
            this.Text = "Registrarse";
            this.Load += new System.EventHandler(this.Registrarse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.TextBox ContraBox;
        private System.Windows.Forms.TextBox ComContraBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}