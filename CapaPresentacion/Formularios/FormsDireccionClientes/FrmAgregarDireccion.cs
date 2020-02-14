using CapaEntidades;
using System;
using System.Data;
using System.Windows.Forms;

using CapaPresentacion.Formularios.FormsBarrios;

namespace CapaPresentacion.Formularios.FormsDireccionClientes
{
    public partial class FrmAgregarDireccion : Form
    {
        PoperContainer container;
        public FrmAgregarDireccion()
        {
            InitializeComponent();
            this.Load += FrmAgregarDireccion_Load;
            this.btnAgregarBarrio.Click += BtnAgregarBarrio_Click;

            this.txtDireccion.KeyPress += TxtKeyPress;
            this.txtNumeroCasa.KeyPress += TxtKeyPress;
            this.listaBarrio.KeyPress += TxtKeyPress;
            this.txtReferencia.KeyPress += TxtKeyPress;
            this.txtObservaciones.KeyPress += TxtKeyPress;
            this.txtCiudadela.KeyPress += TxtKeyPress;
            this.btnAgregarBarrio.KeyPress += TxtKeyPress;

            this.gbDireccion.GotFocus += Gb_GotFocus;
            this.gbObservaciones.GotFocus += Gb_GotFocus;
            this.gbCiudadela.GotFocus += Gb_GotFocus;
            this.gbCasa.GotFocus += Gb_GotFocus;
            this.gbBarrio.GotFocus += Gb_GotFocus;
            this.gbReferencia.GotFocus += Gb_GotFocus;
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

        private void BtnAgregarBarrio_Click(object sender, EventArgs e)
        {
            FrmNuevoBarrio frmNuevoBarrio = new FrmNuevoBarrio
            {
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                TopLevel = false
            };
            frmNuevoBarrio.OnBarrioSuccess += FrmNuevoBarrio_OnBarrioSuccess;
            this.container = new PoperContainer(frmNuevoBarrio);
            this.container.Show(this.btnAgregarBarrio);
        }

        private void FrmNuevoBarrio_OnBarrioSuccess(object sender, EventArgs e)
        {
            EBarrios eBarrio = (EBarrios)sender;
            if (this.container != null)
                this.container = null;

            this.LlenarListaBarrios();
        }

        private void AsignarDatos(EDireccion_clientes eDireccion)
        {
            this.IsEditar = true;
            this.txtDireccion.Text = eDireccion.Direccion;
            this.txtNumeroCasa.Text = eDireccion.Casa;
            this.LlenarListaBarrios();
            this.listaBarrio.SelectedValue = eDireccion.EBarrio.Id_barrio;
            this.txtReferencia.Text = eDireccion.Referencia;
            this.txtObservaciones.Text = eDireccion.Observaciones;
            this.txtCiudadela.Text = eDireccion.Ciudadela;
        }

        private void LlenarListaBarrios()
        {
            DataTable dtBarrios = EBarrios.BuscarBarrios("COMPLETO", "", out string rpta);
            if (dtBarrios != null)
            {
                this.listaBarrio.DataSource = dtBarrios;
                this.listaBarrio.ValueMember = "Id_barrio";
                this.listaBarrio.DisplayMember = "Nombre_barrio";
            }
        }

        private void FrmAgregarDireccion_Load(object sender, EventArgs e)
        {
            if (!this.IsEditar)
            {
                LlenarListaBarrios();
            }          
        }

        private EDireccion_clientes _eDireccion;
        private EClientes _eCliente;

        public EDireccion_clientes EDireccion { get => _eDireccion;
            set
            {
                _eDireccion = value;
                this.AsignarDatos(value);
            }
        }
        private bool _isEditar;
        public EClientes ECliente { get => _eCliente; set => _eCliente = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }

        public bool Comprobaciones(out EDireccion_clientes eDireccion)
        {
            eDireccion = new EDireccion_clientes();
            try
            {           
                if (this.txtDireccion.Text.Equals(string.Empty))
                {
                    Mensajes.MensajeInformacion("Por favor verifique la dirección", "Entendido");
                    return false;
                }

                if (this.txtNumeroCasa.Text.Equals(string.Empty))
                {
                    Mensajes.MensajeInformacion("Por favor verifique el número de casa", "Entendido");
                    return false;
                }

                if (this.listaBarrio.Text.Equals(string.Empty))
                {
                    Mensajes.MensajeInformacion("Por favor verifique el barrio/ciudadela", "Entendido");
                    return false;
                }

                if (!int.TryParse(Convert.ToString(this.listaBarrio.SelectedValue), out int id_barrio))
                {
                    Mensajes.MensajeInformacion("Por favor verifique el barrio/ciudadela", "Entendido");
                    return false;
                }

                eDireccion.ECliente = this.ECliente;
                eDireccion.Direccion = this.txtDireccion.Text;
                eDireccion.Casa = this.txtNumeroCasa.Text;
                eDireccion.EBarrio = new EBarrios { Id_barrio = id_barrio };
                eDireccion.Ciudadela = this.txtCiudadela.Text;
                eDireccion.Referencia = this.txtReferencia.Text;
                eDireccion.Observaciones = this.txtObservaciones.Text;
                eDireccion.Estado_direccion = "ACTIVO";

                if (this.IsEditar)
                {
                    eDireccion.Id_direccion = this.EDireccion.Id_direccion;
                }

                return true;
            }
            catch (Exception)
            {              
                Mensajes.MensajeErrorForm("Hubo un error al comprobar los datos de la dirección");
                return false;
            }
        }       
    }
}
