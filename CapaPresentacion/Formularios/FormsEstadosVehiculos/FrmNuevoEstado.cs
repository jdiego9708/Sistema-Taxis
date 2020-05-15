using CapaEntidades;
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
            this.btnColorPrincipal.Click += BtnColorEstado_Click;
            this.btnColorLetra.Click += BtnColorLetra_Click;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        private bool Comprobaciones(out EEstados_vehiculos eEstado)
        {
            eEstado = new EEstados_vehiculos();

            if (string.IsNullOrEmpty(this.txtNombreEstado.Text))
            {
                Mensajes.MensajeInformacion("Escriba un nombre para el estado", "Entendido");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtAlias.Text))
            {
                Mensajes.MensajeInformacion("Escriba un alias para el estado", "Entendido");
                return false;
            }

            if (this.btnColorPrincipal.Tag == null)
            {
                Mensajes.MensajeInformacion("Seleccione un color para el estado", "Entendido");
                return false;
            }

            if (this.btnColorLetra.Tag == null)
            {
                Mensajes.MensajeInformacion("Seleccione un color para la letra", "Entendido");
                return false;
            }

            eEstado.Nombre_estado = this.txtNombreEstado.Text;
            eEstado.Alias_estado = this.txtAlias.Text;
            eEstado.Color_estado = this.gbColorEstado.BackColor.ToString();
            eEstado.Color_estado = this.gbColorEstado.BackColor.ToString();
            eEstado.Enabled = "ACTIVO";
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out EEstados_vehiculos eEstado))
                {
                    string rpta = EEstados_vehiculos.InsertarEstado(eEstado, out int id_estado);
                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeOkForm("Se guardó correctamente el estado");
                        this.Close();
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar los datos del estado", ex.Message);
            }
        }

        private void BtnColorLetra_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog
            {
                AllowFullOpen = false,
                SolidColorOnly = true,
                AnyColor = true
            };

            if (color.ShowDialog() == DialogResult.OK)
            {
                this.gbColorLetra.BackColor = color.Color;
                this.btnColorLetra.Tag = color.Color;
            }
        }

        private void BtnColorEstado_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog
            {
                AllowFullOpen = false,
                SolidColorOnly = true,
                AnyColor = true
            };

            if (color.ShowDialog() == DialogResult.OK)
            {
                this.gbColorEstado.BackColor = color.Color;
                this.btnColorPrincipal.Tag = color.Color;
            }
        }
    }
}
