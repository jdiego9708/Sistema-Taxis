using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DVehiculos
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
        public DVehiculos() { }
        #endregion

        #region METODO INSERTAR VEHICULO
        public static string InsertarVehiculo(int id_vehiculo, List<string> vs)
        {
            string consulta = "INSERT INTO Vehiculos(Id_vehiculo, Placa, Propietario, Chofer, Marca, Modelo, Color, Estado_vehiculo, Correo_chofer) " +
                "VALUES(@Id_vehiculo, @Placa, @Propietario, @Chofer, @Marca, @Modelo, @Color, @Estado_vehiculo, @Correo_chofer); " +
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

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = id_vehiculo
                };
                SqlCmd.Parameters.Add(Id_vehiculo);

                SQLiteParameter Placa = new SQLiteParameter
                {
                    ParameterName = "@Placa",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Placa);
                contador += 1;

                SQLiteParameter Propietario = new SQLiteParameter
                {
                    ParameterName = "@Propietario",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Propietario);
                contador += 1;

                SQLiteParameter Chofer = new SQLiteParameter
                {
                    ParameterName = "@Chofer",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Chofer);
                contador += 1;

                SQLiteParameter Marca = new SQLiteParameter
                {
                    ParameterName = "@Marca",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Marca);
                contador += 1;

                SQLiteParameter Modelo = new SQLiteParameter
                {
                    ParameterName = "@Modelo",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Modelo);
                contador += 1;

                SQLiteParameter Color = new SQLiteParameter
                {
                    ParameterName = "@Color",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Color);
                contador += 1;

                SQLiteParameter Estado_direccion = new SQLiteParameter
                {
                    ParameterName = "@Estado_vehiculo",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_direccion);
                contador += 1;

                SQLiteParameter Correo_chofer = new SQLiteParameter
                {
                    ParameterName = "@Correo_chofer",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Correo_chofer);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_vehiculo = id;
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

        #region METODO EDITAR VEHICULO
        public static string EditarVehiculo(int id_vehiculo, List<string> vs)
        {
            string consulta = "UPDATE Vehiculos SET " +
                "Placa = @Placa, " +
                "Propietario = @Propietario, " +
                "Chofer = @Chofer, " +
                "Marca = @Marca, " +
                "Modelo = @Modelo, " +
                "Color = @Color, " +
                "Estado_vehiculo = @Estado_vehiculo, " +
                "Correo_chofer = @Correo_chofer " +
                "WHERE Id_vehiculo = @Id_vehiculo ";

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

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = id_vehiculo
                };
                SqlCmd.Parameters.Add(Id_vehiculo);

                SQLiteParameter Placa = new SQLiteParameter
                {
                    ParameterName = "@Placa",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Placa);
                contador += 1;

                SQLiteParameter Propietario = new SQLiteParameter
                {
                    ParameterName = "@Propietario",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Propietario);
                contador += 1;

                SQLiteParameter Chofer = new SQLiteParameter
                {
                    ParameterName = "@Chofer",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Chofer);
                contador += 1;

                SQLiteParameter Marca = new SQLiteParameter
                {
                    ParameterName = "@Marca",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Marca);
                contador += 1;

                SQLiteParameter Modelo = new SQLiteParameter
                {
                    ParameterName = "@Modelo",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Modelo);
                contador += 1;

                SQLiteParameter Color = new SQLiteParameter
                {
                    ParameterName = "@Color",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Color);
                contador += 1;

                SQLiteParameter Estado_direccion = new SQLiteParameter
                {
                    ParameterName = "@Estado_vehiculo",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_direccion);
                contador += 1;

                SQLiteParameter Correo_chofer = new SQLiteParameter
                {
                    ParameterName = "@Correo_chofer",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Correo_chofer);
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

        #region METODO BUSCAR VEHICULOS
        public static DataTable BuscarVehiculos(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Vehiculos ");

            if (tipo_busqueda.Equals("COMPLETO"))
            {
                consulta.Append("WHERE Estado_vehiculo = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("PLACA"))
            {
                consulta.Append("WHERE Placa like '%@Texto_busqueda%' " +
                    "and Estado_vehiculo = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("CHOFER"))
            {
                consulta.Append("WHERE Chofer like '@Texto_busqueda%' " +
                    "and Estado_vehiculo = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("ESTADO"))
            {
                consulta.Append("WHERE Estado_vehiculo = '@Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID VEHICULO"))
            {
                consulta.Append("WHERE Id_vehiculo = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("TODO"))
            {
                consulta.Append("WHERE Placa like '%Texto_busqueda%' OR " +
                    "Chofer like '%Texto_busqueda%' OR " +
                    "Marca like '%Texto_busqueda%' ");
            }

            consulta.Append("ORDER BY Id_vehiculo DESC ");

            DataTable DtResultado = new DataTable("Vehiculos");
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
