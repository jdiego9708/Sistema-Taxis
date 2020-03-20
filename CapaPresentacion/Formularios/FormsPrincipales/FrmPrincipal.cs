using System;
using System.Windows.Forms;

using CapaPresentacion.Formularios.FormsCarreras;

using CapaPresentacion.Formularios.FormsClientes;
using CapaPresentacion.Formularios.FormsEmpleados;
using CapaPresentacion.Formularios.FormsPrincipales.Menus;
using CapaPresentacion.Formularios.FormsVehiculos;
using CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones;
using CapaEntidades;
using CapaPresentacion.Formularios.FormsReportes;
using System.Configuration;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using CapaPresentacion.Formularios.FormsEstadosVehiculos;

namespace CapaPresentacion.Formularios.FormsPrincipales
{
    public partial class FrmPrincipal : Form
    {
        PoperContainer container;
        private readonly KeyboardHookListener m_KeyboardHookManager;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.Load += FrmPrincipal_Load;
            this.btnVehiculos.Click += BtnVehiculos_Click;
            this.btnClientes.Click += BtnClientes_Click;
            this.btnAdministracion.Click += BtnAdministracion_Click;
            m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            m_KeyboardHookManager.Enabled = true;
            m_KeyboardHookManager.KeyDown += M_KeyboardHookManager_KeyDown;

            this.FormClosed += FrmPrincipal_FormClosed;
        }

        private void M_KeyboardHookManager_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyData == (int)Keys.F5)
            {
                //if (frmNuevoCliente == null)
                //{
                frmNuevoCliente = new FrmNuevoCliente
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                //}
                frmNuevoCliente.Show();
                frmNuevoCliente.gbCodigo.Focus();
                return;
            }

            if ((int)e.KeyData == (int)Keys.F6)
            {
                //if (frmNuevoVehiculo == null)
                //{
                frmNuevoVehiculo = new FrmNuevoVehiculo
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmNuevoVehiculo.gbCodigo.Focus();
                //}
                frmNuevoVehiculo.Show();
                return;
            }
        }

        FrmNuevoCliente frmNuevoCliente;
        FrmNuevoVehiculo frmNuevoVehiculo;

        private void FrmNuevoVehiculo_OnVehiculoAddSuccess(object sender, EventArgs e)
        {
            if (this.frmNuevoVehiculo != null)
                this.frmNuevoVehiculo.Close();
        }

        private void FrmNuevoCliente_OnClienteAddSuccess(object sender, EventArgs e)
        {
            if (this.frmNuevoCliente != null)
                this.frmNuevoVehiculo.Close();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnAdministracion_Click(object sender, EventArgs e)
        {
            MenuAdministracion menuAdministracion = new MenuAdministracion();
            menuAdministracion.btnAgregarEmpleado.Click += BtnAgregarEmpleado_Click;
            menuAdministracion.btnEditarEmpleado.Click += BtnEditarEmpleado_Click;
            menuAdministracion.btnObservarempleados.Click += BtnObservarempleados_Click;
            menuAdministracion.btnConfiguracionAvanzada.Click += BtnConfiguracionAvanzada_Click;
            menuAdministracion.btnReporteCarreras.Click += BtnReporteCarreras_Click;
            container = new PoperContainer(menuAdministracion);
            container.Show(btnAdministracion);
        }

        private void BtnReporteCarreras_Click(object sender, EventArgs e)
        {
            FrmReportes frmReporte = new FrmReportes
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmReporte.ShowDialog();
        }

        private void BtnConfiguracionAvanzada_Click(object sender, EventArgs e)
        {
            FrmConfiguracionAplicacion frmConfiguracionAplicacion = new FrmConfiguracionAplicacion
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmConfiguracionAplicacion.ShowDialog();
        }

        private void BtnObservarempleados_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarEmpleados frm = new FrmObservarEmpleados
                {
                    TopLevel = false
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarempleados_Click",
                    "Hubo un error con el botón observar empleados", ex.Message);
            }
        }

        private void BtnEditarEmpleado_Click(object sender, EventArgs e)
        {
            FrmObservarEmpleados frmObservarEmpleados = new FrmObservarEmpleados
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarEmpleados.OnDgvDoubleClick += FrmObservarEmpleados_OnDgvDoubleClick;
            frmObservarEmpleados.ShowDialog();
        }

        private void FrmObservarEmpleados_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                EEmpleados eEmpleado = (EEmpleados)sender;
                FrmNuevoEmpleado frm = new FrmNuevoEmpleado
                {
                    TopLevel = false,
                    IsEditar = true
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                frm.AsignarDatos(eEmpleado);
                if (FormComprobado != null)
                {
                    FormComprobado.WindowState = FormWindowState.Normal;
                    FormComprobado.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarEmpleados_OnDgvDoubleClick",
                    "Hubo un error con el botón editar empleado", ex.Message);
            }
        }

        private void BtnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoEmpleado frm = new FrmNuevoEmpleado
                {
                    TopLevel = false
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAgregarEmpleado_Click",
                    "Hubo un error con el botón agregar empleado", ex.Message);
            }
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            MenuClientes menuClientes = new MenuClientes();
            menuClientes.btnAgregarCliente.Click += BtnAgregarCliente_Click;
            menuClientes.btnEditarCliente.Click += BtnEditarCliente_Click;
            menuClientes.btnObservarClientes.Click += BtnObservarClientes_Click;
            menuClientes.btnInactivarClientes.Click += BtnInactivarClientes_Click;
            container = new PoperContainer(menuClientes);
            container.Show(btnClientes);
        }

        private void BtnInactivarClientes_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frmBuscarClientes = new FrmBuscarClientes
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Inactivar un cliente"
            };
            frmBuscarClientes.OnDgvDoubleClick += FrmBuscarClientes_OnDgvDoubleClick1;
            frmBuscarClientes.ShowDialog();
        }

        private void FrmBuscarClientes_OnDgvDoubleClick1(object sender, EventArgs e)
        {
            Mensajes.MensajePregunta("¿Está seguro que desea inactivar este cliente?",
                "Inactivar", "Cancelar", out DialogResult dialog);
            if (dialog == DialogResult.Yes)
            {
                EClientes eCliente = (EClientes)sender;
                eCliente.Estado_cliente = "INACTIVO";
                string rpta =
                    EClientes.EditarCliente(eCliente, eCliente.Id_cliente);
                if (rpta.Equals("OK"))
                {
                    Mensajes.MensajeOkForm("¡Se inactivó el cliente correctamente!");
                }
                else
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "FrmBuscarClientes_OnDgvDoubleClick1",
                        "Hubo un error al inactivar un cliente", rpta);
                }
            }
        }

        private void BtnObservarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBuscarClientes frm = new FrmBuscarClientes
                {
                    TopLevel = false
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarClientes_Click",
                    "Hubo un error con el botón buscar clientes", ex.Message);
            }
        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frmBuscarClientes = new FrmBuscarClientes
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmBuscarClientes.OnDgvDoubleClick += FrmBuscarClientes_OnDgvDoubleClick;
            frmBuscarClientes.ShowDialog();
        }

        private void FrmBuscarClientes_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                EClientes eCliente = (EClientes)sender;
                FrmNuevoCliente frm = new FrmNuevoCliente
                {
                    TopLevel = false,
                    IsEditar = true
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                frm.AsignarDatos(eCliente);
                if (FormComprobado != null)
                {
                    FormComprobado.WindowState = FormWindowState.Normal;
                    FormComprobado.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmBuscarClientes_OnDgvDoubleClick",
                    "Hubo un error con el botón editar cliente", ex.Message);
            }
        }

        private void BtnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoCliente frm = new FrmNuevoCliente
                {
                    TopLevel = false
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAgregarCliente_Click",
                    "Hubo un error con el botón nuevo cliente", ex.Message);
            }
        }

        #region VEHICULOS
        private void BtnVehiculos_Click(object sender, EventArgs e)
        {
            MenuVehiculos menuVehiculos = new MenuVehiculos();
            menuVehiculos.btnAgregarVehiculo.Click += BtnAgregarVehiculo_Click;
            menuVehiculos.btnEditarVehiculo.Click += BtnEditarVehiculo_Click;
            menuVehiculos.btnObservarVehiculo.Click += BtnObservarVehiculo_Click;
            menuVehiculos.btnInactivarVehiculo.Click += BtnInactivarVehiculo_Click;
            menuVehiculos.btnCarreras.Click += BtnCarreras_Click;
            menuVehiculos.btnEstados.Click += BtnEstados_Click;
            container = new PoperContainer(menuVehiculos);
            container.Show(btnVehiculos);
        }

        private void BtnEstados_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoEstado frm = new FrmNuevoEstado
                {
                    TopLevel = false
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnEstados_Click",
                    "Hubo un error con el botón nuevo estado", ex.Message);
            }
        }

        private void BtnCarreras_Click(object sender, EventArgs e)
        {
            try
            {
                DatosInicioSesion datosInicioSesion = DatosInicioSesion.GetInstancia();

                if (datosInicioSesion.EEmpleado != null)
                {
                    FrmCarreras frm = new FrmCarreras
                    {
                        TopLevel = false,
                        EEmpleado = datosInicioSesion.EEmpleado
                    };
                    frm.OnTurnoTerminado += Frm_OnTurnoTerminado;
                    Form FormComprobado = this.ComprobarExistencia(frm);
                    if (FormComprobado != null)
                    {
                        frm.WindowState = FormWindowState.Normal;
                        frm.Activate();
                    }
                    else
                    {
                        this.panelPrincipal.Controls.Add(frm);
                        this.panelPrincipal.Tag = frm;
                        frm.Show();
                    }
                    frm.BringToFront();
                }
                else
                    Mensajes.MensajeInformacion("No se encontró la información del empleado que inicia sesión", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnVehiculos_Click",
                    "Hubo un error con el botón observar vehiculos", ex.Message);
            }
        }

        private void BtnInactivarVehiculo_Click(object sender, EventArgs e)
        {
            FrmObservarVehiculos FrmObservarVehiculos = new FrmObservarVehiculos
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Inactivar un vehículo"
            };
            FrmObservarVehiculos.OnDgvDoubleClick += FrmObservarVehiculos_OnDgvDoubleClickInactivar;
            FrmObservarVehiculos.ShowDialog();
        }

        private void FrmObservarVehiculos_OnDgvDoubleClickInactivar(object sender, EventArgs e)
        {
            Mensajes.MensajePregunta("¿Está seguro que desea inactivar este vehículo?",
               "Inactivar", "Cancelar", out DialogResult dialog);
            if (dialog == DialogResult.Yes)
            {
                EVehiculos eVehiculo = (EVehiculos)sender;
                eVehiculo.Estado_vehiculo = "INACTIVO";
                string rpta =
                    EVehiculos.EditarVehiculo(eVehiculo, eVehiculo.Id_vehiculo);
                if (rpta.Equals("OK"))
                {
                    Mensajes.MensajeOkForm("¡Se inactivó el vehículo correctamente!");
                }
                else
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarVehiculos_OnDgvDoubleClickInactivar",
                        "Hubo un error al inactivar un vehículo", rpta);
                }
            }
        }

        private void BtnObservarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmObservarVehiculos frm = new FrmObservarVehiculos
                {
                    TopLevel = false
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnObservarVehiculo_Click",
                    "Hubo un error con el botón observar vehiculos", ex.Message);
            }
        }

        private void BtnEditarVehiculo_Click(object sender, EventArgs e)
        {
            FrmObservarVehiculos FrmObservarVehiculos = new FrmObservarVehiculos
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmObservarVehiculos.OnDgvDoubleClick += FrmObservarVehiculos_OnDgvDoubleClick;
            FrmObservarVehiculos.ShowDialog();
        }

        private void FrmObservarVehiculos_OnDgvDoubleClick(object sender, EventArgs e)
        {
            try
            {
                EVehiculos eVehiculo = (EVehiculos)sender;
                FrmNuevoVehiculo frm = new FrmNuevoVehiculo
                {
                    TopLevel = false,
                    IsEditar = true
                };

                Form FormComprobado = this.ComprobarExistencia(frm);
                frm.AsignarDatos(eVehiculo);
                if (FormComprobado != null)
                {
                    FormComprobado.WindowState = FormWindowState.Normal;
                    FormComprobado.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmObservarVehiculos_OnDgvDoubleClick",
                    "Hubo un error con el botón editar vehículo", ex.Message);
            }
        }

        private void BtnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoVehiculo frm = new FrmNuevoVehiculo
                {
                    TopLevel = false
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnAgregarVehiculo_Click",
                    "Hubo un error con el botón agregar vehiculos", ex.Message);
            }
        }

        #endregion

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.lblNombreEmpresa.Text = Convert.ToString(ConfigurationManager.AppSettings["Nombre_empresa"]);
            DatosInicioSesion datos = DatosInicioSesion.GetInstancia();
            if (datos.EEmpleado.Tipo_empleado.Equals("SECRETARIO"))
                this.btnAdministracion.Enabled = false;
            try
            {
                FrmCarreras frm = new FrmCarreras
                {
                    TopLevel = false,
                    EEmpleado = datos.EEmpleado
                };
                frm.OnTurnoTerminado += Frm_OnTurnoTerminado;
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panelPrincipal.Controls.Add(frm);
                    this.panelPrincipal.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();

            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnVehiculos_Click",
                    "Hubo un error con el botón observar vehiculos", ex.Message);
            }
        }

        private void Frm_OnTurnoTerminado(object sender, EventArgs e)
        {
            FrmIniciarSesion frmIniciarSesion = new FrmIniciarSesion();
            frmIniciarSesion.Show();
            this.Hide();
        }

        private Form ComprobarExistencia(Form form)
        {
            if (container != null)
                container.Close();

            Form frmDevolver = null;
            foreach (Form frm in this.panelPrincipal.Controls)
            {
                if (frm.Name.Equals(form.Name))
                {
                    frmDevolver = frm;
                    break;
                }

            }
            return frmDevolver;
        }
    }
}
