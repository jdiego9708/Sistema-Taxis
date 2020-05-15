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
using CapaPresentacion.Servicios;

namespace CapaPresentacion.Formularios.FormsCronograma
{
    public partial class VehiculoCronogramaSmall : UserControl
    {
        public VehiculoCronogramaSmall()
        {
            InitializeComponent();
            this.btnEstado.Click += BtnEstado_Click;
            this.btnOk.Click += BtnOk_Click;
        }

        public event EventHandler OnBtnOkClick;

        private void BtnOk_Click(object sender, EventArgs e)
        {
            OnBtnOkClick?.Invoke(this, e);
        }

        private void BtnEstado_Click(object sender, EventArgs e)
        {
            FrmEstados frmEstados = new FrmEstados
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmEstados.OnEstadoClick += FrmEstados_OnEstadoClick;
        }

        private void FrmEstados_OnEstadoClick(object sender, EventArgs e)
        {
            EEstados_vehiculos eEstado = (EEstados_vehiculos)sender;
            this.btnEstado.BackColor = eEstado.ColorEstado;
            this.btnEstado.ForeColor = eEstado.ColorLetra;

            this.toolTip1.SetToolTip(this.btnEstado, "Estado: " + eEstado.Nombre_estado + " - Alias: " + eEstado.Alias_estado);
            this.btnEstado.Tag = eEstado;
        }

        private void AsignarDatos(ECronogramas cronograma)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Código: ").Append(cronograma.EVehiculo.Id_vehiculo);
            info.Append(" - Placa: ").Append(cronograma.EVehiculo.Placa).Append(Environment.NewLine);
            info.Append("Conductor: ").Append(cronograma.EVehiculo.Chofer).Append(Environment.NewLine);
            info.Append("Modelo: ").Append(cronograma.EVehiculo.Modelo);
            info.Append(" - Color: ").Append(cronograma.EVehiculo.Color);

            this.txtInformacion.Text = info.ToString();
            this.txtCorreo.Text = cronograma.EVehiculo.Correo_chofer;
            if (MailHelpers.EmailValidation(this.txtCorreo.Text))
                this.errorProvider1.SetError(this.txtCorreo, "El correo electrónico no tiene un formato correcto");
            else
                this.errorProvider1.Clear();
            this.dateEstado.MinDate = DateTime.Now;          
        }

        private ECronogramas _eCronograma;

        public ECronogramas ECronograma
        {
            get => _eCronograma;
            set
            {
                _eCronograma = value;
                this.AsignarDatos(value);
            }
        }
    }
}
