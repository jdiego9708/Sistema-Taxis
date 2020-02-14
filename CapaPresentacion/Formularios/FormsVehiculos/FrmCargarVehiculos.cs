using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsVehiculos
{
    public partial class FrmCargarVehiculos : Form
    {
        public FrmCargarVehiculos()
        {
            InitializeComponent();

            this.Load += FrmCargarVehiculos_Load;

            this.btnImportar.Click += BtnImportar_Click;
            this.btnMostrarEsquema.Click += BtnMostrarEsquema_Click;
            this.txtHoja.Click += TxtHoja_Click;
            this.txtHoja.LostFocus += TxtHoja_LostFocus;
            this.btnIniciar.Click += BtnIniciar_Click;
            this.lblResultados.Click += LblResultados_Click;

            this.txtHoja.KeyPress += TxtHoja_KeyPress;
        }

        private void TxtHoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtHoja.Text.Equals("Hoja") || txtHoja.Text.Equals(""))
                {
                    this.gb3.Enabled = false;
                }
                else
                {
                    this.gb3.Enabled = true;
                }
            }
        }

        private void FrmCargarVehiculos_Load(object sender, EventArgs e)
        {
            this.lblResultados.Cursor = Cursors.Hand;
            this.CrearTablaErrores();

            this.dtVehiculosExistentes =
                EVehiculos.BuscarVehiculos("COMPLETO", "", out string rpta);
        }

        private void AddError(string descripcion)
        {
            DataRow row = this.dtErrores.NewRow();
            row["Descripcion"] = descripcion;
            this.dtErrores.Rows.Add(row);

            this.lblResultados.Text = "Se han encontrado errores " +
                "en el procesamiento, verifique";
            this.lblResultados.ForeColor = Color.Red;
        }

        private void CrearTablaErrores()
        {
            this.dtErrores = new DataTable("Errores");
            this.dtErrores.Columns.Add("Descripcion", typeof(string));
        }

        private bool VerificarVehiculo(out EVehiculos eVehiculo, 
            int id_vehiculo, string placa, string propietario,
            string chofer, string marca, string modelo, string color)
        {
            eVehiculo = new EVehiculos();
            bool result = true;
            try
            {
                if (dtVehiculosExistentes != null)
                {
                    DataRow[] rows1 =
                        dtVehiculosExistentes.Select("Placa = '" + placa + "'");

                    DataRow[] rows2 =
                        dtVehiculosExistentes.Select("Id_vehiculo = '" + id_vehiculo + "'");

                    if (rows1.Length < 1)
                        rows1 = null;

                    if (rows2.Length < 1)
                        rows2 = null;

                    if (rows1 != null)
                    {
                        eVehiculo = new EVehiculos(rows1[0]);
                        return true;
                    }
                    else if (rows2 != null)
                    {
                        eVehiculo = new EVehiculos(rows2[0]);
                        return true;
                    }
                }

                eVehiculo.Id_vehiculo = id_vehiculo;
                eVehiculo.Placa = placa;
                eVehiculo.Propietario = propietario;
                eVehiculo.Chofer = chofer;
                eVehiculo.Marca = marca;
                eVehiculo.Modelo = modelo;
                eVehiculo.Color = color;
                eVehiculo.Estado_vehiculo = "ACTIVO";
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        private bool VerificarEsquema()
        {
            bool result = false;

            if (this.dtEsquema != null)
            {
                string columnText = "";
                foreach (DataColumn column in dtEsquema.Columns)
                {
                    columnText = column.ColumnName.ToUpper();
                    foreach (DataColumn columnClient in dtVehiculosCargados.Columns)
                    {
                        if (columnText == columnClient.ColumnName.ToUpper())
                        {
                            result = true;
                            break;
                        }
                    }

                    if (result == false)
                    {
                        Mensajes.MensajeInformacion("No se encontró la columna " + columnText, "Entendido");
                        break;
                    }
                }
            }
            return result;
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VerificarEsquema())
                {
                    MensajeEspera.ShowWait("Cargando");
                    this.CrearTablaErrores();
                    List<EVehiculos> Vehiculos = new List<EVehiculos>();
                    foreach (DataRow row in this.dtVehiculosCargados.Rows)
                    {
                        int Id_vehiculo = Convert.ToInt32(row["Codigo"]);
                        string Placa = Convert.ToString(row["Placa"]).Trim();
                        string Propietario = Convert.ToString(row["Propietario"]).Trim();
                        string Chofer = Convert.ToString(row["Chofer"]).Trim();
                        string Marca = Convert.ToString(row["Marca"]).Trim();
                        string Modelo = Convert.ToString(row["Modelo"]).Trim();
                        string Color = Convert.ToString(row["Color"]).Trim();

                        if (!this.VerificarVehiculo(out EVehiculos eVehiculo,
                            Id_vehiculo, Placa, Propietario, Chofer, Marca, Modelo, Color))
                        {
                            this.AddError("No se pudieron asignar y verificar los datos para crear la entidad Vehiculo");
                            break;
                        }

                        Vehiculos.Add(eVehiculo);                  
                    }

                    if (Vehiculos.Count > 0)
                    {
                        string rpta =
                            EVehiculos.InsertarVehiculos(Vehiculos);
                        if (!rpta.Equals("OK"))
                        {
                            this.AddError("Hubo un error al insertar un vehículo en la base de datos, detalles: " + rpta);
                        }
                        else
                        {
                            MensajeEspera.CloseForm();
                            Mensajes.MensajeInformacion("Se importaron " + Vehiculos.Count + " vehículos.", "Entendido");
                            this.Close();
                        }
                    }

                    MensajeEspera.CloseForm();
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnIniciar_Click",
                    "Hubo un error al cargar los vehículos", ex.Message);
            }
        }

        private void LblResultados_Click(object sender, EventArgs e)
        {
            if (this.dtErrores != null)
            {
                if (this.dtErrores.Rows.Count > 0)
                {
                    FrmErroresCarga errores = new FrmErroresCarga
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    errores.FormClosing += Errores_FormClosing;
                    errores.ObtenerErrores(dtErrores);
                    errores.Show();
                }
            }
        }

        private void Errores_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtHoja.Focus();
        }

        private void TxtHoja_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Equals("Hoja") || txt.Text.Equals(""))
            {
                this.gb3.Enabled = false;
            }
            else
            {
                this.gb3.Enabled = true;
            }
        }

        private void TxtHoja_Click(object sender, EventArgs e)
        {
            this.txtHoja.SelectAll();
        }

        private void BtnMostrarEsquema_Click(object sender, EventArgs e)
        {
            DataTable dtEsquema = new DataTable();
            dtEsquema.Columns.Add("Codigo", typeof(string));
            dtEsquema.Columns.Add("Placa", typeof(string));
            dtEsquema.Columns.Add("Propietario", typeof(string));
            dtEsquema.Columns.Add("Chofer", typeof(string));
            dtEsquema.Columns.Add("Marca", typeof(string));
            dtEsquema.Columns.Add("Modelo", typeof(string));
            dtEsquema.Columns.Add("Color", typeof(string));

            this.dgvVehiculos.DataSource = dtEsquema;
            this.lblResultados.Text = "El archivo a cargar debe tener las mismas columnas en el mismo orden";
            this.gb2.Enabled = true;
            this.dtEsquema = dtEsquema;
        }

        private void BtnImportar_Click(object sender, EventArgs e)
        {

            try
            {
                //Creo un objeto de tipo OpenFileDialog y lo instancio
                OpenFileDialog archivo = new OpenFileDialog();
                //Esta linea es para que solo se puedan visualizar los archivos con esta extension
                archivo.Filter = "Documentos válidos|*.doc;*.xls;*.ppt;*.pdf;*.xlsx";
                //Lo abro como un Dialog
                DialogResult result = archivo.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //Asignamos el nombre del archivo a la caja de texto
                    this.txtArchivo.Text = archivo.SafeFileName;
                    //Asignamos a la propiedad tag del textbox la ruta completa del archivo
                    this.txtArchivo.Tag = archivo.FileName;

                    string hoja = this.txtHoja.Text;

                    if (hoja.Equals("Hoja") || hoja.Equals(""))
                    {
                        Mensajes.MensajeErrorForm("Debe ingresar un nombre de hoja válida, seleccione el archivo de nuevo");
                        this.txtHoja.SelectAll();
                    }
                    else
                    {
                        MensajeEspera.ShowWait("Cargando");
                        DataTable dt = new DataTable();
                        string fileName = archivo.FileName;
                        string query = "SELECT * FROM [" + hoja + "$]";
                        using (OleDbConnection cn = new OleDbConnection { ConnectionString = ConnectionString(fileName, "Yes") })
                        {
                            using (OleDbCommand cmd = new OleDbCommand { CommandText = query, Connection = cn })
                            {
                                cn.Open();

                                OleDbDataReader dr = cmd.ExecuteReader();
                                dt.Load(dr);
                            }
                        }

                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                this.lblResultados.Text = "Se cargaron " + dt.Rows.Count + " registros";
                                this.dgvVehiculos.Enabled = true;
                            }
                            else
                            {
                                this.dgvVehiculos.Enabled = false;
                                this.lblResultados.Text = "No se cargó ningún registro";
                            }
                        }
                        dt.AcceptChanges();
                        this.dgvVehiculos.DataSource = dt;
                        this.gb4.Enabled = true;
                        this.dtVehiculosCargados = dt;
                        this.txtArchivo.Focus();
                        MensajeEspera.CloseForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnImportar_Click",
                    "Hubo un error al importar el archivo", ex.Message);
            }
        }

        public string ConnectionString(string FileName, string Header)
        {
            OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
            if (Path.GetExtension(FileName).ToUpper() == ".XLS")
            {
                Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
            }
            else
            {
                Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
            }

            Builder.DataSource = FileName;

            return Builder.ConnectionString;
        }

        private DataTable dtEsquema;

        private DataTable dtVehiculosExistentes;
        private DataTable dtVehiculosCargados;

        private DataTable dtErrores;
    }
}
