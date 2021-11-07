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
    public partial class Form1 : Form
    {
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            //Establecemos conexión con el servidor
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9300);
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
                btn_Refrescar.Visible = false;

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
                Grid.Rows[0].Cells[0].Value = "Conectados";
                for (int i = 0; i < Grid.RowCount; i++)
                {
                    Grid.Rows[i].Cells[0].Value = null;
                }


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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    Mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    if (Mensaje == "OK\n")
                    {
                        MessageBox.Show("Usuario encontrado");

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
                        btn_Refrescar.Visible = true;


                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado");
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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    Mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    if (Mensaje == "OK\n")
                    {
                        MessageBox.Show("Usuario Creado");
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
                        btn_Refrescar.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("Error: no se ha podido registrar al usuario");
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

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        if (mensaje == "E\n")
                            MessageBox.Show("Error en la búsqueda");
                        else
                            MessageBox.Show("El porcentaje de victorias de " + textBox1.Text + " es: " + mensaje);
                    }
                    else if (Favorito.Checked)
                    {
                        string mensaje = "4/" + textBox1.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        if (mensaje == "E")
                            MessageBox.Show("Error en la búsqueda");
                        else if (mensaje == "X")
                            MessageBox.Show("Este usuario no tiene registrada ninguna partida");
                        else
                            MessageBox.Show("El personaje favorito de " + textBox1.Text + " es: " + mensaje);
                    }
                    else if (ganador.Checked)
                    {
                        string mensaje = "5/" + textBox1.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        if (mensaje == "E")
                            MessageBox.Show("Error en la búsqueda");
                        else if (mensaje == "X")
                        {
                            MessageBox.Show("No se han obtenido datos en la consulta");
                        }
                        else
                            MessageBox.Show("El gandor de la partida con id: " + textBox1.Text + " fue: " + mensaje);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Refrescar_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + textBox1.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            string[] nombres=new string[100];
            nombres= mensaje.Split('/');
            MessageBox.Show(nombres[0]);
            MessageBox.Show(nombres[1]);
            Grid.ColumnCount = 1;
            
            Grid.RowCount = Convert.ToInt32(nombres[0])+1;
            Grid.Rows[0].Cells[0].Value = "Conectados";
            for (int i = 1; i < Grid.RowCount; i++)
            {
                Grid.Rows[i].Cells[0].Value = nombres[i];
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
