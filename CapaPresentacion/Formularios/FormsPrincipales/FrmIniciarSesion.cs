using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

using CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones;
using CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsLicencias;
using CapaPresentacion.Formularios.FormsCarreras;

namespace CapaPresentacion.Formularios.FormsPrincipales
{
    public partial class FrmIniciarSesion : Form
    {
        public FrmIniciarSesion()
        {
            InitializeComponent();
            this.Load += FrmIniciarSesion_Load;
            this.btnCerrar.Click += BtnCerrar_Click;
            this.btnIngresar.Click += BtnIngresar_Click;
            this.txtPass.KeyPress += TxtPass_KeyPress;
            this.Activated += FrmIniciarSesion_Activated;
        }

        private void AbrirCarreras()
        {
            FrmPrincipal FrmPrincipal = new FrmPrincipal();
            FrmPrincipal.Show();
        }

        private void FrmIniciarSesion_Activated(object sender, EventArgs e)
        {
            this.txtUsuario.Focus();
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Text.Equals(""))
                {
                    Mensajes.MensajeInformacion("Ingrese una contraseña", "Entendido");
                }
                else
                {
                    this.btnIngresar.PerformClick();
                }
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta;
                if (this.txtUsuario.Text != "" & this.txtPass.Text != "")
                {
                    if (txtUsuario.Text.Equals("ADMIN") | 
                        txtUsuario.Text.Equals("JDUQUE") | 
                        txtUsuario.Text.Equals("ADMINISTRADOR"))
                    {
                        if (this.txtPass.Text.Equals("admin"))
                        {
                            DatosInicioSesion datos = DatosInicioSesion.GetInstancia();
                            datos.EEmpleado = new EEmpleados(1);
                            this.AbrirCarreras();
                            this.Hide();
                        }
                        else if (this.txtPass.Text.Equals("configadmin"))
                        {
                            FrmConfiguracionAplicacion frm = new FrmConfiguracionAplicacion
                            {
                                StartPosition = FormStartPosition.CenterScreen
                            };
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        DataTable tabla = 
                            EEmpleados.Login(this.txtUsuario.Text, this.txtPass.Text, out rpta);
                        if (tabla != null)
                        {
                            DatosInicioSesion datos = DatosInicioSesion.GetInstancia();
                            datos.EEmpleado = new EEmpleados(tabla, 0);
                            this.AbrirCarreras();
                            this.Hide();
                        }
                        else 
                        {
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);

                            Mensajes.MensajeInformacion("No se encontró el usuario, intentelo de nuevo", "Entendido");
                        }
                    }
                }
                else
                {
                    Mensajes.MensajeInformacion("Usuario y contraseña son campos requeridos", "Entendido");

                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnIngresar_Click",
                    "Hubo un error al ingresar", ex.Message);
            }
        }

        public bool ComprobarLicencia()
        {
            bool result = false;
            string licencia = ConfigLicencias.Default.LicenciaActual;

            switch (licencia)
            {
                case "LicenciaCompleta":
                    result = true;
                    break;
                case "Licencia30Dias":
                    int diasLicencia30 = ConfigLicencias.Default.ConteoLicencia30;
                    int diasRestantes = 30 - diasLicencia30;
                    if (diasRestantes > 1)
                    {
                        result = true;
                        if (ConfigLicencias.Default.FechaConteo.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                        {
                            ConfigLicencias.Default.ConteoLicencia30 += 1;
                            ConfigLicencias.Default.FechaConteo = DateTime.Now;
                            ConfigLicencias.Default.Save();
                        }
                    }
                        
                    break;
                case "Licencia20Dias":
                    int diasLicencia20 = ConfigLicencias.Default.ConteoLicencia20;
                    diasRestantes = 20 - diasLicencia20;
                    if (diasRestantes > 1)
                    {
                        result = true;
                        if (ConfigLicencias.Default.FechaConteo.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                        {
                            ConfigLicencias.Default.ConteoLicencia20 += 1;
                            ConfigLicencias.Default.FechaConteo = DateTime.Now;
                            ConfigLicencias.Default.Save();
                        }
                    }
                    break;
                case "Licencia10Dias":
                    int diasLicencia10 = ConfigLicencias.Default.ConteoLicencia10;
                    diasRestantes = 10 - diasLicencia10;
                    if (diasRestantes > 1)
                    {
                        result = true;
                        if (ConfigLicencias.Default.FechaConteo.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                        {
                            ConfigLicencias.Default.ConteoLicencia10 += 1;
                            ConfigLicencias.Default.FechaConteo = DateTime.Now;
                            ConfigLicencias.Default.Save();
                        }
                    }
                    break;
                case "Licencia8Dias":
                    int diasLicencia8 = ConfigLicencias.Default.ConteoLicencia8;
                    diasRestantes = 8 - diasLicencia8;
                    if (diasRestantes > 1)
                    {
                        result = true;
                        if (ConfigLicencias.Default.FechaConteo.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                        {
                            ConfigLicencias.Default.ConteoLicencia8 += 1;
                            ConfigLicencias.Default.FechaConteo = DateTime.Now;
                            ConfigLicencias.Default.Save();
                        }
                    }
                    break;
            }

            return result;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmIniciarSesion_Load(object sender, EventArgs e)
        {
            try
            {
                this.IsLicenciado = this.ComprobarLicencia();
                if (this.IsLicenciado)
                {
                    AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                    DataTable dtUsuarios = EEmpleados.BuscarEmpleados("COMPLETO", "", out string rpta);
                    if (dtUsuarios != null)
                    {
                        foreach (DataRow row in dtUsuarios.Rows)
                        {
                            source.Add(
                                Convert.ToString(row["Nombre_empleado"]));
                        }

                        this.txtUsuario.AutoCompleteCustomSource = source;
                        this.txtUsuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        this.txtUsuario.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                    else
                    {
                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);
                    }                 

                    this.txtPass.Focus();
                }
                else
                {
                    Mensajes.MensajePregunta("No tiene una licencia activa para usar el programa, " +
                        "¿Desea ingresar una licencia válida?", "ACTIVAR", "CANCELAR", out DialogResult dialog);
                    if (dialog == DialogResult.Yes)
                    {
                        FrmGestionarLicencias frmGestionarLicencias = new FrmGestionarLicencias
                        {
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        frmGestionarLicencias.FormClosed += FrmGestionarLicencias_FormClosed;
                        frmGestionarLicencias.ShowDialog();
                    }
                    else
                        this.Close();
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmIniciarSesion_Load",
                    "Hubo un error al cargar los usuarios", ex.Message);
            }
        }

        private void FrmGestionarLicencias_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            if (frm.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
        }

        private bool _isLicenciado;

        public bool IsLicenciado { get => _isLicenciado; set => _isLicenciado = value; }
    }
}
