using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaEntidades
{
    public class ETurnos
    {
        public ETurnos()
        {

        }

        public ETurnos(DataRow row)
        {
            try
            {
                this.Id_turno = Convert.ToInt32(row["Id_turno"]);

                this.EEmpleado = new EEmpleados(row);

                this.Hora_inicio_turno = TimeSpanConvert.StringToTimeSpan(Convert.ToString(row["Hora_inicio_turno"]));
                this.Hora_fin_turno = TimeSpanConvert.StringToTimeSpan(Convert.ToString(row["Hora_fin_turno"]));
                this.Fecha_turno = Convert.ToDateTime(row["Fecha_turno"]);
                this.Estado_turno = Convert.ToString(row["Estado_turno"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public ETurnos(DataTable dt, int fila)
        {
            try
            {
                this.Id_turno = Convert.ToInt32(dt.Rows[fila]["Id_turno"]);

                this.EEmpleado = new EEmpleados(dt.Rows[fila]);

                this.Hora_inicio_turno = TimeSpanConvert.StringToTimeSpan(Convert.ToString(dt.Rows[fila]["Hora_inicio_turno"]));
                this.Hora_fin_turno = TimeSpanConvert.StringToTimeSpan(Convert.ToString(dt.Rows[fila]["Hora_fin_turno"]));
                this.Fecha_turno = Convert.ToDateTime(dt.Rows[fila]["Fecha_turno"]);
                this.Estado_turno = Convert.ToString(dt.Rows[fila]["Estado_turno"]);
            }
            catch (Exception ex)
            {
                this.OnError?.Invoke(ex.Message, null);
            }
        }

        public static DataTable BuscarTurnos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            return DTurnos.BuscarTurnos(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static string InsertarTurno(ETurnos turno, out int id_turno)
        {
            List<string> vs = new List<string>
            {
                turno.EEmpleado.Id_empleado.ToString(),
                turno.Hora_inicio_turno.ToString(@"hh\:mm\:ss"),
                turno.Hora_fin_turno.ToString(@"hh\:mm\:ss"),
                turno.Fecha_turno.ToString("yyyy-MM-dd"),
                turno.Estado_turno
            };
            return DTurnos.InsertarTurno(out id_turno, vs);
        }

        public static string EditarTurno(ETurnos turno, int id_turno)
        {
            List<string> vs = new List<string>
            {
                turno.EEmpleado.Id_empleado.ToString(),
                turno.Hora_inicio_turno.ToString(@"hh\:mm\:ss"),
                turno.Hora_fin_turno.ToString(@"hh\:mm\:ss"),
                turno.Fecha_turno.ToString("yyyy-MM-dd"),
                turno.Estado_turno
            };
            return DTurnos.EditarTurno(id_turno, vs);
        }

        private int _id_turno;
        private EEmpleados _eEmpleado;
        private TimeSpan _hora_inicio_turno;
        private TimeSpan _hora_fin_turno;
        private DateTime _fecha_turno;
        private string _estado_turno;

        public int Id_turno { get => _id_turno; set => _id_turno = value; }
        public EEmpleados EEmpleado { get => _eEmpleado; set => _eEmpleado = value; }
        public TimeSpan Hora_inicio_turno { get => _hora_inicio_turno; set => _hora_inicio_turno = value; }
        public TimeSpan Hora_fin_turno { get => _hora_fin_turno; set => _hora_fin_turno = value; }
        public DateTime Fecha_turno { get => _fecha_turno; set => _fecha_turno = value; }
        public string Estado_turno { get => _estado_turno; set => _estado_turno = value; }

        public event EventHandler OnError;

    }
}
