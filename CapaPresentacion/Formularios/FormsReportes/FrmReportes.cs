using CapaEntidades;
using CapaPresentacion.Formularios.FormsVehiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsReportes
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
            this.rdListaVehiculos.CheckedChanged += RdListaVehiculos_CheckedChanged;
            this.rdVehiculo.CheckedChanged += RdVehiculo_CheckedChanged;
            this.rdTotal.CheckedChanged += RdTotal_CheckedChanged;
            this.rdRangoFechas.CheckedChanged += RdRangoFechas_CheckedChanged;
            this.rdTurno.CheckedChanged += RdTurno_CheckedChanged;
            this.btnSeleccionar.Click += BtnSeleccionar_Click;
            this.date1.ValueChanged += Date1_ValueChanged;
            this.Load += FrmReportes_Load;
            this.btnGenerar.Click += BtnGenerar_Click;
        }


        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            this.BuscarReporte();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            this.date1.MaxDate = DateTime.Now;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            FrmObservarVehiculos frmObservarVehiculos = new FrmObservarVehiculos
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frmObservarVehiculos.OnDgvDoubleClick += FrmObservarVehiculos_OnDgvDoubleClick;
            frmObservarVehiculos.ShowDialog();
        }

        private void FrmObservarVehiculos_OnDgvDoubleClick(object sender, EventArgs e)
        {
            EVehiculos eVehiculo = (EVehiculos)sender;
            this.btnSeleccionar.Text = "Vehículo seleccionado: " + eVehiculo.Id_vehiculo;
            this.btnSeleccionar.Tag = eVehiculo;
        }

        private void BuscarReporte()
        {
            try
            {
                DataTable dtResumenPrincipal = new DataTable();
                DataTable dtVehiculos = new DataTable();
                DataTable dtVehiculosEstado = new DataTable();
                DataTable dtCarrerasPerdidas = new DataTable();

                string rpta = "";
                bool searchComplete = false;
                if (rdTotal.Checked)
                {
                    if (this.rdVehiculo.Checked)
                    {
                        EVehiculos eVehiculo = (EVehiculos)this.btnSeleccionar.Tag;
                        dtResumenPrincipal =
                            ECarreras.BuscarCarrerasReporte(eVehiculo.Id_vehiculo, out dtVehiculos,
                            out dtVehiculosEstado, out rpta);

                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);

                        searchComplete = true;
                    }
                }
                else if (rdTurno.Checked)
                {
                    if (this.DtTurnos == null)
                    {
                        Mensajes.MensajeInformacion("No hay turnos para realizar la búsqueda", "Entendido");
                        return;
                    }

                    if (string.IsNullOrEmpty(this.listaTurnos.Text))
                    {
                        Mensajes.MensajeInformacion("Debe seleccionar un turno", "Entendido");
                        return;
                    }

                    if (!int.TryParse(Convert.ToString(this.listaTurnos.SelectedValue), out int id_turno))
                    {
                        Mensajes.MensajeInformacion("Hubo un error al recuperar el id del turno, debe ser solo números, valor seleccionado: " +
                             Convert.ToString(this.listaTurnos.SelectedValue), "Entendido");
                        return;
                    }

                    DataRow[] rows = this.DtTurnos.Select(string.Format("Id_turno = {0}", id_turno));
                    if (rows.Length <= 0)
                    {
                        Mensajes.MensajeInformacion("No se encontró el turno guardado", "Entendido");
                        return;
                    }

                    dtCarrerasPerdidas = ECarreras_perdidas.BuscarCarrerasPerdidas("ID TURNO", id_turno.ToString(), out rpta);

                    //Obtener las fechas
                    ETurnos eTurno = new ETurnos(rows[0]);
                    DateTime horaInicio = DateTime.Today.Add(eTurno.Hora_inicio_turno);
                    DateTime horaFin = DateTime.Today.Add(eTurno.Hora_fin_turno);
                    string hora1 = horaInicio.ToString("HH:mm");
                    string hora2 = horaFin.ToString("HH:mm");

                    if (this.rdVehiculo.Checked)
                    {
                        EVehiculos eVehiculo = (EVehiculos)this.btnSeleccionar.Tag;
                        dtResumenPrincipal =
                            ECarreras.BuscarCarrerasReporte(hora1, hora2, eTurno.Fecha_turno.ToString("yyyy-MM-dd"),
                            eVehiculo.Id_vehiculo, out dtVehiculos,
                            out dtVehiculosEstado, out rpta);

                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);

                        searchComplete = true;
                    }
                    else
                    {
                        dtResumenPrincipal =
                            ECarreras.BuscarCarrerasReporte(hora1, hora2, eTurno.Fecha_turno.ToString("yyyy-MM-dd"), out dtVehiculos,
                            out dtVehiculosEstado, out rpta);

                        if (!rpta.Equals("OK"))
                            throw new Exception(rpta);

                        searchComplete = true;
                    }
                }
                else
                {
                    dtResumenPrincipal =
                            ECarreras.BuscarCarrerasReporte(date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"),
                            out dtVehiculos, out dtVehiculosEstado, out rpta);

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);

                    searchComplete = true;
                }

                if (searchComplete)
                {
                    StringBuilder resumen = new StringBuilder();
                    if (dtResumenPrincipal != null)
                    {
                        int cantidadCancelada = 0;
                        DataRow[] rowsBusqueda =
                            dtResumenPrincipal.Select("Estado_carrera = 'CANCELADA' ");
                        if (rowsBusqueda.Length > 0)
                        {
                            string cant = Convert.ToString(rowsBusqueda[0]["CantidadServicios"]);
                            if (!int.TryParse(cant, out cantidadCancelada))
                            {
                                cantidadCancelada = 0;
                            }
                        }

                        int cantidadPendiente = 0;
                        rowsBusqueda =
                            dtResumenPrincipal.Select("Estado_carrera = 'PENDIENTE' ");
                        if (rowsBusqueda.Length > 0)
                        {
                            string cant = Convert.ToString(rowsBusqueda[0]["CantidadServicios"]);
                            if (!int.TryParse(cant, out cantidadPendiente))
                            {
                                cantidadPendiente = 0;
                            }
                        }

                        int cantidadTerminada = 0;
                        rowsBusqueda =
                            dtResumenPrincipal.Select("Estado_carrera = 'TERMINADA' ");
                        if (rowsBusqueda.Length > 0)
                        {
                            string cant = Convert.ToString(rowsBusqueda[0]["CantidadServicios"]);
                            if (!int.TryParse(cant, out cantidadTerminada))
                            {
                                cantidadTerminada = 0;
                            }
                        }

                        int cantidadPerdida = dtCarrerasPerdidas.Rows.Count;

                        resumen.Append("Resultados de carreras: ").Append(Environment.NewLine);
                        resumen.Append("Carreras canceladas: ").Append(cantidadCancelada).Append(" - ");
                        resumen.Append("Carreras pendientes: ").Append(cantidadPendiente).Append(" - ");
                        resumen.Append("Carreras terminadas: ").Append(cantidadTerminada).Append(" - ");
                        resumen.Append("Carreras perdidas: ").Append(cantidadPerdida);
                    }
                    else
                    {
                        resumen.Append("No se encontraron carreras");
                    }

                    this.txtResultados.Text = Convert.ToString(resumen);

                    if (dtVehiculos != null)
                    {
                        this.dgvReporte.clearDataSource();
                        this.dgvReporte.PageSize = 30;
                        this.dgvReporte.SetPagedDataSource(dtVehiculos, this.bindingNavigator1);

                        this.dgvReporte.Columns["Id_vehiculo"].HeaderText = "Código";
                        this.dgvReporte.Columns["CantidadServicios"].HeaderText = "Carreras";
                        this.dgvReporte.Columns["Propietario"].Visible = false;
                        this.dgvReporte.Columns["Color"].Visible = false;
                        this.dgvReporte.Columns["Estado_Vehiculo"].Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarReporte",
                    "Hubo un error al buscar reportes", ex.Message);
            }
        }

        public DataTable DtTurnos { get; set; }

        private void BuscarTurnos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.DtTurnos = ETurnos.BuscarTurnos("FECHA", texto_busqueda, out string rpta);
                if (DtTurnos != null)
                {
                    DataTable dtTurnos1 = new DataTable("Turnos");
                    dtTurnos1.Columns.Add("Id_turno", typeof(int));
                    dtTurnos1.Columns.Add("Turno", typeof(string));
                    foreach (DataRow row in DtTurnos.Rows)
                    {
                        ETurnos eTurno = new ETurnos(row);
                        DateTime inicioTurno = DateTime.Today.Add(eTurno.Hora_inicio_turno);
                        DateTime finTurno = DateTime.Today.Add(eTurno.Hora_fin_turno);
                        string displayText = "Inicio: " + inicioTurno.ToString("hh:mm tt") + " - Fin: " + finTurno.ToString("hh:mm tt");
                        DataRow newRow = dtTurnos1.NewRow();
                        newRow["Id_turno"] = eTurno.Id_turno;
                        newRow["Turno"] = displayText;
                        dtTurnos1.Rows.Add(newRow);
                    }

                    if (dtTurnos1.Rows.Count > 0)
                    {
                        this.listaTurnos.Enabled = true;
                        this.listaTurnos.DataSource = null;
                        this.listaTurnos.DataSource = dtTurnos1;
                        this.listaTurnos.DisplayMember = "Turno";
                        this.listaTurnos.ValueMember = "Id_turno";
                    }
                    else
                        this.listaTurnos.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarTurnos",
                                    "Hubo un error al buscar los turnos", ex.Message);
            }
        }

        private void Date1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker date1 = (DateTimePicker)sender;
                if (this.rdTurno.Checked)
                {
                    this.BuscarTurnos("FECHA", date1.Value.ToString("yyyy-MM-dd"));
                    return;
                }

                if (this.rdRangoFechas.Checked)
                {
                    this.date2.MinDate = date1.Value;
                    return;
                }
            }
            catch (Exception)
            {

            }
        }

        private void RdTurno_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.panelRangoFechas.Visible = true;
                this.lbl.Text = "Turno";
                this.listaTurnos.Visible = true;
                this.date2.Visible = false;
            }
        }

        private void RdRangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.panelRangoFechas.Visible = true;
                this.lbl.Text = "Fecha 2";
                this.listaTurnos.Visible = false;
                this.date2.Visible = true;
            }
        }

        private void RdTotal_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
                this.panelRangoFechas.Visible = false;
        }

        private void RdVehiculo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
                this.btnSeleccionar.Enabled = true;
        }

        private void RdListaVehiculos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                this.btnSeleccionar.Enabled = false;
                this.rdTotal.Enabled = false;
                this.rdRangoFechas.Checked = true;
            }
            else
                this.rdTotal.Enabled = true;

        }
    }
}
