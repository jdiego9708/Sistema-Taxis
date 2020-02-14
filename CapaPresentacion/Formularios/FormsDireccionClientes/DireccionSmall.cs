using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaPresentacion.Properties;

namespace CapaPresentacion.Formularios.FormsDireccionClientes
{
    public partial class DireccionSmall : UserControl
    {
        public DireccionSmall()
        {
            InitializeComponent();
            this.btnSiguiente.Click += BtnSiguiente_Click;
            this.btnEdit.Click += BtnEdit_Click;
        }

        private bool editMode;

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //SI el modo de editar está habilitado lo desactivamos
            if (editMode)
            {
                this.editMode = false;
                this.txtDireccion.ReadOnly = true;
                this.txtNumeroCasa.ReadOnly = true;
                this.txtReferencia.ReadOnly = true;
                this.txtBarrio.Cursor = Cursors.Default;

                this.btnSiguiente.BackgroundImage = Resources.right_arrow;
                this.btnEdit.BackgroundImage = Resources.pencil_32x32;
            }
            else
            {
                this.editMode = true;
                this.txtDireccion.ReadOnly = false;
                this.txtNumeroCasa.ReadOnly = false;
                this.txtReferencia.ReadOnly = false;
                this.txtBarrio.Cursor = Cursors.Hand;

                this.btnSiguiente.BackgroundImage = Resources.save;
                this.btnEdit.BackgroundImage = Resources.cancel_40px;
            }
        }

        public event EventHandler OnBtnDireccionSiguiente;

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                Mensajes.MensajeInformacion("Función en mantenimiento", "Entendido");
            }
            else
            {
                OnBtnDireccionSiguiente?.Invoke(this.EDireccion_Cliente, e);
            }        
        }

        public EDireccion_clientes EDireccion_Cliente;

        public void AsignarDatos(EDireccion_clientes eDireccion_Cliente)
        {
            this.EDireccion_Cliente = eDireccion_Cliente;
            this.txtDireccion.Text = eDireccion_Cliente.Direccion;
            this.txtNumeroCasa.Text = eDireccion_Cliente.Casa;
            this.txtBarrio.Text = eDireccion_Cliente.EBarrio.Nombre_barrio;
            this.txtReferencia.Text = eDireccion_Cliente.Referencia;
        }
    }
}
