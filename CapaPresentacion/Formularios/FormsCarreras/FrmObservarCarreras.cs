using CapaEntidades;
using CapaPresentacion.Formularios.FormsVehiculos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class FrmObservarCarreras : Form
    {
        PoperContainer container;
        public FrmObservarCarreras()
        {
            InitializeComponent();
            this.Load += FrmObservarCarreras_Load;
            this.dgvVehiculos.DoubleClick += DgvVehiculos_DoubleClick;
            this.txtBusquedaVehiculos.OnCustomKeyPress += TxtBusquedaVehiculos_onKeyPress;
            this.txtBusquedaVehiculos.OnPxClick += TxtBusquedaVehiculos_onPxClick;
            this.btnActualizarVehiculos.Click += BtnActualizarVehiculos_Click;
            this.btnActivos.Click += BtnActivos_Click;
            this.btnInactivos.Click += BtnInactivos_Click;
            this.btnTurno.Click += BtnTurno_Click;
            this.dgvCarreras.DoubleClick += DgvCarreras_DoubleClick;
            this.btnNuevoVehiculo.Click += BtnNuevoVehiculo_Click;
        }

        #region PROPIEDADES
        private int _pageSize = 20;
        private DataTable _dtVehiculos;
        public int PageSize { get => _pageSize; set => _pageSize = value; }
        public DataTable DtVehiculos { get => _dtVehiculos; set => _dtVehiculos = value; }
        #endregion

        #region VEHICULOS
        FrmNuevoVehiculo frmNuevoVehiculo;

        private void BtnNuevoVehiculo_Click(object sender, EventArgs e)
        {
            if (frmNuevoVehiculo == null)
            {
                frmNuevoVehiculo = new FrmNuevoVehiculo
                {
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None,
                    TopLevel = false
                };
                frmNuevoVehiculo.OnVehiculoAddSuccess += FrmNuevoVehiculo_OnVehiculoAddSuccess;
                this.container = new PoperContainer(frmNuevoVehiculo);
            }
            frmNuevoVehiculo.Show();
            this.container.Show(btnNuevoVehiculo);
        }

        private void FrmNuevoVehiculo_OnVehiculoAddSuccess(object sender, EventArgs e)
        {
            this.BuscarVehiculosBD();
        }

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
            this.BuscarVehiculosBD();
        }

        private string TipoBusqueda()
        {
            if (this.rdChofer.Checked)
            {
                return "CHOFER";
            }

            if (this.rdPlaca.Checked)
            {
                return "PLACA";
            }

            if (this.rdCodigo.Checked)
            {
                return "CODIGO";
            }

            return "COMPLETO";
        }

        private void TxtBusquedaVehiculos_onKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
                {
                    this.BuscarVehiculosLocal("COMPLETO", "");
                }
                else
                {
                    this.BuscarVehiculosLocal(this.TipoBusqueda(), txt.Texto);
                }
            }
        }

        private void TxtBusquedaVehiculos_onPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (txt.Texto.Equals("") || txt.Texto.Equals(txt.Texto_inicial))
            {
                this.BuscarVehiculosLocal("COMPLETO", "");
            }
            else
            {
                this.BuscarVehiculosLocal(this.TipoBusqueda(), txt.Texto);
            }
        }

        private void DgvVehiculos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos la celda actual
                DataGridViewCell gridViewCell = this.dgvVehiculos.CurrentCell;
                //Obtenemos la fila que corresponde a la celda actual
                DataGridViewRow gridViewRow = this.dgvVehiculos.CurrentRow;
                //Verificamos que esta fila no sea null
                if (gridViewRow != null)
                {
                    //Convertimos DataGridViewRow a DataRow
                    DataRow row = ((DataRowView)gridViewRow.DataBoundItem).Row;
                    //Creamos la entidad vehículo con la fila convertida
                    EVehiculos eVehiculo = new EVehiculos(row);
                    //Creamos un rectángulo con las coordenada de la celda que obtuvimos
                    Rectangle rec = this.dgvVehiculos.GetCellDisplayRectangle(gridViewCell.ColumnIndex, gridViewCell.RowIndex, true);
                    //Creamos el control de opciones
                    OpcionesVehiculos opcionesVehiculos = new OpcionesVehiculos
                    {
                        EVehiculo = eVehiculo
                    };
                    opcionesVehiculos.OnBtnEditarVehiculo += OpcionesVehiculos_OnBtnEditarVehiculo;
                    opcionesVehiculos.OnBtnCambiarEstado += OpcionesVehiculos_OnBtnCambiarEstado;
                    opcionesVehiculos.OnBtnNuevaCarrera += OpcionesVehiculos_OnBtnNuevaCarrera;
                    opcionesVehiculos.OnBtnVerPerfil += OpcionesVehiculos_OnBtnVerPerfil;
                    //Creamos el contenedor
                    this.container = new PoperContainer(opcionesVehiculos);
                    //Abrimos el contenedor
                    this.container.Show(this.dgvVehiculos, rec.Location);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvVehiculos_DoubleClick",
                    "Hubo un error con la tabla de datos",
                    ex.Message);
            }
        }

        private void OpcionesVehiculos_OnBtnVerPerfil(object sender, EventArgs e)
        {
            EVehiculos eVehiculo = (EVehiculos)sender;
        }

        private void OpcionesVehiculos_OnBtnNuevaCarrera(object sender, EventArgs e)
        {
            EVehiculos eVehiculo = (EVehiculos)sender;
            if (this.container != null)
            {
                this.container.Close();
                this.container = null;
            }

            DataGridViewCell gridViewCell = this.dgvVehiculos.CurrentCell;
            DataGridViewRow dataGridViewRow = this.dgvVehiculos.CurrentRow;
            string estado = Convert.ToString(dataGridViewRow.Cells["Estado"].Value);
            if (estado.Equals("") ||
                estado.Equals("DE TURNO"))
            {
                Mensajes.MensajeInformacion("No se puede asignar una carrera a un vehículo inactivo o de turno", "Entendido");
                return;
            }

            if (this.CarrerasEnCurso != null)
            {
                IEnumerable<ECarreras> filtroCarreras =
                    from car in this.CarrerasEnCurso
                    where car.EVehiculo.Id_vehiculo == eVehiculo.Id_vehiculo
                    select car;
                List<ECarreras> listaCarreras = filtroCarreras.ToList();
                if (listaCarreras != null)
                {
                    if (listaCarreras.Count > 0)
                    {
                        Mensajes.MensajeInformacion("¡El vehículo ya está en una carrera!", "Entendido");
                        return;
                    }
                }
            }

            Rectangle rec =
                this.dgvVehiculos.GetCellDisplayRectangle(gridViewCell.ColumnIndex, gridViewCell.RowIndex, true);
            CodigoVehiculo CodigoCliente = new CodigoVehiculo
            {
                EVehiculo = eVehiculo
            };
            CodigoCliente.OnBtnNext += CodigoCliente_OnBtnNext;
            this.container = new PoperContainer(CodigoCliente);
            this.container.Show(this.dgvVehiculos, rec.Location);
        }

        private void CodigoCliente_OnBtnNext(object sender, EventArgs e)
        {
            CodigoVehiculo CodigoCliente = (CodigoVehiculo)sender;
            string codigo = CodigoCliente.txtCodigo.Text;
            if (!codigo.Equals(""))
            {
                DataTable dtDirecciones =
                    EDireccion_clientes.BuscarDireccion("ID CLIENTE", codigo, out string rpta);
                if (dtDirecciones != null)
                {
                    EDireccion_clientes eDireccion = new EDireccion_clientes(dtDirecciones, 0);

                    FrmNuevaCarrera frmNuevaCarrera = new FrmNuevaCarrera
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    frmNuevaCarrera.OnCarreraAsignada += FrmNuevaCarrera_OnCarreraAsignada;
                    frmNuevaCarrera.AsignarDatos(CodigoCliente.EVehiculo, eDireccion);
                    frmNuevaCarrera.ShowDialog();
                }
                else
                {
                    Mensajes.MensajeInformacion("No se encontró ninguna dirección registrada", "Entendido");
                }

            }
        }

        private void FrmNuevaCarrera_OnCarreraAsignada(object sender, EventArgs e)
        {
            ECarreras eCarrera = (ECarreras)sender;
            this.BuscarCarrerasBD();
        }

        private void OpcionesVehiculos_OnBtnCambiarEstado(object sender, EventArgs e)
        {
            EVehiculos eVehiculo = (EVehiculos)sender;

            if (this.container != null)
            {
                this.container.Close();
                this.container = null;
            }

            string estado = Convert.ToString(this.dgvVehiculos.CurrentRow.Cells["Estado"].Value);
            if (string.IsNullOrEmpty(estado))
                estado = "INACTIVO";

            OpcionesEstadoVehiculo opcionesEstadoVehiculo = new OpcionesEstadoVehiculo
            {
                EstadoActual = estado,
                EVehiculo = eVehiculo
            };
            opcionesEstadoVehiculo.OnCambiarEstado += OpcionesEstadoVehiculo_OnCambiarEstado;
            DataGridViewCell gridViewCell = this.dgvVehiculos.CurrentCell;
            Rectangle rec =
                this.dgvVehiculos.GetCellDisplayRectangle(gridViewCell.ColumnIndex, gridViewCell.RowIndex, true);
            this.container = new PoperContainer(opcionesEstadoVehiculo);
            this.container.Show(this.dgvVehiculos, rec.Location);
        }

        private void OpcionesEstadoVehiculo_OnCambiarEstado(object sender, EventArgs e)
        {
            OpcionesEstadoVehiculo opcionesEstadoVehiculo = (OpcionesEstadoVehiculo)sender;

            if (this.container != null)
            {
                this.container.Close();
                this.container = null;
            }

            if (opcionesEstadoVehiculo.EstadoActual.Equals("INACTIVO"))
            {
                //Insertar en detalle de estado de vehículo
                EDetalle_vehiculos_estado eDetalle = new EDetalle_vehiculos_estado
                {
                    Fecha = DateTime.Now,
                    EVehiculo = opcionesEstadoVehiculo.EVehiculo,
                    Estado = opcionesEstadoVehiculo.EstadoSeleccionado
                };
                string rpta = EDetalle_vehiculos_estado.InsertarDetaleVehiculo(eDetalle, out int id_detalle);
                if (rpta.Equals("OK"))
                {
                    this.BuscarVehiculosBD();
                }
                else
                    Mensajes.MensajeErrorCompleto(this.Name, "OpcionesEstadoVehiculo_OnCambiarEstado",
                        "Hubo un error al insertar el estado de un vehículo", rpta);
            }
            else
            {
                DataTable dt = (DataTable)this.dgvVehiculos.DataSource;
                var resultados = from x in dt.Rows.Cast<DataRow>()
                                 where Convert.ToInt32(x["Id_vehiculo"]) ==
                                    opcionesEstadoVehiculo.EVehiculo.Id_vehiculo
                                 select x;

                List<DataRow> list = resultados.ToList();

                EDetalle_vehiculos_estado eDetalle = new EDetalle_vehiculos_estado(list[0]);
                eDetalle.Estado = opcionesEstadoVehiculo.EstadoSeleccionado;
                string rpta = EDetalle_vehiculos_estado.EditarDetaleVehiculo(eDetalle, eDetalle.Id_detalle_vehiculo);
                if (rpta.Equals("OK"))
                {
                    Mensajes.MensajeOkForm("Se cambió el estado del vehículo correctamente");
                    this.BuscarVehiculosBD();
                }
                else
                    Mensajes.MensajeErrorCompleto(this.Name, "OpcionesEstadoVehiculo_OnCambiarEstado",
                        "Hubo un error al insertar el estado de un vehículo", rpta);
            }

        }

        private void OpcionesVehiculos_OnBtnEditarVehiculo(object sender, EventArgs e)
        {
            EVehiculos eVehiculo = (EVehiculos)sender;
            FrmNuevoVehiculo frmNuevoVehiculo = new FrmNuevoVehiculo
            {
                IsEditar = true,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmNuevoVehiculo.OnVehiculoEditSuccess += FrmNuevoVehiculo_OnVehiculoEditSuccess;
            frmNuevoVehiculo.AsignarDatos(eVehiculo);
            frmNuevoVehiculo.ShowDialog();
        }

        private void FrmNuevoVehiculo_OnVehiculoEditSuccess(object sender, EventArgs e)
        {
            this.BuscarVehiculosBD();
        }

        private void AsignarColoresEstadoVehiculos()
        {
            try
            {
                if (this.dgvVehiculos.Rows.Count > 0)
                {
                    //Establecemos opciones del dataGridView
                    this.dgvVehiculos.AlternatingRowsDefaultCellStyle.BackColor = Color.Transparent;

                    //Convertimos el dataSource del dataGrid en DataTable para recorrer
                    DataTable dtVh = (DataTable)dgvVehiculos.DataSource;
                    //Iniciamos un contador para las filas
                    int contadorFilas = 0;
                    //Iniciamos ciclo para recorrer filas
                    foreach (DataRow row in dtVh.Rows)
                    {
                        //Guardamos el estado
                        string estado = Convert.ToString(row["Estado"]);
                        //SI el estado es null o vacío significa que está INACTIVO
                        if (string.IsNullOrEmpty(estado))
                        {
                            //Creamos una fila con un estilo, backColor = ROJO
                            DataGridViewCellStyle styleInactivo = new DataGridViewCellStyle();
                            styleInactivo.BackColor = Color.FromArgb(255, 128, 128);
                            styleInactivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                            styleInactivo.ForeColor = Color.White;

                            this.dgvVehiculos.Rows[contadorFilas].DefaultCellStyle = styleInactivo;
                        }
                        else
                        {
                            if (estado.Equals("ACTIVO"))
                            {
                                //Creamos una fila con un estilo, backColor = VERDE
                                DataGridViewCellStyle styleActivo = new DataGridViewCellStyle();
                                styleActivo.BackColor = Color.Lime;
                                styleActivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                                styleActivo.ForeColor = Color.FromArgb(64, 64, 64);

                                this.dgvVehiculos.Rows[contadorFilas].DefaultCellStyle = styleActivo;
                            }
                            else if (estado.Equals("DE TURNO"))
                            {
                                //Creamos una fila con un estilo, backColor = SAPOTE
                                DataGridViewCellStyle styleActivo = new DataGridViewCellStyle();
                                styleActivo.BackColor = Color.FromArgb(255, 192, 128);
                                styleActivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                                styleActivo.ForeColor = Color.FromArgb(64, 64, 64);

                                this.dgvVehiculos.Rows[contadorFilas].DefaultCellStyle = styleActivo;
                            }
                        }

                        contadorFilas += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AsignarColoresEstadoVehiculos",
                    "Hubo un error al asignar los colores del estado de vehículos",
                    ex.Message);
            }
        }

        public void BuscarVehiculosBD()
        {
            try
            {
                DataTable dtVehiculosInactivos =
                    EDetalle_vehiculos_estado.BuscarDetalleVehiculosCarreras("COMPLETO FECHA",
                    DateTime.Now.ToString("yyyy-MM-dd"), out string rpta);
                this.dgvVehiculos.clearDataSource();
                if (dtVehiculosInactivos != null)
                {
                    this.DtVehiculos = dtVehiculosInactivos;
                    this.dgvVehiculos.Enabled = true;
                    this.dgvVehiculos.PageSize = this.PageSize;
                    this.dgvVehiculos.SetPagedDataSource(dtVehiculosInactivos, this.bindingNavigatorVehiculos);

                    this.dgvVehiculos.Columns["Id_vehiculo"].HeaderText = "Código";

                    if (this.dgvVehiculos.Columns.Contains("CantidadServicios"))
                        this.dgvVehiculos.Columns["CantidadServicios"].HeaderText = "Carreras";

                    this.dgvVehiculos.Columns["Propietario"].Visible = false;
                    this.dgvVehiculos.Columns["Estado_vehiculo"].Visible = false;
                    this.dgvVehiculos.Columns["Id_detalle_vehiculo"].Visible = false;
                    this.dgvVehiculos.Columns["Fecha"].Visible = false;
                    this.dgvVehiculos.Columns["Id_vehiculo1"].Visible = false;

                    if (this.dgvVehiculos.Columns.Contains("Id_vehiculo2"))
                        this.dgvVehiculos.Columns["Id_vehiculo2"].Visible = false;

                    this.dgvVehiculos.Columns["Estado"].Visible = false;
                    this.AsignarColoresEstadoVehiculos();
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarVehiculosBD",
                    "Hubo un error al buscar vehículos", ex.Message);
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

                    this.dgvVehiculos.clearDataSource();
                    if (dtResultados != null)
                    {
                        this.dgvVehiculos.Enabled = true;
                        this.dgvVehiculos.PageSize = this.PageSize;
                        this.dgvVehiculos.SetPagedDataSource(dtResultados, this.bindingNavigatorVehiculos);

                        this.dgvVehiculos.Columns["Id_vehiculo"].HeaderText = "Código";
                        this.dgvVehiculos.Columns["Propietario"].Visible = false;
                        this.dgvVehiculos.Columns["Estado_vehiculo"].Visible = false;
                        this.dgvVehiculos.Columns["Id_detalle_vehiculo"].Visible = false;
                        this.dgvVehiculos.Columns["Fecha"].Visible = false;
                        this.dgvVehiculos.Columns["Id_vehiculo1"].Visible = false;
                        this.dgvVehiculos.Columns["Estado"].Visible = false;
                        this.AsignarColoresEstadoVehiculos();
                    }
                    else
                    {
                        this.dgvVehiculos.Enabled = false;
                    }
                }
                else
                {
                    Mensajes.MensajeInformacion("No hay vehículos para buscar", "Entendido");
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarVehiculosLocal",
                                   "Hubo un error al buscar vehículos localmente", ex.Message);
            }
        }

        #endregion

        #region CARRERAS

        List<ECarreras> CarrerasEnCurso;
        List<ECarreras> CarrerasCanceladas;
        List<ECarreras> CarrerasTerminadas;

        private void DgvCarreras_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos la celda actual
                DataGridViewCell gridViewCell = this.dgvCarreras.CurrentCell;
                //Obtenemos la fila que corresponde a la celda actual
                DataGridViewRow gridViewRow = this.dgvCarreras.CurrentRow;
                //Verificamos que esta fila no sea null
                if (gridViewRow != null)
                {
                    //Convertimos DataGridViewRow a DataRow
                    DataRow row = ((DataRowView)gridViewRow.DataBoundItem).Row;

                    //Como la tabla de dgvCarreras es personalizada no tiene todos los campos
                    //para crear la entidad ECarreras por eso buscamos primero en la lista de carreras en curso
                    if (this.CarrerasEnCurso != null)
                    {
                        int id_carrera = Convert.ToInt32(row["Id_carrera"]);

                        IEnumerable<ECarreras> filtroCarreras =
                            from car in this.CarrerasEnCurso
                            where car.Id_carrera == id_carrera
                            select car;

                        List<ECarreras> listaCarreras = filtroCarreras.ToList();
                        if (listaCarreras != null)
                        {
                            if (listaCarreras.Count > 0)
                            {
                                //Creamos la entidad vehículo con la fila convertida
                                ECarreras eCarrera = listaCarreras[0];
                                //Creamos un rectángulo con las coordenada de la celda que obtuvimos
                                Rectangle rec = this.dgvCarreras.GetCellDisplayRectangle(gridViewCell.ColumnIndex,
                                    gridViewCell.RowIndex, true);
                                //Creamos el control de opciones
                                OpcionesCarreras opcionesCarreras = new OpcionesCarreras
                                {
                                    ECarrera = eCarrera
                                };
                                opcionesCarreras.OnBtnTerminarCarreraClick += OpcionesCarreras_OnBtnTerminarCarreraClick;
                                opcionesCarreras.OnBtnCancelarCarreraClick += OpcionesCarreras_OnBtnCancelarCarreraClick;
                                opcionesCarreras.OnBtnEnviarMensajesClick += OpcionesCarreras_OnBtnEnviarMensajesClick;
                                //Creamos el contenedor
                                this.container = new PoperContainer(opcionesCarreras);
                                //Abrimos el contenedor
                                this.container.Show(this.dgvCarreras, rec.Location);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "DgvCarreras_DoubleClick",
                    "Hubo un error con la tabla de datos",
                    ex.Message);
            }
        }

        private void OpcionesCarreras_OnBtnEnviarMensajesClick(object sender, EventArgs e)
        {
            Mensajes.MensajeInformacion("Función en mantenimiento, debe asignar los campos de IMEI y Número de celular",
                "Entendido");
        }

        private void OpcionesCarreras_OnBtnCancelarCarreraClick(object sender, EventArgs e)
        {
            ECarreras eCarrera = (ECarreras)sender;
            try
            {
                eCarrera.Estado_carrera = "CANCELADA";
                string rpta =
                    ECarreras.EditarCarrera(eCarrera, eCarrera.Id_carrera);
                if (rpta.Equals("OK"))
                {
                    int res =
                        this.CarrerasEnCurso.FindIndex(x => x.Id_carrera == eCarrera.Id_carrera);
                    this.CarrerasEnCurso.Remove(this.CarrerasEnCurso[res]);
                    this.RemoverFila(eCarrera);
                    this.CarrerasCanceladas.Add(eCarrera);
                    Mensajes.MensajeInformacion("¡Carrera cancelada con éxito!", "Entendido");
                    this.ActualizarCarrerasEnCurso();
                }
                else
                {
                    throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "OpcionesCarreras_OnBtnCancelarCarreraClick",
                    "Hubo un error al cancelar una carrera", ex.Message);
            }
        }

        private void OpcionesCarreras_OnBtnTerminarCarreraClick(object sender, EventArgs e)
        {
            ECarreras eCarrera = (ECarreras)sender;
            try
            {
                eCarrera.Estado_carrera = "TERMINADA";
                string rpta =
                    ECarreras.EditarCarrera(eCarrera, eCarrera.Id_carrera);
                if (rpta.Equals("OK"))
                {
                    int res =
                        this.CarrerasEnCurso.FindIndex(x => x.Id_carrera == eCarrera.Id_carrera);

                    this.CarrerasEnCurso.Remove(this.CarrerasEnCurso[res]);
                    this.RemoverFila(eCarrera);

                    this.CarrerasTerminadas.Add(eCarrera);
                    Mensajes.MensajeInformacion("¡Carrera terminada con éxito!", "Entendido");
                    this.ActualizarCarrerasEnCurso();
                }
                else
                {
                    throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "OpcionesCarreras_OnBtnTerminarCarreraClick",
                    "Hubo un error al terminar una carrera", ex.Message);
            }
        }

        private void BuscarCarrerasBD()
        {
            try
            {
                DataTable dtCarreras =
                    ECarreras.BuscarCarreras("COMPLETO FECHA", DateTime.Now.ToString("yyyy-MM-dd"),
                    out string rpta);
                this.dgvCarreras.clearDataSource();
                this.CarrerasEnCurso = null;
                this.CarrerasTerminadas = null;
                this.CarrerasCanceladas = null;
                this.DtCarrerasEnCurso.Rows.Clear();
                if (dtCarreras != null)
                {
                    if (CarrerasEnCurso == null)
                        CarrerasEnCurso = new List<ECarreras>();

                    if (CarrerasCanceladas == null)
                        CarrerasCanceladas = new List<ECarreras>();

                    if (CarrerasTerminadas == null)
                        CarrerasTerminadas = new List<ECarreras>();

                    foreach (DataRow row in dtCarreras.Rows)
                    {
                        ECarreras eCarrera = new ECarreras(row);

                        if (eCarrera.Estado_carrera.Equals("TERMINADA"))
                        {
                            CarrerasTerminadas.Add(eCarrera);
                        }
                        else if (eCarrera.Estado_carrera.Equals("CANCELADA"))
                        {
                            CarrerasCanceladas.Add(eCarrera);
                        }
                        else if (eCarrera.Estado_carrera.Equals("PENDIENTE"))
                        {
                            CarrerasEnCurso.Add(eCarrera);
                            this.AgregarFila(eCarrera);
                        }
                    }

                    if (this.DtCarrerasEnCurso != null)
                    {
                        if (this.DtCarrerasEnCurso.Rows.Count > 0)
                        {
                            this.dgvCarreras.Enabled = true;
                            this.dgvCarreras.PageSize = this.PageSize;
                            this.dgvCarreras.SetPagedDataSource(this.DtCarrerasEnCurso, this.bindingNavigatorCarreras);

                            this.dgvCarreras.Columns["Id_carrera"].Visible = false;
                            this.dgvCarreras.Columns["Hora_carrera"].HeaderText = "Hora";
                            this.dgvCarreras.Columns["Tiempo_llegada"].HeaderText = "Tiempo de llegada";
                        }
                    }
                }
                else
                {
                    this.dgvCarreras.Enabled = false;

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {

                Mensajes.MensajeErrorCompleto(this.Name, "BuscarCarreras",
                    "Hubo un error al buscar carreras", ex.Message);
            }
        }

        private void ActualizarCarrerasEnCurso()
        {
            if (this.DtCarrerasEnCurso != null)
            {
                if (this.DtCarrerasEnCurso.Rows.Count > 0)
                {
                    this.dgvCarreras.Enabled = true;
                    this.dgvCarreras.PageSize = this.PageSize;
                    this.dgvCarreras.SetPagedDataSource(this.DtCarrerasEnCurso, this.bindingNavigatorCarreras);

                    this.dgvCarreras.Columns["Id_carrera"].Visible = false;
                    this.dgvCarreras.Columns["Hora_carrera"].HeaderText = "Hora";
                    this.dgvCarreras.Columns["Tiempo_llegada"].HeaderText = "Tiempo de llegada";
                }
            }
            else
                this.dgvCarreras.Enabled = false;

        }

        private void RemoverFila(ECarreras eCarrera)
        {
            var resultados = from x in this.DtCarrerasEnCurso.Rows.Cast<DataRow>()
                             where Convert.ToInt32(x["Id_carrera"]) ==
                                eCarrera.Id_carrera
                             select x;

            List<DataRow> list = resultados.ToList();

            if (list != null)
            {
                if (list.Count > 0)
                {
                    this.DtCarrerasEnCurso.Rows.Remove(list[0]);
                }
            }
        }

        private void AgregarFila(ECarreras eCarrera)
        {
            DataRow row = this.DtCarrerasEnCurso.NewRow();
            row["Id_carrera"] = eCarrera.Id_carrera;
            row["Hora_carrera"] = eCarrera.Hora_carrera;
            row["Tiempo_llegada"] = eCarrera.Tiempo_llegada + "min";
            row["Cliente"] = eCarrera.ECliente.Nombre_cliente + " - " + eCarrera.ECliente.Celular_cliente;
            row["Direccion"] = eCarrera.EDireccion.Direccion + " - Barrio: " + eCarrera.EDireccion.EBarrio.Nombre_barrio;
            row["Vehiculo"] = "Código: " + eCarrera.EVehiculo.Id_vehiculo +
                " - Placa: " + eCarrera.EVehiculo.Placa + " - Chofer: " + eCarrera.EVehiculo.Chofer;
            this.DtCarrerasEnCurso.Rows.Add(row);
        }

        private void CrearTablaCarreras()
        {
            this.DtCarrerasEnCurso = new DataTable("DtCarreras");
            this.DtCarrerasEnCurso.Columns.Add("Id_carrera", typeof(int));
            this.DtCarrerasEnCurso.Columns.Add("Hora_carrera", typeof(string));
            this.DtCarrerasEnCurso.Columns.Add("Tiempo_llegada", typeof(string));
            this.DtCarrerasEnCurso.Columns.Add("Cliente", typeof(string));
            this.DtCarrerasEnCurso.Columns.Add("Direccion", typeof(string));
            this.DtCarrerasEnCurso.Columns.Add("Vehiculo", typeof(string));
        }

        DataTable DtCarrerasEnCurso { get; set; }

        #endregion

        private void FrmObservarCarreras_Load(object sender, EventArgs e)
        {
            this.BuscarVehiculosBD();
            this.CrearTablaCarreras();
            this.BuscarCarrerasBD();
            this.AsignarColoresEstadoVehiculos();
        }

    }
}
