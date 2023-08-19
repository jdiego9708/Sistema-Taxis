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
    public partial class OpcionesEstadoVehiculo : UserControl
    {
        public OpcionesEstadoVehiculo()
        {
            InitializeComponent();
            this.btnActivar.Click += BtnActivar_Click;
            this.btnInactivar.Click += BtnInactivar_Click;
            this.btnTurno.Click += BtnTurno_Click;
        }

        public event EventHandler OnCambiarEstado;

        private void BtnTurno_Click(object sender, EventArgs e)
        {
            this.EstadoSeleccionado = "DE TURNO";
            OnCambiarEstado?.Invoke(this, e);
        }

        private void BtnInactivar_Click(object sender, EventArgs e)
        {
            this.EstadoSeleccionado = "INACTIVO";
            OnCambiarEstado?.Invoke(this, e);
        }

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            this.EstadoSeleccionado = "ACTIVO";
            OnCambiarEstado?.Invoke(this, e);
        }

        private void Estado_actual(string estado_actual)
        {
            this.txtEstado.Text = estado_actual;

            if (estado_actual.Equals("ACTIVO"))
            {
                this.btnActivar.Enabled = false;
                this.btnInactivar.Enabled = true;
                this.btnTurno.Enabled = true;
                return;
            }

            if (estado_actual.Equals("INACTIVO"))
            {
                this.btnActivar.Enabled = true;
                this.btnInactivar.Enabled = false;
                this.btnTurno.Enabled = true;
                return;
            }

            if (string.IsNullOrEmpty(estado_actual))
            {
                this.btnActivar.Enabled = true;
                this.btnInactivar.Enabled = false;
                this.btnTurno.Enabled = true;
                this.txtEstado.Text = "INACTIVO";
                return;
            }

            if (estado_actual.Equals("DE TURNO"))
            {
                this.btnActivar.Enabled = true;
                this.btnInactivar.Enabled = true;
                this.btnTurno.Enabled = false;
                return;
            }           
        }

        private string _estadoActual;
        private string _estadoSeleccionado;
        private EVehiculos _eVehiculo;
        private EDetalle_vehiculos_estado _eDetalle;

        public string EstadoActual
        {
            get => _estadoActual;
            set
            {
                _estadoActual = value;
                this.Estado_actual(value);
            }
        }

        public EVehiculos EVehiculo { get => _eVehiculo; set => _eVehiculo = value; }
        public string EstadoSeleccionado { get => _estadoSeleccionado; set => _estadoSeleccionado = value; }
        public EDetalle_vehiculos_estado EDetalle { get => _eDetalle; set => _eDetalle = value; }
    }
}
