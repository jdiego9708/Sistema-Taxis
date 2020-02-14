﻿using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using CapaPresentacion.Properties;
using System.Text;
using System.Timers;
using CapaPresentacion.Formularios.FormsClientes;
using CapaPresentacion.Formularios.FormsVehiculos;
using System.Configuration;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class FrmCarreras : Form
    {
        PoperContainer container;
        //private readonly KeyboardHookListener m_KeyboardHookManager;
        //private readonly MouseHookListener m_MouseHookManager;
        System.Timers.Timer aTimer;
        public FrmCarreras()
        {
            InitializeComponent();

            this.Load += FrmCarreras_Load;

            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;

            //m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            //m_MouseHookManager = new MouseHookListener(new GlobalHooker());
            //m_MouseHookManager.Enabled = true;
            //m_MouseHookManager.MouseDown += HookManager_MouseDown;
            //m_MouseHookManager.MouseUp += HookManager_MouseUp;

            this.btnAgregarCliente.Click += BtnAgregarCliente_Click;

            this.btnCarrerasCanceladas.Click += BtnCarrerasCanceladas_Click;
            this.btnCarrerasTerminadas.Click += BtnCarrerasTerminadas_Click;
            this.btnCarrerasEnCurso.Click += BtnCarrerasEnCurso_Click;
            this.btnReporte.Click += BtnReporte_Click;

            this.dgvCarreras.DoubleClick += DgvCarreras_DoubleClick;
            this.btnFinalizarTurno.Click += BtnFinalizarTurno_Click;
        }

        private void BtnFinalizarTurno_Click(object sender, EventArgs e)
        {
            this.ETurno.Hora_fin_turno = DateTime.Now.TimeOfDay;
            FrmTurno frmTurno = new FrmTurno
            {
                StartPosition = FormStartPosition.CenterScreen,
                ETurno = this.ETurno
            };
            frmTurno.FormClosed += FrmTurno_FormClosed;
            frmTurno.OnAbrirTurnoSuccess += FrmTurno_OnAbrirTurnoSuccess;
            frmTurno.OnCerrarTurnoSuccess += FrmTurno_OnCerrarTurnoSuccess;
            frmTurno.ShowDialog();

        }

        private void ChangeEnabledColorButton(string nameButton, GroupBox gb)
        {
            if (gb.Controls.Count > 0)
            {
                foreach (Control control in gb.Controls)
                {
                    if (control is Button btn)
                        if (btn.Name.Equals(nameButton))
                            btn.BackColor = Color.FromArgb(192, 255, 192);
                        else
                            btn.BackColor = Color.Transparent;
                }
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            int minutesDefault = this.Tiempo_predeterminado;
            if (this.CarrerasEnCurso != null)
            {
                foreach (ECarreras eCarrera in this.CarrerasEnCurso)
                {
                    //Asignar el tiempo transcurrido
                    TimeSpan diferenciaHoras = new TimeSpan();

                    DateTime horaInicio = new DateTime();
                    horaInicio = DateTime.Parse(eCarrera.Hora_carrera);

                    DateTime horaActual = new DateTime();
                    horaActual = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));

                    diferenciaHoras = horaActual - horaInicio;

                    int horas = diferenciaHoras.Hours;
                    int minutos = diferenciaHoras.Minutes;
                    int segundos = diferenciaHoras.Seconds;

                    if (minutos >= minutesDefault)
                    {
                        try
                        {
                            eCarrera.Estado_carrera = "TERMINADA";
                            string rpta =
                                ECarreras.EditarCarrera(eCarrera, eCarrera.Id_carrera);

                            BuscarCarrerasDelegate buscarCarrerasDelegate = new BuscarCarrerasDelegate(BuscarCarreras);
                            this.dgvCarreras.Invoke(buscarCarrerasDelegate);

                            BuscarVehiculosDelegate buscarVehiculosDelegate = new BuscarVehiculosDelegate(CargarVehiculos);
                            this.Invoke(buscarVehiculosDelegate);
                        }
                        catch (Exception)
                        { 

                        }
                    }
                }
            }
        }

        private void DgvCarreras_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow rowDataGrid = this.dgvCarreras.CurrentRow;
                if (rowDataGrid != null)
                {
                    DataRow row = ((DataRowView)rowDataGrid.DataBoundItem).Row;
                    int id_carrera = Convert.ToInt32(row["Id_carrera"]);
                    DataRow[] rows =
                        this.dtCarrerasCompleto.Select(string.Format("Id_carrera = '{0}' ", id_carrera));
                    if (rows.Length > 0)
                    {
                        ECarreras eCarrera = new ECarreras(rows[0]);
                        CarreraSmall carreraSmall = new CarreraSmall
                        {
                            ECarrera = eCarrera
                        };
                        carreraSmall.OnTerminarCarrera += CarreraSmall_OnTerminarCarrera;
                        carreraSmall.OnCancelarCarrera += CarreraSmall_OnCancelarCarrera;
                        this.container = new PoperContainer(carreraSmall);
                        this.container.Show(Cursor.Position);
                    }
                    else
                        throw new Exception("No encontramos esta carrera en la tabla de carreras principales");
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvCarreras_DoubleClick",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void Reporte(bool vistaPrevia, out string informacion)
        {
            MensajeEspera.ShowWait("Cargando reporte...");
            this.CargarVehiculos();
            this.BuscarCarreras();
            informacion = "";
            DataTable dtReporte = EDetalle_vehiculos_estado.BuscarDetalleVehiculos("ID TURNO",
                this.ETurno.Id_turno.ToString(), out string rpta);
            List<EDetalle_vehiculos_estado> eDetalleActivos = new List<EDetalle_vehiculos_estado>();
            List<EDetalle_vehiculos_estado> eDetalleTurno = new List<EDetalle_vehiculos_estado>();
            if (dtReporte != null)
            {
                foreach (DataRow row in dtReporte.Rows)
                {
                    EDetalle_vehiculos_estado eDetalle = new EDetalle_vehiculos_estado(row);
                    if (eDetalle.Estado.Equals("DE TURNO"))
                        eDetalleTurno.Add(eDetalle);
                    else if (eDetalle.Estado.Equals("ACTIVO"))
                        eDetalleActivos.Add(eDetalle);
                }
            }

            DataTable dtCarrerasPerdidas =
                ECarreras_perdidas.BuscarCarrerasPerdidas("ID TURNO",
                this.ETurno.Id_turno.ToString(), out rpta);

            bool report = false;
            StringBuilder info = new StringBuilder();
            DateTime horaStart = DateTime.Today.Add(this.ETurno.Hora_inicio_turno);
            info.Append("Inicio de turno: ").Append(this.ETurno.Fecha_turno.ToLongDateString() + " " + horaStart.ToString("hh:mm tt"));
            info.Append(Environment.NewLine);
            DateTime horaEnd = DateTime.Today.Add(this.ETurno.Hora_fin_turno);
            if (horaEnd.ToString("hh:mm tt").Equals(horaStart.ToString("hh:mm tt")))
            {
                info.Append("No se ha cerrado el turno");
                info.Append(Environment.NewLine);
            }
            else
            {
                info.Append("Fin de turno: ").Append(this.ETurno.Fecha_turno.ToLongDateString() + " " + horaEnd.ToString("hh:mm tt"));
                info.Append(Environment.NewLine);
            }

            info.Append("Empleado de turno: ").Append(this.ETurno.EEmpleado.Nombre_empleado);
            info.Append(Environment.NewLine);

            if (this.CarrerasTerminadas != null)
            {
                if (this.CarrerasTerminadas.Count > 0)
                {
                    info.Append("Carreras terminadas con éxito: ").Append(this.CarrerasTerminadas.Count);
                    report = true;
                }
                else
                    info.Append("No se realizaron carreras.");
            }
            else
                info.Append("No se realizaron carreras.");


            info.Append(Environment.NewLine);

            if (this.CarrerasCanceladas != null)
            {
                if (this.CarrerasCanceladas.Count > 0)
                {
                    info.Append("Carreras canceladas: ").Append(this.CarrerasCanceladas.Count);
                    report = true;
                }
                else
                    info.Append("No se cancelaron carreras.");
            }
            else
                info.Append("No se cancelaron carreras.");

            info.Append(Environment.NewLine);

            if (eDetalleActivos.Count > 0)
                info.Append("La cantidad de carros activos fue: ").Append(eDetalleActivos.Count);
            else
                info.Append("No se encontraron carros activos");

            info.Append(Environment.NewLine);

            if (eDetalleTurno.Count > 0)
                info.Append("La cantidad de carros de turno fue: ").Append(eDetalleTurno.Count);
            else
                info.Append("No se encontraron carros de turno");

            info.Append(Environment.NewLine);

            if (dtCarrerasPerdidas != null)
                info.Append("La cantidad de carreras perdidas fue: ").Append(dtCarrerasPerdidas.Rows.Count);
            else
                info.Append("No hay carreras perdidas");

            if (report)
            {
                FrmReporteCarrera reporteCarrera = new FrmReporteCarrera
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                reporteCarrera.AsignarReporte("Reporte de carreras", info.ToString());
                MensajeEspera.CloseForm();

                if (vistaPrevia)
                    reporteCarrera.ShowDialog();

                informacion = info.ToString();
            }
            else
                MensajeEspera.CloseForm();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            this.Reporte(true, out string info);
        }

        private void ComprobarTurnos()
        {
            //Primer paso, comprobar los turnos de hoy
            DataTable dtTurnos =
                ETurnos.BuscarTurnos("FECHA", DateTime.Now.ToString("yyyy-MM-dd"), out string rpta);
            if (dtTurnos != null)
            {
                ETurnos eTurno = new ETurnos(dtTurnos, 0);
                this.ETurno = eTurno;
                //El estado del turno puede ser ABIERTO, CERRADO
                if (eTurno.Estado_turno.Equals("CERRADO"))
                {
                    FrmTurno frmTurno = new FrmTurno
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        EEmpleado = this.EEmpleado
                    };
                    frmTurno.FormClosed += FrmTurno_FormClosed;
                    frmTurno.OnAbrirTurnoSuccess += FrmTurno_OnAbrirTurnoSuccess;
                    frmTurno.OnCerrarTurnoSuccess += FrmTurno_OnCerrarTurnoSuccess;
                    frmTurno.ShowDialog();
                }
                else
                {
                    FrmTurno frmTurno = new FrmTurno
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        ETurno = eTurno
                    };
                    frmTurno.FormClosed += FrmTurno_FormClosed;
                    frmTurno.OnAbrirTurnoSuccess += FrmTurno_OnAbrirTurnoSuccess;
                    frmTurno.OnCerrarTurnoSuccess += FrmTurno_OnCerrarTurnoSuccess;
                    frmTurno.ShowDialog();
                }
            }
            else
            {
                FrmTurno frmTurno = new FrmTurno
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    EEmpleado = this.EEmpleado
                };
                frmTurno.FormClosed += FrmTurno_FormClosed;
                frmTurno.OnAbrirTurnoSuccess += FrmTurno_OnAbrirTurnoSuccess;
                frmTurno.OnCerrarTurnoSuccess += FrmTurno_OnCerrarTurnoSuccess;
                frmTurno.ShowDialog();
            }
        }

        private void FrmTurno_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            if (form.DialogResult != DialogResult.OK)
            {
                this.ControlesEnabled(false);
            }
        }

        private void FrmCarreras_Load(object sender, EventArgs e)
        {
            this.ComprobarTurnos();
            //m_KeyboardHookManager.Enabled = true;
            //m_KeyboardHookManager.KeyPress += M_KeyboardHookManager_KeyPress;
        }

        private void ControlesEnabled(bool value)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = value;
            }
        }

        private void FrmTurno_OnCerrarTurnoSuccess(object sender, EventArgs e)
        {
            FrmTurno frmTurno = (FrmTurno)sender;

            //RadioButton rdVistaPrevia = frmTurno.rdVistaPrevia;
            //RadioButton rdDirecta = frmTurno.rdDirecta;
            string info = "";
            //if (rdDirecta.Checked)
            //{
            this.Reporte(false, out info);
            //}
            //else
            //{
            //    this.Reporte(false, out info);
            //}

            try
            {
                string correoTurno = Convert.ToString(ConfigurationManager.AppSettings["correoTurno"]);
                if (correoTurno.Equals("AUTOMATICO"))
                {
                    DataTable dtCorreos = ECorreos.BuscarCorreos("COMPLETO", "", out string rpta);
                    if (dtCorreos != null)
                    {
                        DataRow[] rows =
                            dtCorreos.Select(string.Format("Tipo_correo = '{0}'", "REPORTES"));
                        if (rows.Length > 0)
                        {
                            ECorreos eCorreo = new ECorreos(rows[0]);
                            string respuesta = EnviarEmailCarreras.SendEmail(info, eCorreo);
                            if (respuesta.Equals("OK"))
                                Mensajes.MensajeInformacion("Se envió el correo electrónico correctamente", "Entendido");
                            else
                                throw new Exception(rpta);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion("Hubo un error con el envío del correo electrónico, detalles: " + ex.Message, "Entendido");
            }

            this.ControlesEnabled(false);
            this.ETurno = null;
            OnTurnoTerminado?.Invoke(sender, e);
            this.Close();
        }

        public event EventHandler OnTurnoTerminado;

        private void FrmTurno_OnAbrirTurnoSuccess(object sender, EventArgs e)
        {
            FrmTurno frmTurno = (FrmTurno)sender;
            this.ControlesEnabled(true);
            this.ETurno = frmTurno.ETurno;
            
            this.ObtenerTiempoPredeterminado();

            this.BuscarCarreras();
            this.CargarVehiculos();

            int contador = 1;
            while (contador <= 3)
            {
                ClienteSmall clienteSmall = new ClienteSmall();
                clienteSmall.OnBtnRemover += ClienteSmall_OnBtnRemover;
                clienteSmall.OnBtnNext += ClienteSmall_OnBtnNext;
                clienteSmall.OnBtnCarreraPerdida += ClienteSmall_OnBtnCarreraPerdida;
                this.panelClientes.AddControl(clienteSmall);
                contador += 1;
            }

            this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
            this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;
            this.aTimer.Start();
        }

        #region CARRERAS
        List<ECarreras> CarrerasEnCurso { get; set; }
        List<ECarreras> CarrerasCanceladas { get; set; }
        List<ECarreras> CarrerasTerminadas { get; set; }

        private void BtnCarrerasEnCurso_Click(object sender, EventArgs e)
        {
            this.BuscarCarrerasLocal("CARRERAS EN CURSO");
            Button btn = (Button)sender;
            this.ChangeEnabledColorButton(btn.Name, this.gbCarreras);
        }

        private void BtnCarrerasTerminadas_Click(object sender, EventArgs e)
        {
            this.BuscarCarrerasLocal("CARRERAS TERMINADAS");
            Button btn = (Button)sender;
            this.ChangeEnabledColorButton(btn.Name, this.gbCarreras);
        }

        private void BtnCarrerasCanceladas_Click(object sender, EventArgs e)
        {
            this.BuscarCarrerasLocal("CARRERAS CANCELADAS");
            Button btn = (Button)sender;
            this.ChangeEnabledColorButton(btn.Name, this.gbCarreras);
        }

        private void BuscarCarrerasLocal(string tipo_busqueda)
        {
            try
            {
                this.dgvCarreras.clearDataSource();
                int pageSize = 10;

                this.dtBusqueda = new DataTable("dtBusqueda");
                this.dtBusqueda.Columns.Add("Id_carrera", typeof(int));
                this.dtBusqueda.Columns.Add("Hora", typeof(string));
                this.dtBusqueda.Columns.Add("Cliente", typeof(string));
                this.dtBusqueda.Columns.Add("Barrio", typeof(string));
                this.dtBusqueda.Columns.Add("Carro", typeof(string));
                this.dtBusqueda.Columns.Add("Tiempo", typeof(string));
                this.dtBusqueda.Columns.Add("Estado", typeof(string));

                if (tipo_busqueda.Equals("CARRERAS TERMINADAS"))
                {
                    if (this.CarrerasTerminadas != null)
                    {
                        if (this.CarrerasTerminadas.Count > 0)
                        {
                            this.dgvCarreras.BackgroundImage = null;
                            List<UserControl> controls = new List<UserControl>();
                            this.dgvCarreras.clearDataSource();
                            foreach (ECarreras eCarrera in this.CarrerasTerminadas)
                            {
                                DataRow newRow = this.dtBusqueda.NewRow();
                                newRow["Id_carrera"] = eCarrera.Id_carrera;
                                newRow["Hora"] = eCarrera.Hora_carrera;
                                newRow["Cliente"] = eCarrera.ECliente.Codigo_cliente;
                                newRow["Barrio"] = eCarrera.EDireccion.EBarrio.Nombre_barrio;
                                newRow["Carro"] = eCarrera.EVehiculo.Id_vehiculo;
                                newRow["Tiempo"] = eCarrera.Tiempo_llegada + " min";
                                newRow["Estado"] = eCarrera.Estado_carrera;
                                this.dtBusqueda.Rows.Add(newRow);
                            }

                            this.dgvCarreras.PageSize = pageSize;
                            this.dgvCarreras.SetPagedDataSource(dtBusqueda, this.bindingNavigator1);
                            this.dgvCarreras.Columns["Estado"].Visible = false;
                            this.dgvCarreras.Columns["Id_carrera"].Visible = false;
                        }
                        else
                        {
                            this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
                            this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;
                        }
                    }
                    else
                    {
                        this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
                        this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;
                    }

                    return;
                }

                if (tipo_busqueda.Equals("CARRERAS CANCELADAS"))
                {
                    if (this.CarrerasCanceladas != null)
                    {
                        if (this.CarrerasCanceladas.Count > 0)
                        {

                            this.dgvCarreras.BackgroundImage = null;
                            List<UserControl> controls = new List<UserControl>();
                            this.dgvCarreras.clearDataSource();
                            foreach (ECarreras eCarrera in this.CarrerasCanceladas)
                            {
                                DataRow newRow = this.dtBusqueda.NewRow();
                                newRow["Id_carrera"] = eCarrera.Id_carrera;
                                newRow["Hora"] = eCarrera.Hora_carrera;
                                newRow["Cliente"] = eCarrera.ECliente.Codigo_cliente;
                                newRow["Barrio"] = eCarrera.EDireccion.EBarrio.Nombre_barrio;
                                newRow["Carro"] = eCarrera.EVehiculo.Id_vehiculo;
                                newRow["Tiempo"] = eCarrera.Tiempo_llegada + " min";
                                newRow["Estado"] = eCarrera.Estado_carrera;
                                this.dtBusqueda.Rows.Add(newRow);
                            }

                            this.dgvCarreras.PageSize = pageSize;
                            this.dgvCarreras.SetPagedDataSource(dtBusqueda, this.bindingNavigator1);
                            this.dgvCarreras.Columns["Estado"].Visible = false;
                            this.dgvCarreras.Columns["Id_carrera"].Visible = false;
                        }
                        else
                        {
                            this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
                            this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;
                        }
                    }
                    else
                    {
                        this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
                        this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;
                    }

                    return;
                }

                if (tipo_busqueda.Equals("CARRERAS EN CURSO"))
                {
                    if (this.CarrerasEnCurso != null)
                    {
                        if (this.CarrerasEnCurso.Count > 0)
                        {
                            this.dgvCarreras.BackgroundImage = null;
                            List<UserControl> controls = new List<UserControl>();
                            this.dgvCarreras.clearDataSource();
                            foreach (ECarreras eCarrera in this.CarrerasEnCurso)
                            {
                                DataRow newRow = this.dtBusqueda.NewRow();
                                newRow["Id_carrera"] = eCarrera.Id_carrera;
                                newRow["Hora"] = eCarrera.Hora_carrera;
                                newRow["Cliente"] = eCarrera.ECliente.Codigo_cliente;
                                newRow["Barrio"] = eCarrera.EDireccion.EBarrio.Nombre_barrio;
                                newRow["Carro"] = eCarrera.EVehiculo.Id_vehiculo;
                                newRow["Tiempo"] = eCarrera.Tiempo_llegada + " min";
                                newRow["Estado"] = eCarrera.Estado_carrera;
                                this.dtBusqueda.Rows.Add(newRow);
                            }

                            this.dgvCarreras.PageSize = pageSize;
                            this.dgvCarreras.SetPagedDataSource(dtBusqueda, this.bindingNavigator1);
                            this.dgvCarreras.Columns["Estado"].Visible = false;
                            this.dgvCarreras.Columns["Id_carrera"].Visible = false;
                        }
                        else
                        {
                            this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
                            this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;
                        }
                    }
                    else
                    {
                        this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
                        this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;
                    }

                    return;
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarCarrerasLocal",
                    "Hubo un error buscando las carreras localmente", ex.Message);
            }
        }

        private void BuscarCarreras()
        {
            try
            {
                this.dtCarrerasCompleto =
                    ECarreras.BuscarCarreras("COMPLETO ID TURNO", this.ETurno.Id_turno.ToString(),
                    out string rpta);

                this.CarrerasEnCurso = new List<ECarreras>();
                this.CarrerasTerminadas = new List<ECarreras>();
                this.CarrerasCanceladas = new List<ECarreras>();

                this.dgvCarreras.clearDataSource();

                if (dtCarrerasCompleto != null)
                {
                    this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
                    this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;

                    string medida_tiempo = "min";

                    this.dtBusqueda = new DataTable("dtBusqueda");
                    this.dtBusqueda.Columns.Add("Id_carrera", typeof(int));
                    this.dtBusqueda.Columns.Add("Hora", typeof(string));
                    this.dtBusqueda.Columns.Add("Cliente", typeof(string));
                    this.dtBusqueda.Columns.Add("Barrio", typeof(string));
                    this.dtBusqueda.Columns.Add("Carro", typeof(string));
                    this.dtBusqueda.Columns.Add("Tiempo", typeof(string));
                    this.dtBusqueda.Columns.Add("Estado", typeof(string));

                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtCarrerasCompleto.Rows)
                    {
                        ECarreras eCarrera = new ECarreras(row);
                        if (eCarrera.Estado_carrera.Equals("PENDIENTE"))
                        {
                            this.dgvCarreras.BackgroundImage = null;
                            this.CarrerasEnCurso.Add(eCarrera);
                            //CarreraSmall carreraSmall = new CarreraSmall
                            //{
                            //    ECarrera = eCarrera,
                            //    MinutesDefault = 5
                            //};
                            //carreraSmall.OnTerminarCarrera += CarreraSmall_OnTerminarCarrera;
                            //controls.Add(carreraSmall);

                        }
                        else if (eCarrera.Estado_carrera.Equals("CANCELADA"))
                        {
                            this.CarrerasCanceladas.Add(eCarrera);
                        }
                        else
                        {
                            this.CarrerasTerminadas.Add(eCarrera);
                        }

                        DataRow newRow = this.dtBusqueda.NewRow();
                        newRow["Id_carrera"] = eCarrera.Id_carrera;
                        newRow["Hora"] = eCarrera.Hora_carrera;
                        newRow["Cliente"] = eCarrera.ECliente.Codigo_cliente;
                        newRow["Barrio"] = eCarrera.EDireccion.EBarrio.Nombre_barrio;
                        newRow["Carro"] = eCarrera.EVehiculo.Id_vehiculo;
                        newRow["Tiempo"] = eCarrera.Tiempo_llegada + " " + medida_tiempo;
                        newRow["Estado"] = eCarrera.Estado_carrera;
                        this.dtBusqueda.Rows.Add(newRow);
                    }

                    if (this.CarrerasEnCurso != null)
                        if (this.CarrerasEnCurso.Count > 0)
                            this.btnCarrerasEnCurso.PerformClick();

                    //this.dgvCarreras.PageSize = pageSize;
                    //this.dgvCarreras.SetPagedDataSource(dtBusqueda, this.bindingNavigator1);
                    //this.dgvCarreras.Columns["Estado"].Visible = false;
                    //this.dgvCarreras.Columns["Id_carrera"].Visible = false;
                }
                else
                {
                    this.dgvCarreras.BackgroundImage = Resources.No_hay_carreras;
                    this.dgvCarreras.BackgroundImageLayout = ImageLayout.Center;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarCarreras()",
                    "Hubo un error al buscar las carreras", ex.Message);
            }
        }

        public delegate void BuscarCarrerasDelegate();
        public delegate void BuscarVehiculosDelegate();
        private void CarreraSmall_OnCancelarCarrera(object sender, EventArgs e)
        {
            if (this.container != null)
            {
                this.container.Close();
                this.container = null;
            }

            CarreraSmall carreraSmall = (CarreraSmall)sender;
            ECarreras eCarrera = carreraSmall.ECarrera;
            eCarrera.Estado_carrera = "CANCELADA";
            string rpta = ECarreras.EditarCarrera(eCarrera, eCarrera.Id_carrera);
            if (rpta.Equals("OK"))
            {
                BuscarCarrerasDelegate buscarCarrerasDelegate = new BuscarCarrerasDelegate(BuscarCarreras);
                carreraSmall.Invoke(buscarCarrerasDelegate);

                BuscarVehiculosDelegate buscarVehiculosDelegate = new BuscarVehiculosDelegate(CargarVehiculos);
                this.Invoke(buscarVehiculosDelegate);
            }
            else
            {
                Mensajes.MensajeInformacion("Hubo un error al cancelar una carrera", "Entendido");
            }
        }

        private void CarreraSmall_OnTerminarCarrera(object sender, EventArgs e)
        {
            if (this.container != null)
            {
                this.container.Close();
                this.container = null;
            }

            CarreraSmall carreraSmall = (CarreraSmall)sender;
            ECarreras eCarrera = carreraSmall.ECarrera;
            eCarrera.Estado_carrera = "TERMINADA";
            string rpta = ECarreras.EditarCarrera(eCarrera, eCarrera.Id_carrera);
            if (rpta.Equals("OK"))
            {
                BuscarCarrerasDelegate buscarCarrerasDelegate = new BuscarCarrerasDelegate(BuscarCarreras);
                carreraSmall.Invoke(buscarCarrerasDelegate);

                BuscarVehiculosDelegate buscarVehiculosDelegate = new BuscarVehiculosDelegate(CargarVehiculos);
                this.Invoke(buscarVehiculosDelegate);
            }
            else
            {
                Mensajes.MensajeInformacion("Hubo un error al terminar una carrera", "Entendido");
            }
        }

        public DataTable dtBusqueda { get; set; }
        public DataTable dtCarrerasCompleto { get; set; }

        #endregion

        private int _tiempo_predeterminado;

        public int Tiempo_predeterminado { get => _tiempo_predeterminado; set => _tiempo_predeterminado = value; }
        private void ObtenerTiempoPredeterminado()
        {
            string time = Convert.ToString(ConfigurationManager.AppSettings["tiempoPredeterminado"]);
            if (int.TryParse(time, out int tiempo))
                this.Tiempo_predeterminado = tiempo;
            else
            {
                Mensajes.MensajeInformacion("No se pudo obtener el tiempo prederminado, el valor por defecto es 5 min", "Entendido");
                this.Tiempo_predeterminado = 5;
            }
        }

        #region CLIENTES
        private void BtnAgregarCliente_Click(object sender, EventArgs e)
        {
            ClienteSmall clienteSmall = new ClienteSmall();
            clienteSmall.OnBtnRemover += ClienteSmall_OnBtnRemover;
            clienteSmall.OnBtnNext += ClienteSmall_OnBtnNext;
            clienteSmall.OnBtnCarreraPerdida += ClienteSmall_OnBtnCarreraPerdida;
            this.panelClientes.AddControl(clienteSmall);
        }

        private void ClienteSmall_OnBtnCarreraPerdida(object sender, EventArgs e)
        {
            EDireccion_clientes eDireccion = (EDireccion_clientes)sender;
            EClientes eCliente = eDireccion.ECliente;

            ECarreras_perdidas eCarreraPerdida = new ECarreras_perdidas
            {
                ECliente = eCliente,
                ETurno = this.ETurno
            };
            string rpta = ECarreras_perdidas.InsertarCarreraPerdida(eCarreraPerdida);
            if (!rpta.Equals("OK"))
            {
                Mensajes.MensajeInformacion("No se pudo insertar la carrera perdida, detalles: " + rpta, "Entendido");
            }
        }

        private void ClienteSmall_OnBtnNext(object sender, EventArgs e)
        {
            CodigoVehiculo CodigoVehiculo = (CodigoVehiculo)sender;
            string codigo = CodigoVehiculo.txtCodigo.Text;
            string id_cliente = CodigoVehiculo.EDireccion.ECliente.Id_cliente.ToString();
            if (!codigo.Equals(""))
            {
                if (this.panelVehiculos.Controls.Count < 1)
                    return;

                List<EDetalle_vehiculos_estado> eDetalles = new List<EDetalle_vehiculos_estado>();
                foreach (Button btn in this.panelVehiculos.Controls)
                {
                    if (btn.Tag != null)
                    {
                        EDetalle_vehiculos_estado eDetalle = (EDetalle_vehiculos_estado)btn.Tag;
                        eDetalles.Add(eDetalle);
                    }
                }

                if (eDetalles.Count > 0)
                {
                    IEnumerable<EDetalle_vehiculos_estado> filtering =
                        from x in eDetalles
                        where x.EVehiculo.Id_vehiculo.ToString() == codigo
                        select x;

                    eDetalles = new List<EDetalle_vehiculos_estado>();
                    eDetalles = filtering.ToList();

                    if (eDetalles.Count > 0)
                    {
                        string estado = eDetalles[0].Estado;

                        if (string.IsNullOrEmpty(estado))
                            estado = "INACTIVO";

                        if (estado.Equals("INACTIVO"))
                        {
                            Mensajes.MensajeInformacion("El carro está inactivo", "Entendido");
                            return;
                        }
                        else
                        {
                            IEnumerable<ECarreras> filtering1 =
                            from y in CarrerasEnCurso
                            where y.EVehiculo.Id_vehiculo.ToString() == codigo
                            select y;

                            List<ECarreras> eDetalles1 = new List<ECarreras>();
                            eDetalles1 = filtering1.ToList();

                            if (eDetalles1.Count > 0)
                            {
                                Mensajes.MensajeInformacion("El carro se encuentra en otra carrera", "Entendido");
                                return;
                            }

                            IEnumerable<ECarreras> filtering2 =
                            from y in CarrerasEnCurso
                            where y.ECliente.Id_cliente.ToString() == id_cliente
                            select y;

                            List<ECarreras> eDetalles2 = new List<ECarreras>();
                            eDetalles2 = filtering2.ToList();

                            //if (eDetalles2.Count > 0)
                            //{
                            //    Mensajes.MensajeInformacion("El cliente se encuentra en otra carrera", "Entendido");
                            //    return;
                            //}

                            //Asignar carrera
                            ECarreras eCarrera = new ECarreras
                            {
                                ECliente = CodigoVehiculo.EDireccion.ECliente,
                                EDireccion = CodigoVehiculo.EDireccion,
                                EVehiculo = eDetalles[0].EVehiculo,
                                EEmpleado = new EEmpleados { Id_empleado = 1 },
                                ETurno = this.ETurno,
                                Fecha_carrera = DateTime.Now,
                                Hora_carrera = DateTime.Now.ToString("HH:mm:ss"),
                                Lugar_ubicacion = "",
                                Tiempo_llegada = this.Tiempo_predeterminado,
                                Estado_carrera = "PENDIENTE",
                                Observaciones = ""
                            };

                            string rpta = ECarreras.InsertarCarrera(eCarrera, out int id_carrera);
                            if (rpta.Equals("OK"))
                            {
                                this.BuscarCarreras();
                            }
                            else
                                Mensajes.MensajeInformacion("Hubo un error al asignar la carrera, detalles: " +
                                   rpta, "Entendido");
                        }
                    }
                    else
                        Mensajes.MensajeInformacion("No se encontró el vehículo registrado", "Entendido");
                }
                else
                    Mensajes.MensajeInformacion("No se encontró el vehículo registrado", "Entendido");
            }
        }

        private void ClienteSmall_OnBtnRemover(object sender, EventArgs e)
        {
            ClienteSmall clienteSmall = (ClienteSmall)sender;
            if (this.panelClientes.controlsUser.Count > 1)
            {
                if (this.panelClientes.controlsUser.Contains(clienteSmall))
                {
                    this.panelClientes.RemoveControl(clienteSmall);
                }
                else
                    Mensajes.MensajeInformacion("No se encontró el cliente en la lista", "Entendido");
            }
            else
                Mensajes.MensajeInformacion("No se pueden remover todos los clientes", "Entendido");
        }

        private void ActivateHotKey()
        {
            //m_MouseHookManager = new MouseHookListener(new GlobalHooker());
            //m_MouseHookManager.Enabled = true;
            //m_MouseHookManager.MouseDown += HookManager_MouseDown;
            //m_MouseHookManager.MouseUp += HookManager_MouseUp;
        }
        FrmNuevoCliente frmNuevoCliente;
        FrmNuevoVehiculo frmNuevoVehiculo;
        private void M_KeyboardHookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.F5)
            {
                if (frmNuevoCliente == null)
                {
                    frmNuevoCliente = new FrmNuevoCliente
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    frmNuevoCliente.OnClienteAddSuccess += FrmNuevoCliente_OnClienteAddSuccess;
                }
                frmNuevoCliente.ShowDialog();
                return;
            }

            if ((int)e.KeyChar == (int)Keys.F6)
            {
                if (frmNuevoVehiculo == null)
                {
                    frmNuevoVehiculo = new FrmNuevoVehiculo
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    frmNuevoVehiculo.OnVehiculoAddSuccess += FrmNuevoVehiculo_OnVehiculoAddSuccess;
                }
                frmNuevoVehiculo.ShowDialog();
                return;
            }
        }

        private void FrmNuevoVehiculo_OnVehiculoAddSuccess(object sender, EventArgs e)
        {
            if (this.frmNuevoVehiculo != null)
                this.frmNuevoVehiculo.Close();
        }

        private void FrmNuevoCliente_OnClienteAddSuccess(object sender, EventArgs e)
        {
            if (this.frmNuevoCliente != null)
                this.frmNuevoVehiculo.Close();
        }
        #endregion

        #region VEHÍCULOS

        private void BtnTurno_Click(object sender, EventArgs e)
        {
            this.BuscarVehiculosLocal("ESTADO", "DE TURNO");
        }

        private void BtnInactivos_Click(object sender, EventArgs e)
        {
            this.BuscarVehiculosLocal("ESTADO", "INACTIVO");
        }

        private void BtnActivos_Click(object sender, EventArgs e)
        {
            this.BuscarVehiculosLocal("ESTADO", "ACTIVO");
        }

        private void BtnActualizarVehiculos_Click(object sender, EventArgs e)
        {
            this.CargarVehiculos();
        }

        private void CargarVehiculos()
        {
            try
            {
                //Cargo los vehículos de la base de datos
                this.DtVehiculos =
                            EDetalle_vehiculos_estado.BuscarDetalleVehiculosCarreras("COMPLETO TURNO",
                            this.ETurno.Id_turno.ToString(), out string rpta);
                this.panelVehiculos.clearDataSource();
                if (DtVehiculos != null)
                {
                    int contador = 1;

                    List<Control> controls = new List<Control>();

                    foreach (DataRow row in DtVehiculos.Rows)
                    {
                        //Guardamos el estado
                        string estado = Convert.ToString(row["Estado"]);
                        int CantidadServicios = 0;
                        if (DtVehiculos.Columns.Contains("CantidadServicios"))
                        {
                            //Verificamos la cantidad de servicios
                            string servicios = Convert.ToString(row["CantidadServicios"]);
                            if (int.TryParse(servicios, out CantidadServicios))
                                row["CantidadServicios"] = CantidadServicios.ToString();
                            else
                                row["CantidadServicios"] = "0";
                        }

                        //SI el estado es null o vacío significa que está INACTIVO
                        if (string.IsNullOrEmpty(estado) || estado.Equals("INACTIVO"))
                        {
                            EVehiculos eVehiculo = new EVehiculos(row);

                            EDetalle_vehiculos_estado eDetalle;

                            if (estado.Equals("INACTIVO"))
                            {
                                eDetalle = new EDetalle_vehiculos_estado(row);
                            }
                            else
                            {
                                eDetalle = new EDetalle_vehiculos_estado
                                {
                                    Id_detalle_vehiculo = 0,
                                    EVehiculo = eVehiculo,
                                    ETurno = this.ETurno,
                                    Fecha = DateTime.Now,
                                    Estado = estado
                                };
                            }

                            #region Botón personalizado inactivo
                            Button btnVehiculoInactivo = new Button();
                            btnVehiculoInactivo.Cursor = Cursors.Hand;
                            btnVehiculoInactivo.BackColor = Color.FromArgb(251, 70, 70);
                            btnVehiculoInactivo.FlatAppearance.BorderColor = Color.FromArgb(251, 70, 70);
                            btnVehiculoInactivo.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 70, 70);
                            btnVehiculoInactivo.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 139, 139);
                            btnVehiculoInactivo.FlatStyle = FlatStyle.Flat;
                            btnVehiculoInactivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                            btnVehiculoInactivo.ForeColor = Color.FromArgb(234, 232, 229);
                            btnVehiculoInactivo.Size = new Size(89, 63);
                            btnVehiculoInactivo.TextAlign = ContentAlignment.TopCenter;
                            btnVehiculoInactivo.UseVisualStyleBackColor = false;
                            btnVehiculoInactivo.Tag = eDetalle;
                            btnVehiculoInactivo.Name = "btn" + contador;
                            btnVehiculoInactivo.Text = "Carro" + Environment.NewLine + eDetalle.EVehiculo.Id_vehiculo.ToString() +
                                Environment.NewLine + "CR = " + CantidadServicios;
                            btnVehiculoInactivo.MouseUp += BtnVehiculo_MouseUp;
                            controls.Add(btnVehiculoInactivo);
                            this.toolTip1.SetToolTip(btnVehiculoInactivo, "Cantidad de servicios: " + CantidadServicios);
                            #endregion
                        }
                        else
                        {
                            EDetalle_vehiculos_estado eDetalle = new EDetalle_vehiculos_estado(row);
                            if (estado.Equals("ACTIVO"))
                            {
                                #region Botón personalizado activo
                                Button btnVehiculoActivo = new Button();
                                btnVehiculoActivo.Cursor = Cursors.Hand;
                                btnVehiculoActivo.BackColor = Color.FromArgb(106, 246, 64);
                                btnVehiculoActivo.FlatAppearance.BorderColor = Color.FromArgb(106, 246, 64);
                                btnVehiculoActivo.FlatAppearance.MouseDownBackColor = Color.Lime;
                                btnVehiculoActivo.FlatAppearance.MouseOverBackColor = Color.FromArgb(131, 212, 96);
                                btnVehiculoActivo.FlatStyle = FlatStyle.Flat;
                                btnVehiculoActivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                btnVehiculoActivo.ForeColor = Color.FromArgb(92, 92, 92);
                                btnVehiculoActivo.Size = new Size(89, 63);
                                btnVehiculoActivo.TextAlign = ContentAlignment.TopCenter;
                                btnVehiculoActivo.UseVisualStyleBackColor = false;
                                btnVehiculoActivo.Tag = eDetalle;
                                btnVehiculoActivo.MouseUp += BtnVehiculo_MouseUp;
                                btnVehiculoActivo.Name = "btn" + contador;
                                btnVehiculoActivo.Text = "Carro" + Environment.NewLine + eDetalle.EVehiculo.Id_vehiculo.ToString() +
                                Environment.NewLine + "CR = " + CantidadServicios; ;
                                controls.Add(btnVehiculoActivo);
                                this.toolTip1.SetToolTip(btnVehiculoActivo, "Cantidad de servicios: " + CantidadServicios);

                                #endregion
                            }
                            else if (estado.Equals("DE TURNO"))
                            {
                                #region Botón personalizado de turno
                                Button btnVehiculoTurno = new Button();
                                btnVehiculoTurno.BackColor = Color.FromArgb(254, 173, 76);
                                btnVehiculoTurno.Cursor = Cursors.Hand;
                                btnVehiculoTurno.FlatAppearance.BorderColor = Color.FromArgb(254, 173, 76);
                                btnVehiculoTurno.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 173, 76);
                                btnVehiculoTurno.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 212, 140);
                                btnVehiculoTurno.FlatStyle = FlatStyle.Flat;
                                btnVehiculoTurno.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                btnVehiculoTurno.ForeColor = Color.FromArgb(92, 92, 92);
                                btnVehiculoTurno.Size = new Size(89, 63);
                                btnVehiculoTurno.TextAlign = ContentAlignment.TopCenter;
                                btnVehiculoTurno.UseVisualStyleBackColor = false;
                                btnVehiculoTurno.Tag = eDetalle;
                                btnVehiculoTurno.Name = "btn" + contador;
                                btnVehiculoTurno.Text = "Carro" + Environment.NewLine + eDetalle.EVehiculo.Id_vehiculo.ToString() +
                                Environment.NewLine + "CR = " + CantidadServicios; ;
                                btnVehiculoTurno.MouseUp += BtnVehiculo_MouseUp;
                                controls.Add(btnVehiculoTurno);
                                this.toolTip1.SetToolTip(btnVehiculoTurno, "Cantidad de servicios: " + CantidadServicios);

                                #endregion
                            }
                        }
                    }

                    this.panelVehiculos.AddArrayControl(controls);
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "CargarVehiculos()",
                    "Hubo un error cargando los vehículos", ex.Message);
            }
        }

        private void BtnVehiculo_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    Button btn = (Button)sender;
            //    EDetalle_vehiculos_estado eDetalle = (EDetalle_vehiculos_estado)btn.Tag;
            //    if (string.IsNullOrEmpty(eDetalle.Estado) ||
            //        eDetalle.Estado.Equals("INACTIVO"))
            //    {
            //        return;
            //    }

            //    if (this.CarrerasEnCurso != null)
            //    {
            //        IEnumerable<ECarreras> Carreras =
            //        from car in this.CarrerasEnCurso
            //        where car.EVehiculo.Id_vehiculo == eDetalle.EVehiculo.Id_vehiculo
            //        select car;

            //        List<ECarreras> CarrerasEnCurso = Carreras.ToList();

            //        if (CarrerasEnCurso.Count > 0)
            //        {
            //            Mensajes.MensajeInformacion("El vehículo se encuentra ocupado en otra carrera", "Entendido");
            //            return;
            //        }
            //    }
            //    return;
            //}
            if (e.Button == MouseButtons.Left)
            {
                Button btn = (Button)sender;
                EDetalle_vehiculos_estado eDetalle = (EDetalle_vehiculos_estado)btn.Tag;

                if (this.container != null)
                {
                    this.container.Close();
                    this.container = null;
                }

                string estado = eDetalle.Estado;

                //if (string.IsNullOrEmpty(estado))
                //    estado = "INACTIVO";

                OpcionesEstadoVehiculo opcionesEstadoVehiculo = new OpcionesEstadoVehiculo
                {
                    EstadoActual = estado,
                    EVehiculo = eDetalle.EVehiculo,
                    EDetalle = eDetalle
                };
                opcionesEstadoVehiculo.OnCambiarEstado += OpcionesEstadoVehiculo_OnCambiarEstado;
                this.container = new PoperContainer(opcionesEstadoVehiculo);
                this.container.Show(btn);
            }
        }

        private void OpcionesEstadoVehiculo_OnCambiarEstado(object sender, EventArgs e)
        {
            OpcionesEstadoVehiculo opcionesEstadoVehiculo = (OpcionesEstadoVehiculo)sender;

            if (this.container != null)
            {
                this.container.Close();
                this.container = null;
            }

            if (opcionesEstadoVehiculo.EstadoActual.Equals(""))
            {
                //Insertar en detalle de estado de vehículo
                EDetalle_vehiculos_estado eDetalle = new EDetalle_vehiculos_estado
                {
                    Fecha = DateTime.Now,
                    EVehiculo = opcionesEstadoVehiculo.EVehiculo,
                    ETurno = this.ETurno,
                    Estado = opcionesEstadoVehiculo.EstadoSeleccionado
                };
                string rpta =
                    EDetalle_vehiculos_estado.InsertarDetaleVehiculo(eDetalle, out int id_detalle);
                if (rpta.Equals("OK"))
                {
                    this.CargarVehiculos();
                }
                else
                    Mensajes.MensajeErrorCompleto(this.Name, "OpcionesEstadoVehiculo_OnCambiarEstado",
                        "Hubo un error al insertar el estado de un vehículo", rpta);
            }
            else
            {
                //DataTable dt = (DataTable)this.dgvVehiculos.DataSource;
                //var resultados = from x in dt.Rows.Cast<DataRow>()
                //                 where Convert.ToInt32(x["Id_vehiculo"]) ==
                //                    opcionesEstadoVehiculo.EVehiculo.Id_vehiculo
                //                 select x;
                //List<DataRow> list = resultados.ToList();

                EDetalle_vehiculos_estado eDetalle = opcionesEstadoVehiculo.EDetalle;
                eDetalle.Estado = opcionesEstadoVehiculo.EstadoSeleccionado;
                string rpta = EDetalle_vehiculos_estado.EditarDetaleVehiculo(eDetalle, eDetalle.Id_detalle_vehiculo);
                if (rpta.Equals("OK"))
                {
                    //Mensajes.MensajeOkForm("Se cambió el estado del vehículo correctamente");
                    this.CargarVehiculos();
                }
                else
                    Mensajes.MensajeErrorCompleto(this.Name, "OpcionesEstadoVehiculo_OnCambiarEstado",
                        "Hubo un error al insertar el estado de un vehículo", rpta);
            }
        }

        private void BuscarVehiculosLocal(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                if (this.DtVehiculos != null)
                {
                    DataTable dtResultados = this.DtVehiculos.Clone();
                    if (tipo_busqueda.Equals("CODIGO"))
                    {
                        if (int.TryParse(texto_busqueda, out int codigo))
                        {
                            DataRow[] filas =
                                this.DtVehiculos.Select("Id_vehiculo = '" + codigo + "'");
                            if (filas != null)
                            {
                                if (filas.Length > 0)
                                {
                                    foreach (DataRow row in filas)
                                    {
                                        dtResultados.ImportRow(row);
                                    }
                                }
                                else
                                    dtResultados = null;
                            }
                            else
                                dtResultados = null;
                        }
                        else
                        {
                            Mensajes.MensajeInformacion("El código debe ser sólo números", "Entendido");
                            return;
                        }
                    }
                    else if (tipo_busqueda.Equals("PLACA"))
                    {
                        DataRow[] filas =
                               this.DtVehiculos.Select("Placa like '%" + texto_busqueda + "%'");
                        if (filas != null)
                        {
                            if (filas.Length > 0)
                            {
                                foreach (DataRow row in filas)
                                {
                                    dtResultados.ImportRow(row);
                                }
                            }
                            else
                                dtResultados = null;

                        }
                        else
                            dtResultados = null;
                    }
                    else if (tipo_busqueda.Equals("CHOFER"))
                    {
                        DataRow[] filas =
                               this.DtVehiculos.Select("Chofer like '%" + texto_busqueda + "%'");
                        if (filas != null)
                        {
                            if (filas.Length > 0)
                            {
                                foreach (DataRow row in filas)
                                {
                                    dtResultados.ImportRow(row);
                                }
                            }
                            else
                                dtResultados = null;

                        }
                        else
                            dtResultados = null;
                    }
                    else if (tipo_busqueda.Equals("COMPLETO"))
                    {
                        dtResultados = this.DtVehiculos;
                        return;
                    }
                    else if (tipo_busqueda.Equals("ESTADO"))
                    {
                        DataRow[] filas;
                        if (texto_busqueda.Equals("INACTIVO"))
                            filas = this.DtVehiculos.Select("Estado IS NULL");
                        else
                            filas = this.DtVehiculos.Select("Estado = '" + texto_busqueda + "'");

                        if (filas != null)
                        {
                            if (filas.Length > 0)
                            {
                                foreach (DataRow row in filas)
                                {
                                    dtResultados.ImportRow(row);
                                }
                            }
                            else
                                dtResultados = null;
                        }
                        else
                            dtResultados = null;
                    }

                    this.panelVehiculos.clearDataSource();
                    if (dtResultados != null)
                    {
                        this.panelVehiculos.Enabled = true;
                        int contador = 0;
                        List<Control> controls = new List<Control>();
                        foreach (DataRow row in dtResultados.Rows)
                        {
                            //Guardamos el estado
                            string estado = Convert.ToString(row["Estado"]);

                            //SI el estado es null o vacío significa que está INACTIVO
                            if (string.IsNullOrEmpty(estado))
                            {
                                EVehiculos eVehiculo = new EVehiculos(row);
                                EDetalle_vehiculos_estado eDetalle = new EDetalle_vehiculos_estado
                                {
                                    Id_detalle_vehiculo = 0,
                                    EVehiculo = eVehiculo,
                                    Fecha = DateTime.Now,
                                    Estado = "INACTIVO"
                                };

                                #region Botón personalizado inactivo
                                Button btnVehiculoInactivo = new Button();
                                btnVehiculoInactivo.Cursor = Cursors.Hand;
                                btnVehiculoInactivo.BackColor = Color.FromArgb(251, 70, 70);
                                btnVehiculoInactivo.FlatAppearance.BorderColor = Color.FromArgb(251, 70, 70);
                                btnVehiculoInactivo.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 70, 70);
                                btnVehiculoInactivo.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 139, 139);
                                btnVehiculoInactivo.FlatStyle = FlatStyle.Flat;
                                btnVehiculoInactivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                btnVehiculoInactivo.ForeColor = Color.FromArgb(234, 232, 229);
                                btnVehiculoInactivo.Size = new Size(89, 55);
                                btnVehiculoInactivo.TextAlign = ContentAlignment.TopCenter;
                                btnVehiculoInactivo.UseVisualStyleBackColor = false;
                                btnVehiculoInactivo.Tag = eDetalle;
                                btnVehiculoInactivo.Name = "btn" + contador;
                                btnVehiculoInactivo.Text = "Código" + Environment.NewLine + eDetalle.EVehiculo.Id_vehiculo.ToString();
                                btnVehiculoInactivo.MouseUp += BtnVehiculo_MouseUp;
                                controls.Add(btnVehiculoInactivo);
                                #endregion
                            }
                            else
                            {
                                EDetalle_vehiculos_estado eDetalle = new EDetalle_vehiculos_estado(row);
                                if (estado.Equals("ACTIVO"))
                                {
                                    #region Botón personalizado activo
                                    Button btnVehiculoActivo = new Button();
                                    btnVehiculoActivo.Cursor = Cursors.Hand;
                                    btnVehiculoActivo.BackColor = Color.FromArgb(106, 246, 64);
                                    btnVehiculoActivo.FlatAppearance.BorderColor = Color.FromArgb(106, 246, 64);
                                    btnVehiculoActivo.FlatAppearance.MouseDownBackColor = Color.Lime;
                                    btnVehiculoActivo.FlatAppearance.MouseOverBackColor = Color.FromArgb(131, 212, 96);
                                    btnVehiculoActivo.FlatStyle = FlatStyle.Flat;
                                    btnVehiculoActivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    btnVehiculoActivo.ForeColor = Color.FromArgb(92, 92, 92);
                                    btnVehiculoActivo.Size = new Size(89, 55);
                                    btnVehiculoActivo.TextAlign = ContentAlignment.TopCenter;
                                    btnVehiculoActivo.UseVisualStyleBackColor = false;
                                    btnVehiculoActivo.Tag = eDetalle;
                                    btnVehiculoActivo.MouseUp += BtnVehiculo_MouseUp;
                                    btnVehiculoActivo.Name = "btn" + contador;
                                    btnVehiculoActivo.Text = "Código" + Environment.NewLine + eDetalle.EVehiculo.Id_vehiculo.ToString();

                                    controls.Add(btnVehiculoActivo);
                                    #endregion
                                }
                                else if (estado.Equals("DE TURNO"))
                                {
                                    #region Botón personalizado de turno
                                    Button btnVehiculoTurno = new Button();
                                    btnVehiculoTurno.BackColor = Color.FromArgb(254, 173, 76);
                                    btnVehiculoTurno.Cursor = Cursors.Hand;
                                    btnVehiculoTurno.FlatAppearance.BorderColor = Color.FromArgb(254, 173, 76);
                                    btnVehiculoTurno.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 173, 76);
                                    btnVehiculoTurno.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 212, 140);
                                    btnVehiculoTurno.FlatStyle = FlatStyle.Flat;
                                    btnVehiculoTurno.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    btnVehiculoTurno.ForeColor = Color.FromArgb(92, 92, 92);
                                    btnVehiculoTurno.Size = new Size(89, 55);
                                    btnVehiculoTurno.TextAlign = ContentAlignment.TopCenter;
                                    btnVehiculoTurno.UseVisualStyleBackColor = false;
                                    btnVehiculoTurno.Tag = eDetalle;

                                    btnVehiculoTurno.Name = "btn" + contador;
                                    btnVehiculoTurno.Text = "Código" + Environment.NewLine + eDetalle.EVehiculo.Id_vehiculo.ToString();
                                    btnVehiculoTurno.MouseUp += BtnVehiculo_MouseUp;
                                    controls.Add(btnVehiculoTurno);
                                    #endregion
                                }
                            }
                        }
                    }
                    else
                        this.panelVehiculos.Enabled = false;
                }
                else
                    Mensajes.MensajeInformacion("No hay vehículos para buscar", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarVehiculosLocal",
                                   "Hubo un error al buscar vehículos localmente", ex.Message);
            }
        }

        private ETurnos _eTurno;
        private DataTable DtVehiculos { get; set; }
        public ETurnos ETurno { get => _eTurno; set => _eTurno = value; }


        private EEmpleados _eEmpleado;

        public EEmpleados EEmpleado
        {
            get => _eEmpleado;
            set
            {
                _eEmpleado = value;
            }
        }

        #endregion
    }
}
