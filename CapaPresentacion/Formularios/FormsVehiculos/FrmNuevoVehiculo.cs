using CapaEntidades;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsVehiculos
{
    public partial class FrmNuevoVehiculo : Form
    {
        public FrmNuevoVehiculo()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;

            this.gbCodigo.GotFocus += Gb_GotFocus;
            this.gbPlaca.GotFocus += Gb_GotFocus;
            this.gbPropietario.GotFocus += Gb_GotFocus;
            this.gbChofer.GotFocus += Gb_GotFocus;
            this.gbMarca.GotFocus += Gb_GotFocus;
            this.gbModelo.GotFocus += Gb_GotFocus;
            this.gbColor.GotFocus += Gb_GotFocus;

            this.txtCodigo.KeyPress += TxtKeyPress;
            this.txtCodigo.KeyPress += TxtKeyPress1;
            this.txtPlaca.KeyPress += TxtKeyPress;
            this.txtPropietario.KeyPress += TxtKeyPress;
            this.txtChofer.KeyPress += TxtKeyPress;
            this.txtMarca.KeyPress += TxtKeyPress;
            this.txtModelo.KeyPress += TxtKeyPress;
            this.txtColor.KeyPress += TxtKeyPress;
            this.txtCodigo.LostFocus += TxtCodigo_LostFocus;
            this.Load += FrmNuevoVehiculo_Load;
        }

        private void TxtCodigo_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals(string.Empty))
                txt.BackColor = Color.FromArgb(255, 192, 192);
            else
            {
                if (txt.Text.Equals(""))
                {
                    Mensajes.MensajeInformacion("Por favor verifique el código", "Entendido");
                    this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                    this.errorProvider1.SetError(this.gbCodigo, "El código está vacío");
                    return;
                }

                if (!int.TryParse(txt.Text, out int codigo))
                {
                    this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                    this.errorProvider1.SetError(this.gbCodigo, "El código debe ser sólo números");
                    return;
                }

                if (this.DtVehiculos != null)
                {
                    DataRow[] rows =
                        this.DtVehiculos.Select(string.Format("Id_vehiculo = {0}", codigo));
                    if (rows.Length > 0)
                    {
                        this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                        this.errorProvider1.SetError(this.gbCodigo, "El código ya existe");
                        return;
                    }
                    else
                    {
                        this.txtCodigo.BackColor = Color.White;
                        this.errorProvider1.Clear();
                    }
                }
                else
                {
                    this.txtCodigo.BackColor = Color.White;
                    this.errorProvider1.Clear();
                }
            }
        }

        private void FrmNuevoVehiculo_Load(object sender, EventArgs e)
        {
            this.DtVehiculos = EVehiculos.BuscarVehiculos("COMPLETO", "", out string rpta);
            //if (dtVehiculos != null)
            //{
            //    EVehiculos eVehiculo = new EVehiculos(dtVehiculos, 0);
            //    this.txtCodigo.Text = (eVehiculo.Id_vehiculo + 1).ToString();
            //}
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

        public event EventHandler OnVehiculoAddSuccess;
        public event EventHandler OnVehiculoEditSuccess;
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EVehiculos eVehiculo))
                {
                    string rpta = "";
                    string mensaje = "";
                    if (this.IsEditar)
                    {
                        rpta = EVehiculos.EditarVehiculo(eVehiculo, this.EVehiculo.Id_vehiculo);
                        mensaje = "Se actualizó correctamente el vehículo";
                    }
                    else
                    {
                        rpta = EVehiculos.InsertarVehiculo(eVehiculo, eVehiculo.Id_vehiculo);
                        mensaje = "Se agregó correctamente el vehículo";
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsEditar)
                            OnVehiculoEditSuccess?.Invoke(eVehiculo, e);
                        else
                            OnVehiculoAddSuccess?.Invoke(eVehiculo, e);

                        Mensajes.MensajeOkForm(mensaje);
                        this.Close();
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar un vehículo", ex.Message);
            }
        }

        public void AsignarDatos(EVehiculos eVehiculo)
        {
            this.EVehiculo = eVehiculo;
            this.txtCodigo.Text = eVehiculo.Id_vehiculo.ToString();
            this.txtPlaca.Text = eVehiculo.Placa;
            this.txtPropietario.Text = eVehiculo.Propietario;
            this.txtChofer.Text = eVehiculo.Chofer;
            this.txtMarca.Text = eVehiculo.Marca;
            this.txtModelo.Text = eVehiculo.Modelo;
            this.txtColor.Text = eVehiculo.Color;
            this.btnGuardar.Text = "Actualizar";
            this.Text = "Editar vehículo";
            this.textBox1.Text = "Edición de vehículo";
        }

        private bool Comprobaciones(out EVehiculos eVehiculo)
        {
            eVehiculo = new EVehiculos();

            if (this.txtPlaca.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Verifique la placa", "Entendido");
                return false;
            }

            if (this.txtPropietario.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Verifique el propietario", "Entendido");
                return false;
            }

            if (this.txtChofer.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Verifique el chofer", "Entendido");
                return false;
            }

            if (this.txtMarca.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Verifique la marca", "Entendido");
                return false;
            }

            if (this.txtModelo.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Verifique el modelo", "Entendido");
                return false;
            }

            if (txtCodigo.Text.Equals(""))
            {
                Mensajes.MensajeInformacion("Por favor verifique el código", "Entendido");
                this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                this.errorProvider1.SetError(this.gbCodigo, "El código está vacío");
                return false;
            }

            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                this.errorProvider1.SetError(this.gbCodigo, "El código debe ser sólo números");
                return false;
            }

            if (this.DtVehiculos != null)
            {
                DataRow[] rows =
                    this.DtVehiculos.Select(string.Format("Id_vehiculo = {0}", codigo));
                if (rows.Length > 0)
                {
                    this.txtCodigo.BackColor = Color.FromArgb(255, 192, 192);
                    this.errorProvider1.SetError(this.gbCodigo, "El código ya existe");
                    return false;
                }
                else
                {
                    this.txtCodigo.BackColor = Color.White;
                    this.errorProvider1.Clear();
                }
            }
            else
            {
                this.txtCodigo.BackColor = Color.White;
                this.errorProvider1.Clear();
            }

            eVehiculo.Id_vehiculo = codigo;
            eVehiculo.Placa = this.txtPlaca.Text;
            eVehiculo.Propietario = this.txtPropietario.Text;
            eVehiculo.Chofer = this.txtChofer.Text;
            eVehiculo.Marca = this.txtMarca.Text;
            eVehiculo.Modelo = this.txtModelo.Text;
            eVehiculo.Color = this.txtColor.Text;
            eVehiculo.Estado_vehiculo = "ACTIVO";

            return true;

        }

        EVehiculos EVehiculo;
        private bool _isEditar;
        private DataTable _dtVehiculos;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
        public DataTable DtVehiculos { get => _dtVehiculos; set => _dtVehiculos = value; }
    }
}
