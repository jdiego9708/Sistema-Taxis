using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ECorreos
    {
        public ECorreos()
        {

        }

        public ECorreos(DataRow row)
        {
            try
            {
                this.Id_correo = Convert.ToInt32(row["Id_correo"]);
                this.Correo_remitente = Convert.ToString(row["Correo_remitente"]);
                this.Clave_correo_remitente = Convert.ToString(row["Clave_correo_remitente"]);
                this.Correo_destinatario = Convert.ToString(row["Correo_destinatario"]);
                this.Correo_copia = Convert.ToString(row["Correo_copia"]);
                this.Tipo_correo = Convert.ToString(row["Tipo_correo"]);
                this.Estado_correo = Convert.ToString(row["Estado_correo"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ECorreos(DataTable dt, int fila)
        {
            try
            {
                this.Id_correo = Convert.ToInt32(dt.Rows[fila]["Id_correo"]);
                this.Correo_remitente = Convert.ToString(dt.Rows[fila]["Correo_remitente"]);
                this.Clave_correo_remitente = Convert.ToString(dt.Rows[fila]["Clave_correo_remitente"]);
                this.Correo_destinatario = Convert.ToString(dt.Rows[fila]["Correo_destinatario"]);
                this.Correo_copia = Convert.ToString(dt.Rows[fila]["Correo_copia"]);
                this.Tipo_correo = Convert.ToString(dt.Rows[fila]["Tipo_correo"]);
                this.Estado_correo = Convert.ToString(dt.Rows[fila]["Estado_correo"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarCorreos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DCorreos.BuscarCorreos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarCorreo(ECorreos correo, out int id_correo)
        {
            List<string> vs = new List<string>
            {
               correo.Correo_remitente, correo.Clave_correo_remitente, 
               correo.Correo_destinatario, correo.Correo_copia, correo.Tipo_correo,
               correo.Estado_correo
            };
            return DCorreos.InsertarCorreo(out id_correo, vs);
        }

        public static string EditarCorreo(ECorreos correo, int id_correo)
        {
            List<string> vs = new List<string>
            {
               correo.Correo_remitente, correo.Clave_correo_remitente,
               correo.Correo_destinatario, correo.Correo_copia, correo.Tipo_correo,
               correo.Estado_correo
            };
            return DCorreos.EditarCorreo(id_correo, vs);
        }

        private int _id_correo;
        private string _correo_remitente;
        private string _clave_correo_remitente;
        private string _correo_destinatario;
        private string _correo_copia;
        private string _tipo_correo;
        private string _estado_correo;

        public int Id_correo { get => _id_correo; set => _id_correo = value; }
        public string Correo_remitente { get => _correo_remitente; set => _correo_remitente = value; }
        public string Clave_correo_remitente { get => _clave_correo_remitente; set => _clave_correo_remitente = value; }
        public string Correo_destinatario { get => _correo_destinatario; set => _correo_destinatario = value; }
        public string Correo_copia { get => _correo_copia; set => _correo_copia = value; }
        public string Estado_correo { get => _estado_correo; set => _estado_correo = value; }
        public string Tipo_correo { get => _tipo_correo; set => _tipo_correo = value; }

        public event EventHandler OnError;

    }
}
