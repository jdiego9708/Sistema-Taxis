using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCarreras
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
        public DCarreras() { }
        #endregion

        #region METODO INSERTAR CARRERA
        public static string InsertarCarrera(out int id_carrera, List<string> vs)
        {
            id_carrera = 0;
            string consulta = "INSERT INTO Carreras(Id_cliente, Id_direccion, Id_vehiculo, " +
                "Id_empleado, Id_turno, Fecha_carrera, Hora_carrera, Lugar_ubicacion, Tiempo_llegada, " +
                "Estado_carrera, Observaciones) " +
                "VALUES(@Id_cliente, @Id_direccion, @Id_vehiculo, @Id_empleado, @Id_turno, @Fecha_carrera, " +
                "@Hora_carrera, @Lugar_ubicacion, @Tiempo_llegada, @Estado_carrera, @Observaciones); " +
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

                SQLiteParameter Id_carrera = new SQLiteParameter
                {
                    ParameterName = "@Id_carrera",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_carrera);

                SQLiteParameter Id_cliente = new SQLiteParameter
                {
                    ParameterName = "@Id_cliente",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                SQLiteParameter Id_direccion = new SQLiteParameter
                {
                    ParameterName = "@Id_direccion",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_direccion);
                contador += 1;

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_vehiculo);
                contador += 1;

                SQLiteParameter Id_empleado = new SQLiteParameter
                {
                    ParameterName = "@Id_empleado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_empleado);
                contador += 1;

                SQLiteParameter Id_turno = new SQLiteParameter
                {
                    ParameterName = "@Id_turno",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SQLiteParameter Fecha_carrera = new SQLiteParameter
                {
                    ParameterName = "@Fecha_carrera",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Fecha_carrera);
                contador += 1;

                SQLiteParameter Hora_carrera = new SQLiteParameter
                {
                    ParameterName = "@Hora_carrera",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Hora_carrera);
                contador += 1;

                SQLiteParameter Lugar_ubicacion = new SQLiteParameter
                {
                    ParameterName = "@Lugar_ubicacion",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Lugar_ubicacion);
                contador += 1;

                SQLiteParameter Tiempo_llegada = new SQLiteParameter
                {
                    ParameterName = "@Tiempo_llegada",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Tiempo_llegada);
                contador += 1;

                SQLiteParameter Estado_carrera = new SQLiteParameter
                {
                    ParameterName = "@Estado_carrera",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_carrera);
                contador += 1;

                SQLiteParameter Observaciones = new SQLiteParameter
                {
                    ParameterName = "@Observaciones",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Observaciones);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_carrera = id;
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

        #region METODO EDITAR CARRERA
        public static string EditarCarrera(int id_carrera, List<string> vs)
        {
            string consulta = "UPDATE Carreras SET " +
                "Id_cliente = @Id_cliente, " +
                "Id_direccion = @Id_direccion, " +
                "Id_vehiculo = @Id_vehiculo, " +
                "Id_empleado = @Id_empleado, " +
                "Id_turno = @Id_turno, " +
                "Lugar_ubicacion = @Lugar_ubicacion, " +
                "Tiempo_llegada = @Tiempo_llegada, " +
                "Estado_carrera = @Estado_carrera, " +
                "Observaciones = @Observaciones " +
                "WHERE Id_carrera = @Id_carrera ";

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

                SQLiteParameter Id_carrera = new SQLiteParameter
                {
                    ParameterName = "@Id_carrera",
                    Value = id_carrera
                };
                SqlCmd.Parameters.Add(Id_carrera);

                SQLiteParameter Id_cliente = new SQLiteParameter
                {
                    ParameterName = "@Id_cliente",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                SQLiteParameter Id_direccion = new SQLiteParameter
                {
                    ParameterName = "@Id_direccion",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_direccion);
                contador += 1;

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_vehiculo);
                contador += 1;

                SQLiteParameter Id_empleado = new SQLiteParameter
                {
                    ParameterName = "@Id_empleado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_empleado);
                contador += 1;

                SQLiteParameter Id_turno = new SQLiteParameter
                {
                    ParameterName = "@Id_turno",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SQLiteParameter Fecha_carrera = new SQLiteParameter
                {
                    ParameterName = "@Fecha_carrera",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Fecha_carrera);
                contador += 1;

                SQLiteParameter Hora_carrera = new SQLiteParameter
                {
                    ParameterName = "@Hora_carrera",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Hora_carrera);
                contador += 1;

                SQLiteParameter Lugar_ubicacion = new SQLiteParameter
                {
                    ParameterName = "@Lugar_ubicacion",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Lugar_ubicacion);
                contador += 1;

                SQLiteParameter Tiempo_llegada = new SQLiteParameter
                {
                    ParameterName = "@Tiempo_llegada",
                    Value = vs[contador]
                };
                SqlCmd.Parameters.Add(Tiempo_llegada);
                contador += 1;

                SQLiteParameter Estado_carrera = new SQLiteParameter
                {
                    ParameterName = "@Estado_carrera",
                    Value = vs[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_carrera);
                contador += 1;

                SQLiteParameter Observaciones = new SQLiteParameter
                {
                    ParameterName = "@Observaciones",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Observaciones);
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

        #region METODO BUSCAR CARRERAS
        public static DataTable BuscarCarreras(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * FROM Carreras car " +
                "INNER JOIN Clientes cl ON car.Id_cliente = cl.Id_cliente " +
                "INNER JOIN Direccion_clientes dcl ON car.Id_direccion = dcl.Id_direccion " +
                "INNER JOIN Barrios bar ON dcl.Id_barrio = bar.Id_barrio " +
                "INNER JOIN Vehiculos veh ON car.Id_vehiculo = veh.Id_vehiculo " +
                "INNER JOIN Empleados em ON car.Id_empleado = em.Id_empleado " +
                "INNER JOIN Turnos tur ON car.Id_turno = tur.Id_turno ");

            if (tipo_busqueda.Equals("COMPLETO FECHA TERMINADO"))
            {
                consulta.Append("WHERE Estado_carrera = 'TERMINADO' and " +
                    "Fecha_carrera = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("COMPLETO FECHA PENDIENTE"))
            {
                consulta.Append("WHERE Estado_carrera = 'PENDIENTE' and " +
                    "Fecha_carrera = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("COMPLETO FECHA CANCELADO"))
            {
                consulta.Append("WHERE Estado_carrera = 'CANCELADO' and " +
                    "Fecha_carrera = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID CLIENTE TERMINADO"))
            {
                consulta.Append("WHERE car.Id_cliente = @Texto_busqueda " +
                    "and Estado_carrera = 'TERMINADO' ");
            }
            else if (tipo_busqueda.Equals("ID CLIENTE PENDIENTE"))
            {
                consulta.Append("WHERE car.Id_cliente = @Texto_busqueda " +
                    "and Estado_carrera = 'PENDIENTE' ");
            }
            else if (tipo_busqueda.Equals("ID CLIENTE CANCELADO"))
            {
                consulta.Append("WHERE car.Id_cliente = @Texto_busqueda " +
                    "and Estado_carrera = 'CANCELADO' ");
            }
            else if (tipo_busqueda.Equals("ID CLIENTE COMPLETO"))
            {
                consulta.Append("WHERE car.Id_cliente = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("COMPLETO FECHA"))
            {
                consulta.Append("WHERE Fecha_carrera = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("COMPLETO ID TURNO"))
            {
                consulta.Append("WHERE car.Id_turno = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY Id_carrera DESC ");

            DataTable DtResultado = new DataTable("Carreras");
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
                    Value = texto_busqueda.Trim()
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

        /**El método va a recibir los parámetros texto1 y texto2, que serían las fechas, 
         * y de salida serán 4 tablas
         * - Tabla principal = Es la que devuelve el método con la cantidad de las carreras CANCELADAS,
         * PENDIENTES Y TERMINADAS
         * - Tabla dtVehiculos = Devuelve la lista de vehículos con la cantidad de carreras realizadas.**/

        public static DataTable BuscarCarrerasReporte(string texto_busqueda1, string texto_busqueda2, string texto_busqueda3,
                            int id_vehiculo, out DataTable dtVehiculos, out DataTable dtVehiculosEstado,
                            out string rpta)
        {
            StringBuilder consulta1 = new StringBuilder();
            //Tabla dtPrincipal
            consulta1.Append("SELECT car.Estado_carrera, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' and " +
                            "car.Id_vehiculo = @Id_vehiculo " +
                            "GROUP BY car.Estado_carrera ");

            StringBuilder consulta2 = new StringBuilder();
            //Tabla dtVehiculos
            consulta2.Append("SELECT vh.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' and " +
                            "car.Id_vehiculo = @Id_vehiculo " +
                            "GROUP BY car.Id_vehiculo ");

            StringBuilder consulta3 = new StringBuilder();
            //Tabla dtVehiculosEstadoCarreras
            consulta3.Append("SELECT * FROM " +
                            "(SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'PENDIENTE' AND " +
                            "car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' " +
                            "GROUP BY vh.Id_vehiculo " +
                            "UNION " +
                            "SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'CANCELADA' AND " +
                            "car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' " +
                            "GROUP BY vh.Id_vehiculo " +
                            "UNION " +
                            "SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'TERMINADA' AND " +
                            "car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' " +
                            "GROUP BY vh.Id_vehiculo) Carrerass " +
                            "WHERE Carrerass.Id_vehiculo = @Id_vehiculo ");

            DataTable DtPrincipal = new DataTable("DtPrincipal");
            dtVehiculos = new DataTable("DtVehiculos");
            dtVehiculosEstado = new DataTable("DtVehiculosEstado");
            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();

                #region CONSULTA TABLA PRINCIPAL
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = Convert.ToString(consulta1),
                    CommandType = CommandType.Text
                };

                SQLiteParameter Texto_busqueda1 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda1",
                    Size = 50,
                    Value = texto_busqueda1.Trim()
                };
                SqlCmd.Parameters.Add(Texto_busqueda1);

                SQLiteParameter Texto_busqueda2 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda2",
                    Size = 50,
                    Value = texto_busqueda2.Trim()
                };
                SqlCmd.Parameters.Add(Texto_busqueda2);

                SQLiteParameter Texto_busqueda3 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda3",
                    Size = 50,
                    Value = texto_busqueda3.Trim()
                };
                SqlCmd.Parameters.Add(Texto_busqueda3);

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Size = 50,
                    Value = id_vehiculo
                };
                SqlCmd.Parameters.Add(Id_vehiculo);

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtPrincipal);

                if (DtPrincipal.Rows.Count < 1)
                {
                    DtPrincipal = null;
                }

                #endregion

                #region CONSULTA TABLA VEHICULOS

                SqlCmd.CommandText = Convert.ToString(consulta2);
                SqlCmd.Parameters.Add(Texto_busqueda1);
                SqlCmd.Parameters.Add(Texto_busqueda2);
                SqlCmd.Parameters.Add(Texto_busqueda3);
                SqlCmd.Parameters.Add(Id_vehiculo);
                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculos);

                if (dtVehiculos.Rows.Count < 1)
                {
                    dtVehiculos = null;
                }

                #endregion

                #region CONSULTA TABLA VEHICULOS ESTADO

                SqlCmd.CommandText = Convert.ToString(consulta3);
                SqlCmd.Parameters.Add(Texto_busqueda1);
                SqlCmd.Parameters.Add(Texto_busqueda2);
                SqlCmd.Parameters.Add(Texto_busqueda3);
                SqlCmd.Parameters.Add(Id_vehiculo);
                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculosEstado);

                if (dtVehiculosEstado.Rows.Count < 1)
                {
                    dtVehiculosEstado = null;
                }

                #endregion

            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                DtPrincipal = null;
                dtVehiculos = null;
                dtVehiculosEstado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtPrincipal = null;
                dtVehiculos = null;
                dtVehiculosEstado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtPrincipal;
        }

        public static DataTable BuscarCarrerasReporte(string texto_busqueda1,
                            string texto_busqueda2, string texto_busqueda3, out DataTable dtVehiculos, out DataTable dtVehiculosEstado,
                            out string rpta)
        {
            StringBuilder consulta1 = new StringBuilder();
            //Tabla dtPrincipal
            consulta1.Append("SELECT car.Estado_carrera, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' " +
                            "GROUP BY car.Estado_carrera ");

            StringBuilder consulta2 = new StringBuilder();
            //Tabla dtVehiculos
            consulta2.Append("SELECT vh.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' " +
                            "GROUP BY car.Id_vehiculo ");

            StringBuilder consulta3 = new StringBuilder();
            //Tabla dtVehiculosEstadoCarreras
            consulta3.Append("SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'PENDIENTE' AND " +
                            "car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' " +
                            "GROUP BY vh.Id_vehiculo " +
                            "UNION " +
                            "SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'CANCELADA' AND " +
                            "car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' " +
                            "GROUP BY vh.Id_vehiculo " +
                            "UNION " +
                            "SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'TERMINADA' AND " +
                            "car.Hora_carrera BETWEEN '" + texto_busqueda1 + "%' AND '" + texto_busqueda2 + "%' and " +
                            "car.Fecha_carrera = '" + texto_busqueda3 + "' " +
                            "GROUP BY vh.Id_vehiculo ");

            DataTable DtPrincipal = new DataTable("DtPrincipal");
            dtVehiculos = new DataTable("DtVehiculos");
            dtVehiculosEstado = new DataTable("DtVehiculosEstado");
            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();

                #region CONSULTA TABLA PRINCIPAL
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = Convert.ToString(consulta1),
                    CommandType = CommandType.Text
                };

                SQLiteParameter Texto_busqueda1 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda1",
                    Size = 50,
                    Value = texto_busqueda1.Trim()
                };
                SqlCmd.Parameters.Add(Texto_busqueda1);

                SQLiteParameter Texto_busqueda2 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda2",
                    Size = 50,
                    Value = texto_busqueda2.Trim()
                };
                SqlCmd.Parameters.Add(Texto_busqueda2);

                SQLiteParameter Texto_busqueda3 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda3",
                    Size = 50,
                    Value = texto_busqueda3.Trim()
                };
                SqlCmd.Parameters.Add(Texto_busqueda3);

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtPrincipal);

                if (DtPrincipal.Rows.Count < 1)
                {
                    DtPrincipal = null;
                }

                #endregion

                #region CONSULTA TABLA VEHICULOS

                SqlCmd.CommandText = Convert.ToString(consulta2);
                SqlCmd.Parameters.Add(Texto_busqueda1);
                SqlCmd.Parameters.Add(Texto_busqueda2);
                SqlCmd.Parameters.Add(Texto_busqueda3);
                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculos);

                if (dtVehiculos.Rows.Count < 1)
                {
                    dtVehiculos = null;
                }

                #endregion

                #region CONSULTA TABLA VEHICULOS ESTADO

                SqlCmd.CommandText = Convert.ToString(consulta3);
                SqlCmd.Parameters.Add(Texto_busqueda1);
                SqlCmd.Parameters.Add(Texto_busqueda2);
                SqlCmd.Parameters.Add(Texto_busqueda3);
                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculosEstado);

                if (dtVehiculosEstado.Rows.Count < 1)
                {
                    dtVehiculosEstado = null;
                }

                #endregion

            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                DtPrincipal = null;
                dtVehiculos = null;
                dtVehiculosEstado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtPrincipal = null;
                dtVehiculos = null;
                dtVehiculosEstado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtPrincipal;
        }

        public static DataTable BuscarCarrerasReporte(string texto_busqueda1,
                    string texto_busqueda2,  out DataTable dtVehiculos, out DataTable dtVehiculosEstado,
                    out string rpta)
        {
            StringBuilder consulta1 = new StringBuilder();
            //Tabla dtPrincipal
            consulta1.Append("SELECT car.Estado_carrera, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Fecha_carrera BETWEEN '" + texto_busqueda1 + "' AND '" + texto_busqueda2 + "' " +
                            "GROUP BY car.Estado_carrera ");

            StringBuilder consulta2 = new StringBuilder();
            //Tabla dtVehiculos
            consulta2.Append("SELECT vh.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Fecha_carrera BETWEEN '" + texto_busqueda1 + "' AND '" + texto_busqueda2 + "' " +
                            "GROUP BY car.Id_vehiculo ");

            StringBuilder consulta3 = new StringBuilder();
            //Tabla dtVehiculosEstadoCarreras
            consulta3.Append("SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'PENDIENTE' AND " +
                            "car.Fecha_carrera BETWEEN '" + texto_busqueda1 + "' AND '" + texto_busqueda2 + "' " +
                            "GROUP BY vh.Id_vehiculo " +
                            "UNION " +
                            "SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'CANCELADA' AND " +
                            "car.Fecha_carrera BETWEEN '" + texto_busqueda1 + "' AND '" + texto_busqueda2 + "' " +
                            "GROUP BY vh.Id_vehiculo " +
                            "UNION " +
                            "SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'TERMINADA' AND " +
                            "car.Fecha_carrera BETWEEN '" + texto_busqueda1 + "' AND '" + texto_busqueda2 + "' " +
                            "GROUP BY vh.Id_vehiculo ");

            DataTable DtPrincipal = new DataTable("DtPrincipal");
            dtVehiculos = new DataTable("DtVehiculos");
            dtVehiculosEstado = new DataTable("DtVehiculosEstado");
            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();

                #region CONSULTA TABLA PRINCIPAL
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = Convert.ToString(consulta1),
                    CommandType = CommandType.Text
                };

                SQLiteParameter Texto_busqueda1 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda1",
                    Size = 50,
                    Value = texto_busqueda1.Trim()
                };
                SqlCmd.Parameters.Add(Texto_busqueda1);

                SQLiteParameter Texto_busqueda2 = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda2",
                    Size = 50,
                    Value = texto_busqueda2.Trim()
                };
                SqlCmd.Parameters.Add(Texto_busqueda2);

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtPrincipal);

                if (DtPrincipal.Rows.Count < 1)
                {
                    DtPrincipal = null;
                }

                #endregion

                #region CONSULTA TABLA VEHICULOS

                SqlCmd.CommandText = Convert.ToString(consulta2);
                SqlCmd.Parameters.Add(Texto_busqueda1);
                SqlCmd.Parameters.Add(Texto_busqueda2);
                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculos);

                if (dtVehiculos.Rows.Count < 1)
                {
                    dtVehiculos = null;
                }

                #endregion

                #region CONSULTA TABLA VEHICULOS ESTADO

                SqlCmd.CommandText = Convert.ToString(consulta3);
                SqlCmd.Parameters.Add(Texto_busqueda1);
                SqlCmd.Parameters.Add(Texto_busqueda2);
                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculosEstado);

                if (dtVehiculosEstado.Rows.Count < 1)
                {
                    dtVehiculosEstado = null;
                }

                #endregion

            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                DtPrincipal = null;
                dtVehiculos = null;
                dtVehiculosEstado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtPrincipal = null;
                dtVehiculos = null;
                dtVehiculosEstado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtPrincipal;
        }

        public static DataTable BuscarCarrerasReporte(int id_vehiculo,
                           out DataTable dtVehiculos, out DataTable dtVehiculosEstado,
                           out string rpta)
        {
            StringBuilder consulta1 = new StringBuilder();
            //Tabla dtPrincipal
            consulta1.Append("SELECT car.Estado_carrera, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Id_vehiculo = @Id_vehiculo " +
                            "GROUP BY car.Estado_carrera ");

            StringBuilder consulta2 = new StringBuilder();
            //Tabla dtVehiculos
            consulta2.Append("SELECT vh.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Id_vehiculo = @Id_vehiculo " +
                            "GROUP BY car.Id_vehiculo ");

            StringBuilder consulta3 = new StringBuilder();
            //Tabla dtVehiculosEstadoCarreras
            consulta3.Append("SELECT * FROM " +
                            "(SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'PENDIENTE' " +
                            "GROUP BY vh.Id_vehiculo " +
                            "UNION " +
                            "SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'CANCELADA' " +
                            "GROUP BY vh.Id_vehiculo " +
                            "UNION " +
                            "SELECT vh.*, car.*, COUNT(*) as CantidadServicios " +
                            "FROM Vehiculos vh " +
                            "INNER JOIN Carreras car ON vh.Id_vehiculo = car.Id_vehiculo " +
                            "WHERE car.Estado_carrera = 'TERMINADA' " +
                            "GROUP BY vh.Id_vehiculo) Carrerass " +
                            "WHERE Carrerass.Id_vehiculo = @Id_vehiculo ");

            DataTable DtPrincipal = new DataTable("DtPrincipal");
            dtVehiculos = new DataTable("DtVehiculos");
            dtVehiculosEstado = new DataTable("DtVehiculosEstado");
            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();

                #region CONSULTA TABLA PRINCIPAL
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = Convert.ToString(consulta1),
                    CommandType = CommandType.Text
                };

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = id_vehiculo
                };
                SqlCmd.Parameters.Add(Id_vehiculo);

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtPrincipal);

                if (DtPrincipal.Rows.Count < 1)
                {
                    DtPrincipal = null;
                }

                #endregion

                #region CONSULTA TABLA VEHICULOS

                SqlCmd.CommandText = Convert.ToString(consulta2);
                SqlCmd.Parameters.Add(Id_vehiculo);
                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculos);

                if (dtVehiculos.Rows.Count < 1)
                {
                    dtVehiculos = null;
                }

                #endregion

                #region CONSULTA TABLA VEHICULOS ESTADO

                SqlCmd.CommandText = Convert.ToString(consulta3);
                SqlCmd.Parameters.Add(Id_vehiculo);
                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculosEstado);

                if (dtVehiculosEstado.Rows.Count < 1)
                {
                    dtVehiculosEstado = null;
                }

                #endregion

            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                DtPrincipal = null;
                dtVehiculos = null;
                dtVehiculosEstado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtPrincipal = null;
                dtVehiculos = null;
                dtVehiculosEstado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtPrincipal;
        }

        #endregion
    }
}
