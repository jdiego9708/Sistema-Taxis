using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDireccion_clientes
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
        public DDireccion_clientes() { }
        #endregion

        #region METODO INSERTAR DIRECCION CLIENTE
        public static string InsertarDireccionCliente(out int id_direccion, List<string> vs)
        {
            id_direccion = 0;
            string consulta = "INSERT INTO Direccion_clientes(Id_cliente, Direccion, Casa, Id_barrio, Ciudadela, Referencia, Observaciones, Estado_direccion) " +
                "VALUES(@Id_cliente, @Direccion, @Casa, @Id_barrio, @Ciudadela, @Referencia, @Observaciones, @Estado_direccion); " +
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

                SQLiteParameter Id_direccion = new SQLiteParameter
                {
                    ParameterName = "@Id_direccion",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_direccion);

                SQLiteParameter Id_cliente = new SQLiteParameter
                {
                    ParameterName = "@Id_cliente",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                SQLiteParameter Direccion = new SQLiteParameter
                {
                    ParameterName = "@Direccion",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Direccion);
                contador += 1;

                SQLiteParameter Casa = new SQLiteParameter
                {
                    ParameterName = "@Casa",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Casa);
                contador += 1;

                SQLiteParameter Id_barrio = new SQLiteParameter
                {
                    ParameterName = "@Id_barrio",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_barrio);
                contador += 1;

                SQLiteParameter Ciudadela = new SQLiteParameter
                {
                    ParameterName = "@Ciudadela",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Ciudadela);
                contador += 1;

                SQLiteParameter Referencia = new SQLiteParameter
                {
                    ParameterName = "@Referencia",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Referencia);
                contador += 1;

                SQLiteParameter Observaciones = new SQLiteParameter
                {
                    ParameterName = "@Observaciones",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Observaciones);
                contador += 1;

                SQLiteParameter Estado_direccion = new SQLiteParameter
                {
                    ParameterName = "@Estado_direccion",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_direccion);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_direccion = id;
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

        #region METODO EDITAR DIRECCION CLIENTE
        public static string EditarDireccionCliente(int id_direccion, List<string> vs)
        {
            string consulta = "UPDATE Direccion_clientes SET " +
                "Id_cliente = @Id_cliente, " +
                "Direccion = @Direccion, " +
                "Casa = @Casa, " +
                "Id_barrio = @Id_barrio, " +
                "Ciudadela = @Ciudadela, " +
                "Referencia = @Referencia, " +
                "Observaciones = @Observaciones, " +
                "Estado_direccion = @Estado_direccion " +
                "WHERE Id_direccion = @Id_direccion ";

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

                SQLiteParameter Id_direccion = new SQLiteParameter
                {
                    ParameterName = "@Id_direccion",
                    Value = id_direccion
                };
                SqlCmd.Parameters.Add(Id_direccion);

                SQLiteParameter Id_cliente = new SQLiteParameter
                {
                    ParameterName = "@Id_cliente",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                SQLiteParameter Direccion = new SQLiteParameter
                {
                    ParameterName = "@Direccion",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Direccion);
                contador += 1;

                SQLiteParameter Casa = new SQLiteParameter
                {
                    ParameterName = "@Casa",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Casa);
                contador += 1;

                SQLiteParameter Id_barrio = new SQLiteParameter
                {
                    ParameterName = "@Id_barrio",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_barrio);
                contador += 1;

                SQLiteParameter Ciudadela = new SQLiteParameter
                {
                    ParameterName = "@Ciudadela",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Ciudadela);
                contador += 1;

                SQLiteParameter Referencia = new SQLiteParameter
                {
                    ParameterName = "@Referencia",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Referencia);
                contador += 1;

                SQLiteParameter Observaciones = new SQLiteParameter
                {
                    ParameterName = "@Observaciones",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Observaciones);
                contador += 1;

                SQLiteParameter Estado_direccion = new SQLiteParameter
                {
                    ParameterName = "@Estado_direccion",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_direccion);
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

        #region METODO BUSCAR DIRECCION CLIENTES
        public static DataTable BuscarDireccionClientes(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * " +
                "FROM Direccion_clientes dcl " +
                "INNER JOIN Clientes cl " +
                "ON dcl.Id_cliente = cl.Id_cliente " +
                "INNER JOIN Bases_clientes bcl " +
                "ON cl.Id_base = bcl.Id_base " +
                "INNER JOIN Barrios ba " +
                "ON dcl.Id_barrio = ba.Id_barrio ");

            if (tipo_busqueda.Equals("COMPLETO"))
            {
                consulta.Append("WHERE Estado_direccion = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("NOMBRE"))
            {
                consulta.Append("WHERE cl.Nombre_cliente like '@Texto_busqueda%' " +
                    "and cl.Estado_cliente = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("CELULAR"))
            {
                consulta.Append("WHERE cl.Celular_cliente like '@Texto_busqueda%' " +
                    "and cl.Estado_cliente = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("ESTADO"))
            {
                consulta.Append("WHERE Estado_direccion = '@Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID CLIENTE"))
            {
                consulta.Append("WHERE cl.Id_cliente = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("CODIGO"))
            {
                consulta.Append("WHERE cl.Codigo_cliente = '" + texto_busqueda + "' ");
            }

            consulta.Append("ORDER BY Id_direccion DESC ");

            DataTable DtResultado = new DataTable("DireccionesCliente");
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
