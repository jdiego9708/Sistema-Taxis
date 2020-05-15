using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ECronogramas
    {
        public ECronogramas()
        {

        }

        public ECronogramas(DataRow row)
        {
            try
            {
                this.Id_cronograma = Convert.ToInt32(row["Id_cronograma"]);
                this.EVehiculo = new EVehiculos(row);             
                this.EEstado = new EEstados_vehiculos(row);
                this.Fecha_cronograma = Convert.ToDateTime(row["Fecha_cronograma"]);
                this.Estado_cronograma = Convert.ToString(row["Estado_cronograma"]);

            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECronogramas(DataTable dt, int fila)
        {
            try
            {
                this.Id_cronograma = Convert.ToInt32(dt.Rows[fila]["Id_cronograma"]);
                this.EVehiculo = new EVehiculos(dt.Rows[fila]);
                this.EEstado = new EEstados_vehiculos(dt.Rows[fila]);
                this.Fecha_cronograma = Convert.ToDateTime(dt.Rows[fila]["Fecha_cronograma"]);
                this.Estado_cronograma = Convert.ToString(dt.Rows[fila]["Estado_cronograma"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarCronogramas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DCronogramas.BuscarCronogramas(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static DataTable BuscarCronogramas(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2, out string rpta)
        {
            return DCronogramas.BuscarCronogramas(tipo_busqueda, texto_busqueda1, texto_busqueda2, out rpta);
        }

        public static string InsertarCronograma(ECronogramas cronograma, out int id_cronograma)
        {
            List<string> vs = new List<string>
            {
                cronograma.EVehiculo.Id_vehiculo.ToString(),
                cronograma.EEstado.Id_estado.ToString(),
                cronograma.Fecha_cronograma.ToString("yyyy-MM-dd"),
                cronograma.Estado_cronograma,
            };
            return DCronogramas.InsertarCronograma(out id_cronograma, vs);
        }

        public static string EditarCronograma(ECronogramas cronograma, int id_cronograma)
        {
            List<string> vs = new List<string>
            {
                cronograma.EVehiculo.Id_vehiculo.ToString(),
                cronograma.EEstado.Id_estado.ToString(),
                cronograma.Fecha_cronograma.ToString("yyyy-MM-dd"),
                cronograma.Estado_cronograma,
            };
            return DCronogramas.EditarCronograma(id_cronograma, vs);
        }

        private int _id_cronograma;
        private EVehiculos _eVehiculo;
        private EEstados_vehiculos _eEstado;
        private DateTime _fecha_cronograma;
        private string _estado_cronograma;

        public int Id_cronograma { get => _id_cronograma; set => _id_cronograma = value; }
        public EVehiculos EVehiculo { get => _eVehiculo; set => _eVehiculo = value; }
        public EEstados_vehiculos EEstado { get => _eEstado; set => _eEstado = value; }
        public DateTime Fecha_cronograma { get => _fecha_cronograma; set => _fecha_cronograma = value; }
        public string Estado_cronograma { get => _estado_cronograma; set => _estado_cronograma = value; }

        public event EventHandler OnError;

    }
}
