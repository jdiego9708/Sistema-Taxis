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
    public class DCronogramas
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
        public DCronogramas() { }
        #endregion

        #region METODO INSERTAR CRONOGRAMA
        public static string InsertarCronograma(out int id_cronograma, List<string> vs)
        {
            id_cronograma = 0;          
            string consulta = "INSERT INTO Cronogramas_vehiculos(Id_vehiculo, Id_estado, " +
                "Fecha_cronograma, Estado_cronograma) " +
                "VALUES(@Id_vehiculo, @Id_estado, " +
                "@Fecha_cronograma, @Estado_cronograma); " +
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

                SQLiteParameter Id_cronograma = new SQLiteParameter
                {
                    ParameterName = "@Id_cronograma",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_cronograma);

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_vehiculo);
                contador += 1;

                SQLiteParameter Id_estado = new SQLiteParameter
                {
                    ParameterName = "@Id_estado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_estado);
                contador += 1;

                SQLiteParameter Fecha_cronograma = new SQLiteParameter
                {
                    ParameterName = "@Fecha_cronograma",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Fecha_cronograma);
                contador += 1;

                SQLiteParameter Estado_cronograma = new SQLiteParameter
                {
                    ParameterName = "@Estado_cronograma",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_cronograma);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_cronograma = id;

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

        #region METODO EDITAR CRONOGRAMA
        public static string EditarCronograma(int id_cronograma, List<string> vs)
        {
            string consulta = "UPDATE Cronogramas_vehiculos SET " +
                "Id_vehiculo = @Id_vehiculo, " +
                "Id_estado = @Id_estado, " +
                "Fecha_cronograma = @Fecha_cronograma, " +
                "Estado_cronograma = @Estado_cronograma " +
                "WHERE Id_cronograma = @Id_cronograma ";

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

                SQLiteParameter Id_cronograma = new SQLiteParameter
                {
                    ParameterName = "@Id_cronograma",
                    Value = id_cronograma
                };
                SqlCmd.Parameters.Add(Id_cronograma);

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_vehiculo);
                contador += 1;

                SQLiteParameter Id_estado = new SQLiteParameter
                {
                    ParameterName = "@Id_estado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_estado);
                contador += 1;

                SQLiteParameter Fecha_cronograma = new SQLiteParameter
                {
                    ParameterName = "@Fecha_cronograma",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Fecha_cronograma);
                contador += 1;

                SQLiteParameter Estado_cronograma = new SQLiteParameter
                {
                    ParameterName = "@Estado_cronograma",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_cronograma);
                contador += 1;

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se ingresó el registro";

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

        #region METODO BUSCAR CRONOGRAMAS
        public static DataTable BuscarCronogramas(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Vehiculos vh " +
                "LEFT JOIN Cronogramas_vehiculos crvh ON vh.Id_vehiculo = crvh.Id_vehiculo ");

            if (tipo_busqueda.Equals("FECHA"))
            {
                consulta.Append("WHERE crvh.Fecha_cronograma = '@Texto_busqueda' ");
            }
            else if (tipo_busqueda.Equals("ID CRONOGRAMA"))
            {
                consulta.Append("WHERE crvh.Id_cronograma = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID VEHICULO"))
            {
                consulta.Append("WHERE crvh.Id_vehiculo = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY crvh.Id_cronograma DESC ");

            DataTable DtResultado = new DataTable("Cronogramas");
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

        public static DataTable BuscarCronogramas(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Vehiculos vh " +
                "LEFT JOIN Cronogramas_vehiculos crvh ON vh.Id_vehiculo = crvh.Id_vehiculo ");

            if (tipo_busqueda.Equals("FECHA ID VEHICULO"))
            {
                consulta.Append("WHERE crvh.Fecha_cronograma = '@Texto_busqueda1' and crvhh.Id_vehiculo = @Texto_busqueda2 ");
            }
            else if (tipo_busqueda.Equals("ID CRONOGRAMA"))
            {
                consulta.Append("WHERE crvh.Id_cronograma = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID VEHICULO"))
            {
                consulta.Append("WHERE crvh.Id_vehiculo = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY crvh.Id_cronograma DESC ");

            DataTable DtResultado = new DataTable("Cronogramas");
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

                SQLiteParameter Texto_busqueda1 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda1",
                    Size = 50,
                    Value = texto_busqueda1.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Texto_busqueda1);

                SQLiteParameter Texto_busqueda2 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda2",
                    Size = 50,
                    Value = texto_busqueda2.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Texto_busqueda2);

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
