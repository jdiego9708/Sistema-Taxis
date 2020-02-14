using CapaEntidades;
using CapaPresentacion.Formularios.FormsClientes;
using CapaPresentacion.Formularios.FormsVehiculos;
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
    public partial class FrmNuevaCarrera : Form
    {
        public FrmNuevaCarrera()
        {
            InitializeComponent();
            this.btnSeleccionarCliente.Click += BtnSeleccionarCliente_Click;
            this.btnSeleccionarVehiculo.Click += BtnSeleccionarVehiculo_Click;
            this.btnAsignarCarrera.Click += BtnAsignarCarrera_Click;
            this.Load += FrmNuevaCarrera_Load;

            this.tiempoLlegada.KeyPress += TiempoLlegada_KeyPress;
            this.Activated += FrmNuevaCarrera_Activated;
        }

        private void FrmNuevaCarrera_Activated(object sender, EventArgs e)
        {
            this.tiempoLlegada.Focus();
            this.tiempoLlegada.Select(0, this.tiempoLlegada.Text.Length);
        }

        private void TiempoLlegada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.btnAsignarCarrera.PerformClick();
            }
        }

        private void FrmNuevaCarrera_Load(object sender, EventArgs e)
        {
            this.tiempoLlegada.Focus();
            this.tiempoLlegada.Select(0, this.tiempoLlegada.Text.Length);
        }

        EDireccion_clientes EDireccion;
        EClientes ECliente;
        EVehiculos EVehiculo;

        public event EventHandler OnCarreraAsignada;

        public void AsignarDatos(EVehiculos eVehiculo, EDireccion_clientes eDireccion_Clientes)
        {
            //Abrir vehículo
            if (this.gbVehiculo.Controls.Count > 0)
                this.gbVehiculo.Controls.Clear();

            this.EVehiculo = eVehiculo;
            FrmVehiculoCarrera FrmVehiculoCarrera = new FrmVehiculoCarrera
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            FrmVehiculoCarrera.AsignarDatos(eVehiculo);
            this.gbVehiculo.Controls.Add(FrmVehiculoCarrera);
            FrmVehiculoCarrera.Show();

            //Abrir cliente
            if (this.gbCliente.Controls.Count > 0)
                this.gbCliente.Controls.Clear();

            this.EDireccion = eDireccion_Clientes;
            this.ECliente = eDireccion_Clientes.ECliente;
            FrmClienteCarrera frmClienteCarrera = new FrmClienteCarrera
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            frmClienteCarrera.AsignarDatos(eDireccion_Clientes.ECliente, eDireccion_Clientes);
            this.gbCliente.Controls.Add(frmClienteCarrera);
            frmClienteCarrera.Show();
        }

        private void BtnAsignarCarrera_Click(object sender, EventArgs e)
        {
            if (this.EDireccion != null && this.ECliente != null && this.EVehiculo != null)
            {
                if (int.TryParse(this.tiempoLlegada.Value.ToString(), out int tiempo_llegada))
                {
                    MensajeEspera.ShowWait("Asignando...");
                    ECarreras eCarrera = new ECarreras
                    {
                        ECliente = this.ECliente,
                        EDireccion = this.EDireccion,
                        EVehiculo = this.EVehiculo,
                        EEmpleado = new EEmpleados { Id_empleado = 1 },
                        Fecha_carrera = DateTime.Now,
                        Hora_carrera = DateTime.Now.ToString("HH:mm:ss"),
                        Lugar_ubicacion = this.txtLugarUbicacion.Text,
                        Tiempo_llegada = tiempo_llegada,
                        Estado_carrera = "PENDIENTE",
                        Observaciones = ""
                    };

                    string rpta = ECarreras.InsertarCarrera(eCarrera, out int id_carrera);
                    if (rpta.Equals("OK"))
                    {
                        MensajeEspera.CloseForm();
                        //Mensajes.MensajeInformacion("La carrera fue aprobada con el siguiente código: " + id_carrera.ToString(),
                        //    "Entendido");
                        eCarrera.Id_carrera = id_carrera;
                        this.OnCarreraAsignada?.Invoke(eCarrera, e);
                        this.Close();
                    }
                    else
                        throw new Exception(rpta);

                }             
            }
            else
            {
                Mensajes.MensajeInformacion("Verifique los datos seleccionados", "Entendido");
            }
        }

        private void BtnSeleccionarVehiculo_Click(object sender, EventArgs e)
        {
            FrmObservarVehiculos frmObservarVehiculos = new FrmObservarVehiculos
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarVehiculos.OnDgvDoubleClick += FrmObservarVehiculos_OnDgvDoubleClick;
            frmObservarVehiculos.ShowDialog();
        }

        private void FrmObservarVehiculos_OnDgvDoubleClick(object sender, EventArgs e)
        {
            EVehiculos eVehiculo = (EVehiculos)sender;

            if (this.gbVehiculo.Controls.Count > 0)
                this.gbVehiculo.Controls.Clear();

            this.EVehiculo = eVehiculo;
            FrmVehiculoCarrera FrmVehiculoCarrera = new FrmVehiculoCarrera
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            FrmVehiculoCarrera.AsignarDatos(eVehiculo);
            this.gbVehiculo.Controls.Add(FrmVehiculoCarrera);
            FrmVehiculoCarrera.Show();
        }

        private void BtnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frmBuscarClientes = new FrmBuscarClientes
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmBuscarClientes.OnBtnDireccionNext += FrmBuscarClientes_OnBtnDireccionNext;
            frmBuscarClientes.ShowDialog();
        }

        private void FrmBuscarClientes_OnBtnDireccionNext(object sender, EventArgs e)
        {
            EDireccion_clientes eDireccion_Clientes = (EDireccion_clientes)sender;

            if (this.gbCliente.Controls.Count > 0)
                this.gbCliente.Controls.Clear();

            this.EDireccion = eDireccion_Clientes;
            this.ECliente = eDireccion_Clientes.ECliente;
            FrmClienteCarrera frmClienteCarrera = new FrmClienteCarrera
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            frmClienteCarrera.AsignarDatos(eDireccion_Clientes.ECliente, eDireccion_Clientes);
            this.gbCliente.Controls.Add(frmClienteCarrera);
            frmClienteCarrera.Show();
        }
    }
}
