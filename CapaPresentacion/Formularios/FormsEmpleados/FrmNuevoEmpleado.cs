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
    public partial class FrmNuevoEmpleado : Form
    {
        public FrmNuevoEmpleado()
        {
            InitializeComponent();
            this.Load += FrmNuevoEmpleado_Load;
            this.btnGuardar.Click += BtnGuardar_Click;

            this.txtPass1.KeyPress += TxtPass1_KeyPress;
        }

        private void TxtPass1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.TextLength < 5)
                    Mensajes.MensajeInformacion("La contraseña debe tener mínimo 5 caracteres", "Entendido");
                else
                {
                    this.txtPass2.Enabled = true;
                    this.txtPass2.Focus();
                }
            }
        }

        public event EventHandler OnEmpleadoAddSuccess;
        public event EventHandler OnEmpleadoEditSuccess;

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EEmpleados eEmpleado, out ECredenciales eCredenciales))
                {
                    string rpta = "";
                    string mensaje = "";

                    if (this.IsEditar)
                    {
                        rpta = EEmpleados.EditarEmpleados(eEmpleado, this.EEmpleado.Id_empleado);
                        mensaje = "Empleado actualizado correctamente";
                    }
                    else
                    {
                        rpta = EEmpleados.InsertarEmpleados(eEmpleado, out int id_empleado);
                        eEmpleado.Id_empleado = id_empleado;
                        eCredenciales.Id_empleado = id_empleado;
                        mensaje = "Empleado agregado correctamente";
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsEditar)
                        {
                            if (this.ECredenciales != null)
                            {
                                if (this.ECredenciales.Password != eCredenciales.Password)
                                {
                                    rpta = ECredenciales.InsertarCredenciales(eCredenciales);
                                }
                            }
                        }
                        else
                        {                           
                            rpta = ECredenciales.InsertarCredenciales(eCredenciales);
                        }

                        if (!rpta.Equals("OK"))
                            Mensajes.MensajeInformacion("No se pudieron guardar las credenciales de ingreso", "Entendido");

                        if (this.IsEditar)
                            OnEmpleadoEditSuccess?.Invoke(eEmpleado, e);
                        else
                            OnEmpleadoAddSuccess?.Invoke(eEmpleado, e);

                        this.Close();
                        Mensajes.MensajeOkForm(mensaje);
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar un empleado", ex.Message);
            }
        }

        private void FrmNuevoEmpleado_Load(object sender, EventArgs e)
        {
            if (!this.IsEditar)
                this.LlenarListaCargo();
        }

        private void LlenarListaCargo()
        {
            this.listaCargo.Items.Clear();
            this.listaCargo.Items.Add("ADMINISTRADOR");
            this.listaCargo.Items.Add("SECRETARIO");
        }

        public void AsignarDatos(EEmpleados eEmpleado)
        {
            this.EEmpleado = eEmpleado;
            this.txtNombres.Text = eEmpleado.Nombre_empleado;
            this.txtCorreo.Text = eEmpleado.Correo_empleado;
            this.LlenarListaCargo();
            this.listaCargo.Text = eEmpleado.Tipo_empleado;
            this.Text = "Editar datos de un empleado";
            this.btnGuardar.Text = "Actualizar";

            if (eEmpleado.ECredenciales != null)
            {
                this.ECredenciales = eEmpleado.ECredenciales;
                this.txtPass1.Text = eEmpleado.ECredenciales.Password;
                this.txtPass2.Text = eEmpleado.ECredenciales.Password;
            }
        }

        private bool Comprobaciones(out EEmpleados eEmpleado, out ECredenciales eCredenciales)
        {
            eEmpleado = new EEmpleados();
            eCredenciales = new ECredenciales();

            if (this.txtNombres.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Verifique el campo nombres y apellidos", "Entendido");
                return false;
            }

            if (this.listaCargo.Text.Equals(string.Empty))
            {
                Mensajes.MensajeInformacion("Verifique el cargo", "Entendido");
                return false;
            }

            if (!this.txtPass1.Text.Equals(this.txtPass2.Text))
            {
                Mensajes.MensajeInformacion("Verifique las contraseñas, deben ser las mismas", "Entendido");
                return false;
            }

            if (IsEditar)
                eEmpleado.Id_empleado = this.EEmpleado.Id_empleado;

            eEmpleado.Nombre_empleado = this.txtNombres.Text;
            eEmpleado.Tipo_empleado = this.listaCargo.Text;
            eEmpleado.Correo_empleado = this.txtCorreo.Text;

            if (this.IsEditar)
                eEmpleado.Estado_empleado = this.EEmpleado.Estado_empleado;
            else
                eEmpleado.Estado_empleado = "ACTIVO";

            if (IsEditar)
                eCredenciales.Id_empleado = this.ECredenciales.Id_empleado;

            eCredenciales.Password = this.txtPass2.Text;
            eCredenciales.Fecha_modificacion = DateTime.Now;

            return true;
        }

        EEmpleados EEmpleado;
        ECredenciales ECredenciales;
        private bool _isEditar;

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
