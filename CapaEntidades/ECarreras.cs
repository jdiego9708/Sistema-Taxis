using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ECarreras
    {
        public ECarreras()
        {

        }

        public ECarreras(DataRow row)
        {
            try
            {
                this.Id_carrera = Convert.ToInt32(row["Id_carrera"]);

                this.ECliente = new EClientes
                {
                    Id_cliente = Convert.ToInt32(row["Id_cliente1"]),
                    Codigo_cliente = Convert.ToString(row["Codigo_cliente"]),
                    Nombre_cliente = Convert.ToString(row["Nombre_cliente"]),
                    Celular_cliente = Convert.ToString(row["Celular_cliente"]),
                    Estado_cliente = Convert.ToString(row["Estado_cliente"])
                };

                this.EDireccion = new EDireccion_clientes
                {
                    Id_direccion = Convert.ToInt32(row["Id_direccion"]),
                    Direccion = Convert.ToString(row["Direccion"]),
                    ECliente = this.ECliente,
                    Casa = Convert.ToString(row["Casa"]),
                    EBarrio = new EBarrios
                    {
                        Id_barrio = Convert.ToInt32(row["Id_barrio"]),
                        Nombre_barrio = Convert.ToString(row["Nombre_barrio"])
                    },
                    Ciudadela = Convert.ToString(row["Ciudadela"]),
                    Referencia = Convert.ToString(row["Referencia"]),
                    Observaciones = Convert.ToString(row["Observaciones"]),
                    Estado_direccion = Convert.ToString(row["Estado_direccion"])
                };

                this.EVehiculo = new EVehiculos
                {
                    Id_vehiculo = Convert.ToInt32(row["Id_vehiculo"]),
                    Placa = Convert.ToString(row["Placa"]),
                    Propietario = Convert.ToString(row["Propietario"]),
                    Chofer = Convert.ToString(row["Chofer"]),
                    Marca = Convert.ToString(row["Marca"]),
                    Modelo = Convert.ToString(row["Modelo"]),
                    Color = Convert.ToString(row["Color"]),
                    Estado_vehiculo = Convert.ToString(row["Estado_vehiculo"])
                };

                this.EEmpleado = new EEmpleados
                {
                    Id_empleado = Convert.ToInt32(row["Id_empleado"]),
                    Nombre_empleado = Convert.ToString(row["Nombre_empleado"]),
                    Correo_empleado = Convert.ToString(row["Correo_empleado"]),
                    Tipo_empleado = Convert.ToString(row["Tipo_empleado"]),
                    Estado_empleado = Convert.ToString(row["Estado_empleado"])
                };

                this.ETurno = new ETurnos(row);

                this.Fecha_carrera = Convert.ToDateTime(row["Fecha_carrera"]);
                this.Hora_carrera = Convert.ToString(row["Hora_carrera"]);
                this.Lugar_ubicacion = Convert.ToString(row["Lugar_ubicacion"]);
                this.Tiempo_llegada = Convert.ToInt32(row["Tiempo_llegada"]);
                this.Estado_carrera = Convert.ToString(row["Estado_carrera"]);
                this.Observaciones = Convert.ToString(row["Observaciones"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECarreras(DataTable dt, int fila)
        {
            try
            {
                this.Id_carrera = Convert.ToInt32(dt.Rows[fila]["Id_carrera"]);

                this.ECliente = new EClientes
                {
                    Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"]),
                    Nombre_cliente = Convert.ToString(dt.Rows[fila]["Nombre_cliente"]),
                    Codigo_cliente = Convert.ToString(dt.Rows[fila]["Codigo_cliente"]),
                    Celular_cliente = Convert.ToString(dt.Rows[fila]["Celular_cliente"]),
                    Estado_cliente = Convert.ToString(dt.Rows[fila]["Estado_cliente"])
                };

                this.EDireccion = new EDireccion_clientes
                {
                    Id_direccion = Convert.ToInt32(dt.Rows[fila]["Id_direccion"]),
                    Direccion = Convert.ToString(dt.Rows[fila]["Direccion"]),
                    ECliente = this.ECliente,
                    Casa = Convert.ToString(dt.Rows[fila]["Casa"]),
                    EBarrio = new EBarrios
                    {
                        Id_barrio = Convert.ToInt32(dt.Rows[fila]["Id_barrio"]),
                        Nombre_barrio = Convert.ToString(dt.Rows[fila]["Nombre_barrio"])
                    },
                    Ciudadela = Convert.ToString(dt.Rows[fila]["Ciudadela"]),
                    Referencia = Convert.ToString(dt.Rows[fila]["Referencia"]),
                    Observaciones = Convert.ToString(dt.Rows[fila]["Observaciones"]),
                    Estado_direccion = Convert.ToString(dt.Rows[fila]["Estado_direccion"])
                };

                this.EVehiculo = new EVehiculos
                {
                    Id_vehiculo = Convert.ToInt32(dt.Rows[fila]["Id_vehiculo"]),
                    Placa = Convert.ToString(dt.Rows[fila]["Placa"]),
                    Propietario = Convert.ToString(dt.Rows[fila]["Propietario"]),
                    Chofer = Convert.ToString(dt.Rows[fila]["Chofer"]),
                    Marca = Convert.ToString(dt.Rows[fila]["Marca"]),
                    Modelo = Convert.ToString(dt.Rows[fila]["Modelo"]),
                    Color = Convert.ToString(dt.Rows[fila]["Color"]),
                    Estado_vehiculo = Convert.ToString(dt.Rows[fila]["Estado_vehiculo"])
                };

                this.EEmpleado = new EEmpleados
                {
                    Id_empleado = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]),
                    Nombre_empleado = Convert.ToString(dt.Rows[fila]["Nombre_empleado"]),
                    Correo_empleado = Convert.ToString(dt.Rows[fila]["Correo_empleado"]),
                    Tipo_empleado = Convert.ToString(dt.Rows[fila]["Tipo_empleado"]),
                    Estado_empleado = Convert.ToString(dt.Rows[fila]["Estado_empleado"])
                };

                this.ETurno = new ETurnos(dt.Rows[fila]);

                this.Fecha_carrera = Convert.ToDateTime(dt.Rows[fila]["Fecha_carrera"]);
                this.Hora_carrera = Convert.ToString(dt.Rows[fila]["Hora_carrera"]);
                this.Lugar_ubicacion = Convert.ToString(dt.Rows[fila]["Lugar_ubicacion"]);
                this.Tiempo_llegada = Convert.ToInt32(dt.Rows[fila]["Tiempo_llegada"]);
                this.Estado_carrera = Convert.ToString(dt.Rows[fila]["Estado_carrera"]);
                this.Observaciones = Convert.ToString(dt.Rows[fila]["Observaciones"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarCarrerasReporte(int id_vehiculo,
           out DataTable dtVehiculos, out DataTable dtVehiculosEstado, out string rpta)
        {
            return DCarreras.BuscarCarrerasReporte(id_vehiculo,
                out dtVehiculos, out dtVehiculosEstado, out rpta);
        }

        public static DataTable BuscarCarrerasReporte(string texto_busqueda1, string texto_busqueda2, string texto_busqueda3, int id_vehiculo,
            out DataTable dtVehiculos, out DataTable dtVehiculosEstado, out string rpta)
        {
            return DCarreras.BuscarCarrerasReporte(texto_busqueda1, texto_busqueda2, texto_busqueda3, id_vehiculo,
                out dtVehiculos, out dtVehiculosEstado, out rpta);
        }

        public static DataTable BuscarCarrerasReporte(string texto_busqueda1, string texto_busqueda2,
            string texto_busqueda3,
            out DataTable dtVehiculos, out DataTable dtVehiculosEstado, out string rpta)
        {
            return DCarreras.BuscarCarrerasReporte(texto_busqueda1, texto_busqueda2, texto_busqueda3,
                out dtVehiculos, out dtVehiculosEstado, out rpta);
        }
      public static DataTable BuscarCarrerasReporte(string texto_busqueda1, string texto_busqueda2,
                out DataTable dtVehiculos, out DataTable dtVehiculosEstado, out string rpta)
        {
            return DCarreras.BuscarCarrerasReporte(texto_busqueda1, texto_busqueda2,
                out dtVehiculos, out dtVehiculosEstado, out rpta);
        }

        public static DataTable BuscarCarreras(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DCarreras.BuscarCarreras(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarCarrera(ECarreras eCarrera, out int id_carrera)
        {
            List<string> vs = new List<string>
            {
                eCarrera.ECliente.Id_cliente.ToString(),
                eCarrera.EDireccion.Id_direccion.ToString(),
                eCarrera.EVehiculo.Id_vehiculo.ToString(),
                eCarrera.EEmpleado.Id_empleado.ToString(),
                eCarrera.ETurno.Id_turno.ToString(),
                eCarrera.Fecha_carrera.ToString("yyyy-MM-dd"),
                eCarrera.Hora_carrera, eCarrera.Lugar_ubicacion,
                eCarrera.Tiempo_llegada.ToString(),
                eCarrera.Estado_carrera, eCarrera.Observaciones
            };
            return DCarreras.InsertarCarrera(out id_carrera, vs);
        }

        public static string EditarCarrera(ECarreras eCarrera, int id_carrera)
        {
            List<string> vs = new List<string>
            {
                eCarrera.ECliente.Id_cliente.ToString(),
                eCarrera.EDireccion.Id_direccion.ToString(),
                eCarrera.EVehiculo.Id_vehiculo.ToString(),
                eCarrera.EEmpleado.Id_empleado.ToString(),
                eCarrera.ETurno.Id_turno.ToString(),
                eCarrera.Fecha_carrera.ToString("yyyy-MM-dd"),
                eCarrera.Hora_carrera, eCarrera.Lugar_ubicacion,
                eCarrera.Tiempo_llegada.ToString(),
                eCarrera.Estado_carrera, eCarrera.Observaciones
            };
            return DCarreras.EditarCarrera(id_carrera, vs);
        }

        private int _id_carrera;
        private EClientes _eCliente;
        private EDireccion_clientes _eDireccion;
        private EVehiculos _eVehiculo;
        private EEmpleados _eEmpleado;
        private ETurnos _eTurno;
        private DateTime _fecha_carrera;
        private string _hora_carrera;
        private string _lugar_ubicacion;
        private int _tiempo_llegada;
        private string _estado_carrera;
        private string _observaciones;

        public int Id_carrera { get => _id_carrera; set => _id_carrera = value; }
        public EClientes ECliente { get => _eCliente; set => _eCliente = value; }
        public EDireccion_clientes EDireccion { get => _eDireccion; set => _eDireccion = value; }
        public EVehiculos EVehiculo { get => _eVehiculo; set => _eVehiculo = value; }
        public EEmpleados EEmpleado { get => _eEmpleado; set => _eEmpleado = value; }
        public DateTime Fecha_carrera { get => _fecha_carrera; set => _fecha_carrera = value; }
        public string Hora_carrera { get => _hora_carrera; set => _hora_carrera = value; }
        public string Lugar_ubicacion { get => _lugar_ubicacion; set => _lugar_ubicacion = value; }
        public int Tiempo_llegada { get => _tiempo_llegada; set => _tiempo_llegada = value; }
        public string Estado_carrera { get => _estado_carrera; set => _estado_carrera = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
        public ETurnos ETurno { get => _eTurno; set => _eTurno = value; }

        public event EventHandler OnError;

    }
}
