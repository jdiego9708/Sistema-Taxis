using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace CapaDatos
{
    public class DClientes
    {
        #region VARIABLES
        private static string mensaje_respuesta;
        public static string Mensaje_respuesta
        {
            get
            {
                return mensaje_respuesta;
            }

            set
            {
                mensaje_respuesta = value;
            }
        }

        #endregion

        #region CONSTRUCTOR VACIO
        public DClientes() { }
        #endregion

        #region METODO INSERTAR CLIENTE
        public static string InsertarCliente(out int id_cliente, List<string> vs)
        {
            id_cliente = 0;          
            string consulta = "INSERT INTO Clientes(Codigo_cliente, Id_base, Nombre_cliente, Celular_cliente, Estado_cliente) " +
                "VALUES(@Codigo_cliente, @Id_base, @Nombre_cliente, @Celular_cliente, @Estado_cliente); " +
                "SELECT last_insert_rowid() ";

            SQLiteConnection SqlCon = DConexion.Conex(out string rpta);
            try
            {
                int contador = 0;

                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SQLiteParameter Id_cliente = new SQLiteParameter
                {
                    ParameterName = "@Id_cliente",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_cliente);

                SQLiteParameter Codigo_cliente = new SQLiteParameter
                {
                    ParameterName = "@Codigo_cliente",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Codigo_cliente);
                contador += 1;

                SQLiteParameter Id_base = new SQLiteParameter
                {
                    ParameterName = "@Id_base",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_base);
                contador += 1;

                SQLiteParameter Nombre_cliente = new SQLiteParameter
                {
                    ParameterName = "@Nombre_cliente",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_cliente);
                contador += 1;

                SQLiteParameter Celular_cliente = new SQLiteParameter
                {
                    ParameterName = "@Celular_cliente",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Celular_cliente);
                contador += 1;

                SQLiteParameter Estado_cliente = new SQLiteParameter
                {
                    ParameterName = "@Estado_cliente",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_cliente);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_cliente = id;
                if (id > 0)
                    rpta = "OK";
                else
                    throw new Exception("La identificación única (ID) no se obtuvo correctamente: " + rpta);

                if (!rpta.Equals("OK"))
                {
                    if (Mensaje_respuesta != null)
                        rpta = Mensaje_respuesta;
                }
            }
            //Mostramos posible error que tengamos
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO EDITAR CLIENTE
        public static string EditarCliente(int id_cliente, List<string> vs)
        {
            string consulta = "UPDATE Clientes " +
                "SET Codigo_cliente = @Codigo_cliente, " +
                "Id_base = @Id_base, " +
                "Nombre_cliente = @Nombre_cliente, " +
                "Celular_cliente = @Celular_cliente, " +
                "Estado_cliente = @Estado_cliente " +
                "WHERE Id_cliente = @Id_cliente ";

            SQLiteConnection SqlCon = DConexion.Conex(out string rpta);
            try
            {
                int contador = 0;

                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SQLiteParameter Id_cliente = new SQLiteParameter
                {
                    ParameterName = "@Id_cliente",
                    Value = id_cliente
                };
                SqlCmd.Parameters.Add(Id_cliente);

                SQLiteParameter Codigo_cliente = new SQLiteParameter
                {
                    ParameterName = "@Codigo_cliente",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Codigo_cliente);
                contador += 1;

                SQLiteParameter Id_base = new SQLiteParameter
                {
                    ParameterName = "@Id_base",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_base);
                contador += 1;

                SQLiteParameter Nombre_cliente = new SQLiteParameter
                {
                    ParameterName = "@Nombre_cliente",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_cliente);
                contador += 1;

                SQLiteParameter Celular_cliente = new SQLiteParameter
                {
                    ParameterName = "@Celular_cliente",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Celular_cliente);
                contador += 1;

                SQLiteParameter Estado_cliente = new SQLiteParameter
                {
                    ParameterName = "@Estado_cliente",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Estado_cliente);
                contador += 1;

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se ingresó el registro";

                if (!rpta.Equals("OK"))
                {
                    if (Mensaje_respuesta != null)
                        rpta = Mensaje_respuesta;
                }
            }
            //Mostramos posible error que tengamos
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO BUSCAR CLIENTES
        public static DataTable BuscarClientes(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * " +
                "FROM Clientes cl INNER JOIN Bases_clientes bcl ON cl.Id_base = bcl.Id_base ");

            if (tipo_busqueda.Equals("COMPLETO"))
            {
                consulta.Append("WHERE cl.Estado_cliente = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("NOMBRE"))
            {
                consulta.Append("WHERE cl.Nombre_cliente like '" + texto_busqueda + "%' " +
                    "and cl.Estado_cliente = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("CELULAR"))
            {
                consulta.Append("WHERE cl.Celular_cliente like '" + texto_busqueda + "%' " +
                    "and cl.Estado_cliente = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("ESTADO"))
            {
                consulta.Append("WHERE cl.Estado_cliente = '@Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID CLIENTE"))
            {
                consulta.Append("WHERE cl.Id_cliente = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("CODIGO"))
            {
                consulta.Append("WHERE cl.Codigo_cliente = '" + texto_busqueda + "' ");
            }

            consulta.Append("ORDER BY cl.Id_cliente DESC ");

            DataTable DtResultado = new DataTable("Clientes");
            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = Convert.ToString(consulta),
                    CommandType = CommandType.Text
                };

                SQLiteParameter Texto_busqueda = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda",
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Texto_busqueda);

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);

                if (DtResultado.Rows.Count < 1)
                {
                    DtResultado = null;
                }
            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtResultado;
        }

        #endregion
    }
}
