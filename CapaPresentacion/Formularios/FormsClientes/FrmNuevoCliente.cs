using CapaEntidades;
using CapaPresentacion.Formularios.FormsDireccionClientes;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsClientes
{
    public partial class FrmNuevoCliente : Form
    {
        public FrmNuevoCliente()
        {
            InitializeComponent();
            this.Load += FrmNuevoCliente_Load;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;

            this.txtNombres.KeyPress += TxtKeyPress;
            this.txtCelular.KeyPress += TxtKeyPress;
            this.txtCodigo.KeyPress += TxtKeyPress;
            this.txtCodigo.KeyPress += TxtKeyPress1;

            this.gbDireccion.GotFocus += Gb_GotFocus;
            this.gbCelular.GotFocus += Gb_GotFocus;
            this.gbNombres.GotFocus += Gb_GotFocus;
            this.gbCodigo.GotFocus += Gb_GotFocus;

            this.txtCodigo.LostFocus += TxtCodigo_LostFocus;
            this.txtCodigo.BackColorChanged += TxtCodigo_BackColorChanged;
        }

        private void TxtKeyPress1(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = Thread.CurrentThread.CurrentCulture;
            if (char.IsDigit(e.KeyChar) ||
                (int)e.KeyChar == (int)Keys.Back ||
                (int)e.KeyChar == (int)Keys.Enter)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtCodigo_BackColorChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.BackColor == Color.FromArgb(255, 192, 192))
                this.errorProvider3.SetError(this.gbCodigo, "El código ya existe o el campo está vacío");
            else
                this.errorProvider3.Clear();
        }

        private void TxtCodigo_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals(string.Empty))
                txt.BackColor = Color.FromArgb(255, 192, 192);
            else
            {
                string codigoCliente = "";

                if (this.gbBd.Tag != null)
                {
                    EBases_clientes eBase = (EBases_clientes)this.gbBd.Tag;
                    codigoCliente = this.txtCodigo.Text + eBase.Alias_base;                   
                }
                else
                {
                    this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                    return;
                }

                if (this.DtClientes != null)
                {
                    if (codigoCliente.Equals(""))
                    {
                        Mensajes.MensajeInformacion("Por favor verifique el código", "Entendido");
                        this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                        return;
                    }

                    DataRow[] rows =
                        this.DtClientes.Select(string.Format("Codigo_cliente = '{0}'", codigoCliente));
                    if (rows.Length > 0)
                    {
                        this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                        return;
                    }
                    else
                        this.txtCodigo.BackColor = Color.White;
                }
                else
                    this.txtCodigo.BackColor = Color.White;
            }
        }

        private void Gb_GotFocus(object sender, EventArgs e)
        {
            GroupBox gb = (GroupBox)sender;
            if (gb.Controls.Count > 0)
                gb.Controls[0].Focus();
        }

        private void TxtKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        public event EventHandler OnClienteAddSuccess;
        public event EventHandler OnClienteAddSuccessDireccion;
        public event EventHandler OnClienteEditSuccess;
        public event EventHandler OnClienteEditSuccessDireccion;

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EClientes eCliente, out EDireccion_clientes eDireccion))
                {
                    string rpta = "";
                    string mensaje = "";

                    if (this.IsEditar)
                    {
                        rpta = EClientes.EditarCliente(eCliente, this.ECliente.Id_cliente);
                        mensaje = "Se actualizó el cliente correctamente";
                    }
                    else
                    {
                        rpta = EClientes.InsertarCliente(eCliente, out int id_cliente);
                        eDireccion.ECliente.Id_cliente = id_cliente;
                        mensaje = "Se agregó el cliente correctamente";
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsEditar)
                        {
                            eDireccion.ECliente = this.ECliente;

                            rpta = EDireccion_clientes.EditarDireccion(eDireccion, this.EDireccion.Id_direccion);
                            OnClienteEditSuccess?.Invoke(eCliente, e);
                            OnClienteEditSuccessDireccion?.Invoke(eDireccion, e);
                        }
                        else
                        {
                            rpta = EDireccion_clientes.InsertarDireccion(eDireccion, out int id_direccion);
                            OnClienteAddSuccess?.Invoke(eCliente, e);
                            OnClienteAddSuccessDireccion?.Invoke(eDireccion, e);
                        }


                        if (rpta.Equals("OK"))
                        {
                            Mensajes.MensajeOkForm(mensaje);
                            this.Close();
                        }
                        else
                        {
                            Mensajes.MensajeInformacion("Se guardó la información básica del cliente pero hubo un error " +
                                "al guardar la dirección, registrela manualmente", "Entendido");
                            this.Close();
                        }
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar el cliente", ex.Message);
            }
        }

        public void AsignarDatos(EClientes eCliente)
        {
            this.ECliente = eCliente;
            this.IsEditar = true;
            this.textBox5.Text = "Edición de cliente";
            this.btnGuardar.Text = "Actualizar";

            this.txtCodigo.Text = eCliente.Codigo_cliente;
            this.txtNombres.Text = eCliente.Nombre_cliente;
            this.txtCelular.Text = eCliente.Celular_cliente;
            this.CargarBases();
            this.listaBases.SelectedValue = eCliente.EBase.Id_base;

            DataTable dtDirecciones =
                EDireccion_clientes.BuscarDireccion("ID CLIENTE",
                eCliente.Id_cliente.ToString(), out string rpta);
            if (dtDirecciones != null)
            {
                EDireccion_clientes eDireccion = new EDireccion_clientes(dtDirecciones, 0);
                this.CargarFormularioDireccion();
                this.frmAgregarDireccion.EDireccion = eDireccion;
                this.frmAgregarDireccion.ECliente = eCliente;
            }
            else
            {
                Mensajes.MensajeInformacion("No hay ninguna dirección registrada", "Entendido");
            }           
        }

        public void AsignarDatos(EDireccion_clientes eDireccion)
        {
            this.IsEditar = true;
            this.ECliente = eDireccion.ECliente;
            this.EDireccion = eDireccion;

            this.textBox5.Text = "Edición de cliente";
            this.btnGuardar.Text = "Actualizar";

            this.txtCodigo.Text = eDireccion.ECliente.Codigo_cliente;
            this.txtNombres.Text = eDireccion.ECliente.Nombre_cliente;
            this.txtCelular.Text = eDireccion.ECliente.Celular_cliente;

            this.CargarFormularioDireccion();
            this.CargarBases();

            this.listaBases.SelectedValue = eDireccion.ECliente.EBase.Id_base;

            this.frmAgregarDireccion.EDireccion = eDireccion;
            this.frmAgregarDireccion.ECliente = eDireccion.ECliente;
        }

        private bool Comprobaciones(out EClientes eCliente, out EDireccion_clientes eDireccion)
        {
            eCliente = new EClientes();
            eDireccion = new EDireccion_clientes();

            if (this.txtNombres.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Por favor verifique el nombre", "Entendido");
                return false;
            }

            if (this.txtCelular.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Por favor verifique el celular", "Entendido");
                return false;
            }

            if (this.txtCodigo.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Por favor verifique el código", "Entendido");
                return false;
            }

            if (string.IsNullOrEmpty(this.listaBases.Text))
            {
                Mensajes.MensajeInformacion("Por favor verifique la base de datos seleccionada", "Entendido");
                return false;
            }

            if (this.gbBd.Tag != null)
            {
                EBases_clientes eBase = (EBases_clientes)this.gbBd.Tag;
                eCliente.EBase = eBase;
            }

            if (this.txtCodigo.Text.Equals(""))
            {
                this.errorProvider3.SetError(this.gbCodigo, "El código es obligatorio");
                return false;
            }

            if (this.DtClientes != null)
            {
                if (!this.IsEditar)
                {
                    DataRow[] rows =
                        this.DtClientes.Select(string.Format("Codigo_cliente = '{0}' AND Id_base = {1}",
                        this.txtCodigo.Text, eCliente.EBase.Id_base));
                    if (rows.Length > 0)
                    {
                        this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                        this.errorProvider3.SetError(this.gbCodigo, "El código ya existe");
                        return false;
                    }
                    else
                    {
                        this.txtCodigo.BackColor = Color.White;
                        this.errorProvider3.Clear();
                    }
                }
            }

            eCliente.Codigo_cliente = this.txtCodigo.Text;
            eCliente.Nombre_cliente = this.txtNombres.Text;
            eCliente.Celular_cliente = this.txtCelular.Text;
            if (this.IsEditar)
                eCliente.Estado_cliente = this.ECliente.Estado_cliente;
            else
                eCliente.Estado_cliente = "ACTIVO";

            if (this.frmAgregarDireccion != null)
            {
                if (!this.frmAgregarDireccion.Comprobaciones(out eDireccion))
                {
                    return false;
                }
            }
            else
            {
                Mensajes.MensajeInformacion("Por favor verifique la dirección, el formulario no se a creado", "Entendido");
                return false;
            }

            eDireccion.ECliente = eCliente;

            if (this.IsEditar)
            {
                eDireccion.ECliente = this.ECliente;
            }

            return true;
        }

        FrmAgregarDireccion frmAgregarDireccion;

        private void CargarFormularioDireccion()
        {
            if (this.gbDireccion.Controls.Count > 0)
                this.gbDireccion.Controls.Clear();

            frmAgregarDireccion = new FrmAgregarDireccion
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            this.gbDireccion.Controls.Add(frmAgregarDireccion);
            frmAgregarDireccion.Show();
        }

        private void CargarBases()
        {
            this.DtBases = EBases_clientes.BuscarBases("COMPLETO", "", out string rpta);
            if (DtBases != null)
            {
                EBases_clientes eBase = new EBases_clientes(DtBases.Rows[0]);
                this.gbBd.Tag = eBase;
                this.gbBd.Text = "Base de datos (" + eBase.Alias_base + ")";

                this.listaBases.DataSource = DtBases;
                this.listaBases.DisplayMember = "Nombre_base";
                this.listaBases.ValueMember = "Id_base";
                this.listaBases.SelectedIndexChanged += ListaBases_SelectedIndexChanged;
            }
            else
            {
                Mensajes.MensajeInformacion("No se encontró ninguna base de datos para ligar el cliente", "Entendido");
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }
            }
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            this.DtClientes = EClientes.BuscarClientes("COMPLETO", "", out string rpta);
            if (!this.IsEditar)
            {
                this.CargarFormularioDireccion();
                this.CargarBases();
            }

            if (this.DtClientes != null)
            {
                EClientes eCliente = new EClientes(this.DtClientes, 0);
                this.txtCodigo.Text = (eCliente.Id_cliente + 1).ToString();
            }

            this.txtCodigo.Focus();
            this.txtCodigo.SelectAll();
            this.gbCodigo.Focus();
        }

        private void ListaBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (int.TryParse(cb.SelectedValue.ToString(), out int id_base))
            {
                if (this.DtBases != null)
                {
                    DataRow[] rows = this.DtBases.Select(string.Format("Id_base = {0}", id_base));
                    if (rows.Length > 0)
                    {
                        EBases_clientes eBase = new EBases_clientes(rows[0]);
                        this.gbBd.Tag = eBase;
                        this.gbBd.Text = "Base de datos (" + eBase.Alias_base + ")";
                    }
                }
            }
            else
                Mensajes.MensajeInformacion("Hubo un error al obtener el id de la base seleccionada", "Entendido");
        }

        private DataTable _dtBases;
        private DataTable _dtClientes;
        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }

        private EClientes _eCliente;
        private EDireccion_clientes _eDireccion;
        public EDireccion_clientes EDireccion { get => _eDireccion; set => _eDireccion = value; }
        public EClientes ECliente { get => _eCliente; set => _eCliente = value; }
        public DataTable DtClientes { get => _dtClientes; set => _dtClientes = value; }
        public DataTable DtBases { get => _dtBases; set => _dtBases = value; }
    }
}
