namespace cliente
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btn_Desconectar = new System.Windows.Forms.Button();
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_Iniciar_Sesion = new System.Windows.Forms.Button();
            this.btn_Registrarse = new System.Windows.Forms.Button();
            this.Contra1Text = new System.Windows.Forms.TextBox();
            this.nombre1Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Nombre2Text = new System.Windows.Forms.TextBox();
            this.Contra2Text = new System.Windows.Forms.TextBox();
            this.Contra3Text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Registrarse2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.porcentaje = new System.Windows.Forms.RadioButton();
            this.Favorito = new System.Windows.Forms.RadioButton();
            this.ganador = new System.Windows.Forms.RadioButton();
            this.btn_Enviar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.btn_Invitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Desconectar
            // 
            this.btn_Desconectar.Enabled = false;
            this.btn_Desconectar.Location = new System.Drawing.Point(440, 62);
            this.btn_Desconectar.Name = "btn_Desconectar";
            this.btn_Desconectar.Size = new System.Drawing.Size(81, 23);
            this.btn_Desconectar.TabIndex = 0;
            this.btn_Desconectar.Text = "Desconectar";
            this.btn_Desconectar.UseVisualStyleBackColor = true;
            this.btn_Desconectar.Click += new System.EventHandler(this.btn_Desconectar_Click);
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.Location = new System.Drawing.Point(181, 62);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(75, 23);
            this.btn_Conectar.TabIndex = 1;
            this.btn_Conectar.Text = "Conectar";
            this.btn_Conectar.UseVisualStyleBackColor = true;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_Iniciar_Sesion
            // 
            this.btn_Iniciar_Sesion.Location = new System.Drawing.Point(224, 259);
            this.btn_Iniciar_Sesion.Name = "btn_Iniciar_Sesion";
            this.btn_Iniciar_Sesion.Size = new System.Drawing.Size(75, 23);
            this.btn_Iniciar_Sesion.TabIndex = 2;
            this.btn_Iniciar_Sesion.Text = "Iniciar Sesión";
            this.btn_Iniciar_Sesion.UseVisualStyleBackColor = true;
            this.btn_Iniciar_Sesion.Visible = false;
            this.btn_Iniciar_Sesion.Click += new System.EventHandler(this.btn_Iniciar_Sesion_Click);
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.Location = new System.Drawing.Point(373, 259);
            this.btn_Registrarse.Name = "btn_Registrarse";
            this.btn_Registrarse.Size = new System.Drawing.Size(75, 23);
            this.btn_Registrarse.TabIndex = 3;
            this.btn_Registrarse.Text = "Registrarse";
            this.btn_Registrarse.UseVisualStyleBackColor = true;
            this.btn_Registrarse.Visible = false;
            this.btn_Registrarse.Click += new System.EventHandler(this.btn_Registrarse_Click);
            // 
            // Contra1Text
            // 
            this.Contra1Text.HideSelection = false;
            this.Contra1Text.Location = new System.Drawing.Point(314, 185);
            this.Contra1Text.MaxLength = 50;
            this.Contra1Text.Name = "Contra1Text";
            this.Contra1Text.Size = new System.Drawing.Size(100, 20);
            this.Contra1Text.TabIndex = 4;
            this.Contra1Text.UseSystemPasswordChar = true;
            this.Contra1Text.Visible = false;
            this.Contra1Text.TextChanged += new System.EventHandler(this.Contra1Text_TextChanged);
            // 
            // nombre1Text
            // 
            this.nombre1Text.Location = new System.Drawing.Point(314, 135);
            this.nombre1Text.MaxLength = 50;
            this.nombre1Text.Name = "nombre1Text";
            this.nombre1Text.Size = new System.Drawing.Size(100, 20);
            this.nombre1Text.TabIndex = 5;
            this.nombre1Text.Visible = false;
            this.nombre1Text.TextChanged += new System.EventHandler(this.nombre1Text_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contraseña:";
            this.label2.Visible = false;
            // 
            // Nombre2Text
            // 
            this.Nombre2Text.Location = new System.Drawing.Point(314, 119);
            this.Nombre2Text.MaxLength = 50;
            this.Nombre2Text.Name = "Nombre2Text";
            this.Nombre2Text.Size = new System.Drawing.Size(100, 20);
            this.Nombre2Text.TabIndex = 8;
            this.Nombre2Text.Visible = false;
            // 
            // Contra2Text
            // 
            this.Contra2Text.Location = new System.Drawing.Point(314, 159);
            this.Contra2Text.MaxLength = 50;
            this.Contra2Text.Name = "Contra2Text";
            this.Contra2Text.Size = new System.Drawing.Size(100, 20);
            this.Contra2Text.TabIndex = 9;
            this.Contra2Text.UseSystemPasswordChar = true;
            this.Contra2Text.Visible = false;
            // 
            // Contra3Text
            // 
            this.Contra3Text.Location = new System.Drawing.Point(314, 214);
            this.Contra3Text.MaxLength = 50;
            this.Contra3Text.Name = "Contra3Text";
            this.Contra3Text.Size = new System.Drawing.Size(100, 20);
            this.Contra3Text.TabIndex = 10;
            this.Contra3Text.UseSystemPasswordChar = true;
            this.Contra3Text.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nombre:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Contraseña: ";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Confirmar Contraseña:";
            this.label5.Visible = false;
            // 
            // btn_Registrarse2
            // 
            this.btn_Registrarse2.Location = new System.Drawing.Point(305, 288);
            this.btn_Registrarse2.Name = "btn_Registrarse2";
            this.btn_Registrarse2.Size = new System.Drawing.Size(75, 23);
            this.btn_Registrarse2.TabIndex = 14;
            this.btn_Registrarse2.Text = "Registrarse";
            this.btn_Registrarse2.UseVisualStyleBackColor = true;
            this.btn_Registrarse2.Visible = false;
            this.btn_Registrarse2.Click += new System.EventHandler(this.btn_Registrarse2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(157, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(456, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Indique el nombre de usuario o el id de partida";
            this.label6.Visible = false;
            // 
            // porcentaje
            // 
            this.porcentaje.AutoSize = true;
            this.porcentaje.Location = new System.Drawing.Point(284, 178);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(164, 17);
            this.porcentaje.TabIndex = 16;
            this.porcentaje.TabStop = true;
            this.porcentaje.Text = "Dime el porcentje de victorias";
            this.porcentaje.UseVisualStyleBackColor = true;
            this.porcentaje.Visible = false;
            // 
            // Favorito
            // 
            this.Favorito.AutoSize = true;
            this.Favorito.Location = new System.Drawing.Point(284, 211);
            this.Favorito.Name = "Favorito";
            this.Favorito.Size = new System.Drawing.Size(147, 17);
            this.Favorito.TabIndex = 17;
            this.Favorito.TabStop = true;
            this.Favorito.Text = "Dime el personaje favorito";
            this.Favorito.UseVisualStyleBackColor = true;
            this.Favorito.Visible = false;
            // 
            // ganador
            // 
            this.ganador.AutoSize = true;
            this.ganador.Location = new System.Drawing.Point(284, 240);
            this.ganador.Name = "ganador";
            this.ganador.Size = new System.Drawing.Size(163, 17);
            this.ganador.TabIndex = 18;
            this.ganador.TabStop = true;
            this.ganador.Text = "Dime el ganador de la partida";
            this.ganador.UseVisualStyleBackColor = true;
            this.ganador.Visible = false;
            // 
            // btn_Enviar
            // 
            this.btn_Enviar.Enabled = false;
            this.btn_Enviar.Location = new System.Drawing.Point(327, 277);
            this.btn_Enviar.Name = "btn_Enviar";
            this.btn_Enviar.Size = new System.Drawing.Size(75, 23);
            this.btn_Enviar.TabIndex = 19;
            this.btn_Enviar.Text = "Enviar";
            this.btn_Enviar.UseVisualStyleBackColor = true;
            this.btn_Enviar.Visible = false;
            this.btn_Enviar.Click += new System.EventHandler(this.btn_Enviar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(314, 145);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(21, 122);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(130, 109);
            this.Grid.TabIndex = 21;
            this.Grid.Visible = false;
            this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // btn_Invitar
            // 
            this.btn_Invitar.Location = new System.Drawing.Point(48, 259);
            this.btn_Invitar.Name = "btn_Invitar";
            this.btn_Invitar.Size = new System.Drawing.Size(75, 23);
            this.btn_Invitar.TabIndex = 22;
            this.btn_Invitar.Text = "Invitar";
            this.btn_Invitar.UseVisualStyleBackColor = true;
            this.btn_Invitar.Visible = false;
            this.btn_Invitar.Click += new System.EventHandler(this.btn_Invitar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Invitar);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Enviar);
            this.Controls.Add(this.ganador);
            this.Controls.Add(this.Favorito);
            this.Controls.Add(this.porcentaje);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Registrarse2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Contra3Text);
            this.Controls.Add(this.Contra2Text);
            this.Controls.Add(this.Nombre2Text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombre1Text);
            this.Controls.Add(this.Contra1Text);
            this.Controls.Add(this.btn_Registrarse);
            this.Controls.Add(this.btn_Iniciar_Sesion);
            this.Controls.Add(this.btn_Conectar);
            this.Controls.Add(this.btn_Desconectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Desconectar;
        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombre1Text;
        private System.Windows.Forms.TextBox Contra1Text;
        private System.Windows.Forms.Button btn_Registrarse;
        private System.Windows.Forms.Button btn_Iniciar_Sesion;
        private System.Windows.Forms.Button btn_Registrarse2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Contra3Text;
        private System.Windows.Forms.TextBox Contra2Text;
        private System.Windows.Forms.TextBox Nombre2Text;
        private System.Windows.Forms.Button btn_Enviar;
        private System.Windows.Forms.RadioButton ganador;
        private System.Windows.Forms.RadioButton Favorito;
        private System.Windows.Forms.RadioButton porcentaje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button btn_Invitar;
    }
}

