using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
 

namespace cliente
{
    public partial class Partida : Form
    {
        Socket server;
        string[] Datos;
        string sesion;
        int IDp;
        int nMensajes = 0;
        delegate void DelegadoParaEscribirMensaje(string mensaje);

        string[] chatmensajes = new string[7];
        public Partida(Socket server, string[] trozos, string sesion)
        {
            InitializeComponent();

            this.server = server;
            Datos = trozos;
            this.sesion = sesion;
            IDp = Convert.ToInt32(trozos[Convert.ToInt32(trozos[1]) + 2]);

        }

        private void btn_chat_Click(object sender, EventArgs e)
        {
            if (MensajeBox.Text != string.Empty)
            {
                string Mensaje = "8/" + IDp + "/" + sesion + "/" + MensajeBox.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(Mensaje);
                server.Send(msg);
                MensajeBox.Clear();
            }

        }

        public void RecibirMensaje(string mensaje)
        {
            DelegadoParaEscribirMensaje delegado = new DelegadoParaEscribirMensaje(EscribeMensaje);
            this.Invoke(delegado, new object[] { mensaje });
        }
        private void EscribeMensaje(string mensaje)
        {
            if (nMensajes < 6)
            {
                chatmensajes[nMensajes] = mensaje;
                Chat.Text = Chat.Text + Environment.NewLine + mensaje;
                nMensajes++;
            }
            else
            {
                Chat.Text = string.Empty;
                chatmensajes[0] = null;
                int i = 1;
                while (i < nMensajes)
                {
                    chatmensajes[i - 1] = chatmensajes[i];
                    i++;
                }
                chatmensajes[nMensajes] = mensaje;
                int j = 1;
                Chat.Text = chatmensajes[0];
                while (j <= nMensajes)
                {
                    Chat.Text = Chat.Text + Environment.NewLine + chatmensajes[j];
                    j++;
                }

            }
        }

        private void MensajeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (MensajeBox.Text != string.Empty)
                {
                    string Mensaje = "8/" + IDp + "/" + sesion + "/" + MensajeBox.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(Mensaje);
                    server.Send(msg);
                    MensajeBox.Clear();
                }
            }
        }

        private void Partida_Load(object sender, EventArgs e)
        {
            int x = 175;
            int y = 25;
            string strButtonName = "btn_Tablero";  //Nombre que van a tener los botones del tablero

            int nBoton = 0; //Almaceno el numero de boton
            for (int i = 1; i <= 3; i++)
            {
                nBoton++; //Para dessincronizarlos, le sumo 1 al cambiar de fila
                for (int j = 1; j <= 4; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
                    btn.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.BackgroundImage = Properties.Resources._1;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Empty;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += new EventHandler(btn_click);


                    this.Controls.Add(btn);
                    x += 50;
                    nBoton++;
                }

                y += 50;
                x = 175;

            }

            x = 25;
            y = 175;

            for (int i = 1; i <= 2; i++)
            {
                nBoton++; //Para dessincronizarlos, le sumo 1 al cambiar de fila
                for (int j = 1; j <= 10; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
                    btn.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.BackgroundImage = Properties.Resources._1;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Empty;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += new EventHandler(btn_click);


                    this.Controls.Add(btn);
                    x += 50;
                    nBoton++;
                }

                y += 50;
                x = 25;
            }
            x = 175;
            y = 275;

            for (int i = 1; i <= 3; i++)
            {
                nBoton++; //Para dessincronizarlos, le sumo 1 al cambiar de fila
                for (int j = 1; j <= 1; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
                    btn.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.BackgroundImage = Properties.Resources._1;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Empty;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += new EventHandler(btn_click);


                    this.Controls.Add(btn);
                    x += 50;
                    nBoton++;
                }

                y += 50;
                x = 175;
            }
            x = 325;
            y = 275;

            for (int i = 1; i <= 3; i++)
            {
                nBoton++; //Para dessincronizarlos, le sumo 1 al cambiar de fila
                for (int j = 1; j <= 1; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
                    btn.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.BackgroundImage = Properties.Resources._1;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Empty;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += new EventHandler(btn_click);

                    this.Controls.Add(btn);
                    x += 50;
                    nBoton++;
                }

                y += 50;
                x = 325;
            }
            x = 25;
            y = 425;

            for (int i = 1; i <= 2; i++)
            {
                nBoton++; //Para dessincronizarlos, le sumo 1 al cambiar de fila
                for (int j = 1; j <= 10; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
                    btn.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.BackgroundImage = Properties.Resources._1;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Empty;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += new EventHandler(btn_click);


                    this.Controls.Add(btn);
                    x += 50;
                    nBoton++;
                }

                y += 50;
                x = 25;
            }
            x = 175;
            y = 525;

            for (int i = 1; i <= 3; i++)
            {
                nBoton++; //Para dessincronizarlos, le sumo 1 al cambiar de fila
                for (int j = 1; j <= 4; j++)
                {
                    var btn = new Button();
                    btn.Text = "";
                    btn.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
                    btn.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.BackgroundImage = Properties.Resources._1;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Empty;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += new EventHandler(btn_click);


                    this.Controls.Add(btn);
                    x += 50;
                    nBoton++;
                }

                y += 50;
                x = 175;
            }
            var room1 = new Button();
            room1.Text = "";
            room1.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
            room1.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
            room1.Location = new Point(25, 25);
            room1.Size = new Size(150,150);
            room1.BackgroundImage = Properties.Resources._1;
            room1.BackgroundImageLayout = ImageLayout.Stretch;
            room1.FlatStyle = FlatStyle.Flat;
            room1.FlatAppearance.BorderColor = Color.Empty;
            room1.FlatAppearance.BorderSize = 0;
            room1.Click += new EventHandler(room1_Click);


            this.Controls.Add(room1);
          
            nBoton++;

            var room2 = new Button();
            room2.Text = "";
            room2.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
            room2.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
            room2.Location = new Point(375, 25);
            room2.Size = new Size(150, 150);
            room2.BackgroundImage = Properties.Resources._1;
            room2.BackgroundImageLayout = ImageLayout.Stretch;
            room2.FlatStyle = FlatStyle.Flat;
            room2.FlatAppearance.BorderColor = Color.Empty;
            room2.FlatAppearance.BorderSize = 0;
            room2.Click += new EventHandler(room2_Click);

            this.Controls.Add(room2);

            nBoton++;

            var room3 = new Button();
            room3.Text = "";
            room3.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
            room3.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
            room3.Location = new Point(25, 275);
            room3.Size = new Size(150, 150);
            room3.BackgroundImage = Properties.Resources._1;
            room3.BackgroundImageLayout = ImageLayout.Stretch;
            room3.FlatStyle = FlatStyle.Flat;
            room3.FlatAppearance.BorderColor = Color.Empty;
            room3.FlatAppearance.BorderSize = 0;
            room3.Click += new EventHandler(room3_Click);


            this.Controls.Add(room3);

            nBoton++;

            var room4 = new Button();
            room4.Text = "";
            room4.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
            room4.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
            room4.Location = new Point(25, 525);
            room4.Size = new Size(150, 150);
            room4.BackgroundImage = Properties.Resources._1;
            room4.BackgroundImageLayout = ImageLayout.Stretch;
            room4.FlatStyle = FlatStyle.Flat;
            room4.FlatAppearance.BorderColor = Color.Empty;
            room4.FlatAppearance.BorderSize = 0;
            room4.Click += new EventHandler(room4_Click);


            this.Controls.Add(room4);

            nBoton++;

            var room5 = new Button();
            room5.Text = "";
            room5.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
            room5.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
            room5.Location = new Point(375, 525);
            room5.Size = new Size(150, 150);
            room5.BackgroundImage = Properties.Resources._1;
            room5.BackgroundImageLayout = ImageLayout.Stretch;
            room5.FlatStyle = FlatStyle.Flat;
            room5.FlatAppearance.BorderColor = Color.Empty;
            room5.FlatAppearance.BorderSize = 0;
            room5.Click += new EventHandler(room5_Click);


            this.Controls.Add(room5);

            nBoton++;

            var room6 = new Button();
            room6.Text = "";
            room6.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
            room6.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
            room6.Location = new Point(375, 275);
            room6.Size = new Size(150, 150);
            room6.BackgroundImage = Properties.Resources._1;
            room6.BackgroundImageLayout = ImageLayout.Stretch;
            room6.FlatStyle = FlatStyle.Flat;
            room6.FlatAppearance.BorderColor = Color.Empty;
            room6.FlatAppearance.BorderSize = 0;
            room6.Click += new EventHandler(room6_Click);


            this.Controls.Add(room6);

            nBoton++;

            var room7 = new Button();
            room7.Text = "";
            room7.Name = string.Format("{0}_{1}", strButtonName, nBoton); // Le doy un name que me permita identificar el boton
            room7.Tag = nBoton; // Le añado un tag, para permitirme ordenarlos
            room7.Location = new Point(225, 275);
            room7.Size = new Size(100, 150);
            room7.BackgroundImage = Properties.Resources._1;
            room7.BackgroundImageLayout = ImageLayout.Stretch;
            room7.FlatStyle = FlatStyle.Flat;
            room7.FlatAppearance.BorderColor = Color.Empty;
            room7.FlatAppearance.BorderSize = 0;
            room7.Click += new EventHandler(room7_Click);


            this.Controls.Add(room7);

            nBoton++;



        }

        private void btn_click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
        }

        private Boolean Distancia(Point Casilla, Point Localizacion,int dado)
        {
            
            int distY = Math.Abs(Casilla.Y - Localizacion.Y);
            int distX = Math.Abs(Casilla.X - Localizacion.X);

            int dist = distY + distX;
            
            if(dist == dado * 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean DistanciaRoom(Point Casilla, Point Localizacion, int dado)
        {

            int distY = Math.Abs(Casilla.Y - Localizacion.Y);
            int distX = Math.Abs(Casilla.X - Localizacion.X);

            int dist = distY + distX;

            if (dist <= dado * 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void room1_Click(object sender, EventArgs e)
        {
            
        }

        private void room2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void room7_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void room6_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void room5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void room4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void room3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hols");
        }
    }
}
