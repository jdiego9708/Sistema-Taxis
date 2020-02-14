using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace CapaDatos
{
    public class DCorreos
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
        public DCorreos() { }
        #endregion

        #region METODO INSERTAR CORREO
        public static string InsertarCorreo(out int id_correo, List<string> vs)
        {
            id_correo = 0;
            string consulta = "INSERT INTO ConfiguracionCorreos(Correo_remitente, Clave_correo_remitente, Correo_destinatario, Correo_copia, Tipo_correo, Estado_correo) " +
                "VALUES(@Correo_remitente, @Clave_correo_remitente, @Correo_destinatario, @Correo_copia, @Tipo_correo, @Estado_correo); " +
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

                SQLiteParameter Id_correo = new SQLiteParameter
                {
                    ParameterName = "@Id_correo",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_correo);

                SQLiteParameter Correo_remitente = new SQLiteParameter
                {
                    ParameterName = "@Correo_remitente",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Correo_remitente);
                contador += 1;

                SQLiteParameter Clave_correo_remitente = new SQLiteParameter
                {
                    ParameterName = "@Clave_correo_remitente",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Clave_correo_remitente);
                contador += 1;

                SQLiteParameter Correo_destinatario = new SQLiteParameter
                {
                    ParameterName = "@Correo_destinatario",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Correo_destinatario);
                contador += 1;

                SQLiteParameter Correo_copia = new SQLiteParameter
                {
                    ParameterName = "@Correo_copia",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Correo_copia);
                contador += 1;

                SQLiteParameter Tipo_correo = new SQLiteParameter
                {
                    ParameterName = "@Tipo_correo",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Tipo_correo);
                contador += 1;

                SQLiteParameter Estado_correo = new SQLiteParameter
                {
                    ParameterName = "@Estado_correo",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Estado_correo);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_correo = id;
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

        #region METODO EDITAR CORREO
        public static string EditarCorreo(int id_correo, List<string> vs)
        {
            string consulta = "UPDATE ConfiguracionCorreos SET " +
                "Correo_remitente = @Correo_remitente, " +
                "Clave_correo_remitente = @Clave_correo_remitente, " +
                "Correo_destinatario = @Correo_destinatario , " +
                "Correo_copia = @Correo_copia, " +
                "Tipo_correo = @Tipo_correo, " +
                "Estado_correo = @Estado_correo " +
                "WHERE Id_correo = @Id_correo";

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

                SQLiteParameter Id_correo = new SQLiteParameter
                {
                    ParameterName = "@Id_correo",
                    Value = id_correo
                };
                SqlCmd.Parameters.Add(Id_correo);

                SQLiteParameter Correo_remitente = new SQLiteParameter
                {
                    ParameterName = "@Correo_remitente",
                    Value = Convert.ToString(vs[contador]).Trim()
                };
                SqlCmd.Parameters.Add(Correo_remitente);
                contador += 1;

                SQLiteParameter Clave_correo_remitente = new SQLiteParameter
                {
                    ParameterName = "@Clave_correo_remitente",
                    Value = Convert.ToString(vs[contador]).Trim()
                };
                SqlCmd.Parameters.Add(Clave_correo_remitente);
                contador += 1;

                SQLiteParameter Correo_destinatario = new SQLiteParameter
                {
                    ParameterName = "@Correo_destinatario",
                    Value = Convert.ToString(vs[contador]).Trim()
                };
                SqlCmd.Parameters.Add(Correo_destinatario);
                contador += 1;

                SQLiteParameter Correo_copia = new SQLiteParameter
                {
                    ParameterName = "@Correo_copia",
                    Value = Convert.ToString(vs[contador]).Trim()
                };
                SqlCmd.Parameters.Add(Correo_copia);
                contador += 1;

                SQLiteParameter Tipo_correo = new SQLiteParameter
                {
                    ParameterName = "@Tipo_correo",
                    Value = Convert.ToString(vs[contador]).Trim()
                };
                SqlCmd.Parameters.Add(Tipo_correo);
                contador += 1;

                SQLiteParameter Estado_correo = new SQLiteParameter
                {
                    ParameterName = "@Estado_correo",
                    Value = Convert.ToString(vs[contador]).Trim()
                };
                SqlCmd.Parameters.Add(Estado_correo);
                contador += 1;

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se ingresó el registro";

                if (!rpta.Equals("OK"))
                {
                    if (Mensaje_respuesta != null)
                        rpta = Mensaje_respuesta;
                }

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

        #region METODO BUSCAR CORREOS

        public static DataTable BuscarCorreos(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            string comprobacion = Comprobaciones.ComprobacionTablaCorreos("ConfiguracionCorreos");
            if (!comprobacion.Equals("OK"))
            {
                rpta = comprobacion;
                return null;
            }

            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * " +
                "FROM ConfiguracionCorreos ");

            if (tipo_busqueda.Equals("TIPO"))
            {
                consulta.Append("WHERE Tipo_correo = '" + texto_busqueda + "' ");
            }
            else if (tipo_busqueda.Equals("ID CORREO"))
            {
                consulta.Append("WHERE Id_correo = " + texto_busqueda + " ");
            }

            consulta.Append("ORDER BY Id_correo DESC ");

            DataTable DtResultado = new DataTable("Correos");
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
