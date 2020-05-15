using CapaEntidades;
using CapaPresentacion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsEstadosVehiculos
{
    public partial class FrmEstados : Form
    {
        public FrmEstados()
        {
            InitializeComponent();
            this.Load += FrmEstados_Load;
        }

        private void FrmEstados_Load(object sender, EventArgs e)
        {
            this.BuscarEstados("COMPLETO", "");
        }

        public event EventHandler OnEstadoClick;

        private void BuscarEstados(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtEstados = EEstados_vehiculos.BuscarEstados("COMPLETO", "", out string rpta);
                if (dtEstados != null)
                {
                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtEstados.Rows)
                    {
                        EEstados_vehiculos eEstado = new EEstados_vehiculos(row);
                        //Solo los estados habilitados
                        if (eEstado.Enabled.Equals("ACTIVO"))
                        {
                            EstadoSmall estadoSmall = new EstadoSmall
                            {
                                EEstados_Vehiculos = eEstado
                            };
                            estadoSmall.OnEstadoClick += EstadoSmall_OnEstadoClick;
                            controls.Add(estadoSmall);
                        }
                    }

                    if (controls.Count > 0)
                    {
                        this.panelEstados.BackgroundImage = null;
                        this.panelEstados.AddArrayControl(controls);
                    }
                    else
                    {
                        this.panelEstados.BackgroundImage = Resources.No_hay_estados;
                    }
                }
                else
                    if (!rpta.Equals("OK"))
                    throw new Exception(rpta);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarEstados",
                    "Hubo un error al buscar los estados", ex.Message);
            }
        }

        private void EstadoSmall_OnEstadoClick(object sender, EventArgs e)
        {
            this.OnEstadoClick?.Invoke(sender, e);
        }
    }
}
