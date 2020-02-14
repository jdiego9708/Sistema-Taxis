using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SQLite;

namespace CapaDatos
{
    public class DBases_clientes
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
        public DBases_clientes() { }
        #endregion

        #region METODO INSERTAR BASE
        public static string InsertarBase(out int id_base, List<string> vs)
        {
            id_base = 0;          
            string consulta = "INSERT INTO Bases_clientes(Nombre_base, Alias_base) " +
                "VALUES(@Nombre_base, @Alias_base); " +
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

                SQLiteParameter Id_base = new SQLiteParameter
                {
                    ParameterName = "@Id_base",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_base);

                SQLiteParameter Nombre_base = new SQLiteParameter
                {
                    ParameterName = "@Nombre_base",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_base);
                contador += 1;

                SQLiteParameter Alias_base = new SQLiteParameter
                {
                    ParameterName = "@Alias_base",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Alias_base);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_base = id;

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

        #region METODO EDITAR BASE
        public static string EditarBarrio(int id_base, List<string> vs)
        {
            string consulta = "UPDATE Bases_clientes " +
                "SET Nombre_base = @Nombre_base, " +
                "Alias_base = @Alias_base " +
                "WHERE Id_base = @Id_base; ";

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

                SQLiteParameter Id_base = new SQLiteParameter
                {
                    ParameterName = "@Id_base",
                    Value = id_base
                };
                SqlCmd.Parameters.Add(Id_base);

                SQLiteParameter Nombre_base = new SQLiteParameter
                {
                    ParameterName = "@Nombre_base",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_base);
                contador += 1;

                SQLiteParameter Alias_base = new SQLiteParameter
                {
                    ParameterName = "@Alias_base",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Alias_base);
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

        #region METODO BUSCAR BASES
        public static DataTable BuscarBases(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Bases_clientes ");

            if (tipo_busqueda.Equals("NOMBRE"))
            {
                consulta.Append("WHERE Nombre_base like '@Texto_busqueda%' ");
            }
            else if (tipo_busqueda.Equals("ID BASE"))
            {
                consulta.Append("WHERE Id_base = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY Id_base ASC ");

            DataTable DtResultado = new DataTable("Bases");
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
