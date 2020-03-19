using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaEntidades
{
    public class EEstados_vehiculos
    {
        public EEstados_vehiculos()
        {

        }

        public EEstados_vehiculos(DataRow row)
        {
            try
            {
                this.Id_estado = Convert.ToInt32(row["Id_estado"]);
                this.Nombre_estado = Convert.ToString(row["Nombre_estado"]);
                this.Alias_estado = Convert.ToString(row["Alias_estado"]);
                this.Color_estado = Convert.ToString(row["Color_estado"]);
                this.Enabled = Convert.ToString(row["Enabled"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EEstados_vehiculos(DataTable dt, int fila)
        {
            try
            {
                this.Id_estado = Convert.ToInt32(dt.Rows[fila]["Id_estado"]);
                this.Nombre_estado = Convert.ToString(dt.Rows[fila]["Nombre_estado"]);
                this.Alias_estado = Convert.ToString(dt.Rows[fila]["Alias_estado"]);
                this.Color_estado = Convert.ToString(dt.Rows[fila]["Color_estado"]);
                this.Enabled = Convert.ToString(dt.Rows[fila]["Enabled"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarEstados(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DEstados_vehiculos.BuscarEstados(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarEstado(EEstados_vehiculos estado, out int id_estado)
        {
            List<string> vs = new List<string>
            {
               estado.Nombre_estado,estado.Alias_estado,
               estado.Color_estado, estado.Enabled
            };
            return DEstados_vehiculos.InsertarEstadoVehiculo(out id_estado, vs);
        }

        public static string EditarEstado(EEstados_vehiculos estado, int id_estado)
        {
            List<string> vs = new List<string>
            {
               estado.Nombre_estado,estado.Alias_estado,
               estado.Color_estado, estado.Enabled
            };
            return DEstados_vehiculos.EditarEstadoVehiculo(id_estado, vs);
        }


        private int _id_estado;
        private string _nombre_estado;
        private string _alias_estado;
        private string _color_estado;
        private string _enabled;

        public int Id_estado { get => _id_estado; set => _id_estado = value; }
        public string Nombre_estado { get => _nombre_estado; set => _nombre_estado = value; }
        public string Alias_estado { get => _alias_estado; set => _alias_estado = value; }
        public string Color_estado { get => _color_estado; set => _color_estado = value; }
        public string Enabled { get => _enabled; set => _enabled = value; }

        public event EventHandler OnError;

    }
}
