using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace CapaDatos
{
    public class DEstados_vehiculos
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
        public DEstados_vehiculos() { }
        #endregion

        #region METODO INSERTAR ESTADO
        public static string InsertarEstadoVehiculo(out int id_estado, List<string> vs)
        {
            id_estado = 0;
            string consulta = "INSERT INTO Estados_vehiculos(Nombre_estado, Alias_estado, Color_estado, " +
                "Color_letra, Estado_order, Enabled) " +
                "VALUES(@Nombre_estado, @Alias_estado, @Color_estado, @Color_letra, @Estado_order, @Enabled); " +
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

                SQLiteParameter Id_estado = new SQLiteParameter
                {
                    ParameterName = "@Id_estado",
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_estado);

                SQLiteParameter Nombre_estado = new SQLiteParameter
                {
                    ParameterName = "@Nombre_estado",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_estado);
                contador += 1;

                SQLiteParameter Alias_estado = new SQLiteParameter
                {
                    ParameterName = "@Alias_estado",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Alias_estado);
                contador += 1;

                SQLiteParameter Color_estado = new SQLiteParameter
                {
                    ParameterName = "@Color_estado",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Color_estado);
                contador += 1;

                SQLiteParameter Color_letra = new SQLiteParameter
                {
                    ParameterName = "@Color_letra",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Color_letra);
                contador += 1;

                SQLiteParameter Estado_order = new SQLiteParameter
                {
                    ParameterName = "@Estado_order",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Estado_order);
                contador += 1;

                SQLiteParameter Enabled = new SQLiteParameter
                {
                    ParameterName = "@Enabled",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Enabled);
                contador += 1;
               
                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_estado = id;
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

        #region METODO EDITAR ESTADO
        public static string EditarEstadoVehiculo(int id_estado, List<string> vs)
        {
            string consulta = "UPDATE Estados_vehiculos SET " +
                "Nombre_estado = @Nombre_estado, " +
                "Alias_estado = @Alias_estado, " +
                "Color_estado = @Color_estado, " +
                "Color_letra = @Color_letra, " +
                "Estado_order = @Estado_order, " +
                "Enabled = @Enabled " +
                "WHERE Id_estado = @Id_estado ";

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

                SQLiteParameter Id_estado = new SQLiteParameter
                {
                    ParameterName = "@Id_estado",
                    Value = id_estado
                };
                SqlCmd.Parameters.Add(Id_estado);

                SQLiteParameter Nombre_estado = new SQLiteParameter
                {
                    ParameterName = "@Nombre_estado",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_estado);
                contador += 1;

                SQLiteParameter Alias_estado = new SQLiteParameter
                {
                    ParameterName = "@Alias_estado",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Alias_estado);
                contador += 1;

                SQLiteParameter Color_estado = new SQLiteParameter
                {
                    ParameterName = "@Color_estado",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Color_estado);
                contador += 1;

                SQLiteParameter Color_letra = new SQLiteParameter
                {
                    ParameterName = "@Color_letra",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Color_letra);
                contador += 1;

                SQLiteParameter Estado_order = new SQLiteParameter
                {
                    ParameterName = "@Estado_order",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Estado_order);
                contador += 1;

                SQLiteParameter Enabled = new SQLiteParameter
                {
                    ParameterName = "@Enabled",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Enabled);
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

        #region METODO BUSCAR ESTADOS
        public static DataTable BuscarEstados(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Estados_vehiculos ");

            if (tipo_busqueda.Equals("COMPLETO"))
            {
                consulta.Append("WHERE Enabled = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("NOMBRE"))
            {
                consulta.Append("WHERE Nombre = '@Texto_busqueda' " +
                    "and Estado_vehiculo = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("ID ESTADO"))
            {
                consulta.Append("WHERE Id_estado = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY Id_estado DESC ");

            DataTable DtResultado = new DataTable("Estados_vehiculos");
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
