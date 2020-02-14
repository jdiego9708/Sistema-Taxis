using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsBD
{
    public partial class FrmConexionBD : Form
    {
        public FrmConexionBD()
        {
            InitializeComponent();
            this.Load += FrmConexionBD_Load;
            this.listaBD.SelectedIndexChanged += ListaBD_SelectedIndexChanged;
            this.btnSeleccionarBD.Click += BtnSeleccionarBD_Click;
            this.btnGuardarBD.Click += BtnGuardarBD_Click;
            this.txtBDPrincipal.DoubleClick += TxtBDPrincipal_DoubleClick;
            this.txtDestino.Click += TxtDestino_Click;
            this.btnGenerarBackup.Click += BtnGenerarBackup_Click;
            this.timer1.Tick += Timer1_Tick;
        }

        #region BACKUP BD
        bool backupFinish = true;
        int conteoBackup = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (conteoBackup < 10)
            {
                switch (conteoBackup)
                {
                    case 3:
                        MensajeEspera.ChangeMensaje("Recuperando base de datos...");
                        break;
                    case 5:
                        MensajeEspera.ChangeMensaje("Recuperando tablas...");
                        break;
                    case 8:
                        MensajeEspera.ChangeMensaje("Recuperando información...");
                        break;
                    case 10:
                        MensajeEspera.ChangeMensaje("Finalizando copia...");
                        break;
                }
                conteoBackup += 1;
            }
            else
            {
                if (backupFinish)
                {
                    MensajeEspera.CloseForm();
                    this.CerrarTimer();
                }
            }
        }

        private void CerrarTimer()
        {
            timer1.Stop();
            Mensajes.MensajeOkForm("¡Se guardó correctamente la copia de seguridad!");
        }

        private void BtnGenerarBackup_Click(object sender, EventArgs e)
        {
            backupFinish = false;
            if (this.txtDestino.Text.Equals("") | this.txtDestino.Text.Equals("Seleccionar destino") |
                this.txtOrigen.Text.Equals("") | this.txtOrigen.Text.Equals("NO DISPONIBLE"))
            {
                Mensajes.MensajeInformacion("Por favor verifique la dirección de destino y la dirección de origen", "Entendido");
                backupFinish = true;
                return;
            }

            if (this.txtNombreArchivo.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("Por favor verifique el nombre del archivo", "Entendido");
                backupFinish = true;
                this.txtNombreArchivo.Focus();
                return;
            }

            MensajeEspera.ShowWait("Cargando...");
            this.timer1.Start();
            string rpta = "OK";
            string rutaDestino = this.txtDestino.Text;
            string rutaOrigen = this.txtOrigen.Text;
            string nombreArchivo = this.txtNombreArchivo.Text;
            try
            {
                bool insert = true;
                if (Path.Combine(rutaDestino, nombreArchivo).Equals(rutaOrigen))
                {
                    insert = false;
                }

                if (insert)
                {
                    string extension = "";
                    int posicionExtension =
                        rutaOrigen.LastIndexOf('.', rutaOrigen.Length - 1);
                    if (posicionExtension > 0)
                    {
                        extension = rutaOrigen.Substring(posicionExtension);
                        nombreArchivo = nombreArchivo + extension;
                        DirectoryInfo DirectoryInfo = new DirectoryInfo(rutaDestino);
                        DirectoryInfo directoryOrigen = new DirectoryInfo(rutaOrigen);
                        string destino = Path.Combine(DirectoryInfo.ToString(), nombreArchivo);
                        string origen = Path.Combine("\\", directoryOrigen.ToString());
                        File.Copy(origen, destino, true);
                        this.backupFinish = true;                       
                    }
                    else
                    {
                        throw new Exception("No se encontró la extensión del archivo de base de datos");
                    }
                }
            }
            catch (Exception ex)
            {
                backupFinish = true;
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGenerarBackup_Click",
                    "Hubo un error al generar el backup", ex.Message);
                rpta = ex.Message;
            }
        }
        private void TxtDestino_Click(object sender, EventArgs e)
        {
            //OpenFileDialog archivo = new OpenFileDialog();
            //archivo.ValidateNames = false;
            //archivo.CheckFileExists = false;
            //archivo.CheckPathExists = true;
            //DialogResult result = archivo.ShowDialog();
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string folderName = fbd.SelectedPath;
                    this.txtDestino.Text = folderName;
                }
                else
                {
                    this.txtDestino.Text = "";
                }
            }
        
        }

        private void ObtenerOrigen(string dataSource)
        {
            try
            {
                int posicionIgual = dataSource.IndexOf("=");
                if (posicionIgual > 0)
                {
                    string origen = dataSource.Substring(posicionIgual + 1);
                    this.txtOrigen.Text = origen;

                    string destinoGuardado = Convert.ToString(ConfigurationManager.AppSettings["DestinoBackup"]);
                    if (destinoGuardado.Equals(""))
                        this.txtDestino.Text = "Seleccionar destino";
                    else
                    {
                        this.txtDestino.Text = destinoGuardado;
                        this.chkRecordarDestino.Checked = true;
                    }

                }
                else
                    throw new Exception("No se encontró el símbolo '=', por favor verificar el origen de la base de datos");
            } 
            catch (Exception ex)
            {
                this.txtOrigen.Text = "NO DISPONIBLE";
                Mensajes.MensajeErrorCompleto(this.Name, "ObtenerOrigen(string dataSource)",
                    "Hubo un error al obtener el origen de la base de datos", ex.Message);
            }

        }
        #endregion

        #region BASE DE DATOS
        private void TxtBDPrincipal_DoubleClick(object sender, EventArgs e)
        {
            if (this.txtBDPrincipal.ReadOnly)
                this.txtBDPrincipal.ReadOnly = false;
            else
                this.txtBDPrincipal.ReadOnly = true;
        }

        private void BtnGuardarBD_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtBDPrincipal.Text.Equals(""))
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings[this.listaBD.Text].ConnectionString = this.txtBDPrincipal.Text;
                    config.Save(ConfigurationSaveMode.Modified, true);
                    ConfigurationManager.RefreshSection("connectionStrings");

                    if (this.chkConnect.Checked)
                    {
                        Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config1.AppSettings.Settings["nameBDConnection"].Value = this.listaBD.Text;
                        config1.Save(ConfigurationSaveMode.Modified, true);
                        ConfigurationManager.RefreshSection("appSettings");
                    }

                    Mensajes.MensajeInformacion("Se actualizó correctamente el archivo de base de datos, por favor reiniciar la aplicación", "Entendido");

                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardarBD_Click",
                    "Hubo un error al guardar la nueva ruta de base de datos", ex.Message);
            }
        }

        private void BtnSeleccionarBD_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "Documentos válidos|*.db";
            DialogResult result = archivo.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txtBDPrincipal.Text = "Data Source=" + archivo.FileName;
            }
        }

        private void ListaBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Text.Equals(""))
            {
                this.ObtenerCadenaConexionPorNombre(cb.Text);
            }
        }

        private void ObtenerCadenaConexionPorNombre(string Nombre_cadena)
        {
            Configuration appconfig =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringSettings connStringSettings = appconfig.ConnectionStrings.ConnectionStrings[Nombre_cadena];

            string cadena = Convert.ToString(connStringSettings);
            this.txtBDPrincipal.Text = cadena;
        }

        private List<string> ObtenerListaCadenasConexion()
        {
            List<string> cns = new List<string>();
            Configuration appconfig =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (ConnectionStringSettings cn in appconfig.ConnectionStrings.ConnectionStrings)
            {
                cns.Add(cn.Name);
            }
            return cns;
        }

        #endregion

        private void FrmConexionBD_Load(object sender, EventArgs e)
        {
            this.listaBD.DataSource = this.ObtenerListaCadenasConexion();
            this.listaBD.Text = Convert.ToString(ConfigurationManager.AppSettings["nameBDConnection"]);
            this.ObtenerOrigen(this.txtBDPrincipal.Text);
            this.txtNombreArchivo.Text = "Backup - " + DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}
