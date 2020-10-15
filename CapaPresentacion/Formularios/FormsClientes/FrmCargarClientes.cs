using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsClientes
{
    public partial class FrmCargarClientes : Form
    {
        public FrmCargarClientes()
        {
            InitializeComponent();

            this.Load += FrmCargarClientes_Load;

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

        private void FrmCargarClientes_Load(object sender, EventArgs e)
        {
            this.lblResultados.Cursor = Cursors.Hand;
            this.CrearTablaErrores();

            this.dtBarriosExistentes =
                EBarrios.BuscarBarrios("COMPLETO", "", out string rpta);

            this.dtClientesExistentes =
                EClientes.BuscarClientes("COMPLETO", "", out rpta);

            this.DtBases = EBases_clientes.BuscarBases("COMPLETO", "", out rpta);
            if (DtBases != null)
            {
                EBases_clientes eBase = new EBases_clientes(DtBases.Rows[0]);
                this.gbBd.Tag = eBase;
                this.gbBd.Text = "Base de datos (" + eBase.Alias_base + ")(2)";

                this.listaBases.DataSource = DtBases;
                this.listaBases.DisplayMember = "Nombre_base";
                this.listaBases.ValueMember = "Id_base";
                this.listaBases.SelectedIndexChanged += ListaBases_SelectedIndexChanged;
            }
            else
            {
                Mensajes.MensajeInformacion("No se encontró ninguna base de datos para ligar el cliente", "Entendido");
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }
            }
        }

        private void ListaBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (int.TryParse(cb.SelectedValue.ToString(), out int id_base))
            {
                if (this.DtBases != null)
                {
                    DataRow[] rows = this.DtBases.Select(string.Format("Id_base = {0}", id_base));
                    if (rows.Length > 0)
                    {
                        EBases_clientes eBase = new EBases_clientes(rows[0]);
                        this.gbBd.Tag = eBase;
                        this.gbBd.Text = "Base de datos (" + eBase.Alias_base + ")(2)";
                    }
                }
            }
            else
                Mensajes.MensajeInformacion("Hubo un error al obtener el id de la base seleccionada", "Entendido");
        }

        private bool VerificarBarrio(out EBarrios eBarrio, string barrio)
        {
            eBarrio = new EBarrios();
            bool result = true;
            try
            {
                if (dtBarriosExistentes != null)
                {
                    if (barrio.Equals(""))
                        barrio = "NINGUNO";

                    DataRow[] rows =
                        dtBarriosExistentes.Select("Nombre_barrio like '" + barrio.Trim().ToUpper() + "'");
                    if (rows.Length > 1)
                    {
                        eBarrio = new EBarrios(rows[0]);
                        return true;
                    }
                }
                else
                {
                    this.dtBarriosExistentes = new DataTable();
                    this.dtBarriosExistentes.Columns.Add("Id_barrio", typeof(int));
                    this.dtBarriosExistentes.Columns.Add("Nombre_barrio", typeof(string));
                }

                eBarrio = new EBarrios
                {
                    Nombre_barrio = barrio.Trim()
                };
                string rpta = EBarrios.InsertarBarrio(eBarrio, out int id_barrio);
                if (rpta.Equals("OK"))
                {
                    eBarrio.Id_barrio = id_barrio;
                    DataRow newRow = this.dtBarriosExistentes.NewRow();
                    newRow["Id_barrio"] = id_barrio;
                    newRow["Nombre_barrio"] = barrio.Trim();
                    this.dtBarriosExistentes.Rows.Add(newRow);
                }
                else
                    throw new Exception(rpta);

            }
            catch (Exception ex)
            {
                result = false;
                if (ex.Message.Equals("OK"))
                {
                    this.AddError("No existe el barrio " + barrio + " en la base de datos");
                }
                else
                {
                    this.AddError("Hubo un error al buscar el barrio, detalles: " + ex.Message);
                }
            }
            return result;
        }

        private bool VerificarCliente(out EClientes eClienteSalida,
            EClientes eClienteEntrada)
        {
            eClienteSalida = eClienteEntrada;
            try
            {
                if (this.gbBd.Tag != null)
                {
                    EBases_clientes eBase = (EBases_clientes)this.gbBd.Tag;
                    eClienteSalida.EBase = eBase;
                }
                else
                    return false;

                if (!eClienteEntrada.Codigo_cliente.Equals(""))
                {
                    if (dtClientesExistentes != null)
                    {
                        //Falta que busque la base que es

                        DataRow[] rows2 =
                            dtClientesExistentes.Select("Codigo_cliente = '" + eClienteEntrada.Codigo_cliente + "' and " +
                            "Id_base = " + eClienteSalida.EBase.Id_base);

                        if (rows2.Length > 0)
                        {
                            eClienteSalida = new EClientes(rows2[0]);
                            this.AddError("El código" + eClienteEntrada.Codigo_cliente + " ya existe en la base seleccionada.");
                            return false;
                        }

                        //DataRow[] rows1 =
                        //  dtClientesExistentes.Select("Nombre_cliente = '" + eClienteEntrada.Nombre_cliente + "'");

                        //if (rows1.Length > 1)
                        //{
                        //    eClienteSalida = new EClientes(rows1[0]);
                        //    this.AddError("El nombre " + eClienteEntrada.Nombre_cliente + "ya existe.");
                        //    return false;
                        //}
                    }
                }
                else
                {
                    this.AddError("El código del cliente " + eClienteEntrada.Nombre_cliente + " está vacío.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "VerificarCliente",
                    "Hubo un error verificando un cliente", ex.Message);
                return false;
            }

            return true;
        }

        private bool VerificarClientes(out string consulta)
        {
            bool result = true;
            consulta = "";
            StringBuilder consultaCompleta = new StringBuilder();

            int contador = 1;
            foreach (DataRow row in this.dtClientes.Rows)
            {
                string codigo_cliente = Convert.ToString(row["Codigo_cliente"]);
                string nombre_cliente = Convert.ToString(row["Nombre_cliente"]);
                string celular_cliente = Convert.ToString(row["Celular_cliente"]);
                EClientes eCliente = new EClientes
                {
                    Codigo_cliente = codigo_cliente,
                    Nombre_cliente = nombre_cliente,
                    Celular_cliente = celular_cliente,
                    Estado_cliente = "ACTIVO"
                };

                if (codigo_cliente.Equals(""))
                {
                    this.AddError("El código del cliente en la fila " + contador + " está vacío.");
                    break;
                }

                if (nombre_cliente.Equals(""))
                {
                    this.AddError("El nombre del cliente en la fila " + contador + " está vacío.");
                    break;
                }

                string barrio = Convert.ToString(row["Nombre_barrio"]);

                if (!this.VerificarBarrio(out EBarrios eBarrio, barrio))
                    break;

                if (this.VerificarCliente(out EClientes eClienteSalida, eCliente))
                {
                    consultaCompleta.Append("INSERT INTO Clientes " +
                    "(Codigo_cliente, Id_base, Nombre_cliente, Celular_cliente, Estado_cliente) " +
                    "VALUES('" + eClienteSalida.Codigo_cliente + "','" +
                    eClienteSalida.EBase.Id_base + "','" +
                    eClienteSalida.Nombre_cliente + "','" +
                    eClienteSalida.Celular_cliente + "','" +
                    eClienteSalida.Estado_cliente + "'); ");

                    string direccion = Convert.ToString(row["Direccion"]).Trim();
                    string casa = Convert.ToString(row["Casa"]).Trim();
                    string ciudadela = Convert.ToString(row["Ciudadela"]).Trim();
                    string referencia = Convert.ToString(row["Referencia"]).Trim();
                    string observaciones = Convert.ToString(row["Observaciones"]).Trim();

                    EDireccion_clientes eDireccion = new EDireccion_clientes
                    {
                        ECliente = eClienteSalida,
                        Direccion = direccion,
                        Casa = casa,
                        EBarrio = eBarrio,
                        Ciudadela = ciudadela,
                        Referencia = referencia,
                        Observaciones = observaciones,
                        Estado_direccion = "ACTIVO"
                    };

                    consultaCompleta.Append("INSERT INTO Direccion_clientes " +
                    "(Id_cliente, Direccion, Casa, Id_barrio, Ciudadela, Referencia, Observaciones, Estado_direccion) " +
                    "VALUES(last_insert_rowid(),'" +
                    eDireccion.Direccion + "','" +
                    eDireccion.Casa + "','" +
                    eDireccion.EBarrio.Id_barrio + "','" +
                    eDireccion.Ciudadela + "','" +
                    eDireccion.Referencia + "','" +
                    eDireccion.Observaciones + "','" +
                    eDireccion.Estado_direccion + "'); ");
                }
                else
                    result = false;
            }

            if (result)
                consulta = consultaCompleta.ToString();

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
                    columnText = column.ColumnName.ToUpper().Trim();
                    foreach (DataColumn columnClient in dtClientes.Columns)
                    {
                        if (columnText == columnClient.ColumnName.ToUpper().Trim())
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
                    string rpta = "OK";
                    MensajeEspera.ShowWait("Cargando");
                    this.CrearTablaErrores();

                    if (this.VerificarClientes(out string consulta))
                    {
                        rpta = EClientes.InsertarClientes(consulta);
                        if (rpta.Equals("OK"))
                        {
                            MensajeEspera.CloseForm();
                            Mensajes.MensajeInformacion("Se importaron los clientes correctamente", "Entendido");
                            this.Close();
                        }
                        else
                            throw new Exception("Hubo un error al insertar los clientes en la consulta masiva, " + rpta);
                    }
                    MensajeEspera.CloseForm();
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnIniciar_Click",
                    "Hubo un error al cargar los clientes", ex.Message);
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
            if (txt.Text.Equals("Hoja") | txt.Text.Equals(""))
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
            dtEsquema.Columns.Add("Codigo_cliente", typeof(string));
            dtEsquema.Columns.Add("Nombre_cliente", typeof(string));
            dtEsquema.Columns.Add("Celular_cliente", typeof(string));
            dtEsquema.Columns.Add("Direccion", typeof(string));
            dtEsquema.Columns.Add("Casa", typeof(string));
            dtEsquema.Columns.Add("Nombre_barrio", typeof(string));
            dtEsquema.Columns.Add("Ciudadela", typeof(string));
            dtEsquema.Columns.Add("Referencia", typeof(string));
            dtEsquema.Columns.Add("Observaciones", typeof(string));

            this.dgvClientes.DataSource = dtEsquema;
            this.lblResultados.Text = "El archivo a cargar debe tener las mismas columnas, nombre igual y en el mismo orden";
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

                        this.dtClientes = dt;
                        MensajeEspera.CloseForm();
                        if (this.VerificarEsquema())
                        {
                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    this.lblResultados.Text = "Se cargaron " + dt.Rows.Count + " registros";
                                    this.dgvClientes.Enabled = true;
                                }
                                else
                                {
                                    this.dgvClientes.Enabled = false;
                                    this.lblResultados.Text = "No se cargó ningún registro";
                                }
                            }
                            dt.AcceptChanges();
                            this.dgvClientes.DataSource = dt;
                            this.gb4.Enabled = true;

                            this.txtArchivo.Focus();
                        }
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
        private DataTable _dtBases;

        private DataTable dtClientesExistentes;
        private DataTable dtBarriosExistentes;

        private DataTable dtClientes;
        private DataTable dtErrores;

        public DataTable DtBases { get => _dtBases; set => _dtBases = value; }
    }
}
