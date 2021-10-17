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
            if (nombreBox.Text == string.Empty || ContraBox.Text == string.Empty || ComContraBox.Text == string.Empty)
            {
                if (nombreBox.Text == string.Empty)
                    errorProvider1.SetError(nombreBox, "Por favor introduce todos los datos");
                if (ContraBox.Text == string.Empty)
                    errorProvider1.SetError(ContraBox, "Por favor introduce todos los datos");
                if (ComContraBox.Text == string.Empty)
                    errorProvider1.SetError(ComContraBox, "Por favor introduce todos los datos");
            }
            else if (ContraBox.Text != ComContraBox.Text)
            {
                errorProvider1.SetError(ContraBox, "Por favor, las contraseñas deben ser iguales");
                errorProvider1.SetError(ComContraBox, "Por favor, las contraseñas deben ser iguales");
            }
            else
            {
                errorProvider1.SetError(nombreBox,string.Empty);
                errorProvider1.SetError(ContraBox,string.Empty);
                errorProvider1.SetError(ComContraBox, string.Empty);
                //Establecemos conexión con el servidor
                IPAddress direc = IPAddress.Parse("169.254.15.179");
                IPEndPoint ipep = new IPEndPoint(direc, 9080);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
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

                        if (Mensaje == "OK\n")
                        {
                            MessageBox.Show("Usuario Creado");
                            this.Close();
    
                        }
                        else
                        {
                            MessageBox.Show("Error: no se ha podido registrar al usuario");
                        }
                        server.Shutdown(SocketShutdown.Both);
                        server.Close();

                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Problema de rebasamiento");
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

        private void Registrarse_Load(object sender, EventArgs e)
        {
            errorProvider1.SetError(nombreBox, string.Empty);
            errorProvider1.SetError(ContraBox, string.Empty);
            errorProvider1.SetError(ComContraBox, string.Empty);
        }

        private void nombreBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(nombreBox, string.Empty);
        }

        private void ContraBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(ContraBox, string.Empty);
        }

        private void ComContraBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(ComContraBox, string.Empty);
        }
    }
}
