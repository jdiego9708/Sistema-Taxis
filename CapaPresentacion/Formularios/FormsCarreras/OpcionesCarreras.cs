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
    public partial class OpcionesCarreras : UserControl
    {
        public OpcionesCarreras()
        {
            InitializeComponent();
            this.btnTerminarCarrera.Click += BtnTerminarCarrera_Click;
            this.btnCancelarCarrera.Click += BtnCancelarCarrera_Click;
            this.btnEnviarMensaje.Click += BtnEnviarMensaje_Click;
        }

        private void BtnEnviarMensaje_Click(object sender, EventArgs e)
        {
            OnBtnEnviarMensajesClick?.Invoke(this.ECarrera, e);
        }

        private void BtnCancelarCarrera_Click(object sender, EventArgs e)
        {
            OnBtnCancelarCarreraClick?.Invoke(this.ECarrera, e);
        }

        private void BtnTerminarCarrera_Click(object sender, EventArgs e)
        {
            OnBtnTerminarCarreraClick?.Invoke(this.ECarrera, e);
        }

        public event EventHandler OnBtnTerminarCarreraClick;
        public event EventHandler OnBtnCancelarCarreraClick;
        public event EventHandler OnBtnEnviarMensajesClick;

        private void AsignarDatos(ECarreras eCarrera)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Código carrera: ").Append(eCarrera.Id_carrera.ToString());
            info.Append(Environment.NewLine);
            info.Append("Cliente: ").Append(eCarrera.ECliente.Nombre_cliente);
            info.Append(Environment.NewLine);
            info.Append("Dirección: ").Append(eCarrera.EDireccion.Direccion).Append(" ");
            info.Append("Barrio: ").Append(eCarrera.EDireccion.EBarrio.Nombre_barrio);
            this.txtInformacion.Text = info.ToString();

            TimeSpan diferenciaHoras = new TimeSpan();

            DateTime horaInicio = new DateTime();
            horaInicio = DateTime.Parse(eCarrera.Hora_carrera);

            DateTime horaActual = new DateTime();
            horaActual = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));

            diferenciaHoras = horaActual - horaInicio;
            double minutos = diferenciaHoras.TotalMinutes;

            this.lblTiempoTranscurrido.Text = Convert.ToInt32(minutos) + " minutos transcurridos.";
        }

        private ECarreras _eCarrera;

        public ECarreras ECarrera
        {
            get => _eCarrera;
            set
            {
                _eCarrera = value;
                this.AsignarDatos(value);
            }
        }
    }
}
