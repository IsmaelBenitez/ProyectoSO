using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Version_1
{
    public partial class Consultas : Form
    {
        Socket server;
        public Consultas()
        {
            InitializeComponent();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                errorProvider1.SetError(textBox1, string.Empty);
                //Conectamos el serivdor
                IPAddress direc = IPAddress.Parse("169.254.15.179");
                IPEndPoint ipep = new IPEndPoint(direc, 9080);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket

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
                        errorProvider1.SetError(btnEnviar, "Debes seleccionar una de las opciones");
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
                errorProvider1.SetError(textBox1, "Por favor introduce los datos");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, string.Empty);
        }
    }
}
