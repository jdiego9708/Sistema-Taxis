using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsCorreos
{
    public partial class FrmCorreos : Form
    {
        public FrmCorreos()
        {
            InitializeComponent();
            this.rdErrores.CheckedChanged += Rd_CheckedChanged;
            this.rdReportes.CheckedChanged += Rd_CheckedChanged;
            this.Load += FrmCorreos_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.chkCopia.CheckedChanged += ChkCopia_CheckedChanged;
            this.btnCancelarEdicion.Click += BtnCancelarEdicion_Click;
        }

        private void BtnCancelarEdicion_Click(object sender, EventArgs e)
        {
            if (this.IsEditar)
                if (this._eCorreo != null)
                {
                    this.IsEditar = false;
                    this.ECorreo = _eCorreo;
                }
        }

        private void ChkCopia_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)           
                this.gbCopia.Enabled = true;
            else
                this.gbCopia.Enabled = false;
        }

        private bool Comprobaciones(out ECorreos eCorreo)
        {
            eCorreo = new ECorreos();
            if (!this.ComprobacionEmail(this.txtCorreoEnvio.Text))
            {
                Mensajes.MensajeInformacion("El correo del remitente no tiene un formato correcto", "Entendido");
                return false;
            }

            if (!this.ComprobacionEmail(this.txtCorreoReceptor.Text))
            {
                Mensajes.MensajeInformacion("El correo del destinatario no tiene un formato correcto", "Entendido");
                return false;
            }

            if (this.chkCopia.Checked)
            {
                if (!this.ComprobacionEmail(this.txtCopia.Text))
                {
                    Mensajes.MensajeInformacion("El correo para el envío de copia no tiene un formato correcto", "Entendido");
                    return false;
                }
                else
                    eCorreo.Correo_copia = this.txtCopia.Text;
            }
            else
                eCorreo.Correo_copia = string.Empty;

            if (this.txtPass1.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("La contraseña del correo de envío es obligatoria", "Entendido");
                return false;
            }
            else
                eCorreo.Clave_correo_remitente = this.txtPass1.Text;

            eCorreo.Correo_remitente = this.txtCorreoEnvio.Text;
            eCorreo.Correo_destinatario = this.txtCorreoReceptor.Text;
            eCorreo.Estado_correo = "ACTIVO";

            if (this.rdErrores.Checked)
                eCorreo.Tipo_correo = "ERRORES";
            else
                eCorreo.Tipo_correo = "REPORTES";

            if (this.ECorreo != null)
                eCorreo.Id_correo = this.ECorreo.Id_correo;
            else
            {
                Mensajes.MensajeInformacion("No se encontró el id del correo ligado", "Entendido");
                return false;
            }

            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (this.IsEditar)
            {
                if (this.Comprobaciones(out ECorreos eCorreo))
                {
                    string rpta = ECorreos.EditarCorreo(eCorreo, eCorreo.Id_correo);
                    if (rpta.Equals("OK"))
                    {
                        this.IsEditar = false;
                        this.BuscarCorreos();

                        Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config1.AppSettings.Settings["correoTurno"].Value = this.chkCorreoTurno.Checked ? "AUTOMATICO" : "MANUAL";
                        config1.Save(ConfigurationSaveMode.Modified, true);
                        ConfigurationManager.RefreshSection("appSettings");

                        Mensajes.MensajeOkForm("Se guardaron los cambios correctamente");
                        return;
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("Hubo un error al guardar los cambios, detalles: " + rpta, "Entendido");
                        return;
                    }
                }
            }
            else
            {
                this.IsEditar = true;
            }
        }

        private void HabilitarControles(bool value)
        {
            this.gbPrincipal.Enabled = value;
        }

        private bool ComprobacionEmail(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void BuscarCorreos()
        {
            DataTable dtCorreos = ECorreos.BuscarCorreos("COMPLETO", "", out string rpta);
            if (dtCorreos != null)
            {
                this.DtCorreos = dtCorreos;

                DataRow[] rows =
                    dtCorreos.Select(string.Format("Tipo_correo = '{0}'", "REPORTES"));
                if (rows.Length > 0)
                {
                    ECorreos eCorreo = new ECorreos(rows[0]);
                    this.ECorreo = eCorreo;
                    this.rdReportes.Tag = eCorreo;
                }

                rows =
                    dtCorreos.Select(string.Format("Tipo_correo = '{0}'", "ERRORES"));
                if (rows.Length > 0)
                {
                    ECorreos eCorreo = new ECorreos(rows[0]);
                    this.rdErrores.Tag = eCorreo;
                }

                return;
            }
            else
                if (!rpta.Equals("OK"))
                Mensajes.MensajeInformacion("No se pudo recuperar los correos de la base de datos, detalles: " + rpta, "Detalles");
        }

        private void FrmCorreos_Load(object sender, EventArgs e)
        {
            this.BuscarCorreos();

            string correoTurno = Convert.ToString(ConfigurationManager.AppSettings["correoTurno"]);
            if (correoTurno.Equals("AUTOMATICO"))          
                this.chkCorreoTurno.Checked = true;           
            else
                this.chkCorreoTurno.Checked = false;

            //ECorreos eCorreo = (ECorreos)this.rdReportes.Tag;
            //this.ECorreo = eCorreo;
        }

        private void AsignarDatos(ECorreos eCorreo)
        {
            if (eCorreo != null)
            {
                this.txtCorreoEnvio.Text = eCorreo.Correo_remitente;
                this.txtCorreoReceptor.Text = eCorreo.Correo_destinatario;
                this.txtPass1.Text = eCorreo.Clave_correo_remitente;
                if (eCorreo.Correo_copia.Equals(""))
                {
                    this.chkCopia.Checked = false;
                    this.txtCopia.Text = string.Empty;
                    this.gbCopia.Enabled = false;
                }
                else
                {
                    this.chkCopia.Checked = true;
                    this.txtCopia.Text = eCorreo.Correo_copia;
                    this.gbCopia.Enabled = true;
                }
            }
        }

        private void Rd_CheckedChanged(object sender, EventArgs e)
        {
            ECorreos eCorreo;
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                if (rd.Tag != null)
                {
                    eCorreo = (ECorreos)rd.Tag;
                    this.ECorreo = eCorreo;
                    if (eCorreo.Tipo_correo.Equals("REPORTES"))
                        this.chkCorreoTurno.Visible = true;
                    else
                        this.chkCorreoTurno.Visible = false;

                }
            }
        }

        private bool _isEditar;
        private DataTable _dtCorreos;
        private ECorreos _eCorreo;

        public bool IsEditar { get => _isEditar;
            set
            {
                _isEditar = value;
                if (value)
                {
                    this.btnGuardar.Text = "Actualizar";
                    this.HabilitarControles(true);
                    this.btnCancelarEdicion.Visible = true;
                }
                else
                {
                    this.btnGuardar.Text = "Habilitar edición";
                    this.HabilitarControles(false);
                    this.btnCancelarEdicion.Visible = false;
                }
            }
        }
        public DataTable DtCorreos { get => _dtCorreos; set => _dtCorreos = value; }
        public ECorreos ECorreo { get => _eCorreo; 
            set
            {
                _eCorreo = value;
                this.AsignarDatos(value);
            }              
        }
    }
}
