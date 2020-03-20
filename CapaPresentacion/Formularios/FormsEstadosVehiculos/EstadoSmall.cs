using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion.Formularios.FormsEstadosVehiculos
{
    public partial class EstadoSmall : UserControl
    {
        public EstadoSmall()
        {
            InitializeComponent();
        }

        private void AsignarDatos(EEstados_vehiculos estado)
        {
            if (estado != null)
            {
                this.panelColor.BackColor = estado.Color;
                this.txtInfo.BackColor = estado.Color;
                this.BackColor = estado.Color;

                this.toolTip1.SetToolTip(this.panelColor, estado.Nombre_estado);
                this.txtInfo.Text = estado.Alias_estado;
            }
        }

        private EEstados_vehiculos _eEstados_Vehiculos;
        public EEstados_vehiculos EEstados_Vehiculos
        {
            get => _eEstados_Vehiculos;
            set
            {
                _eEstados_Vehiculos = value;
                this.AsignarDatos(value);
            }
        }
    }
}
