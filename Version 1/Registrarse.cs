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

namespace Version_1
{
    public partial class Registrarse : Form
    {
        Socket server;
        public Registrarse()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (nombreBox.Text == null || ContraBox.Text == null || ComContraBox.Text == null)
            {
                MessageBox.Show("Por favor ingrese todos los datos");
            }
            else if (ContraBox.Text != ComContraBox.Text)
            {
                MessageBox.Show("Por favor, las contraseñas deben ser iguales");
            }
            else
            {
                //Establecemos conexión con el servidor
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                IPEndPoint ipep = new IPEndPoint(direc, 9200);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    MessageBox.Show("Conectado");
                    try
                    {


                        //Generamos el mensaje de petición de iniciar sesión
                        string Mensaje = "2/" + nombreBox.Text + "/" + ContraBox.Text;

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(Mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        Mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                        if (Mensaje == "OK")
                        {
                            MessageBox.Show("Usuario Creado");
                            this.Close();
    
                        }
                        else
                        {
                            MessageBox.Show("Error:no se ha podido registrar al usuario");
                        }
                        server.Shutdown(SocketShutdown.Both);
                        server.Close();

                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Problema de rebasamiento");
                    }

                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        MessageBox.Show("Conectado");
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show("No he podido conectar con el servidor");
                        return;
                    }
                }
                catch (SocketException ex)
                {
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
            }
        }
    }
}
