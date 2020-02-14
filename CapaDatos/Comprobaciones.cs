using System;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace CapaDatos
{
    public class Comprobaciones
    {
        public static string ComprobacionTablaCorreos(string nombreTabla)
        {
            string rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT name FROM sqlite_master WHERE TYPE='table' AND name='" + nombreTabla + "' ");

            DataTable DtResultado = new DataTable("Comprobacion");
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

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);

                if (DtResultado.Rows.Count < 1)
                {
                    consulta = new StringBuilder();
                    consulta.Append("CREATE TABLE ConfiguracionCorreos ( " +
                        "Id_correo INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                        "Correo_remitente TEXT NOT NULL, " +
                        "Clave_correo_remitente TEXT NOT NULL, " +
                        "Correo_destinatario TEXT NOT NULL, " +
                        "Correo_copia TEXT NOT NULL, " +
                        "Tipo_correo TEXT NOT NULL, " +
                        "Estado_correo TEXT NOT NULL DEFAULT 'ACTIVO'); " +
                        "INSERT INTO ConfiguracionCorreos (Correo_remitente, Clave_correo_remitente, Correo_destinatario, Correo_copia, Tipo_correo, Estado_correo) " +
                        "VALUES ('', '', '', '', 'REPORTES', 'ACTIVO'); " +
                        "INSERT INTO ConfiguracionCorreos (Correo_remitente, Clave_correo_remitente, Correo_destinatario, Correo_copia, Tipo_correo, Estado_correo) " +
                        "VALUES ('', '', '', '', 'ERRORES', 'ACTIVO'); ");

                    SqlCmd = new SQLiteCommand
                    {
                        Connection = SqlCon,
                        CommandText = Convert.ToString(consulta),
                        CommandType = CommandType.Text
                    };

                    SqlCmd.ExecuteNonQuery();

                    consulta = new StringBuilder();
                    consulta.Append("SELECT name FROM sqlite_master WHERE TYPE='table' AND name='" + nombreTabla + "' ");

                    SqlCmd = new SQLiteCommand
                    {
                        Connection = SqlCon,
                        CommandText = Convert.ToString(consulta),
                        CommandType = CommandType.Text
                    };

                    SqlData = new SQLiteDataAdapter(SqlCmd);
                    SqlData.Fill(DtResultado);

                    if (DtResultado.Rows.Count < 1)
                    {
                        DtResultado = null;
                        rpta = "No se creo a tabla " + nombreTabla;
                    }
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

            return rpta;
        }

        public static string ComprobacionTablaCarrerasPerdidas(string nombreTabla)
        {
            string rpta = "OK";
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT name FROM sqlite_master WHERE TYPE='table' AND name='" + nombreTabla + "' ");

            DataTable DtResultado = new DataTable("Comprobacion");
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

                SQLiteDataAdapter SqlData = new SQLiteDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);

                if (DtResultado.Rows.Count < 1)
                {
                    consulta = new StringBuilder();
                    consulta.Append("CREATE TABLE Carreras_perdidas ( " +
                        "Id_turno INTEGER NOT NULL, " +
                        "Id_cliente INTEGER NOT NULL, " +
                        "FOREIGN KEY('Id_cliente') REFERENCES 'Clientes'('Id_cliente'), " +
                        "FOREIGN KEY('Id_turno') REFERENCES 'Turnos'('Id_turno')); ");

                    SqlCmd = new SQLiteCommand
                    {
                        Connection = SqlCon,
                        CommandText = Convert.ToString(consulta),
                        CommandType = CommandType.Text
                    };

                    SqlCmd.ExecuteNonQuery();

                    consulta = new StringBuilder();
                    consulta.Append("SELECT name FROM sqlite_master WHERE TYPE='table' AND name='" + nombreTabla + "' ");

                    SqlCmd = new SQLiteCommand
                    {
                        Connection = SqlCon,
                        CommandText = Convert.ToString(consulta),
                        CommandType = CommandType.Text
                    };

                    SqlData = new SQLiteDataAdapter(SqlCmd);
                    SqlData.Fill(DtResultado);

                    if (DtResultado.Rows.Count < 1)
                    {
                        DtResultado = null;
                        rpta = "No se creo a tabla " + nombreTabla;
                    }
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

            return rpta;
        }
    }
}
