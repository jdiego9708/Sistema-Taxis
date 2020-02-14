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
    public class DBarrios
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
        public DBarrios() { }
        #endregion

        #region METODO INSERTAR BARRIO
        public static string InsertarBarrio(out int id_barrio, List<string> vs)
        {
            id_barrio = 0;          
            string consulta = "INSERT INTO Barrios(Nombre_barrio) " +
                "VALUES(@Nombre_barrio); " +
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

                SQLiteParameter Id_barrio = new SQLiteParameter
                {
                    ParameterName = "@Id_barrio",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_barrio);

                SQLiteParameter Nombre_barrio = new SQLiteParameter
                {
                    ParameterName = "@Nombre_barrio",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_barrio);
                contador += 1;
              
                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_barrio = id;

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

        #region METODO EDITAR BARRIO
        public static string EditarBarrio(int id_barrio, List<string> vs)
        {
            string consulta = "UPDATE Barrios " +
                "SET Nombre_barrio = @Nombre_barrio " +              
                "WHERE Id_barrio = @Id_barrio; ";

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

                SQLiteParameter Id_barrio = new SQLiteParameter
                {
                    ParameterName = "@Id_barrio",
                    Value = id_barrio
                };
                SqlCmd.Parameters.Add(Id_barrio);

                SQLiteParameter Nombre_barrio = new SQLiteParameter
                {
                    ParameterName = "@Nombre_barrio",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_barrio);
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

        #region METODO BUSCAR BARRIOS
        public static DataTable BuscarBarrios(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Barrios ");

            if (tipo_busqueda.Equals("NOMBRE"))
            {
                consulta.Append("WHERE Nombre_barrio like '@Texto_busqueda%' ");
            }
            else if (tipo_busqueda.Equals("ID BARRIO"))
            {
                consulta.Append("WHERE Id_barrio = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY Id_barrio DESC ");

            DataTable DtResultado = new DataTable("Barrios");
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
