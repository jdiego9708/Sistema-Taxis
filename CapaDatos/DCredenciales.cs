using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCredenciales
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
        public DCredenciales() { }
        #endregion

        #region METODO INSERTAR CREDENCIAL
        public static string InsertarCredenciales(List<string> vs)
        {
            string consulta = "INSERT INTO Credenciales_empleado(Id_empleado, Password, Fecha_modificacion) " +
                "VALUES(@Id_empleado, @Password, @Fecha_modificacion); " +
                "SELECT last_insert_rowid() ";
            int contador = 0;
            SQLiteConnection SqlCon = DConexion.Conex(out string rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SQLiteParameter Id_empleado = new SQLiteParameter
                {
                    ParameterName = "@Id_empleado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_empleado);
                contador += 1;

                SQLiteParameter Password = new SQLiteParameter
                {
                    ParameterName = "@Password",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Password);
                contador += 1;

                SQLiteParameter Fecha_modificacion = new SQLiteParameter
                {
                    ParameterName = "@Fecha_modificacion",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Fecha_modificacion);
                contador += 1;

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "ERROR";

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

        #region METODO EDITAR CREDENCIALES
        public static string EditarCredenciales(List<string> vs)
        {
            string consulta = "UPDATE Credenciales_empleado SET " +
                "Password = '@Password', " +
                "Fecha_modificacion = '@Fecha_modificacion' " +
                "WHERE Id_empleado = @Id_empleado ";
            int contador = 0;
            SQLiteConnection SqlCon = DConexion.Conex(out string rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SQLiteParameter Id_empleado = new SQLiteParameter
                {
                    ParameterName = "@Id_empleado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_empleado);
                contador += 1;

                SQLiteParameter Password = new SQLiteParameter
                {
                    ParameterName = "@Password",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Password);
                contador += 1;

                SQLiteParameter Fecha_modificacion = new SQLiteParameter
                {
                    ParameterName = "@Fecha_modificacion",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Fecha_modificacion);
                contador += 1;

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "ERROR";

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

        #region METODO BUSCAR CREDENCIALES
        public static DataTable BuscarCredenciales(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Credenciales_empleado ");

            if (tipo_busqueda.Equals("ID EMPLEADO"))
            {
                consulta.Append("WHERE Id_empleado = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY Fecha_modificacion DESC ");

            DataTable DtResultado = new DataTable("Credenciales");
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
