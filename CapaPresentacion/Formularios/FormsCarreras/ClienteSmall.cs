using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CapaEntidades;
using CapaPresentacion.Formularios.FormsClientes;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class ClienteSmall : UserControl
    {
        PoperContainer container;
        public ClienteSmall()
        {
            InitializeComponent();
            this.txtCodigo.KeyPress += TxtCodigo_KeyPress;

            this.btnLimpiar.Click += BtnLimpiar_Click;
            this.btnRemover.Click += BtnRemover_Click;
            this.txtCodigo.Click += TxtCodigo_Click;
            this.btnEditar.Click += BtnEditar_Click;

            this.codigoVehiculo1.OnBtnNext += CodigoVehiculo1_OnBtnNext;
            this.btnCarreraPerdida.Click += BtnCarreraPerdida_Click;
        }

        private void BtnCarreraPerdida_Click(object sender, EventArgs e)
        {
            if (this.EDireccion == null)
            {
                Mensajes.MensajeInformacion("No hay direcciones seleccionadas", "Entendido");
                return;
            }

            OnBtnCarreraPerdida?.Invoke(this.EDireccion, e);
            this.btnLimpiar.PerformClick();
            this.codigoVehiculo1.txtCodigo.Clear();
            this.codigoVehiculo1.txtCodigo.Focus();
            this.codigoVehiculo1.txtCodigo.SelectAll();          
        }

        private void CodigoVehiculo1_OnBtnNext(object sender, EventArgs e)
        {
            CodigoVehiculo codigoVehiculo = (CodigoVehiculo)sender;

            if (this.EDireccion == null)
            {
                Mensajes.MensajeInformacion("No hay direcciones seleccionadas", "Entendido");
                return;
            }

            codigoVehiculo.EDireccion = this.EDireccion;
            OnBtnNext?.Invoke(codigoVehiculo, e);
            this.codigoVehiculo1.txtCodigo.Clear();
            this.codigoVehiculo1.txtCodigo.Focus();
            this.codigoVehiculo1.txtCodigo.SelectAll();
        }

        public event EventHandler OnBtnNext;
        public event EventHandler OnBtnRemover;
        public event EventHandler OnBtnCarreraPerdida;

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            FrmNuevoCliente frmNuevoCliente = new FrmNuevoCliente
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Editar datos de cliente"
            };
            frmNuevoCliente.AsignarDatos(this.EDireccion);
            frmNuevoCliente.OnClienteEditSuccessDireccion += FrmNuevoCliente_OnClienteEditSuccessDireccion;
            frmNuevoCliente.txtCodigo.Focus();
            frmNuevoCliente.ShowDialog();
        }

        private void FrmNuevoCliente_OnClienteEditSuccessDireccion(object sender, EventArgs e)
        {
            EDireccion_clientes eDireccion = (EDireccion_clientes)sender;
            this.BuscarCliente("ID CLIENTE",eDireccion.ECliente.Id_cliente.ToString());
        }

        private void TxtCodigo_Click(object sender, EventArgs e)
        {
            this.txtCodigo.SelectAll();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            OnBtnRemover?.Invoke(this, e);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtInformacion.Text = "Búsqueda de clientes por código";
            this.txtCodigo.Text = "0";
        }

        private EDireccion_clientes _eDireccion;

        public EDireccion_clientes EDireccion
        {
            get => _eDireccion;
            set
            {
                _eDireccion = value;
                if (value != null)
                    this.btnEditar.Enabled = true;
                else
                    this.btnEditar.Enabled = false;
            }
        }

        private void BuscarCliente(string tipo_busqueda, string codigo)
        {
            try
            {
                DataTable dtDireccionCliente =
                    EDireccion_clientes.BuscarDireccion(tipo_busqueda, codigo, out string rpta);
                if (dtDireccionCliente != null)
                {
                    if (dtDireccionCliente.Rows.Count == 1)
                    {
                        EDireccion_clientes eDireccion = new EDireccion_clientes(dtDireccionCliente, 0);
                        this.EDireccion = eDireccion;
                        StringBuilder info = new StringBuilder();
                        info.Append("Nombre: ").Append(eDireccion.ECliente.Nombre_cliente).Append(" - ");
                        info.Append("Celular: ").Append(eDireccion.ECliente.Celular_cliente).Append(" - ");
                        info.Append("Barrio: ").Append(eDireccion.EBarrio.Nombre_barrio).Append(Environment.NewLine);
                        info.Append("Dirección: ").Append(eDireccion.Direccion).Append(Environment.NewLine);
                        info.Append("Casa: ").Append(eDireccion.Casa).Append(" - ");
                        info.Append("Referencia: ").Append(eDireccion.Referencia);

                        this.txtInformacion.Text = info.ToString();

                        this.codigoVehiculo1.txtCodigo.Focus();
                        this.codigoVehiculo1.txtCodigo.SelectAll();
                    }
                    else
                    {
                        ClientesBases clientesBases = new ClientesBases
                        {
                            DtBases = dtDireccionCliente
                        };
                        clientesBases.OnClienteBaseNext += ClientesBases_OnClienteBaseNext;
                        this.container = new PoperContainer(clientesBases);
                        this.container.Show(this.txtCodigo);
                        clientesBases.dgvBases.Focus();
                    }
                    
                }
                else
                {
                    this.txtInformacion.Text = "No se encontró el cliente";

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarCliente(string codigo)",
                    "Hubo un error al buscar un cliente", ex.Message);
            }
        }

        private void ClientesBases_OnClienteBaseNext(object sender, EventArgs e)
        {
            DataRow row = (DataRow)sender;
            EDireccion_clientes eDireccion = new EDireccion_clientes(row);
            this.EDireccion = eDireccion;
            StringBuilder info = new StringBuilder();
            info.Append("Nombre: ").Append(eDireccion.ECliente.Nombre_cliente).Append(" - ");
            info.Append("Celular: ").Append(eDireccion.ECliente.Celular_cliente).Append(" - ");
            info.Append("Barrio: ").Append(eDireccion.EBarrio.Nombre_barrio).Append(Environment.NewLine);
            info.Append("Dirección: ").Append(eDireccion.Direccion).Append(Environment.NewLine);
            info.Append("Casa: ").Append(eDireccion.Casa).Append(" - ");
            info.Append("Referencia: ").Append(eDireccion.Referencia);

            this.txtInformacion.Text = info.ToString();

            if (this.container != null)
                this.container.Close();

            this.codigoVehiculo1.txtCodigo.Focus();
            this.codigoVehiculo1.txtCodigo.SelectAll();
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (!txt.Text.Equals(""))
                {
                    string texto = txt.Text.Trim();
                    if (int.TryParse(texto, out int codigo))
                    {
                        this.BuscarCliente("CODIGO", txt.Text);
                        return;
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("Solo números", "Entendido");
                    }
                }
            }
            else if (char.IsDigit(e.KeyChar) ||
                    e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
