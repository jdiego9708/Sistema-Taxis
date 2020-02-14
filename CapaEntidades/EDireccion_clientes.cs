using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaEntidades
{
    public class EDireccion_clientes
    {
        public EDireccion_clientes()
        {

        }

        public EDireccion_clientes(DataRow row)
        {
            try
            {
                this.Id_direccion = Convert.ToInt32(row["Id_direccion"]);

                this.ECliente = new EClientes(row);
               
                this.Direccion = Convert.ToString(row["Direccion"]);
                this.Casa = Convert.ToString(row["Casa"]);

                this.EBarrio = new EBarrios
                {
                    Id_barrio = Convert.ToInt32(row["Id_barrio"]),
                    Nombre_barrio = Convert.ToString(row["Nombre_barrio"])
                };

                this.Ciudadela = Convert.ToString(row["Ciudadela"]);
                this.Referencia = Convert.ToString(row["Referencia"]);
                this.Observaciones = Convert.ToString(row["Observaciones"]);
                this.Estado_direccion = Convert.ToString(row["Estado_direccion"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EDireccion_clientes(DataTable dt, int fila)
        {
            try
            {
                this.Id_direccion = Convert.ToInt32(dt.Rows[fila]["Id_direccion"]);

                this.ECliente = new EClientes(dt.Rows[fila]);

                this.Direccion = Convert.ToString(dt.Rows[fila]["Direccion"]);
                this.Casa = Convert.ToString(dt.Rows[fila]["Casa"]);

                this.EBarrio = new EBarrios
                {
                    Id_barrio = Convert.ToInt32(dt.Rows[fila]["Id_barrio"]),
                    Nombre_barrio = Convert.ToString(dt.Rows[fila]["Nombre_barrio"])
                };

                this.Ciudadela = Convert.ToString(dt.Rows[fila]["Ciudadela"]);
                this.Referencia = Convert.ToString(dt.Rows[fila]["Referencia"]);
                this.Observaciones = Convert.ToString(dt.Rows[fila]["Observaciones"]);
                this.Estado_direccion = Convert.ToString(dt.Rows[fila]["Estado_direccion"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarDireccion(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DDireccion_clientes.BuscarDireccionClientes(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarDireccion(EDireccion_clientes direccion, out int id_direccion)
        {
            List<string> vs = new List<string>
            {
                direccion.ECliente.Id_cliente.ToString(),
                direccion.Direccion,
                direccion.Casa, direccion.EBarrio.Id_barrio.ToString(),
                direccion.Ciudadela,direccion.Referencia,
                direccion.Observaciones, direccion.Estado_direccion
            };

            return DDireccion_clientes.InsertarDireccionCliente(out id_direccion, vs);
        }

        public static string InsertarDirecciones(List<EDireccion_clientes> direcciones)
        {
            StringBuilder consultaCompleta = new StringBuilder();
            int contador = 0;
            try
            {
                foreach (EDireccion_clientes direccion in direcciones)
                {
                    string consulta = "INSERT INTO Direccion_clientes " +
                    "(Id_cliente, Direccion, Casa, Id_barrio, Ciudadela, Referencia, Observaciones, Estado_direccion) " +
                    "VALUES('" + direccion.ECliente.Id_cliente + "','" +
                    direccion.Direccion + "','" +
                    direccion.Casa + "','" +
                    direccion.EBarrio.Id_barrio + "','" +
                    direccion.Ciudadela + "','" +
                    direccion.Referencia + "','" +
                    direccion.Observaciones + "','" +
                    direccion.Estado_direccion + "'); ";
                    consultaCompleta.Append(consulta);
                    contador += 1;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            return DConexion.EjecutarConsultaCadena(Convert.ToString(consultaCompleta), false);
        }

        public static string EditarDireccion(EDireccion_clientes direccion, int id_direccion)
        {
            List<string> vs = new List<string>
            {
                direccion.ECliente.Id_cliente.ToString(),
                direccion.Direccion,
                direccion.Casa, direccion.EBarrio.Id_barrio.ToString(),
                direccion.Ciudadela,direccion.Referencia,
                direccion.Observaciones, direccion.Estado_direccion
            };

            return DDireccion_clientes.EditarDireccionCliente(id_direccion, vs);
        }

        private int _id_direccion;
        private EClientes _eCliente;
        private string _direccion;
        private string _casa;
        private EBarrios _eBarrio;
        private string _ciudadela;
        private string _referencia;
        private string _observaciones;
        private string _estado_direccion;

        public int Id_direccion { get => _id_direccion; set => _id_direccion = value; }
        public EClientes ECliente { get => _eCliente; set => _eCliente = value; }
        public string Casa { get => _casa; set => _casa = value; }
        public string Referencia { get => _referencia; set => _referencia = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
        public string Estado_direccion { get => _estado_direccion; set => _estado_direccion = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public EBarrios EBarrio { get => _eBarrio; set => _eBarrio = value; }
        public string Ciudadela { get => _ciudadela; set => _ciudadela = value; }

        public event EventHandler OnError;

    }
}
