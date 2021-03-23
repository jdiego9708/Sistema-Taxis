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

namespace CapaPresentacion.Formularios.FormsVehiculos
{
    public partial class FrmObservarVehiculos : Form
    {
        PoperContainer container;
        public FrmObservarVehiculos()
        {
            InitializeComponent();
            this.Load += FrmObservarVehiculos_Load;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;
            this.dgvVehiculos.DoubleClick += DgvVehiculos_DoubleClick;
            this.btnAgregar.Click += BtnAgregar_Click;
            this.btnEditar.Click += BtnEditar_Click;
        }

        FrmNuevoVehiculo frmNuevoVehiculo;

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridRow = this.dgvVehiculos.CurrentRow;
            if (dataGridRow != null)
            {
                if (frmNuevoVehiculo != null)
                    frmNuevoVehiculo.Close();

                DataRow row = ((DataRowView)dataGridRow.DataBoundItem).Row;
                EVehiculos eVehiculo = new EVehiculos(row);

                frmNuevoVehiculo = new FrmNuevoVehiculo
                {
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false,
                    IsEditar = true
                };
                frmNuevoVehiculo.AsignarDatos(eVehiculo);
                frmNuevoVehiculo.OnVehiculoEditSuccess += FrmNuevoVehiculo_OnVehiculoAddSuccess;
                this.container = new PoperContainer(frmNuevoVehiculo);
                frmNuevoVehiculo.Show();
                this.container.Show(btnAgregar);
            }
        }
        
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (frmNuevoVehiculo == null)
            {
                frmNuevoVehiculo = new FrmNuevoVehiculo
                {
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false
                };
                frmNuevoVehiculo.OnVehiculoAddSuccess += FrmNuevoVehiculo_OnVehiculoAddSuccess;
                this.container = new PoperContainer(frmNuevoVehiculo);
            }
            frmNuevoVehiculo.Show();
            this.container.Show(btnAgregar);
        }

        private void FrmNuevoVehiculo_OnVehiculoAddSuccess(object sender, EventArgs e)
        {
            this.BuscarVehiculos("COMPLETO", "");

            if (this.container != null)
                this.container.Close();
        }

        public event EventHandler OnDgvDoubleClick;

        private void DgvVehiculos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow gridViewRow = this.dgvVehiculos.CurrentRow;
                if (gridViewRow != null)
                {
                    DataRow row = ((DataRowView)gridViewRow.DataBoundItem).Row;
                    if (OnDgvDoubleClick != null)
                    {
                        this.OnDgvDoubleClick?.Invoke(new EVehiculos(row), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvVehiculos_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarVehiculos(this.TipoBusqueda(), "");
                }
                else
                {
                    this.BuscarVehiculos(this.TipoBusqueda(), txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarVehiculos(this.TipoBusqueda(), "");
            }
            else
            {
                this.BuscarVehiculos(this.TipoBusqueda(), txt.Texto);
            }
        }

        private string TipoBusqueda()
        {
            if (this.rdChofer.Checked)
            {
                return "CHOFER";
            }

            if (this.rdPlaca.Checked)
            {
                return "PLACA";
            }

            return "COMPLETO";
        }

        private void FrmObservarVehiculos_Load(object sender, EventArgs e)
        {
            this.BuscarVehiculos("COMPLETO", "");
        }

        private void BuscarVehiculos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtVehiculos =
                    EVehiculos.BuscarVehiculos(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtVehiculos != null)
                {
                    this.btnEditar.Enabled = true;

                    this.lblResultados.Text = "Se encontraron " + dtVehiculos.Rows.Count + " vehículos.";
                    this.dgvVehiculos.Enabled = true;
                    this.dgvVehiculos.PageSize = 15;
                    this.dgvVehiculos.SetPagedDataSource(dtVehiculos, this.bindingNavigator1);

                    this.dgvVehiculos.Columns["Id_vehiculo"].Visible = true;
                    this.dgvVehiculos.Columns["Id_vehiculo"].HeaderText = "Código";
                    this.dgvVehiculos.Columns["Estado_vehiculo"].Visible = false;

                    if (this.dgvVehiculos.Columns.Contains("Propietario"))
                        this.dgvVehiculos.Columns["Propietario"].Visible = false;

                    if (this.dgvVehiculos.Columns.Contains("Color"))
                        this.dgvVehiculos.Columns["Color"].Visible = false;
                }
                else
                {
                    this.btnEditar.Enabled = false;

                    this.lblResultados.Text = "No se encontraron vehículos";
                    this.dgvVehiculos.Enabled = false;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarVehiculos",
                    "Hubo un error al buscar vehículos", ex.Message);
            }
        }
    }
}
