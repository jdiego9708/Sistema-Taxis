using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDetalle_vehiculos_estado
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
        public DDetalle_vehiculos_estado() { }
        #endregion

        #region METODO INSERTAR DETALLE VEHICULO

        public static string ConsultaInsertar =
            "INSERT INTO Detalle_vehiculo_estado(Fecha, Id_vehiculo, Id_turno, Id_estado) " +
                "VALUES(@Fecha, @Id_vehiculo, @Id_turno, @Id_estado); ";
        public static string InsertarVehiculo(out int id_detalle_vehiculo, List<string> vs)
        {
            id_detalle_vehiculo = 0;
            string consulta = ConsultaInsertar +
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

                SQLiteParameter Id_detalle_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_detalle_vehiculo",
                    Value = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_detalle_vehiculo);

                SQLiteParameter Fecha = new SQLiteParameter
                {
                    ParameterName = "@Fecha",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Fecha);
                contador += 1;

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_vehiculo);
                contador += 1;

                SQLiteParameter Id_turno = new SQLiteParameter
                {
                    ParameterName = "@Id_turno",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SQLiteParameter Id_estado = new SQLiteParameter
                {
                    ParameterName = "@Id_estado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_estado);
                contador += 1;

                int id = Convert.ToInt32(SqlCmd.ExecuteScalar());
                id_detalle_vehiculo = id;
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

        #region METODO EDITAR DETALLE VEHICULO

        public static string ConsultaEditar =
            "UPDATE Detalle_vehiculo_estado SET " +
            "Fecha = @Fecha, " +
            "Id_vehiculo = @Id_vehiculo, " +
            "Id_turno = @Id_turno, " +
            "Id_estado = @Id_estado " +
            "WHERE Id_detalle_vehiculo = @Id_detalle_vehiculo ";

        public static string EditarVehiculo(int id_detalle_vehiculo, List<string> vs)
        {
            string consulta = ConsultaEditar;

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

                SQLiteParameter Id_detalle_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_detalle_vehiculo",
                    Value = id_detalle_vehiculo
                };
                SqlCmd.Parameters.Add(Id_detalle_vehiculo);

                SQLiteParameter Fecha = new SQLiteParameter
                {
                    ParameterName = "@Fecha",
                    Value = vs[contador].Trim()
                };
                SqlCmd.Parameters.Add(Fecha);
                contador += 1;

                SQLiteParameter Id_vehiculo = new SQLiteParameter
                {
                    ParameterName = "@Id_vehiculo",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_vehiculo);
                contador += 1;

                SQLiteParameter Id_turno = new SQLiteParameter
                {
                    ParameterName = "@Id_turno",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SQLiteParameter Id_estado = new SQLiteParameter
                {
                    ParameterName = "@Id_estado",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_estado);
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

        #region METODO BUSCAR DETALLE VEHICULOS
        public static DataTable BuscarDetalleVehiculos(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * " +
                "FROM Vehiculos vh " +
                "INNER JOIN Detalle_vehiculo_estado dvh " +
                "ON vh.Id_vehiculo = dvh.Id_vehiculo " +
                "INNER JOIN Turnos tur " +
                "ON dvh.Id_turno = tur.Id_turno " +
                "INNER JOIN Estados_vehiculos estvh " +
                "ON dvh.Id_estado = estvh.Id_estado ");

            if (tipo_busqueda.Equals("COMPLETO"))
            {
                consulta.Append("WHERE vh.Estado_vehiculo = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("COMPLETO FECHA"))
            {
                consulta.Append("WHERE dvh.Fecha = '" + texto_busqueda + "' " +
                    "and vh.Estado_vehiculo = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("ID TURNO"))
            {
                consulta.Append("WHERE dvh.Id_turno = " + texto_busqueda + " " +
                    "and vh.Estado_vehiculo = 'ACTIVO' ");
            }
            else if (tipo_busqueda.Equals("ID VEHICULO"))
            {
                consulta.Append("WHERE dvh.Id_vehiculo = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY dvh.Id_detalle_vehiculo DESC ");

            DataTable DtResultado = new DataTable("Vehiculos_detalle");
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

        public static DataTable BuscarDetalleVehiculosCarreras(string tipo_busqueda, string texto_busqueda,
             out string rpta)
        {
            StringBuilder consulta = new StringBuilder();
            /**Para devolver una única tabla de DetalleVehículosCarreras
             * Se debe hacer lo siguiente:
             * 1- Consultar los vehículos que están en DetalleVehiculosCarreras con una fecha en específico
             * 2- Consultar todos los vehículos que tenemos en la base de datos
             * 3- Después de tener los resultados correctos, recorremos la tabla VehiculosDetalles y con cada ID
             * vehiculo que aparezca lo removemos de la tabla Vehiculos luego
             * combinamos las dos tablas, usando DataTable.Merge()**/

            DataTable DtResultado = new DataTable("Vehiculos_detalle");
            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();

                #region PRIMER CONSULTA
                //Primer consulta --> Consultar los que estén en vehículos y en detalle con fecha espefícifca
                consulta.Append("SELECT * " +
                                "FROM Detalle_vehiculo_estado dvh INNER JOIN Vehiculos vh "  +
                                "ON dvh.Id_vehiculo = vh.Id_vehiculo " +
                                "LEFT JOIN (SELECT car.Id_vehiculo, COUNT(*) as CantidadServicios " +
                                            "FROM Carreras car INNER JOIN Vehiculos vh ON car.Id_vehiculo = vh.Id_vehiculo " +
                                            "WHERE car.Id_turno = @Texto_busqueda AND car.Estado_carrera = 'TERMINADA' " +
                                            "GROUP BY car.Id_vehiculo) as dcar " +
                                "ON dvh.Id_vehiculo = dcar.Id_vehiculo " +
                                "INNER JOIN Estados_vehiculos es ON dvh.Id_estado = es.Id_estado " +
                                "INNER JOIN Turnos tur ON dvh.Id_turno = tur.Id_turno " +
                                "WHERE dvh.Fecha = @Fecha " +
                                "and vh.Estado_vehiculo = 'ACTIVO' " +
                                "and dvh.Id_turno = @Texto_busqueda " +
                                "ORDER BY es.Estado_order, dcar.CantidadServicios ASC ");

                //Tabla para almacenar la consulta
                DataTable dtVehiculosDetalle = new DataTable();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = Convert.ToString(consulta),
                    CommandType = CommandType.Text
                };

                SQLiteParameter Fecha = new SQLiteParameter
                {
                    ParameterName = "@Fecha",
                    Size = 50,
                    Value = DateTime.Now.ToString("yyyy-MM-dd")
                };
                SqlCmd.Parameters.Add(Fecha);

                SQLiteParameter Texto_busqueda = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda",
                    Size = 50,
                    Value = texto_busqueda
                };
                SqlCmd.Parameters.Add(Texto_busqueda);

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculosDetalle);

                if (dtVehiculosDetalle.Rows.Count < 1)
                {
                    dtVehiculosDetalle = null;
                }
                #endregion

                #region SEGUNDA CONSULTA
                //Segunda consulta --> Consultar todos los vehículos
                consulta = new StringBuilder();
                consulta.Append("SELECT * FROM Vehiculos vh " +
                    "WHERE vh.Estado_vehiculo = 'ACTIVO' ");

                SqlCmd.CommandText = consulta.ToString();
                //Tabla para almacenar los vehículos
                DataTable dtVehiculos = new DataTable();

                SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(dtVehiculos);

                if (dtVehiculos.Rows.Count < 1)
                {
                    dtVehiculos = null;
                }
                #endregion

                //Procedimientos con las dos tablas -> Recorrer tabla VehiculosDetalles
                if (dtVehiculosDetalle != null)
                {
                    //Iniciar ciclo
                    foreach (DataRow row in dtVehiculosDetalle.Rows)
                    {
                        //Capturar el id del vehiculo, que buscaremos en la tabla vehículos
                        int id_vehiculo = Convert.ToInt32(row["Id_vehiculo"]);
                        DataRow[] filas =
                            dtVehiculos.Select("Id_vehiculo = '" + id_vehiculo.ToString() + "'");
                        //Comprobamos si encontró filas
                        if (filas != null)
                        {
                            //Removemos las filas que encontró
                            if (filas.Length > 0)
                                dtVehiculos.Rows.Remove(filas[0]);
                        }
                    }
                    dtVehiculosDetalle.Merge(dtVehiculos);
                    DtResultado = dtVehiculosDetalle;
                }
                else
                {
                    if (dtVehiculos != null)
                    {
                        DataColumn column1 = new DataColumn("Id_detalle_vehiculo", typeof(string));
                        DataColumn column2 = new DataColumn("Fecha", typeof(string));
                        DataColumn column3 = new DataColumn("Id_vehiculo1", typeof(string));
                        DataColumn column4 = new DataColumn("Estado", typeof(string));
                        dtVehiculos.Columns.Add(column1);
                        dtVehiculos.Columns.Add(column2);
                        dtVehiculos.Columns.Add(column3);
                        dtVehiculos.Columns.Add(column4);
                        DtResultado = dtVehiculos;
                    }
                    else
                    {
                        DtResultado = null;
                    }
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
