using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public partial class FrmReporteCarrera : Form
    {
        public FrmReporteCarrera()
        {
            InitializeComponent();
        }

        public void Imprimir()
        {
            ControladorImpresion obj = new ControladorImpresion();
            obj.Imprimir(this.reportViewer1.LocalReport);
        }

        public void AsignarReporte(string titulo_reporte, string informacion)
        {
            try
            {
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("TituloReporte", titulo_reporte);
                parameters[1] = new ReportParameter("Informacion", informacion);

                this.reportViewer1.Dock = DockStyle.Fill;
                this.Controls.Add(this.reportViewer1);

                this.reportViewer1.LocalReport.ReportEmbeddedResource =
                    "CapaPresentacion.Formularios.FormsCarreras.rptCarrerasDiarias.rdlc";

                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.Refresh();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "AsignarReporte",
                    "Hubo un error al asignar reporte", ex.Message);
            }
        }
    }
}
