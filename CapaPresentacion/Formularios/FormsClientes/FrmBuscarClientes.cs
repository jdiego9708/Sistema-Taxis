using CapaEntidades;
using CapaPresentacion.Formularios.FormsDireccionClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsClientes
{
    public partial class FrmBuscarClientes : Form
    {
        PoperContainer container;
        public FrmBuscarClientes()
        {
            InitializeComponent();
            this.Load += FrmBuscarClientes_Load;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_onKeyPress;
            this.txtBusqueda.OnPxClick += TxtBusqueda_onPxClick;

            this.dgvClientes.DoubleClick += DgvClientes_DoubleClick;
            this.btnAgregar.Click += BtnAgregar_Click;
            this.btnEditar.Click += BtnEditar_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        FrmNuevoCliente frmNuevoCliente;

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridRow = this.dgvClientes.CurrentRow;
            if (dataGridRow != null)
            {
                if (frmNuevoCliente != null)
                    frmNuevoCliente.Close();

                DataRow row = ((DataRowView)dataGridRow.DataBoundItem).Row;
                EClientes eCliente = new EClientes(row);

                frmNuevoCliente = new FrmNuevoCliente
                {
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false,
                    IsEditar = true
                };
                frmNuevoCliente.AsignarDatos(eCliente);
                frmNuevoCliente.OnClienteEditSuccess += FrmNuevoCliente_OnClienteAddSuccess;
                this.container = new PoperContainer(frmNuevoCliente);
                frmNuevoCliente.Show();
                this.container.Show(btnAgregar);
            }
        }
       
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (this.frmNuevoCliente == null)
            {
                frmNuevoCliente = new FrmNuevoCliente
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                frmNuevoCliente.OnClienteAddSuccess += FrmNuevoCliente_OnClienteAddSuccess;
            }
            else
            {
                if (this.frmNuevoCliente.IsEditar)
                {
                    this.frmNuevoCliente = null;
                    frmNuevoCliente = new FrmNuevoCliente
                    {
                        TopLevel = false,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill
                    };
                    frmNuevoCliente.OnClienteAddSuccess += FrmNuevoCliente_OnClienteAddSuccess;
                }
            }
            this.container = new PoperContainer(frmNuevoCliente);
            this.container.Show(btnAgregar);
        }

        private void FrmNuevoCliente_OnClienteAddSuccess(object sender, EventArgs e)
        {
            this.BuscarClientes("COMPLETO", "");
            if (this.container != null)
            {
                this.frmNuevoCliente = null;
                this.container.Close();
            }
        }

        public event EventHandler OnBtnDireccionNext;
        public event EventHandler OnDgvDoubleClick;

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.BuscarClientes("COMPLETO", "");
        }

        private void DgvClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow gridViewRow = this.dgvClientes.CurrentRow;
                if (gridViewRow != null)
                {
                    if (this.OnDgvDoubleClick == null)
                    {
                        DataRow dataRow = ((DataRowView)gridViewRow.DataBoundItem).Row;
                        EClientes eCliente = new EClientes(dataRow);
                        FrmObservarDirecciones frmObservarDirecciones = new FrmObservarDirecciones
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                            IsCarrera = this.IsCarrera
                        };
                        frmObservarDirecciones.OnBtnDireccionNext += FrmObservarDirecciones_OnBtnDireccionNext;
                        frmObservarDirecciones.AsignarDatos(eCliente);
                        frmObservarDirecciones.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvClientes_DoubleClick",
                    "Hubo une error con la tabla de datos", ex.Message);
            }
        }

        private void FrmObservarDirecciones_OnBtnDireccionNext(object sender, EventArgs e)
        {
            EDireccion_clientes eDireccion = (EDireccion_clientes)sender;
            OnBtnDireccionNext?.Invoke(eDireccion, e);
            this.Close();
        }

        private void TxtBusqueda_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarClientes("COMPLETO ", "");
                }
                else
                {
                    if (this.rdNombre.Checked)
                    {
                        this.BuscarClientes("NOMBRE", txt.Texto);
                    }
                    else
                    {
                        this.BuscarClientes("CELULAR", txt.Texto);
                    }
                }
            }
        }

        private void TxtBusqueda_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarClientes("COMPLETO ", "");
            }
            else
            {
                if (this.rdNombre.Checked)
                {
                    this.BuscarClientes("NOMBRE", txt.Texto);
                }
                else
                {
                    this.BuscarClientes("CELULAR", txt.Texto);
                }
            }
        }

        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            this.BuscarClientes("COMPLETO", "");
        }

        private void BuscarClientes(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtClientes = 
                    EClientes.BuscarClientes(tipo_busqueda, texto_busqueda, out string rpta);
                this.dgvClientes.clearDataSource();
                if (dtClientes != null)
                {
                    this.btnEditar.Enabled = true;

                    this.lblResultados.Text = "Se encontraron " + dtClientes.Rows.Count + " clientes.";
                    this.dgvClientes.Enabled = true;
                    this.dgvClientes.PageSize = 40;
                    this.dgvClientes.SetPagedDataSource(dtClientes, this.bindingNavigator1);

                    this.dgvClientes.Columns["Id_cliente"].Visible = false;
                    this.dgvClientes.Columns["Id_base"].Visible = false;
                    this.dgvClientes.Columns["Id_base1"].Visible = false;
                    this.dgvClientes.Columns["Nombre_base"].Visible = false;
                    this.dgvClientes.Columns["Alias_base"].HeaderText = "Alias";
                    this.dgvClientes.Columns["Codigo_cliente"].HeaderText = "Código";
                    this.dgvClientes.Columns["Estado_cliente"].Visible = false;
                    this.dgvClientes.Columns["Nombre_cliente"].HeaderText = "Nombre";
                    this.dgvClientes.Columns["Celular_cliente"].HeaderText = "Celular";
                }
                else
                {
                    this.dgvClientes.Enabled = false;
                    this.btnEditar.Enabled = false;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarClientes",
                    "Hubo un error al buscar clientes", ex.Message);
            }
        }

        private bool _isCarrera;

        public bool IsCarrera { get => _isCarrera; set => _isCarrera = value; }

    }
}
