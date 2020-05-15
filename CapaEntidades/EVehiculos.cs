using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaEntidades
{
    public class EVehiculos
    {
        public EVehiculos()
        {

        }

        public EVehiculos(DataRow row)
        {
            try
            {
                this.Id_vehiculo = Convert.ToInt32(row["Id_vehiculo"]);
                this.Placa = Convert.ToString(row["Placa"]);
                this.Propietario = Convert.ToString(row["Propietario"]);
                this.Chofer = Convert.ToString(row["Chofer"]);
                this.Marca = Convert.ToString(row["Marca"]);
                this.Modelo = Convert.ToString(row["Modelo"]);
                this.Color = Convert.ToString(row["Color"]);
                this.Estado_vehiculo = Convert.ToString(row["Estado_vehiculo"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public EVehiculos(DataTable dt, int fila)
        {
            try
            {
                this.Id_vehiculo = Convert.ToInt32(dt.Rows[fila]["Id_vehiculo"]);
                this.Placa = Convert.ToString(dt.Rows[fila]["Placa"]);
                this.Propietario = Convert.ToString(dt.Rows[fila]["Propietario"]);
                this.Chofer = Convert.ToString(dt.Rows[fila]["Chofer"]);
                this.Marca = Convert.ToString(dt.Rows[fila]["Marca"]);
                this.Modelo = Convert.ToString(dt.Rows[fila]["Modelo"]);
                this.Color = Convert.ToString(dt.Rows[fila]["Color"]);
                this.Estado_vehiculo = Convert.ToString(dt.Rows[fila]["Estado_vehiculo"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarVehiculos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DVehiculos.BuscarVehiculos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarVehiculo(EVehiculos vehiculo, int id_vehiculo)
        {
            List<string> vs = new List<string>
            {
                vehiculo.Placa, vehiculo.Propietario,
                vehiculo.Chofer, vehiculo.Marca,
                vehiculo.Modelo, vehiculo.Color,
                vehiculo.Estado_vehiculo,
                vehiculo.Correo_chofer
            };
            return DVehiculos.InsertarVehiculo(id_vehiculo, vs);
        }

        public static string InsertarVehiculos(List<EVehiculos> eVehiculos)
        {
            StringBuilder consultaCompleta = new StringBuilder();

            foreach (EVehiculos eVehiculo in eVehiculos)
            {
                string consulta = "INSERT INTO Vehiculos " +
                "(Id_vehiculo, Placa, Propietario, Chofer, Marca, Modelo, Color, Estado_vehiculo, Correo_chofer) " +
                "VALUES('" + eVehiculo.Id_vehiculo + "',' " +
                eVehiculo.Placa + "','" +
                eVehiculo.Propietario + "','" +
                eVehiculo.Chofer + "','" +
                eVehiculo.Marca + "','" +
                eVehiculo.Modelo + "','" +
                eVehiculo.Color + "','" +
                eVehiculo.Estado_vehiculo + "','" +
                eVehiculo.Correo_chofer + "'); ";
                consultaCompleta.Append(consulta);
            }

            return DConexion.EjecutarConsultaCadena(Convert.ToString(consultaCompleta), false);
        }

        public static string EditarVehiculo(EVehiculos vehiculo, int id_vehiculo)
        {
            List<string> vs = new List<string>
            {
                vehiculo.Placa, vehiculo.Propietario,
                vehiculo.Chofer, vehiculo.Marca,
                vehiculo.Modelo, vehiculo.Color,
                vehiculo.Estado_vehiculo,
                vehiculo.Correo_chofer,
            };
            return DVehiculos.EditarVehiculo(id_vehiculo, vs);
        }

        private int _id_vehiculo;
        private string _placa;
        private string _propietario;
        private string _chofer;
        private string _marca;
        private string _modelo;
        private string _color;
        private string _estado_vehiculo;
        private string _correo_chofer;

        public int Id_vehiculo { get => _id_vehiculo; set => _id_vehiculo = value; }
        public string Placa { get => _placa; set => _placa = value; }
        public string Propietario { get => _propietario; set => _propietario = value; }
        public string Chofer { get => _chofer; set => _chofer = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public string Color { get => _color; set => _color = value; }
        public string Estado_vehiculo { get => _estado_vehiculo; set => _estado_vehiculo = value; }
        public string Correo_chofer { get => _correo_chofer; set => _correo_chofer = value; }

        public event EventHandler OnError;

    }
}
