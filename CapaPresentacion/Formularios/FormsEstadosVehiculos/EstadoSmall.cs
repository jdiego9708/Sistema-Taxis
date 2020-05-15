using System;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion.Formularios.FormsEstadosVehiculos
{
    public partial class EstadoSmall : UserControl
    {
        public EstadoSmall()
        {
            InitializeComponent();
            this.panelColor.Click += Color_Click;
            this.txtInfo.Click += Color_Click;
            this.Click += Color_Click;
        }

        private void Color_Click(object sender, EventArgs e)
        {
            OnEstadoClick?.Invoke(this.EEstados_Vehiculos, e);
        }

        public event EventHandler OnEstadoClick;

        private void AsignarDatos(EEstados_vehiculos estado)
        {
            if (estado != null)
            {
                this.panelColor.BackColor = estado.ColorEstado;
                this.txtInfo.BackColor = estado.ColorEstado;
                this.txtInfo.ForeColor = estado.ColorLetra;
                this.BackColor = estado.ColorEstado;

                this.panelColor.Cursor = Cursors.Hand;
                this.txtInfo.Cursor = Cursors.Hand;
                this.Cursor = Cursors.Hand;

                this.toolTip1.SetToolTip(this.panelColor, estado.Nombre_estado);
                this.txtInfo.Text = estado.Nombre_estado + Environment.NewLine + estado.Alias_estado;
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
