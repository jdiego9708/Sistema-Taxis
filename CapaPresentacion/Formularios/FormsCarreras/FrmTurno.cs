using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class FrmTurno : Form
    {
        Button btnCancelar;
        public FrmTurno()
        {
            InitializeComponent();
            this.btnCancelar = new Button();
            this.btnCancelar.Click += BtnCancelar_Click;
            this.btnAbrir.Click += BtnAbrir_Click;
            this.Load += FrmTurno_Load;
            this.btnContinuar.Click += BtnContinuar_Click;
        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            OnAbrirTurnoSuccess?.Invoke(this, e);         
            this.Close();
        }

        private void FrmTurno_Load(object sender, EventArgs e)
        {
            this.CancelButton = this.btnCancelar;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (this.btnContinuar.Visible)
            {
                Mensajes.MensajePregunta("¿Continuar con el turno en curso?", 
                    "Continuar", "Cerrar turno", out DialogResult dialog);
                if (dialog == DialogResult.Yes)
                {
                    this.btnContinuar.PerformClick();
                    return;
                }
                else
                {
                    this.btnAbrir.PerformClick();
                    return;
                }
            }
            else
            {
                Mensajes.MensajePregunta("¿Abrir un nuevo turno?",
                   "Nuevo turno", "Cancelar", out DialogResult dialog);
                if (dialog == DialogResult.Yes)
                {
                    this.btnAbrir.PerformClick();
                    return;
                }
                else
                {
                    this.Close();
                    return;
                }
            }
        }

        public event EventHandler OnAbrirTurnoSuccess;
        public event EventHandler OnCerrarTurnoSuccess;

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            if (this.EEmpleado != null)
            {
                ETurnos eTurno = new ETurnos
                {
                    EEmpleado = this.EEmpleado,
                    Hora_inicio_turno = DateTime.Now.TimeOfDay,
                    Hora_fin_turno = DateTime.Now.TimeOfDay,
                    Fecha_turno = DateTime.Now,
                    Estado_turno = "ABIERTO"
                };

                string rpta = ETurnos.InsertarTurno(eTurno, out int id_turno);
                if (rpta.Equals("OK"))
                {
                    eTurno.Id_turno = id_turno;
                    this.ETurno = eTurno;
                    this.DialogResult = DialogResult.OK;
                    OnAbrirTurnoSuccess?.Invoke(this, e);
                    this.Close();
                    return;
                }
                else
                {
                    Mensajes.MensajeInformacion("Hubo un error al abrir el turno, detalles: " + rpta, "Entendido");
                    return;
                }
            }

            if (this.ETurno != null)
            {
                MensajeEspera.ShowWait("Finalizando");
                this.ETurno.Estado_turno = "CERRADO";
                this.ETurno.Hora_fin_turno = DateTime.Now.TimeOfDay;

                string rpta = ETurnos.EditarTurno(this.ETurno, this.ETurno.Id_turno);
                if (rpta.Equals("OK"))
                {
                    this.DialogResult = DialogResult.OK;
                    OnCerrarTurnoSuccess?.Invoke(this, e);
                    MensajeEspera.CloseForm();

                    this.Close();
                    return;
                }
                else
                {
                    Mensajes.MensajeInformacion("Hubo un error al cerrar el turno, detalles: " + rpta, "Entendido");
                    return;
                }
            }
        }

        private void AsignarDatos(EEmpleados eEmpleado)
        {
            this.txtPrincipal.Text = "Apertura de turno";
            this.btnAbrir.Text = "Abrir turno";
            this.btnContinuar.Visible = false;

            DataTable dtTurnos = ETurnos.BuscarTurnos("COMPLETO", "", out string rpta);
            if (dtTurnos != null)
            {
                ETurnos eTurno = new ETurnos(dtTurnos, 0);

                DateTime horaUltimoTurno = DateTime.Today.Add(eTurno.Hora_fin_turno);
                this.txtInformacion.Text = "Último cierre de turno: " + eTurno.Fecha_turno.ToLongDateString().ToLowerInvariant() +
                    " - " + horaUltimoTurno.ToString("hh:mm tt").ToLowerInvariant() + Environment.NewLine +
                    "Fecha y hora actual: " + DateTime.Now.ToLongDateString().ToLowerInvariant() + " - " +
                    DateTime.Now.ToLongTimeString().ToLowerInvariant() + Environment.NewLine +
                    "Empleado de turno: " + eEmpleado.Nombre_empleado.ToUpperInvariant();
            }
            else
                if (!rpta.Equals("OK"))
                throw new Exception(rpta);
            else
                this.txtInformacion.Text = "No se encontró la fecha del turno anterior";
        }

        private void AsignarDatos(ETurnos eTurno)
        {
            this.txtPrincipal.Text = "Información de turno";
            this.btnAbrir.Text = "Cerrar turno";
            this.btnContinuar.Visible = true;

            DateTime horaUltimoTurno = DateTime.Today.Add(eTurno.Hora_inicio_turno);
            this.txtInformacion.Text = "Última apertura de turno: " + eTurno.Fecha_turno.ToLongDateString().ToLowerInvariant() +
                " - " + horaUltimoTurno.ToString("hh:mm tt").ToLowerInvariant() + Environment.NewLine +
                "Fecha y hora actual: " + DateTime.Now.ToLongDateString().ToLowerInvariant() + " - " +
                DateTime.Now.ToLongTimeString().ToLowerInvariant() + Environment.NewLine +
                "Empleado de turno: " + eTurno.EEmpleado.Nombre_empleado.ToUpperInvariant();
        }

        private EEmpleados _eEmpleado;
        private ETurnos _eTurno;

        public EEmpleados EEmpleado
        {
            get => _eEmpleado;
            set
            {
                _eEmpleado = value;
                this.AsignarDatos(value);
            }
        }

        public ETurnos ETurno
        {
            get => _eTurno;
            set
            {
                _eTurno = value;
                this.AsignarDatos(value);
            }
        }
    }
}
