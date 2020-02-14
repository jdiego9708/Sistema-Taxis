using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaEntidades
{
    public class ECarreras_perdidas
    {
        public ECarreras_perdidas()
        {

        }

        public ECarreras_perdidas(DataRow row)
        {
            try
            {
                this.ETurno = new ETurnos(row);
                this.ECliente = new EClientes(row);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECarreras_perdidas(DataTable dt, int fila)
        {
            try
            {
                this.ETurno = new ETurnos(dt.Rows[fila]);
                this.ECliente = new EClientes(dt.Rows[fila]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarCarrerasPerdidas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DCarreras_perdidas.BuscarCarrerasPerdidas(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarCarreraPerdida(ECarreras_perdidas carrera)
        {
            List<string> vs = new List<string>
            {
                carrera.ETurno.Id_turno.ToString(),
                carrera.ECliente.Id_cliente.ToString()
            };
            return DCarreras_perdidas.InsertarCarreraPerdida(vs);
        }   

        private ETurnos _eTurno;
        private EClientes _eCliente;

        public ETurnos ETurno { get => _eTurno; set => _eTurno = value; }
        public EClientes ECliente { get => _eCliente; set => _eCliente = value; }

        public event EventHandler OnError;

    }
}
