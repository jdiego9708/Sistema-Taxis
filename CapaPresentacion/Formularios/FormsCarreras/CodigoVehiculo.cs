using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class CodigoVehiculo : UserControl
    {
        public CodigoVehiculo()
        {
            InitializeComponent();
            this.Load += CodigoVehiculo_Load;
            this.btnSiguiente.Click += BtnSiguiente_Click;
            this.txtCodigo.KeyPress += txtCodigo_KeyPress;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (!txt.Text.Equals(""))
                {
                    string texto = txt.Text.Trim();
                    if (int.TryParse(texto, out int codigo))
                    {
                        OnBtnNext?.Invoke(this, e);
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("Solo números", "Entendido");
                    }
                }
            }
            else if (char.IsDigit(e.KeyChar) ||
                    e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            OnBtnNext?.Invoke(this, e);
        }

        public event EventHandler OnBtnNext;
        public EVehiculos EVehiculo { get; set; }
        public EDireccion_clientes EDireccion { get; set; }

        private void CodigoVehiculo_Load(object sender, EventArgs e)
        {
            this.txtCodigo.Focus();
        }
    }
}
