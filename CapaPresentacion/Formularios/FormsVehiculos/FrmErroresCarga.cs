using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsVehiculos
{
    public partial class FrmErroresCarga : Form
    {
        public FrmErroresCarga()
        {
            InitializeComponent();
        }

        public void ObtenerErrores(DataTable dt)
        {
            if (dt != null)
            {
                this.dgvErrores.PageSize = 15;
                this.dgvErrores.clearDataSource();
                this.dgvErrores.SetPagedDataSource(dt, this.bindingNavigator1);
            }
        }
    }
}
