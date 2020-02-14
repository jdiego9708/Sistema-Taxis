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

namespace CapaPresentacion.Formularios.FormsEmpleados
{
    public partial class FrmObservarEmpleados : Form
    {
        PoperContainer container;
        public FrmObservarEmpleados()
        {
            InitializeComponent();
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;

            this.btnAgregar.Click += BtnAgregar_Click;
            this.btnEditar.Click += BtnEditar_Click;
            this.dgvEmpleados.DoubleClick += DgvEmpleados_DoubleClick;

            this.Load += FrmObservarEmpleados_Load;
        }

        private void FrmObservarEmpleados_Load(object sender, EventArgs e)
        {
            this.BuscarEmpleados("COMPLETO", "");

            if (this.OnDgvDoubleClick != null)
            {
                this.btnAgregar.Visible = false;
                this.btnEditar.Visible = false;
            }
        }

        public event EventHandler OnDgvDoubleClick;

        private void DgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow gridRow = this.dgvEmpleados.CurrentRow;
                if (gridRow != null)
                {
                    DataRow row = ((DataRowView)gridRow.DataBoundItem).Row;
                    if (OnDgvDoubleClick != null)
                    {
                        this.OnDgvDoubleClick?.Invoke(new EEmpleados(row), e);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvEmpleados_DoubleClick",
                    "Hubo un error con la tabla de datos y el evento double click", ex.Message);
            }
        }

        FrmNuevoEmpleado FrmNuevoEmpleado;

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridRow = this.dgvEmpleados.CurrentRow;
            if (dataGridRow != null)
            {
                if (FrmNuevoEmpleado != null)
                    FrmNuevoEmpleado.Close();

                DataRow row = ((DataRowView)dataGridRow.DataBoundItem).Row;
                EEmpleados eEmpleado = new EEmpleados(row);

                FrmNuevoEmpleado = new FrmNuevoEmpleado
                {
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false,
                    IsEditar = true
                };
                FrmNuevoEmpleado.AsignarDatos(eEmpleado);
                FrmNuevoEmpleado.OnEmpleadoEditSuccess += FrmNuevoEmpleado_OnEmpleadoAddSuccess;
                this.container = new PoperContainer(FrmNuevoEmpleado);
                FrmNuevoEmpleado.Show();
                this.container.Show(btnAgregar);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (FrmNuevoEmpleado == null)
            {
                FrmNuevoEmpleado = new FrmNuevoEmpleado
                {
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false
                };
                FrmNuevoEmpleado.OnEmpleadoAddSuccess += FrmNuevoEmpleado_OnEmpleadoAddSuccess;
                this.container = new PoperContainer(FrmNuevoEmpleado);
            }
            FrmNuevoEmpleado.Show();
            this.container.Show(btnAgregar);
        }

        private void FrmNuevoEmpleado_OnEmpleadoAddSuccess(object sender, EventArgs e)
        {
            this.BuscarEmpleados("COMPLETO", "");

            if (this.container != null)
                this.container.Close();
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarEmpleados("COMPLETO", "");
                }
                else
                {
                    this.BuscarEmpleados("NOMBRE", txt.Texto);
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarEmpleados("COMPLETO", "");
            }
            else
            {
                this.BuscarEmpleados("NOMBRE", txt.Texto);
            }
        }

        private void BuscarEmpleados(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtEmpleadoss =
                    EEmpleados.BuscarEmpleados(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtEmpleadoss != null)
                {
                    this.btnEditar.Enabled = true;
                    this.lblResultados.Text = "Se encontraron " + dtEmpleadoss.Rows.Count + " empleados.";
                    this.dgvEmpleados.Enabled = true;
                    this.dgvEmpleados.PageSize = 15;
                    this.dgvEmpleados.SetPagedDataSource(dtEmpleadoss, this.bindingNavigator1);

                    this.dgvEmpleados.Columns["Id_empleado"].Visible = false;
                    this.dgvEmpleados.Columns["Nombre_empleado"].HeaderText = "Nombre";
                    this.dgvEmpleados.Columns["Correo_empleado"].HeaderText = "Correo electrónico";
                    this.dgvEmpleados.Columns["Tipo_empleado"].HeaderText = "Cargo";
                    this.dgvEmpleados.Columns["Estado_empleado"].Visible = false;
                }
                else
                {
                    this.btnEditar.Enabled = false;

                    this.lblResultados.Text = "No se encontraron empleados";
                    this.dgvEmpleados.Enabled = false;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarEmpleados",
                    "Hubo un error al buscar empleados", ex.Message);
            }
        }
    }
}
