using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsEstadosVehiculos
{
    public partial class FrmNuevoEstado : Form
    {
        PoperContainer container;
        public FrmNuevoEstado()
        {
            InitializeComponent();
            this.btnColor.Click += BtnColor_Click;
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog
            {
                AllowFullOpen = false,
                SolidColorOnly = true,
                AnyColor = true
            };

            if (color.ShowDialog() == DialogResult.OK)
            {
                this.gbColor.BackColor = color.Color;
            }
        }
    }
}
