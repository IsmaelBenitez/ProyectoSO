namespace Version_1
{
    partial class Consultas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.porcentaje = new System.Windows.Forms.RadioButton();
            this.Favorito = new System.Windows.Forms.RadioButton();
            this.ganador = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // porcentaje
            // 
            this.porcentaje.AutoSize = true;
            this.porcentaje.Location = new System.Drawing.Point(67, 179);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(172, 17);
            this.porcentaje.TabIndex = 0;
            this.porcentaje.TabStop = true;
            this.porcentaje.Text = "Dime mi porcentaje de victorias";
            this.porcentaje.UseVisualStyleBackColor = true;
            // 
            // Favorito
            // 
            this.Favorito.AutoSize = true;
            this.Favorito.Location = new System.Drawing.Point(67, 220);
            this.Favorito.Name = "Favorito";
            this.Favorito.Size = new System.Drawing.Size(149, 17);
            this.Favorito.TabIndex = 1;
            this.Favorito.TabStop = true;
            this.Favorito.Text = "Dime mi personaje favorito";
            this.Favorito.UseVisualStyleBackColor = true;
            // 
            // ganador
            // 
            this.ganador.AutoSize = true;
            this.ganador.Location = new System.Drawing.Point(67, 259);
            this.ganador.Name = "ganador";
            this.ganador.Size = new System.Drawing.Size(151, 17);
            this.ganador.TabIndex = 2;
            this.ganador.TabStop = true;
            this.ganador.Text = "Dime quien gano la partida";
            this.ganador.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Indique el nombre del jugador o el id de partida:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(129, 313);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 361);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ganador);
            this.Controls.Add(this.Favorito);
            this.Controls.Add(this.porcentaje);
            this.Name = "Consultas";
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.Consultas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton porcentaje;
        private System.Windows.Forms.RadioButton Favorito;
        private System.Windows.Forms.RadioButton ganador;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnviar;
    }
}

