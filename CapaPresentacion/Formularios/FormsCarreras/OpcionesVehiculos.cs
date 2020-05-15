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
    public partial class OpcionesVehiculos : UserControl
    {
        public OpcionesVehiculos()
        {
            InitializeComponent();
            this.btnEditarVehiculo.Click += BtnEditarVehiculo_Click;
            this.btnAgregarObservacion.Click += BtnAgregarObservacion_Click;
        }

        private void BtnAgregarObservacion_Click(object sender, EventArgs e)
        {
            OnBtnAgregarObservacion?.Invoke(this.EVehiculo, e);
        }

        private void BtnEditarVehiculo_Click(object sender, EventArgs e)
        {
            OnBtnEditarVehiculo?.Invoke(this.EVehiculo, e);
        }

        public event EventHandler OnBtnAgregarObservacion;
        public event EventHandler OnBtnEditarVehiculo;

        private void AsignarDatos(EVehiculos eVehiculo)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.Append("Código: ").Append(eVehiculo.Id_vehiculo);
            cadena.Append(Environment.NewLine);
            cadena.Append("Placa: ").Append(eVehiculo.Placa);
            this.txtVehiculo.Text = cadena.ToString();
        }

        private EVehiculos _eVehiculo;

        public EVehiculos EVehiculo
        {
            get => _eVehiculo;
            set
            {
                _eVehiculo = value;
                this.AsignarDatos(value);
            }
        }
    }
}
