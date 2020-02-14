using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class ClientesBases : UserControl
    {
        public ClientesBases()
        {
            InitializeComponent();
            this.dgvBases.PreviewKeyDown += DgvBases_PreviewKeyDown;
        }
        public event EventHandler OnClienteBaseNext;
        private void DgvBases_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Enter))
            {
                DataGridViewRow rowGrid = this.dgvBases.CurrentRow;
                DataRow row = ((DataRowView)rowGrid.DataBoundItem).Row;
                OnClienteBaseNext?.Invoke(row, e);
            }
        }      

        private void AsignarBases(DataTable dtBases)
        {
            this.dgvBases.DataSource = dtBases;
            foreach(DataGridViewColumn column in this.dgvBases.Columns)
            {
                if (column.Name.Equals("Alias_base"))
                {
                    column.Visible = true;
                    column.HeaderText = "Alias";
                }
                else if (column.Name.Equals("Nombre_base"))
                {
                    column.Visible = true;
                    column.HeaderText = "Nombre";
                }
                else
                    column.Visible = false;
            }
        }

        private DataTable _dtBases;

        public DataTable DtBases { get => _dtBases;
            set
            {
                _dtBases = value;
                this.AsignarBases(value);
            }
        }
    }
}
