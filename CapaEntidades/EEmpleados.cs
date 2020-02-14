using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class EEmpleados
    {
        public EEmpleados()
        {

        }

        public EEmpleados(DataRow row)
        {
            try
            {
                this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                this.Nombre_empleado = Convert.ToString(row["Nombre_empleado"]);
                this.Correo_empleado = Convert.ToString(row["Correo_empleado"]);
                this.Tipo_empleado = Convert.ToString(row["Tipo_empleado"]);
                this.Estado_empleado = Convert.ToString(row["Estado_empleado"]);

                DataTable dtCredenciales =
                    DCredenciales.BuscarCredenciales("ID EMPLEADO", this.Id_empleado.ToString(), out string rpta);
                if (dtCredenciales != null)
                {
                    this.ECredenciales = new ECredenciales(dtCredenciales, 0);
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EEmpleados(DataTable dt, int fila)
        {
            try
            {
                this.Id_empleado = Convert.ToInt32(dt.Rows[fila]["Id_empleado"]);
                this.Nombre_empleado = Convert.ToString(dt.Rows[fila]["Nombre_empleado"]);
                this.Correo_empleado = Convert.ToString(dt.Rows[fila]["Correo_empleado"]);
                this.Tipo_empleado = Convert.ToString(dt.Rows[fila]["Tipo_empleado"]);
                this.Estado_empleado = Convert.ToString(dt.Rows[fila]["Estado_empleado"]);

                DataTable dtCredenciales =
                    DCredenciales.BuscarCredenciales("ID EMPLEADO", this.Id_empleado.ToString(), out string rpta);
                if (dtCredenciales != null)
                {
                    this.ECredenciales = new ECredenciales(dtCredenciales, 0);
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EEmpleados(int id_empleado)
        {
            try
            {
                DataTable dt =
                    DEmpleados.BuscarEmpleado("ID EMPLEADO", id_empleado.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_empleado = Convert.ToInt32(dt.Rows[0]["Id_empleado"]);
                    this.Nombre_empleado = Convert.ToString(dt.Rows[0]["Nombre_empleado"]);
                    this.Correo_empleado = Convert.ToString(dt.Rows[0]["Correo_empleado"]);
                    this.Tipo_empleado = Convert.ToString(dt.Rows[0]["Tipo_empleado"]);
                    this.Estado_empleado = Convert.ToString(dt.Rows[0]["Estado_empleado"]);

                    DataTable dtCredenciales =
                        DCredenciales.BuscarCredenciales("ID EMPLEADO", this.Id_empleado.ToString(), out rpta);
                    if (dtCredenciales != null)
                    {
                        this.ECredenciales = new ECredenciales(dtCredenciales, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable Login(string nombre_empleado, string password, out string rpta)
        {
            return DEmpleados.Login(nombre_empleado, password, out rpta);
        }

        public static DataTable BuscarEmpleados(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DEmpleados.BuscarEmpleado(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarEmpleados(EEmpleados empleado, out int id_empleado)
        {
            List<string> vs = new List<string>
            {
                empleado.Nombre_empleado, empleado.Correo_empleado,
                empleado.Tipo_empleado, empleado.Estado_empleado
            };
            return DEmpleados.InsertarEmpleado(out id_empleado, vs);
        }

        public static string EditarEmpleados(EEmpleados empleado, int id_empleado)
        {
            List<string> vs = new List<string>
            {
                empleado.Nombre_empleado, empleado.Correo_empleado,
                empleado.Tipo_empleado, empleado.Estado_empleado
            };
            return DEmpleados.EditarEmpleado(id_empleado, vs);
        }

        private int _id_empleado;
        private string _nombre_empleado;
        private string _correo_empleado;
        private string _tipo_empleado;
        private string _estado_empleado;

        private ECredenciales _eCredenciales;

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public string Nombre_empleado { get => _nombre_empleado; set => _nombre_empleado = value; }
        public string Correo_empleado { get => _correo_empleado; set => _correo_empleado = value; }
        public string Tipo_empleado { get => _tipo_empleado; set => _tipo_empleado = value; }
        public string Estado_empleado { get => _estado_empleado; set => _estado_empleado = value; }
        public ECredenciales ECredenciales { get => _eCredenciales; set => _eCredenciales = value; }

        public event EventHandler OnError;

    }
}
