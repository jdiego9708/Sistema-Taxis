using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EBases_clientes
    {
        public EBases_clientes()
        {

        }

        public EBases_clientes(DataRow row)
        {
            try
            {
                this.Id_base = Convert.ToInt32(row["Id_base"]);
                this.Nombre_base = Convert.ToString(row["Nombre_base"]);              
                this.Alias_base = Convert.ToString(row["Alias_base"]);              
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EBases_clientes(DataTable dt, int fila)
        {
            try
            { 
                this.Id_base = Convert.ToInt32(dt.Rows[fila]["Id_base"]);
                this.Nombre_base = Convert.ToString(dt.Rows[fila]["Nombre_base"]);
                this.Alias_base = Convert.ToString(dt.Rows[fila]["Alias_base"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarBases(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DBases_clientes.BuscarBases(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarBase(EBases_clientes basecl, out int id_base)
        {
            List<string> vs = new List<string>
            {
                basecl.Nombre_base, basecl.Alias_base
            };
            return DBases_clientes.InsertarBase(out id_base, vs);
        }

        public static string EditarBase(EBases_clientes basecl, int id_base)
        {
            List<string> vs = new List<string>
            {
                basecl.Nombre_base, basecl.Alias_base
            };
            return DBases_clientes.EditarBarrio(id_base, vs);
        }

        private int _id_base;
        private string _nombre_base;
        private string _alias_base;

        public int Id_base { get => _id_base; set => _id_base = value; }
        public string Nombre_base { get => _nombre_base; set => _nombre_base = value; }
        public string Alias_base { get => _alias_base; set => _alias_base = value; }

        public event EventHandler OnError;

    }
}
