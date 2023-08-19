using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EDetalle_vehiculos_estado
    {
        public EDetalle_vehiculos_estado()
        {

        }

        public EDetalle_vehiculos_estado(DataRow row)
        {
            try
            {
                this.Id_detalle_vehiculo = Convert.ToInt32(row["Id_detalle_vehiculo"]);
                this.EVehiculo = new EVehiculos(row);
                this.ETurno = new ETurnos(row);
                this.Fecha = Convert.ToDateTime(row["Fecha"]);
                this.Estado = Convert.ToString(row["Estado"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDetalle_vehiculos_estado(DataTable dt, int fila)
        {
            try
            {
                this.Id_detalle_vehiculo = Convert.ToInt32(dt.Rows[fila]["Id_detalle_vehiculo"]);
                this.EVehiculo = new EVehiculos(dt.Rows[fila]);
                this.ETurno = new ETurnos(dt.Rows[fila]);
                this.Fecha = Convert.ToDateTime(dt.Rows[fila]["Fecha"]);
                this.Estado = Convert.ToString(dt.Rows[fila]["Estado"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarDetalleVehiculosCarreras(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DDetalle_vehiculos_estado.BuscarDetalleVehiculosCarreras(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static DataTable BuscarDetalleVehiculos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DDetalle_vehiculos_estado.BuscarDetalleVehiculos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarDetaleVehiculo(EDetalle_vehiculos_estado eDetalle, 
            out int id_detalle_vehiculo)
        {
            List<string> vs = new List<string>
            {
                eDetalle.Fecha.ToString("yyyy-MM-dd"),
                eDetalle.EVehiculo.Id_vehiculo.ToString(),
                eDetalle.ETurno.Id_turno.ToString(),
                eDetalle.Estado
            };
            return DDetalle_vehiculos_estado.InsertarVehiculo(out id_detalle_vehiculo, vs);
        }

        public static string EditarDetaleVehiculo(EDetalle_vehiculos_estado eDetalle,
            int id_detalle_vehiculo)
        {
            List<string> vs = new List<string>
            {
                eDetalle.Fecha.ToString("yyyy-MM-dd"),
                eDetalle.EVehiculo.Id_vehiculo.ToString(),
                eDetalle.ETurno.Id_turno.ToString(),
                eDetalle.Estado
            };
            return DDetalle_vehiculos_estado.EditarVehiculo(id_detalle_vehiculo, vs);
        }


        private int _id_detalle_vehiculo;
        private DateTime _fecha;
        private EVehiculos _eVehiculo;
        private ETurnos _eTurno;
        private string _estado;

        public int Id_detalle_vehiculo { get => _id_detalle_vehiculo; set => _id_detalle_vehiculo = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public EVehiculos EVehiculo { get => _eVehiculo; set => _eVehiculo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public ETurnos ETurno { get => _eTurno; set => _eTurno = value; }

        public event EventHandler OnError;

    }
}
