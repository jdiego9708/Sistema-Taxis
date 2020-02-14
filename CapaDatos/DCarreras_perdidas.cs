using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace CapaDatos
{
    public class DCarreras_perdidas
    {
        #region VARIABLES
        private static string mensaje_respuesta;
        public static string Mensaje_respuesta
        {
            get
            {
                return mensaje_respuesta;
            }

            set
            {
                mensaje_respuesta = value;
            }
        }

        #endregion

        #region CONSTRUCTOR VACIO
        public DCarreras_perdidas() { }
        #endregion

        #region METODO INSERTAR CARRERA PERDIDA
        public static string InsertarCarreraPerdida(List<string> vs)
        {
            string rpta = "";
            string comprobacion = Comprobaciones.ComprobacionTablaCarrerasPerdidas("Carreras_perdidas");
            if (!comprobacion.Equals("OK"))
            {
                rpta = comprobacion;
                return null;
            }

            string consulta = "INSERT INTO Carreras_perdidas(Id_turno, Id_cliente) " +
                "VALUES(@Id_turno, @Id_cliente); ";

            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                int contador = 0;

                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SQLiteParameter Id_turno = new SQLiteParameter
                {
                    ParameterName = "@Id_turno",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SQLiteParameter Id_cliente = new SQLiteParameter
                {
                    ParameterName = "@Id_cliente",
                    Value = Convert.ToInt32(vs[contador])
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se ingresó el registro";

                if (!rpta.Equals("OK"))
                {
                    if (Mensaje_respuesta != null)
                        rpta = Mensaje_respuesta;
                }
            }
            //Mostramos posible error que tengamos
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO BUSCAR CARRERAS PERDIDAS
        public static DataTable BuscarCarrerasPerdidas(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            string comprobacion = Comprobaciones.ComprobacionTablaCarrerasPerdidas("Carreras_perdidas");
            if (!comprobacion.Equals("OK"))
            {
                rpta = comprobacion;
                return null;
            }

            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT * " +
                "FROM Carreras_perdidas cp " +
                "INNER JOIN Turnos tur ON cp.Id_turno = tur.Id_turno " +
                "INNER JOIN Clientes cl ON cp.Id_cliente = cl.Id_cliente ");

            if (tipo_busqueda.Equals("ID CLIENTE"))
            {
                consulta.Append("WHERE cp.Id_cliente = @Texto_busqueda ");
            }           
            else if (tipo_busqueda.Equals("ID TURNO"))
            {
                consulta.Append("WHERE cp.Id_turno = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY cp.Id_turno DESC ");

            DataTable DtResultado = new DataTable("CarrerasPerdidas");
            SQLiteConnection SqlCon = DConexion.Conex(out rpta);
            try
            {
                if (SqlCon == null)
                    throw new Exception(rpta);

                SqlCon.Open();
                SQLiteCommand SqlCmd = new SQLiteCommand
                {
                    Connection = SqlCon,
                    CommandText = Convert.ToString(consulta),
                    CommandType = CommandType.Text
                };

                SQLiteParameter Texto_busqueda = new SQLiteParameter
                {
                    ParameterName = "@Texto_busqueda",
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Texto_busqueda);

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);

                if (DtResultado.Rows.Count < 1)
                {
                    DtResultado = null;
                }
            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return DtResultado;
        }

        #endregion
    }
}
