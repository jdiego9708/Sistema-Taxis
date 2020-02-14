using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class ConfigTime : UserControl
    {
        public ConfigTime()
        {
            InitializeComponent();
            this.numericMinutos.KeyPress += NumericMinutos_KeyPress;
            this.numericMinutos.Enter += NumericMinutos_Enter;
        }

        private void NumericMinutos_Enter(object sender, EventArgs e)
        {
            this.numericMinutos.Select(0, this.numericMinutos.Text.Length);
        }

        private string _mensaje;
        private int _minutesDefault;
        private int _minutesSelected;

        public int MinutesDefault { get => _minutesDefault;
            set
            {
                _minutesDefault = value;
                this.numericMinutos.Value = value;
            }
        }
        public int MinutesSelected { get => _minutesSelected; set => _minutesSelected = value; }
        public string Mensaje
        {
            get => _mensaje;
            set
            {
                _mensaje = value;
                this.gbMensaje.Text = value;
            }
        }

        public event EventHandler OnNumericEnter;
        private void NumericMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.MinutesSelected = Convert.ToInt32(numericMinutos.Value);
                OnNumericEnter?.Invoke(MinutesSelected, e);
            }
        }
    }
}
