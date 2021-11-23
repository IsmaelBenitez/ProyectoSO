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
        int nMensajes=0;
        delegate void DelegadoParaEscribirMensaje(string mensaje);
        public Partida(Socket server,string[] trozos,string sesion)
        {
            InitializeComponent();
            
            this.server = server;
            Datos = trozos;
            this.sesion = sesion;
            IDp = Convert.ToInt32(trozos[Convert.ToInt32(trozos[1]) + 2]);

        }

        private void btn_chat_Click(object sender, EventArgs e)
        {
            if(MensajeBox.Text!=string.Empty)
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
                Chat.Text = Chat.Text + Environment.NewLine + mensaje;
                nMensajes++;
            }
            else
            {
                Chat.Text = string.Empty;
                nMensajes = 0;
                Chat.Text = Chat.Text + Environment.NewLine + mensaje;
                nMensajes++;
            }
        }
    }
}
