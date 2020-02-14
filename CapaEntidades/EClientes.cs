using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaEntidades
{
    public class EClientes
    {
        public EClientes()
        {

        }

        public EClientes(DataRow row)
        {
            try
            {
                this.Id_cliente = Convert.ToInt32(row["Id_cliente"]);
                this.Codigo_cliente = Convert.ToString(row["Codigo_cliente"]);
                this.EBase = new EBases_clientes(row);
                this.Nombre_cliente = Convert.ToString(row["Nombre_cliente"]);
                this.Celular_cliente = Convert.ToString(row["Celular_cliente"]);
                this.Estado_cliente = Convert.ToString(row["Estado_cliente"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EClientes(DataTable dt, int fila)
        {
            try
            {
                this.Id_cliente = Convert.ToInt32(dt.Rows[fila]["Id_cliente"]);
                this.Codigo_cliente = Convert.ToString(dt.Rows[fila]["Codigo_cliente"]);
                this.EBase = new EBases_clientes(dt.Rows[fila]);
                this.Nombre_cliente = Convert.ToString(dt.Rows[fila]["Nombre_cliente"]);
                this.Celular_cliente = Convert.ToString(dt.Rows[fila]["Celular_cliente"]);
                this.Estado_cliente = Convert.ToString(dt.Rows[fila]["Estado_cliente"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarClientes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DClientes.BuscarClientes(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarCliente(EClientes cliente, out int id_cliente)
        {
            List<string> vs = new List<string>
            {
                cliente.Codigo_cliente, cliente.EBase.Id_base.ToString(),
                cliente.Nombre_cliente, cliente.Celular_cliente,
                cliente.Estado_cliente
            };
            return DClientes.InsertarCliente(out id_cliente, vs);
        }

        public static string InsertarCliente(EClientes cliente)
        {
            string consulta = "INSERT INTO Clientes (Codigo_cliente, Nombre_cliente, Celular_cliente, Estado_cliente) " +
                "VALUES('" + cliente.Codigo_cliente + "',' " +
                cliente.Nombre_cliente + "','" +
                cliente.Celular_cliente + "','" +
                cliente.Estado_cliente + "');";
            return DConexion.EjecutarConsultaCadena(Convert.ToString(consulta), false);
        }

        private static StringBuilder ConsultaCompleta;

        public static string InsertarClientes(List<EClientes> Clientes)
        {
            StringBuilder consultaCompleta = new StringBuilder();
            int contador = 0;
            try
            {              
                foreach (EClientes eCliente in Clientes)
                {                   
                    string consulta = "INSERT INTO Clientes " +
                    "(Codigo_cliente, Id_base, Nombre_cliente, Celular_cliente, Estado_cliente) " +
                    "VALUES('" + eCliente.Codigo_cliente + "','" +
                    eCliente.EBase.Id_base + "','" +
                    eCliente.Nombre_cliente + "','" +
                    eCliente.Celular_cliente + "','" +
                    eCliente.Estado_cliente + "'); ";
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

        public static string InsertarClientes(string consulta)
        {           
            return DConexion.EjecutarConsultaCadena(consulta, false);
        }

        public static string EditarCliente(EClientes cliente, int id_cliente)
        {
            List<string> vs = new List<string>
            {
                cliente.Codigo_cliente, cliente.EBase.Id_base.ToString(),
                cliente.Nombre_cliente, cliente.Celular_cliente,
                cliente.Estado_cliente
            };
            return DClientes.EditarCliente(id_cliente, vs);
        }

        private int _id_cliente;
        private string _codigo_cliente;
        private EBases_clientes _eBase;
        private string _nombre_cliente;
        private string _celular_cliente;
        private string _estado_cliente;

        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public string Nombre_cliente { get => _nombre_cliente; set => _nombre_cliente = value; }
        public string Celular_cliente { get => _celular_cliente; set => _celular_cliente = value; }
        public string Estado_cliente { get => _estado_cliente; set => _estado_cliente = value; }
        public string Codigo_cliente { get => _codigo_cliente; set => _codigo_cliente = value; }
        public EBases_clientes EBase { get => _eBase; set => _eBase = value; }

        public event EventHandler OnError;

    }
}
