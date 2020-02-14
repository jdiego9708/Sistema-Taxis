using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsBD;
using CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsCorreos;
using CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsLicencias;
using CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsPersonalizacion;
using CapaPresentacion.Formularios.FormsClientes;
using CapaPresentacion.Formularios.FormsVehiculos;

namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones
{
    public partial class FrmConfiguracionAplicacion : Form
    {
        public FrmConfiguracionAplicacion()
        {
            InitializeComponent();
            this.btnLicencias.Click += BtnLicencias_Click;
            this.btnBaseDatos.Click += BtnBaseDatos_Click;
            this.Load += FrmConfiguracionAplicacion_Load;
            this.btnCargarClientes.Click += BtnCargarClientes_Click;
            this.btnCargarVehiculos.Click += BtnCargarVehiculos_Click;
            this.btnPersonalizar.Click += BtnPersonalizar_Click;
            this.btnEnvioCorreos.Click += BtnEnvioCorreos_Click;
        }

        private void BtnEnvioCorreos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                FrmCorreos frm = new FrmCorreos
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnEnvioCorreos_Click",
                    "Hubo un error con el botón CORREOS", ex.Message);
            }
        }

        private void BtnPersonalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                FrmPersonalizarAplicacion frm = new FrmPersonalizarAplicacion
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnPersonalizar_Click",
                    "Hubo un error con el botón personalizar aplicación", ex.Message);
            }
        }

        private void BtnCargarVehiculos_Click(object sender, EventArgs e)
        {
            FrmCargarVehiculos frmCargarVehiculos = new FrmCargarVehiculos();
            frmCargarVehiculos.ShowDialog();
        }

        private void BtnCargarClientes_Click(object sender, EventArgs e)
        {
            FrmCargarClientes frmCargarClientes = new FrmCargarClientes();
            frmCargarClientes.ShowDialog();
        }

        private void BtnLicencias_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                FrmGestionarLicencias frm = new FrmGestionarLicencias
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnLicencias_Click",
                    "Hubo un error con el botón licencias", ex.Message);
            }
        }

        private void FrmConfiguracionAplicacion_Load(object sender, EventArgs e)
        {
            this.btnBaseDatos.PerformClick();
        }

        private void BtnBaseDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panel1.Controls.Count > 0)
                    this.panel1.Controls.Clear();

                FrmConexionBD frm = new FrmConexionBD
                {
                    TopLevel = false,
                    StartPosition = FormStartPosition.CenterParent,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                this.panel1.Controls.Add(frm);
                this.panel1.Tag = frm;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnBaseDatos_Click",
                    "Hubo un error con el botón base de datos", ex.Message);
            }
        }

        private Form ComprobarExistencia(Form form)
        {
            Form frmDevolver = null;
            foreach (Control control in this.panel1.Controls)
            {
                if (control is Form frm)
                {
                    if (frm.Name.Equals(form.Name))
                    {
                        frmDevolver = frm;
                        break;
                    }
                }
            }

            return frmDevolver;
        }
    }
}
