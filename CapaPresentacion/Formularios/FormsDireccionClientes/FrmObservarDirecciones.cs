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

namespace CapaPresentacion.Formularios.FormsDireccionClientes
{
    public partial class FrmObservarDirecciones : Form
    {
        public FrmObservarDirecciones()
        {
            InitializeComponent();
        }

        public EClientes ECliente;

        private void BuscarDirecciones(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtDirecciones =
                    EDireccion_clientes.BuscarDireccion(tipo_busqueda, texto_busqueda, out string rpta);
                if (dtDirecciones != null)
                {
                    this.panelDirecciones.Enabled = true;
                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtDirecciones.Rows)
                    {
                        EDireccion_clientes eDireccion = new EDireccion_clientes(row);
                        DireccionSmall direccionSmall = new DireccionSmall();
                        direccionSmall.OnBtnDireccionSiguiente += DireccionSmall_OnBtnDireccionSiguiente;
                        direccionSmall.AsignarDatos(eDireccion);
                        controls.Add(direccionSmall);
                    }
                    this.panelDirecciones.AddArrayControl(controls);

                    if (dtDirecciones.Rows.Count == 1)
                    {
                        this.label1.Text = "Se encontró una dirección";
                    }
                    else if (dtDirecciones.Rows.Count > 1)
                    {
                        this.label1.Text = "Se encontraron " + dtDirecciones.Rows.Count + " direcciones";
                    }

                }
                else
                {
                    this.label1.Text = "No se encontró ninguna dirección";
                    this.panelDirecciones.Enabled = false;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarDirecciones",
                    "Hubo un error al buscar direcciones", ex.Message);
            }
        }

        private void DireccionSmall_OnBtnDireccionSiguiente(object sender, EventArgs e)
        {
            EDireccion_clientes eDireccion = (EDireccion_clientes)sender;
            eDireccion.ECliente = this.ECliente;
            OnBtnDireccionNext?.Invoke(eDireccion, e);
            this.Close();
        }

        public void AsignarDatos(EClientes eCliente)
        {
            this.ECliente = eCliente;
            this.BuscarDirecciones("ID CLIENTE", eCliente.Id_cliente.ToString());
        }

        public event EventHandler OnBtnDireccionNext;

        private bool _isCarrera;

        public bool IsCarrera { get => _isCarrera; set => _isCarrera = value; }
    }
}
