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
    public partial class FrmVehiculoCarrera : Form
    {
        public FrmVehiculoCarrera()
        {
            InitializeComponent();
        }

        public EVehiculos EVehiculo;

        public void AsignarDatos(EVehiculos eVehiculo)
        {
            this.EVehiculo = eVehiculo;
            this.txtCodigo.Text = eVehiculo.Id_vehiculo.ToString();
            this.txtPlaca.Text = eVehiculo.Placa;
            this.txtChofer.Text = eVehiculo.Chofer;
            this.txtMarca.Text = eVehiculo.Marca;
            this.txtModelo.Text = eVehiculo.Modelo;
            this.txtColor.Text = eVehiculo.Color;
            this.txtPropietario.Text = eVehiculo.Propietario;
        }
    }
}
