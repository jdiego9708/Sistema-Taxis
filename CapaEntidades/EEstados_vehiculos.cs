namespace CapaEntidades
{
    using CapaDatos;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;

    public class EEstados_vehiculos
    {
        public EEstados_vehiculos()
        {

        }

        public EEstados_vehiculos(DataRow row)
        {
            try
            {
                if (Convert.IsDBNull(row["Id_estado"]))
                    return;

                this.Id_estado = Convert.ToInt32(row["Id_estado"]);
                this.Nombre_estado = Convert.ToString(row["Nombre_estado"]);
                this.Alias_estado = Convert.ToString(row["Alias_estado"]);
                this.Color_estado = Convert.ToString(row["Color_estado"]);
                this.ColorEstado = this.ToColor(this.Color_estado);
                this.Color_letra = Convert.ToString(row["Color_letra"]);
                this.ColorLetra = this.ToColor(this.Color_letra);
                this.Enabled = Convert.ToString(row["Enabled"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EEstados_vehiculos(DataTable dt, int fila)
        {
            try
            {
                if (Convert.IsDBNull(dt.Rows[fila]["Id_estado"]))
                    return;

                this.Id_estado = Convert.ToInt32(dt.Rows[fila]["Id_estado"]);
                this.Nombre_estado = Convert.ToString(dt.Rows[fila]["Nombre_estado"]);
                this.Alias_estado = Convert.ToString(dt.Rows[fila]["Alias_estado"]);
                this.Color_estado = Convert.ToString(dt.Rows[fila]["Color_estado"]);
                this.ColorEstado = this.ToColor(this.Color_estado);
                this.Color_letra = Convert.ToString(dt.Rows[fila]["Color_letra"]);
                this.ColorLetra = this.ToColor(this.Color_letra);
                this.Enabled = Convert.ToString(dt.Rows[fila]["Enabled"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EEstados_vehiculos(int id_estado)
        {
            try
            {
                DataTable dt =
                    BuscarEstados("ID ESTADO", id_estado.ToString(), out string rpta);
                if (dt != null)
                {
                    this.Id_estado = Convert.ToInt32(dt.Rows[0]["Id_estado"]);
                    this.Nombre_estado = Convert.ToString(dt.Rows[0]["Nombre_estado"]);
                    this.Alias_estado = Convert.ToString(dt.Rows[0]["Alias_estado"]);
                    this.Color_estado = Convert.ToString(dt.Rows[0]["Color_estado"]);
                    this.ColorEstado = this.ToColor(this.Color_estado);
                    this.Color_letra = Convert.ToString(dt.Rows[0]["Color_letra"]);
                    this.ColorLetra = this.ToColor(this.Color_letra);
                    this.Enabled = Convert.ToString(dt.Rows[0]["Enabled"]);
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        private Color ToColor(string color)
        {
            var arrColorFragments = color?.Split(',').Select(sFragment => 
            { int.TryParse(sFragment, out int fragment); return fragment; }).ToArray();

            switch (arrColorFragments?.Length)
            {
                case 3:
                    return Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]);
                case 4:
                    return Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2], arrColorFragments[3]);
                default:
                    return Color.Transparent;
            }
        }

        public static DataTable BuscarEstados(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DEstados_vehiculos.BuscarEstados(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarEstado(EEstados_vehiculos estado, out int id_estado)
        {
            List<string> vs = new List<string>
            {
               estado.Nombre_estado,estado.Alias_estado,
               estado.Color_estado, estado.Color_letra, estado.Enabled
            };
            return DEstados_vehiculos.InsertarEstadoVehiculo(out id_estado, vs);
        }

        public static string EditarEstado(EEstados_vehiculos estado, int id_estado)
        {
            List<string> vs = new List<string>
            {
               estado.Nombre_estado,estado.Alias_estado,
               estado.Color_estado, estado.Color_letra, estado.Enabled
            };
            return DEstados_vehiculos.EditarEstadoVehiculo(id_estado, vs);
        }

        private int _id_estado;
        private string _nombre_estado;
        private string _alias_estado;
        private string _color_estado;
        private string _color_letra;
        private string _enabled;
        private Color _colorEstado;
        private Color _colorLetra;

        public int Id_estado { get => _id_estado; set => _id_estado = value; }
        public string Nombre_estado { get => _nombre_estado; set => _nombre_estado = value; }
        public string Alias_estado { get => _alias_estado; set => _alias_estado = value; }
        public string Color_estado { get => _color_estado; set => _color_estado = value; }
        public string Enabled { get => _enabled; set => _enabled = value; }
        public Color ColorEstado { get => _colorEstado; set => _colorEstado = value; }
        public string Color_letra { get => _color_letra; set => _color_letra = value; }
        public Color ColorLetra { get => _colorLetra; set => _colorLetra = value; }

        public event EventHandler OnError;

    }
}
