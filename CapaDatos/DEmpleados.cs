using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DEmpleados
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
        public DEmpleados() { }
        #endregion

        #region METODO INSERTAR EMPLEADO
        public static string InsertarEmpleado(out int id_empleado, List<string> vs)
        {
            id_empleado = 0;
            string consulta = "INSERT INTO Empleados(Nombre_empleado, Correo_empleado, Tipo_empleado, Estado_empleado) " +
                "VALUES(@Nombre_empleado, @Correo_empleado, @Tipo_empleado, @Estado_empleado); " +
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

                SQLiteParameter Id_empleado = new SQLiteParameter
                {
                    ParameterName = "@Id_empleado",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_empleado);

                SQLiteParameter Nombre_empleado = new SQLiteParameter
                {
                    ParameterName = "@Nombre_empleado",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_empleado);
                contador += 1;

                SQLiteParameter Correo_empleado = new SQLiteParameter
                {
                    ParameterName = "@Correo_empleado",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Correo_empleado);
                contador += 1;

                SQLiteParameter Tipo_empleado = new SQLiteParameter
                {
                    ParameterName = "@Tipo_empleado",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Tipo_empleado);
                contador += 1;

                SQLiteParameter Estado_empleado = new SQLiteParameter
                {
                    ParameterName = "@Estado_empleado",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Estado_empleado);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_empleado = id;
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

        #region METODO EDITAR EMPLEADO
        public static string EditarEmpleado(int id_empleado, List<string> vs)
        {
            string consulta = "UPDATE Empleados SET " +
                "Nombre_empleado = @Nombre_empleado, " +
                "Correo_empleado = @Correo_empleado, " +
                "Tipo_empleado = @Tipo_empleado, " +
                "Estado_empleado = @Estado_empleado " +
                "WHERE Id_empleado = @Id_empleado ";

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

                SQLiteParameter Id_empleado = new SQLiteParameter
                {
                    ParameterName = "@Id_empleado",
                    Value = id_empleado
                };
                SqlCmd.Parameters.Add(Id_empleado);

                SQLiteParameter Nombre_empleado = new SQLiteParameter
                {
                    ParameterName = "@Nombre_empleado",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_empleado);
                contador += 1;

                SQLiteParameter Correo_empleado = new SQLiteParameter
                {
                    ParameterName = "@Correo_empleado",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Correo_empleado);
                contador += 1;

                SQLiteParameter Tipo_empleado = new SQLiteParameter
                {
                    ParameterName = "@Tipo_empleado",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Tipo_empleado);
                contador += 1;

                SQLiteParameter Estado_empleado = new SQLiteParameter
                {
                    ParameterName = "@Estado_empleado",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Estado_empleado);
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

        #region METODO BUSCAR EMPLEADOS
        public static DataTable BuscarEmpleado(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Empleados ");

            if (tipo_busqueda.Equals("COMPLETO"))
            {
                consulta.Append("WHERE Estado_empleado = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("NOMBRE"))
            {
                consulta.Append("WHERE Nombre_empleado like '@Texto_busqueda%' " +
                    "and Estado_empleado = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("TIPO EMPLEADO"))
            {
                consulta.Append("WHERE Tipo_empleado like '@Texto_busqueda' " +
                    "and Estado_empleado = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("ESTADO"))
            {
                consulta.Append("WHERE Estado_empleado = '@Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID EMPLEADO"))
            {
                consulta.Append("WHERE Id_empleado = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY Id_empleado DESC ");

            DataTable DtResultado = new DataTable("Empleados");
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

        #region METODO LOGIN
        public static DataTable Login(string nombre_empleado, string password,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM " +
                "Empleados em INNER JOIN Credenciales_empleado cred ON em.Id_empleado = cred.Id_empleado " +
                "WHERE em.Nombre_empleado = @Nombre and " +
                "cred.Password = @Password " +
                "ORDER BY cred.Fecha_modificacion DESC ");

            DataTable DtResultado = new DataTable("Empleados");
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

                SQLiteParameter Nombre = new SQLiteParameter
                {
                    ParameterName = "@Nombre",
                    Size = 150,
                    Value = nombre_empleado
                };
                SqlCmd.Parameters.Add(Nombre);

                SQLiteParameter Texto_busqueda = new SQLiteParameter
                {
                    ParameterName = "@Password",
                    Size = 50,
                    Value = password
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
