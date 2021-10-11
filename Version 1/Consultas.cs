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
            iniciar_Sesion Form = new iniciar_Sesion();
            Form.ShowDialog();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                //Conectamos el serivdor
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                IPEndPoint ipep = new IPEndPoint(direc, 9200);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    MessageBox.Show("Conectado");
      
                    if (porcentaje.Checked)
                    {
                        string mensaje = "3/" + textBox1.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        if (mensaje == "E")
                            MessageBox.Show("Error en la búsqueda");
                        else
                            MessageBox.Show("El porcentaje de victorias de "+textBox1.Text+" es: " + mensaje);
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
                        else
                            MessageBox.Show("El personaje de " + textBox1.Text + " es: " + mensaje);
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
                        else
                            MessageBox.Show("El gandor de la partida con id: " + textBox1.Text + " fue: " + mensaje);
                    }

                    
                   

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
                MessageBox.Show("Por favor introduce los datos");
        }
    }
}
