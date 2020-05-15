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
using CapaPresentacion.Formularios.FormsEstadosVehiculos;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class OpcionesEstadoVehiculo : UserControl
    {
        public OpcionesEstadoVehiculo()
        {
            InitializeComponent();
        }

        public event EventHandler OnCambiarEstado;
    
        public void BuscarEstados(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtEstados = EEstados_vehiculos.BuscarEstados(tipo_busqueda, texto_busqueda, out string rpta);
                this.panelEstados.clearDataSource();
                if (dtEstados != null)
                {
                    List<UserControl> controls = new List<UserControl>();

                    foreach(DataRow row in dtEstados.Rows)
                    {
                        EEstados_vehiculos eEstado = new EEstados_vehiculos(row);
                        EstadoSmall estadoSmall = new EstadoSmall
                        {
                            EEstados_Vehiculos = eEstado,
                        };
                        estadoSmall.OnEstadoClick += EstadoSmall_OnEstadoClick;
                        controls.Add(estadoSmall);
                    }

                    this.panelEstados.AddArrayControl(controls);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarEstados",
                    "Hubo un error al buscar los estados", ex.Message);
            }
        }

        private void EstadoSmall_OnEstadoClick(object sender, EventArgs e)
        {
            EEstados_vehiculos eEstado = (EEstados_vehiculos)sender;
            this.EstadoSeleccionado = eEstado;
            OnCambiarEstado?.Invoke(this, e);
        }

        private void Estado_actual(EEstados_vehiculos estado_actual)
        {
            this.txtEstado.Text = estado_actual.Nombre_estado + " - " + estado_actual.Alias_estado;

            foreach(EstadoSmall estadoSmall in this.panelEstados.controlsUser)
            {
                if (estadoSmall.EEstados_Vehiculos.Id_estado !=
                    estado_actual.Id_estado)
                {
                    estadoSmall.Enabled = false;
                }
            }                 
        }

        private EEstados_vehiculos _estadoActual;
        private EEstados_vehiculos _estadoSeleccionado;
        private EVehiculos _eVehiculo;
        private EDetalle_vehiculos_estado _eDetalle;

        public EEstados_vehiculos EstadoActual
        {
            get => _estadoActual;
            set
            {
                _estadoActual = value;
                this.Estado_actual(value);
            }
        }

        public EVehiculos EVehiculo { get => _eVehiculo; set => _eVehiculo = value; }
        public EEstados_vehiculos EstadoSeleccionado { get => _estadoSeleccionado; set => _estadoSeleccionado = value; }
        public EDetalle_vehiculos_estado EDetalle { get => _eDetalle; set => _eDetalle = value; }
    }
}
