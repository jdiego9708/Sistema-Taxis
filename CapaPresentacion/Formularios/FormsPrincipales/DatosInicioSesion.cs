using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Formularios.FormsPrincipales
{
    public class DatosInicioSesion
    {
        #region PATRON SINGLETON
        private static DatosInicioSesion _Instancia;
        public static DatosInicioSesion GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DatosInicioSesion();
            }
            return _Instancia;
        }
        #endregion

        private EEmpleados _eEmpleado;
        public EEmpleados EEmpleado { get => _eEmpleado; set => _eEmpleado = value; }
    }
}
