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

namespace CapaPresentacion.Formularios.FormsBarrios
{
    public partial class FrmNuevoBarrio : Form
    {
        public FrmNuevoBarrio()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        public event EventHandler OnBarrioSuccess;
        public void AsignarDatos(EBarrios eBarrio)
        {
            this.EBarrio = eBarrio;
            this.IsEditar = true;
            this.txtNombreBarrio.Text = eBarrio.Nombre_barrio;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNombreBarrio.Text.Equals(""))
                {
                    Mensajes.MensajeInformacion("El nombre del barrio no puede estar vacío.", "Entendido");
                    return;
                }
                else
                {
                    EBarrios eBarrio = new EBarrios
                    {
                        Nombre_barrio = this.txtNombreBarrio.Text
                    };

                    string rpta = "";
                    string mensaje = "";

                    if (this.IsEditar)
                    {
                        rpta = EBarrios.EditarBarrio(eBarrio, this.EBarrio.Id_barrio);
                        mensaje = "Se actualizó el barrio correctamente";
                    }
                    else
                    {
                        rpta = EBarrios.InsertarBarrio(eBarrio, out int id_barrio);
                        eBarrio.Id_barrio = id_barrio;
                        mensaje = "Se agregó el barrio correctamente";
                    }

                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeInformacion(mensaje, "Entendido");
                        this.OnBarrioSuccess?.Invoke(eBarrio, e);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar un barrio", ex.Message);
            }
        }

        private bool _isEditar;
        public EBarrios EBarrio { get; set; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}
