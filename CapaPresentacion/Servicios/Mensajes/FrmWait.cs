using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Servicios.Mensajes
{
    public partial class FrmWait : Form
    {
        #region PATRON SINGLETON
        //private static FrmWait _Instancia;
        //public static FrmWait GetInstancia()
        //{
        //    if (_Instancia == null || _Instancia.IsDisposed)
        //    {
        //        _Instancia = new FrmWait();
        //    }
        //    return _Instancia;
        //}
        #endregion

        public FrmWait()
        {
            InitializeComponent();
            this.Load += FrmWait_Load;
        }

        public delegate void SetMensaje(string text);
        private void SetTextboxMensaje(string text)
        {
            this.txtMensaje.Text = text;
        }

        public void ObtenerTexto(string mensaje)
        {
            var @delegate = new SetMensaje(SetTextboxMensaje);
            new Task(() => this.txtMensaje.BeginInvoke(@delegate, mensaje)).Start();
        }

        private void FrmWait_Load(object sender, EventArgs e)
        {
            this.txtMensaje.Text = this.Mensaje;
        }

        private string _mensaje;

        public string Mensaje {
            get
            {
                return _mensaje;
            }
            set
            {
                _mensaje = value;      
            }
        }
    }
}
