using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Timers;
using CapaEntidades;
using System.Reflection;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class CarreraSmall : UserControl
    {
        System.Timers.Timer aTimer;
        PoperContainer container;
        public CarreraSmall()
        {
            InitializeComponent();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000; 
            this.btnTerminar.Click += BtnTerminar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.btnConfiguracion.Click += BtnConfiguracion_Click;
        }

        private void BtnConfiguracion_Click(object sender, EventArgs e)
        {
            ConfigTime configTime = new ConfigTime
            {
                MinutesDefault = this.MinutesDefault,
                Mensaje = "Minutos para finalizar"
            };
            configTime.OnNumericEnter += ConfigTime_OnNumericEnter;
            this.container = new PoperContainer(configTime);
            this.container.Show(btnConfiguracion);
        }

        private void ConfigTime_OnNumericEnter(object sender, EventArgs e)
        {
            int minutes = (int)sender;
            this.MinutesDefault = minutes;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            OnCancelarCarrera?.Invoke(this, e);
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            OnTerminarCarrera?.Invoke(this, e);
        }

        private bool ConvertHour(string hora, out TimeSpan Hora)
        {
            Hora = new TimeSpan();
            int[] partes =
                hora.Split(new char[] { ':' }).Select(x => Convert.ToInt32(x)).ToArray();
            if (partes.Length < 1)
                partes = null;

            if (partes != null)
            {
                TimeSpan tiempo = new TimeSpan(partes[0], partes[1], partes[2]);
                Hora = tiempo;
                return true;
            }
            else
                return false;
        }

        private void AsignarDatos(ECarreras eCarrera)
        {
            //Asignar la hora de inicio
            if (this.ConvertHour(ECarrera.Hora_carrera, out TimeSpan HoraInicio))
            {
                DateTime time = DateTime.Today.Add(HoraInicio);
                //this.lblHoraInicio.Text = "Hora de inicio: " + HoraInicio.ToString(@"hh\:mm\:ss");
                this.lblHoraInicio.Text = "Hora de inicio: " + time.ToString("hh:mm tt");
            }        

            //Asignar el tiempo de llegada
            this.lblTiempoLlegada.Text = "Tiempo de llegada: " + ECarrera.Tiempo_llegada.ToString() + " min. ";

            //Asignar la información de la carrera
            StringBuilder info = new StringBuilder();
            info.Append("Vehículo: ").Append(eCarrera.EVehiculo.Id_vehiculo);
            info.Append(Environment.NewLine);
            info.Append("Cliente: ").Append(eCarrera.ECliente.Nombre_cliente).Append(" Código: ").Append(eCarrera.ECliente.Id_cliente);
            info.Append(Environment.NewLine);
            info.Append("Dirección: ").Append(eCarrera.EDireccion.Direccion).Append(" ");
            info.Append("Barrio: ").Append(eCarrera.EDireccion.EBarrio.Nombre_barrio);
            info.Append(Environment.NewLine);
            info.Append("Observaciones: ").Append(eCarrera.Observaciones);
            this.txtInformacion.Text = info.ToString();

            this.Hora_carrera = eCarrera.Hora_carrera;
           
            if (eCarrera.Estado_carrera.Equals("TERMINADA"))
            {
                this.lblTiempoTranscurrido.Text = "Carrera terminada";
                this.btnCancelar.Visible = false;
                this.btnConfiguracion.Visible = false;
                this.btnTerminar.Visible = false;
                return;
            }

            if (eCarrera.Estado_carrera.Equals("CANCELADA"))
            {
                this.lblTiempoTranscurrido.Text = "Carrera cancelada";
                this.btnCancelar.Visible = false;
                this.btnConfiguracion.Visible = false;
                this.btnTerminar.Visible = false;
                return;
            }

            //Iniciar el timer
            if (aTimer != null)
                aTimer.Enabled = true;
        }

        public event EventHandler OnTerminarCarrera;
        public event EventHandler OnCancelarCarrera;

        private string Hora_carrera { get; set; }
        
        private ECarreras _eCarrera;

        public ECarreras ECarrera { get => _eCarrera;
            set
            {
                _eCarrera = value;
                this.AsignarDatos(value);
            }
        }

        public int MinutesDefault { get => _minutesDefault; set => _minutesDefault = value; }

        private int _minutesDefault;
        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Asignar el tiempo transcurrido
            TimeSpan diferenciaHoras = new TimeSpan();

            DateTime horaInicio = new DateTime();
            horaInicio = DateTime.Parse(Hora_carrera);

            DateTime horaActual = new DateTime();
            horaActual = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));

            diferenciaHoras = horaActual - horaInicio;

            int horas = diferenciaHoras.Hours;
            int minutos = diferenciaHoras.Minutes;
            int segundos = diferenciaHoras.Seconds;

            string displayHours =
                Convert.ToString(horas).Length > 1 ? horas.ToString() : "0" + horas.ToString();

            string displayMinutes =
                Convert.ToString(minutos).Length > 1 ? minutos.ToString() : "0" + minutos.ToString();

            //if (minutos == MinutesDefault)
            //{
            //    aTimer.Stop();
            //    OnTerminarCarrera?.Invoke(this, null);
            //}

            string displaySeconds =
                Convert.ToString(segundos).Length > 1 ? segundos.ToString() : "0" + segundos.ToString();

            SetControlPropertyThreadSafe(lblTiempoTranscurrido, "Text",
                string.Format("Tiempo transcurrido: {0}:{1}", displayMinutes, displaySeconds));          
        }

        ////Crear clase de evento
        //public class TerminarClass
        //{
        //    //Patron singleton para poder recuperar la misma instancia
        //    #region PATRON SINGLETON
        //    private static TerminarClass _Instancia;
        //    public static TerminarClass GetInstancia()
        //    {
        //        if (_Instancia == null)
        //        {
        //            _Instancia = new TerminarClass();
        //        }
        //        return _Instancia;
        //    }
        //    #endregion

        //    public ECarreras _eCarrera;

        //    //Evento que se instancia en asignar datos
        //    public event EventHandler OnTerminar;

        //    //Método que se llamará desde el método stático
        //    public void Terminar()
        //    {
        //        OnTerminar?.Invoke(_eCarrera, null);
        //    }
        //}

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe),
                    new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

    }
}
