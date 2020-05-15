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

namespace CapaPresentacion.Formularios.FormsCronograma
{
    public partial class FrmCronogramaVehiculos : Form
    {
        public FrmCronogramaVehiculos()
        {
            InitializeComponent();
            this.Load += FrmCronogramaVehiculos_Load;
            this.btnVehiculosSeleccionados.Click += BtnVehiculosSeleccionados_Click;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_OnCustomKeyPress;
            this.txtBusqueda.OnPxClick += TxtBusqueda_OnPxClick;
        }

        private void TxtBusqueda_OnPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Texto) || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarVehiculos("COMPLETO", "");
            }
            else
            {
                this.BuscarVehiculos("TODO", txt.Texto);
            }
        }

        private void TxtBusqueda_OnCustomKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Texto) || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarVehiculos("COMPLETO", "");
            }
            else
            {
                this.BuscarVehiculos("TODO", txt.Texto);
            }
        }

        private void BtnVehiculosSeleccionados_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmCronogramaVehiculos_Load(object sender, EventArgs e)
        {
            this.BuscarVehiculos("COMPLETO", "");
        }

        private void BuscarVehiculos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                DataTable dtVehiculos =
                  EVehiculos.BuscarVehiculos(tipo_busqueda, texto_busqueda, out string rpta);
                this.panelVehiculos.clearDataSource();
                if (dtVehiculos != null)
                {
                    this.panelVehiculos.BackgroundImage = null;
                    this.panelVehiculos.PageSize = 10;
                    this.panelVehiculos.OnBsPositionChanged += PanelVehiculos_OnBsPositionChanged;
                    this.panelVehiculos.SetPagedDataSource(dtVehiculos, this.bindingNavigator1);
                }
                else
                {
                    this.panelVehiculos.BackgroundImage = Properties.Resources.No_hay_vehiculos;
                    this.panelVehiculos.BackgroundImageLayout = ImageLayout.Center;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarVehiculos",
                    "Hubo un error al buscar los vehículos", ex.Message);
            }
        }

        private int positionChanged = 1;

        private void PanelVehiculos_OnBsPositionChanged(object sender, EventArgs e)
        {
            if (positionChanged != this.panelVehiculos.bs.Position)
            {
                DataTable dtVehiculos = (DataTable)sender;

                List<UserControl> controls = new List<UserControl>();

                foreach (DataRow row in dtVehiculos.Rows)
                {
                    EVehiculos eVehiculo = new EVehiculos(row);

                    ECronogramas eCronograma = new ECronogramas
                    {
                        EVehiculo = eVehiculo,
                        Fecha_cronograma = DateTime.Now,
                        Estado_cronograma = "ACTIVO",
                    };

                    VehiculoCronogramaSmall vehiculoCronogramaSmall = new VehiculoCronogramaSmall
                    {
                        ECronograma = eCronograma,
                    };

                    vehiculoCronogramaSmall.OnBtnOkClick += VehiculoCronogramaSmall_OnBtnOkClick;
                    controls.Add(vehiculoCronogramaSmall);
                }

                this.panelVehiculos.AddArrayControl(controls);
            }
        }

        private void VehiculoCronogramaSmall_OnBtnOkClick(object sender, EventArgs e)
        {
            VehiculoCronogramaSmall cronogramaSmall = (VehiculoCronogramaSmall)sender;

            if (this.Comprobaciones(cronogramaSmall, out ECronogramas eCronograma))
            {
                this.AgregarCronograma(eCronograma);
            }
        }

        private void AgregarCronograma(ECronogramas eCronograma)
        {
            this.CronogramasSeleccionados.Add(eCronograma);
        }

        private bool Comprobaciones(VehiculoCronogramaSmall cronogramaSmall, out ECronogramas eCronograma)
        {
            eCronograma = new ECronogramas();
            EVehiculos eVehiculo = cronogramaSmall.ECronograma.EVehiculo;
            //Buscar en la lista de vehículos seleccionados el id del vehículo del control
            List<ECronogramas> eCronogramas =
                this.CronogramasSeleccionados.Where(x => x.EVehiculo.Id_vehiculo == eVehiculo.Id_vehiculo).ToList();
            //Comprobar cantidad de resultados
            if (eCronogramas.Count > 0)
            {
                //Si el véhículo ya está en la lista devolvemos falso
                Mensajes.MensajeInformacion("El vehículo ya está en la lista", "Entendido");
                return false;
            }

            //Comprobar si no está en otro cronograma con la misma fecha
            DataTable dtCronogramas =
                  ECronogramas.BuscarCronogramas("FECHA ID VEHICULO",
                  cronogramaSmall.dateEstado.Value.ToString("yyyy-MM-dd"), eVehiculo.Id_vehiculo.ToString(), out string rpta);
            if (dtCronogramas != null)
            {
                //Si hay resultados significa que si hay un vehículo con una fecha en específico
                Mensajes.MensajeInformacion("El vehículo ya está programado para esta fecha", "Entendido");
                return false;
            }

            //Comprobar si se seleccionó un estado
            if (cronogramaSmall.btnEstado.Tag == null)
            {
                Mensajes.MensajeInformacion("Seleccione un estado", "Entendido");
                return false;
            }

            EEstados_vehiculos eEstado = (EEstados_vehiculos)cronogramaSmall.Tag;

            eCronograma.EEstado = eEstado;
            eCronograma.EVehiculo = eVehiculo;
            eCronograma.Fecha_cronograma = cronogramaSmall.dateEstado.Value;
            eCronograma.Estado_cronograma = "ACTIVO";

            return true;
        }

        private List<ECronogramas> _cronogramasSeleccionados;

        public List<ECronogramas> CronogramasSeleccionados
        {
            get => _cronogramasSeleccionados;
            set
            {
                _cronogramasSeleccionados = value;
                this.btnVehiculosSeleccionados.Text = value.Count + " vehículos seleccionados.";
            }
        }

    }
}
