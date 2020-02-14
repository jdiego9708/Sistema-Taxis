using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SQLite;
using System.Data;

namespace CapaDatos
{
    public static class DConexion
    {        
        private static string ObtenerCadenaDeConexion(string Nombre_cadena_de_conexion, string tipo_dato)
        {
            string cadena = "";
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;

            if (connections.Count != 0)
            {
                foreach (ConnectionStringSettings connection in connections)
                {

                    string name = connection.Name;
                    string provider = connection.ProviderName;
                    string connectionString = connection.ConnectionString;
                    if (name.Equals(Nombre_cadena_de_conexion) && tipo_dato.Equals("COMPLETA"))
                    {
                        cadena = connectionString;
                        break;
                    }
                    else if (name.Equals(Nombre_cadena_de_conexion) && tipo_dato.Equals("NOMBRE SERVIDOR"))
                    {
                        cadena = name;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No existe la conexión");
            }
            return cadena;
        }

        public static string Cn
        {
            get { return ObtenerCadenaDeConexion(Convert.ToString(ConfigurationManager.AppSettings["nameBDConnection"]), "COMPLETA"); }
        }

        public static SQLiteConnection Conex(out string rpta)
        {
            rpta = "OK";
            try
            {
                string conec = Cn;
                SQLiteConnection conn = new SQLiteConnection(conec);
                return conn;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }
        }

        public static DataTable EjecutarConsultaDt(string consulta, out string rpta)
        {
            rpta = "OK";
            DataTable tabla = new DataTable();
            SQLiteConnection cnn = Conex(out rpta);
            try
            {
                if (cnn == null)
                    throw new Exception(rpta);

                cnn.Open();
                SQLiteCommand m = new SQLiteCommand(consulta, cnn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(m);

                da.Fill(tabla);

                if (tabla.Rows.Count < 1)
                    tabla = null;

                return tabla;
            }
            catch (SQLiteException ex)
            {
                rpta = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return null;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }

        public static string EjecutarConsultaCadena(string consulta, bool returnIdentity)
        {
            SQLiteConnection cnn = Conex(out string rpta);
            try
            {
                if (cnn == null)
                    throw new Exception(rpta);

                cnn.Open();
                SQLiteCommand m = new SQLiteCommand(consulta, cnn);
                if (returnIdentity)
                {
                    int id = Convert.ToInt32(m.ExecuteScalar());
                    Id_autogenerado = id;
                    if (id > 0)
                        rpta = "OK";
                    else
                        throw new Exception("La identificación única (ID) no se obtuvo correctamente");
                }
                else
                {
                    rpta = m.ExecuteNonQuery() >= 1 ? "OK" : "ERROR";
                }
            }
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
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return rpta;
        }

        public static int Id_autogenerado;
    }
}
