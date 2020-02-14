using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsPersonalizacion
{
    public partial class FrmPersonalizarAplicacion : Form
    {
        public FrmPersonalizarAplicacion()
        {
            InitializeComponent();
            this.Load += FrmPersonalizarAplicacion_Load;
            this.btnGuardarNombre.Click += BtnGuardarNombre_Click;
            this.btnNuevaBase.Click += BtnNuevaBase_Click;
            this.btnSaveBD.Click += BtnSaveBD_Click;
            this.btnGuardarTiempo.Click += BtnGuardarTiempo_Click;
        }

        private void BtnGuardarTiempo_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config1.AppSettings.Settings["tiempoPredeterminado"].Value = this.numericUpDown1.Value.ToString();
                config1.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
                Mensajes.MensajeInformacion("Se actualizó correctamente el tiempo predeterminado, reincie la aplicación para que los cambios se apliquen", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardarTiempo_Click",
                    "Hubo un error al guardar el tiempo predeterminado", ex.Message);
            }
        }

        private void BtnSaveBD_Click(object sender, EventArgs e)
        {
            if (this.txtNombreBD.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El nombre de la base de datos no puede estar vacío", "Entendido");
                return;
            }

            if (this.txtAlias.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("El alias de la base de datos no puede estar vacío", "Entendido");
                return;
            }

            if (DtBases != null)
            {
                DataRow[] rows =
                this.DtBases.Select(string.Format("Nombre_base = '{0}'", this.txtNombreBD.Text));
                if (rows.Length > 0)
                {
                    Mensajes.MensajeInformacion("El nombre de la base de datos ya existe", "Entendido");
                    return;
                }

                rows =
                     this.DtBases.Select(string.Format("Alias_base = '{0}'", this.txtAlias.Text));
                if (rows.Length > 0)
                {
                    Mensajes.MensajeInformacion("El alias de la base de datos ya existe", "Entendido");
                    return;
                }
            }

            EBases_clientes eBase = new EBases_clientes
            {
                Nombre_base = this.txtNombreBD.Text,
                Alias_base = this.txtAlias.Text
            };

            string rpta = EBases_clientes.InsertarBase(eBase, out int id_base);
            if (rpta.Equals("OK"))
            {
                Mensajes.MensajeOkForm("Se insertó la base de datos correctamente, reinicie la aplicación");
                this.Close();
            }
            else
                Mensajes.MensajeInformacion("Hubo un error al insertar la base de datos, detalles: " + rpta, "Entendido");
        }

        private void BtnNuevaBase_Click(object sender, EventArgs e)
        {
            this.gbNuevaBase.Visible = true;   
        }

        private void BtnGuardarNombre_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config1.AppSettings.Settings["Nombre_empresa"].Value = this.txtNombreEmpresa.Text;
                config1.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
                Mensajes.MensajeInformacion("Se actualizó correctamente el nombre de la empresa, reincie la aplicación para que los cambios se apliquen", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardarNombre_Click",
                    "Hubo un error al guardar el nombre de la empresa", ex.Message);
            }

        }

        private void ObtenerTiempoPredeterminado()
        {
            string time = Convert.ToString(ConfigurationManager.AppSettings["tiempoPredeterminado"]);
            if (int.TryParse(time, out int tiempo))
                this.numericUpDown1.Value = tiempo;
            else
                Mensajes.MensajeInformacion("No se pudo obtener el tiempo prederminado, el valor por defecto es 5 min", "Entendido");
        }

        private void ObtenerBases()
        {
            this.DtBases = EBases_clientes.BuscarBases("COMPLETO", "", out string rpta);
            if (DtBases != null)
            {
                this.listaBases.DataSource = DtBases;
                this.listaBases.DisplayMember = "Nombre_base";
                this.listaBases.ValueMember = "Id_base";
            }
        }

        private void ObtenerNombreEmpresa()
        {
            this.txtNombreEmpresa.Text = Convert.ToString(ConfigurationManager.AppSettings["Nombre_empresa"]);
        }

        private void FrmPersonalizarAplicacion_Load(object sender, EventArgs e)
        {
            this.ObtenerNombreEmpresa();
            this.ObtenerBases();
            this.ObtenerTiempoPredeterminado();
        }

        private DataTable _dtBases;

        public DataTable DtBases { get => _dtBases; set => _dtBases = value; }
    }
}
