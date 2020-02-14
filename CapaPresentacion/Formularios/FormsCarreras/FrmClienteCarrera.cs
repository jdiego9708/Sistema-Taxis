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

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class FrmClienteCarrera : Form
    {
        public FrmClienteCarrera()
        {
            InitializeComponent();
        }

        public EClientes ECliente;

        public void AsignarDatos(EClientes eCliente, EDireccion_clientes eDireccion)
        {
            this.ECliente = eCliente;
            this.txtNombreCliente.Text = eCliente.Nombre_cliente;
            this.txtCelularCliente.Text = eCliente.Celular_cliente;

            this.txtDireccion.Text = eDireccion.Direccion;
            this.txtNumeroCasa.Text = eDireccion.Casa;
            this.txtReferencia.Text = eDireccion.Referencia;
            this.txtBarrio.Text = eDireccion.EBarrio.Nombre_barrio;
            this.txtCiudadela.Text = eDireccion.Ciudadela;
        }
    }
}
