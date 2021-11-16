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
using System.Threading;

namespace cliente
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread Atender;
        Boolean Parate;
        Boolean Cambia;
        string[] Invitados=new string[6];
        int invitados;
        string sesion;


        
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            //Establecemos conexión con el servidor
            IPAddress direc = IPAddress.Parse("169.254.15.179");
            IPEndPoint ipep = new IPEndPoint(direc, 9000);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket

                label1.Visible = true;
                label2.Visible = true;
                nombre1Text.Visible = true;
                Contra1Text.Visible = true;
                btn_Iniciar_Sesion.Visible = true;
                btn_Iniciar_Sesion.Enabled = false;
                btn_Registrarse.Visible = true;
                btn_Conectar.Enabled = false;
                btn_Desconectar.Enabled = true;
            }
            catch (SocketException ex)
            {
                MessageBox.Show("No se ha podido conectar con el servidor");
                return;
            }

            ThreadStart ts = delegate { AtenderServidor(); };
            Atender = new Thread(ts);
            Atender.Start();

        }

        private void btn_Desconectar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.SetError(btn_Desconectar, string.Empty);
                //Enviamos mensaje de desconexión
                string Mensaje = "0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(Mensaje);
                server.Send(msg);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                Atender.Abort();
                btn_Conectar.Enabled = true;
                //Desaparecen los datos de iniciar sesión
                label1.Visible = false;
                label2.Visible = false;
                nombre1Text.Visible = false;
                Contra1Text.Visible = false;
                btn_Iniciar_Sesion.Visible = false;
                btn_Registrarse.Visible = false;
                btn_Desconectar.Enabled = false;
                nombre1Text.Text = string.Empty;
                Contra1Text.Text = string.Empty;

                //desaparecen los datos de hacer consultas
                label6.Visible = false;
                porcentaje.Visible = false;
                Favorito.Visible = false;
                ganador.Visible = false;
                btn_Enviar.Visible = false;
                textBox1.Visible = false;
                textBox1.Text = string.Empty;
                btn_Enviar.Enabled = false;
                Grid.Visible = false;
                btn_Invitar.Visible = false;



                //Desaparece el registrarse
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                Nombre2Text.Visible = false;
                Contra2Text.Visible = false;
                Contra3Text.Visible = false;
                btn_Registrarse2.Visible = false;
                Nombre2Text.Text = string.Empty;
                Contra2Text.Text = string.Empty;
                Contra3Text.Text = string.Empty;

                //Limpiamos el data grid view de conectados

            }
            catch
            {
                errorProvider1.SetError(btn_Desconectar, "No hay ninguna conexión establecida");
            }
        }

        private void nombre1Text_TextChanged(object sender, EventArgs e)
        {
            if (Text != string.Empty && Contra1Text.Text != string.Empty)
                btn_Iniciar_Sesion.Enabled = true;
            else
                btn_Iniciar_Sesion.Enabled = false;

        }

        private void Contra1Text_TextChanged(object sender, EventArgs e)
        {
            if (Text != string.Empty && nombre1Text.Text != string.Empty)
                btn_Iniciar_Sesion.Enabled = true;
            else
                btn_Iniciar_Sesion.Enabled = false;
        }

        private void btn_Iniciar_Sesion_Click(object sender, EventArgs e)
        {
            if (nombre1Text.Text == string.Empty || Contra1Text.Text == string.Empty)
            {
                if (nombre1Text.Text == string.Empty)
                    errorProvider1.SetError(nombre1Text, "Por favor ingrese todos los datos");
                if (Contra1Text.Text == string.Empty)
                    errorProvider1.SetError(Contra1Text, "Por favor ingrese todos los datos");
            }
            else
            {
                //Limpiamos el simbolo de error
                errorProvider1.SetError(nombre1Text, string.Empty);
                errorProvider1.SetError(Contra1Text, string.Empty);
                try
                {


                    //Generamos el mensaje de petición de iniciar sesión
                    string Mensaje = "1/" + nombre1Text.Text + "/" + Contra1Text.Text;

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(Mensaje);
                    server.Send(msg);

                    Parate = false;
                    Cambia=false;
      
                    while (!Parate)
                    {
                        if (Cambia)
                        {
                            sesion = nombre1Text.Text;
                            //Desaparecen los datos de iniciar sesión
                            label1.Visible = false;
                            label2.Visible = false;
                            nombre1Text.Visible = false;
                            Contra1Text.Visible = false;
                            btn_Iniciar_Sesion.Visible = false;
                            btn_Registrarse.Visible = false;
                            nombre1Text.Text = string.Empty;
                            Contra1Text.Text = string.Empty;

                            //Aparecen los datos de hacer consultas
                            label6.Visible = true;
                            porcentaje.Visible = true;
                            Favorito.Visible = true;
                            ganador.Visible = true;
                            btn_Enviar.Visible = true;
                            textBox1.Visible = true;
                            Grid.Visible = true;
                            btn_Invitar.Visible = true;



                            Parate = true;
                        }

                    }
                    
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Error de rebasamiento");
                    return;
                }
            }
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            //Aparecen los datos para registrarse

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            Nombre2Text.Visible = true;
            Contra2Text.Visible = true;
            Contra3Text.Visible = true;
            btn_Registrarse2.Visible = true;

            //Desaparecen los datos de iniciar sesión
            label1.Visible = false;
            label2.Visible = false;
            nombre1Text.Visible = false;
            Contra1Text.Visible = false;
            btn_Iniciar_Sesion.Visible = false;
            btn_Registrarse.Visible = false;
            nombre1Text.Text = string.Empty;
            Contra1Text.Text = string.Empty;


        }

        private void btn_Registrarse2_Click(object sender, EventArgs e)
        {
            if (Nombre2Text.Text == string.Empty || Contra2Text.Text == string.Empty || Contra3Text.Text == string.Empty)
            {
                if (Nombre2Text.Text == string.Empty)
                    errorProvider1.SetError(Nombre2Text, "Por favor introduce todos los datos");
                if (Contra2Text.Text == string.Empty)
                    errorProvider1.SetError(Contra2Text, "Por favor introduce todos los datos");
                if (Contra3Text.Text == string.Empty)
                    errorProvider1.SetError(Contra3Text, "Por favor introduce todos los datos");
            }
            else if (Contra2Text.Text != Contra3Text.Text)
            {
                errorProvider1.SetError(Contra2Text, "Por favor, las contraseñas deben ser iguales");
                errorProvider1.SetError(Contra3Text, "Por favor, las contraseñas deben ser iguales");
            }
            else
            {
                errorProvider1.SetError(Nombre2Text, string.Empty);
                errorProvider1.SetError(Contra2Text, string.Empty);
                errorProvider1.SetError(Contra3Text, string.Empty);
                try
                {


                    //Generamos el mensaje de petición de iniciar sesión
                    string Mensaje = "2/" + Nombre2Text.Text + "/" + Contra2Text.Text;

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(Mensaje);
                    server.Send(msg);

                    Parate = false;
                    Cambia = false;
                    
                    while(!Parate)
                    {
                        if (Cambia)
                        {
                            sesion = Nombre2Text.Text;
                            //Desaparece el registrarse
                            label3.Visible = false;
                            label4.Visible = false;
                            label5.Visible = false;
                            Nombre2Text.Visible = false;
                            Contra2Text.Visible = false;
                            Contra3Text.Visible = false;
                            btn_Registrarse2.Visible = false;
                            Nombre2Text.Text = string.Empty;
                            Contra2Text.Text = string.Empty;
                            Contra3Text.Text = string.Empty;

                            //Aparecen los datos de hacer consultas
                            label6.Visible = true;
                            porcentaje.Visible = true;
                            Favorito.Visible = true;
                            ganador.Visible = true;
                            btn_Enviar.Visible = true;
                            textBox1.Visible = true;
                            Grid.Visible = true;
                            btn_Invitar.Visible = true;



                            Parate = true;
                        }
                    }

                }
                catch (OverflowException)
                {
                    MessageBox.Show("Error de rebasamiento");
                    return;
                }
                catch (SocketException ex)
                {
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
            }
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                try
                {
                    if (porcentaje.Checked)
                    {
                        string mensaje = "3/" + textBox1.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (Favorito.Checked)
                    {
                        string mensaje = "4/" + textBox1.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else if (ganador.Checked)
                    {
                        string mensaje = "5/" + textBox1.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                    }
                    else
                        errorProvider1.SetError(btn_Enviar, "Debes seleccionar una de las opciones");
                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Problema de rebasamiento");
                }
            }
            else
                errorProvider1.SetError(textBox1, "Por favor, introduce los datos");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Text != string.Empty)
                btn_Enviar.Enabled = true;
            else
                btn_Enviar.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Grid.ColumnCount = 1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string Mensaje = "0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(Mensaje);
                server.Send(msg);
            }
            catch
            {

            }
        }
        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                switch (codigo)
                {
                    case 1:
                        if (trozos[1] == "OK")
                        {
                            MessageBox.Show("Usuario encontrado");
                            Cambia = true;
                        }
                        else
                        {
                            MessageBox.Show("Usuario no encontrado");
                            Parate = true;    
                        }
                        break;
                    case 2:
                        if (trozos[1] == "OK")
                        {
                            MessageBox.Show("Usuario Creado");
                            Cambia = true;
                        }
                        else
                        {
                            MessageBox.Show("Error: no se ha podido registrar al usuario");
                            Parate = true;
                        }
                        break;
                    case 3:
                        if (trozos[1] == "E")
                            MessageBox.Show("Error en la búsqueda");
                        else
                            MessageBox.Show("El porcentaje de victorias de " + textBox1.Text + " es: " + trozos[1]);
                        break;
                    case 4:
                        if (trozos[1] == "E")
                            MessageBox.Show("Error en la búsqueda");
                        else if (trozos[1] == "X")
                            MessageBox.Show("Este usuario no tiene registrada ninguna partida");
                        else
                            MessageBox.Show("El personaje favorito de " + textBox1.Text + " es: " + trozos[1]);
                        break;
                    case 5:
                        if (trozos[1] == "E")
                            MessageBox.Show("Error en la búsqueda");
                        else if (trozos[1] == "X")
                        {
                            MessageBox.Show("No se han obtenido datos en la consulta");
                        }
                        else
                            MessageBox.Show("El gandor de la partida con id: " + textBox1.Text + " fue: " + trozos[1]);
                        break;
                    case 6:

                        int nfilas= Convert.ToInt32(trozos[1]);

                        Grid.Rows.Clear();

                        for (int i = 1; i <= nfilas; i++)
                        {
                            string usuario = trozos[i + 1];
                            Grid.Rows.Add(usuario);
                        }

                        break;
                }
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
 
            if (invitados < 6)
            {
                int j = e.RowIndex;
                if (Grid.Rows[j].Cells[0].Style.BackColor == Color.Green)
                {
                    Grid.Rows[j].Cells[0].Style.BackColor = Color.White;
                    EliminarInvitado(Grid[0, j].Value.ToString());
                }
                else
                {
                    if (Grid[0, j].Value.ToString() != sesion)
                    {
                        Invitados[invitados] = Grid[0, j].Value.ToString();
                        Grid.Rows[j].Cells[0].Style.BackColor = Color.Green;
                        invitados++;
                    }
                }
            }



        }
        public void EliminarInvitado(string nombre)
        {
            int i = 0;
            while (i < invitados)
            {
                if (nombre == Invitados[i])
                {
                    Invitados[i] = null;
                    int j = i;
                    while (j < invitados - 1)
                    {
                        Invitados[j] = Invitados[j - 1];
                        j = j + 1;
                    }
                    invitados--;
                }
                i = i + 1;
            }
        }

        private void btn_Invitar_Click(object sender, EventArgs e)
        {
            if (invitados < -1)
                MessageBox.Show("Se necesitan mínimo tres participantes");
            else
            {
                string mensaje = "6";

                int i = 0;
                while (i < invitados)
                {
                    mensaje = mensaje + "/" + Invitados[i];
                    i++;
                }
                MessageBox.Show(mensaje);
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            
        }
    }
}
