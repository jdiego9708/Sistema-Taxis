using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EBarrios
    {
        public EBarrios()
        {

        }

        public EBarrios(DataRow row)
        {
            try
            {
                this.Id_barrio = Convert.ToInt32(row["Id_barrio"]);
                this.Nombre_barrio = Convert.ToString(row["Nombre_barrio"]);              
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EBarrios(DataTable dt, int fila)
        {
            try
            {
                this.Id_barrio = Convert.ToInt32(dt.Rows[fila]["Id_barrio"]);
                this.Nombre_barrio = Convert.ToString(dt.Rows[fila]["Nombre_barrio"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarBarrios(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DBarrios.BuscarBarrios(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarBarrio(EBarrios barrio, out int id_barrio)
        {
            List<string> vs = new List<string>
            {
                barrio.Nombre_barrio
            };
            return DBarrios.InsertarBarrio(out id_barrio, vs);
        }

        public static string EditarBarrio(EBarrios barrio, int id_barrio)
        {
            List<string> vs = new List<string>
            {
                barrio.Nombre_barrio
            };
            return DBarrios.EditarBarrio(id_barrio, vs);
        }

        private int _id_barrio;
        private string _nombre_barrio;

        public int Id_barrio { get => _id_barrio; set => _id_barrio = value; }
        public string Nombre_barrio { get => _nombre_barrio; set => _nombre_barrio = value; }

        public event EventHandler OnError;

    }
}
