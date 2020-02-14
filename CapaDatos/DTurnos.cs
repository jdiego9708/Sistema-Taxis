using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace CapaDatos
{
    public class DTurnos
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
        public DTurnos() { }
        #endregion

        #region METODO INSERTAR TURNO
        public static string InsertarTurno(out int id_turno, List<string> vs)
        {
            id_turno = 0;
            string consulta = "INSERT INTO Turnos(Id_empleado, Hora_inicio_turno, Hora_fin_turno, Fecha_turno, Estado_turno) " +
                "VALUES(@Id_empleado, @Hora_inicio_turno, @Hora_fin_turno, @Fecha_turno, @Estado_turno); " +
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

                SQLiteParameter Id_turno = new SQLiteParameter
                {
                    ParameterName = "@Id_turno",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_turno);

                SQLiteParameter Id_empleado = new SQLiteParameter
                {
                    ParameterName = "@Id_empleado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_empleado);
                contador += 1;

                SQLiteParameter Hora_inicio_turno = new SQLiteParameter
                {
                    ParameterName = "@Hora_inicio_turno",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Hora_inicio_turno);
                contador += 1;

                SQLiteParameter Hora_fin_turno = new SQLiteParameter
                {
                    ParameterName = "@Hora_fin_turno",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Hora_fin_turno);
                contador += 1;

                SQLiteParameter Fecha_turno = new SQLiteParameter
                {
                    ParameterName = "@Fecha_turno",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Fecha_turno);
                contador += 1;

                SQLiteParameter Estado_turno = new SQLiteParameter
                {
                    ParameterName = "@Estado_turno",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Estado_turno);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_turno = id;
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

        #region METODO EDITAR TURNO
        public static string EditarTurno(int id_turno, List<string> vs)
        {
            string consulta = "UPDATE Turnos SET " +
                "Hora_inicio_turno = @Hora_inicio_turno, " +
                "Id_empleado = @Id_empleado, " +
                "Hora_fin_turno = @Hora_fin_turno , " +
                "Fecha_turno = @Fecha_turno, " +
                "Estado_turno = @Estado_turno " +
                "WHERE Id_turno = @Id_turno";

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

                SQLiteParameter Id_turno = new SQLiteParameter
                {
                    ParameterName = "@Id_turno",
                    Value = id_turno
                };
                SqlCmd.Parameters.Add(Id_turno);

                SQLiteParameter Id_empleado = new SQLiteParameter
                {
                    ParameterName = "@Id_empleado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_empleado);
                contador += 1;

                SQLiteParameter Hora_inicio_turno = new SQLiteParameter
                {
                    ParameterName = "@Hora_inicio_turno",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Hora_inicio_turno);
                contador += 1;

                SQLiteParameter Hora_fin_turno = new SQLiteParameter
                {
                    ParameterName = "@Hora_fin_turno",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Hora_fin_turno);
                contador += 1;

                SQLiteParameter Fecha_turno = new SQLiteParameter
                {
                    ParameterName = "@Fecha_turno",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Fecha_turno);
                contador += 1;

                SQLiteParameter Estado_turno = new SQLiteParameter
                {
                    ParameterName = "@Estado_turno",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Estado_turno);
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

        #region METODO BUSCAR TURNOS
        public static DataTable BuscarTurnos(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * " +
                "FROM Turnos tu " +
                "INNER JOIN Empleados em ON tu.Id_empleado = em.Id_empleado ");

            if (tipo_busqueda.Equals("FECHA"))
            {
                consulta.Append("WHERE Fecha_turno = '" + texto_busqueda + "' ");
            }
            else if (tipo_busqueda.Equals("ID TURNO"))
            {
                consulta.Append("WHERE Id_turno = " + texto_busqueda + " ");
            }

            consulta.Append("ORDER BY Id_turno DESC ");

            DataTable DtResultado = new DataTable("Turnos");
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
