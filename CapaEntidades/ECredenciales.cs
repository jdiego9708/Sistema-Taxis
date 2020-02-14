using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ECredenciales
    {
        public ECredenciales()
        {

        }

        public ECredenciales(DataRow row)
        {
            try
            {
                this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                this.Password = Convert.ToString(row["Password"]);
                this.Fecha_modificacion = Convert.ToDateTime(row["Fecha_modificacion"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECredenciales(DataTable dt, int fila)
        {
            try
            {
                this.Id_empleado = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]);
                this.Password = Convert.ToString(dt.Rows[fila]["Password"]);
                this.Fecha_modificacion = Convert.ToDateTime(dt.Rows[fila]["Fecha_modificacion"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static string InsertarCredenciales(ECredenciales credenciales)
        {
            List<string> vs = new List<string>
            {
               credenciales.Id_empleado.ToString(),
                credenciales.Password,
                credenciales.Fecha_modificacion.ToString("yyyy-MM-dd")
            };
            return DCredenciales.InsertarCredenciales(vs);
        }

        public static string EditarCredenciales(ECredenciales credenciales)
        {
            List<string> vs = new List<string>
            {
                credenciales.Id_empleado.ToString(),
                credenciales.Password,
                credenciales.Fecha_modificacion.ToString("yyyy-MM-dd")
            };
            return DCredenciales.EditarCredenciales(vs);
        }

        public static DataTable BuscarCredenciales(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DCredenciales.BuscarCredenciales(tipo_busqueda, texto_busqueda, out rpta);
        }


        private int _id_empleado;
        private string _password;
        private DateTime _fecha_modificacion;

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime Fecha_modificacion { get => _fecha_modificacion; set => _fecha_modificacion = value; }

        public event EventHandler OnError;

    }
}
