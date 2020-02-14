using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Properties;

namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsLicencias
{
    public partial class FrmGestionarLicencias : Form
    {
        public FrmGestionarLicencias()
        {
            InitializeComponent();
            this.Load += FrmGestionarLicencias_Load;
            this.btnCambiarLicencia.Click += BtnCambiarLicencia_Click;
            this.rdLicenciaCompleta.CheckedChanged += Rd_CheckedChanged;
            this.rd30dias.CheckedChanged += Rd_CheckedChanged;
            this.rd20dias.CheckedChanged += Rd_CheckedChanged;
            this.rd10dias.CheckedChanged += Rd_CheckedChanged;
            this.rd8dias.CheckedChanged += Rd_CheckedChanged;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNuevaLicencia.Text.Equals(""))
                {
                    Mensajes.MensajeInformacion("Digite una clave de licencia válida", "Entendido");
                    return;
                }
                else
                {
                    string licenciaSeleccionada = "";
                    foreach (Control control in this.gbLicenciasLista.Controls)
                    {
                        if (control is RadioButton rd)
                        {
                            if (rd.Checked)
                            {
                                licenciaSeleccionada = Convert.ToString(rd.Tag);
                                break;
                            }
                        }
                    }
                    
                    if (licenciaSeleccionada != "")
                    {
                        bool result = false;
                        switch (licenciaSeleccionada)
                        {
                            case "LicenciaCompleta":
                                string licenciaCompleta = ConfigLicencias.Default.LicenciaCompleta;
                                if (this.txtNuevaLicencia.Text.Equals(licenciaCompleta))
                                    result = true;
                                else
                                    result = false;
                                break;
                            case "Licencia30Dias":
                                string licencia30 = ConfigLicencias.Default.Licencia30Dias;
                                if (this.txtNuevaLicencia.Text.Equals(licencia30))
                                    result = true;
                                else
                                    result = false;
                                break;
                            case "Licencia20Dias":
                                string licencia20 = ConfigLicencias.Default.Licencia20Dias;
                                if (this.txtNuevaLicencia.Text.Equals(licencia20))
                                    result = true;
                                else
                                    result = false;
                                break;
                            case "Licencia10Dias":
                                string licencia10 = ConfigLicencias.Default.Licencia10Dias;
                                if (this.txtNuevaLicencia.Text.Equals(licencia10))
                                    result = true;
                                else
                                    result = false;
                                break;
                            case "Licencia8Dias":
                                string licencia8 = ConfigLicencias.Default.Licencia8Dias;
                                if (this.txtNuevaLicencia.Text.Equals(licencia8))
                                    result = true;
                                else
                                    result = false;
                                break;
                        }

                        if (result)
                        {
                            ConfigLicencias.Default.LicenciaActual = licenciaSeleccionada;
                            ConfigLicencias.Default.Save();
                            Mensajes.MensajeInformacion("Se guardó correctamente la licencia actual, " +
                                "la aplicación se cerrará, inicie nuevamente", "Entendido");
                            this.DialogResult = DialogResult.OK;
                            Application.Exit();
                        }
                        else
                        {
                            Mensajes.MensajeInformacion("La licencia que trata de activar no corresponde a ninguna " +
                                "en la base de datos, por favor verifique", "Entendido");
                            return;
                        }
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("Digite seleccione una licencia válida", "Entendido");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al guardar los datos de las licencias", ex.Message);
            }
        }

        private bool ComprobarLicencia(string licencia, out int diasRestantes)
        {
            bool result = false;
            diasRestantes = 0;
            string licenciaActual = ConfigLicencias.Default.LicenciaActual;
            switch (licencia)
            {
                case "LicenciaCompleta":

                    if (licenciaActual.Equals(licencia))
                    {
                        Mensajes.MensajeInformacion("Ya tiene la licencia actual activa", "Entendido");
                        result = false;
                    }
                    else
                        result = true;

                    break;
                case "Licencia30Dias":

                    if (licenciaActual.Equals(licencia))
                    {
                        Mensajes.MensajeInformacion("Ya tiene la licencia por 30 días activa", "Entendido");
                        result = false;
                    }
                    else
                    {                       
                        int diasLicencia30 = ConfigLicencias.Default.ConteoLicencia30;
                        diasRestantes = (30 - diasLicencia30);
                        if (diasLicencia30 > 30)
                        {
                            Mensajes.MensajeInformacion("No se puede activar la licencia por 30 días, " +
                                "debido a que ya expiró", "Entendido");
                            result = false;
                        }
                        else
                            result = true;
                    }

                    break;
                case "Licencia20Dias":

                    if (licenciaActual.Equals(licencia))
                    {
                        Mensajes.MensajeInformacion("Ya tiene la licencia por 20 días activa", "Entendido");
                        result = false;
                    }
                    else
                    {
                        int diasLicencia20 = ConfigLicencias.Default.ConteoLicencia20;
                        diasRestantes = (20 - diasLicencia20);
                        if (diasLicencia20 > 20)
                        {
                            Mensajes.MensajeInformacion("No se puede activar la licencia por 20 días, " +
                                "debido a que ya expiró", "Entendido");
                            result = false;
                        }
                        else
                            result = true;
                    }

                    break;
                case "Licencia10Dias":

                    if (licenciaActual.Equals(licencia))
                    {
                        Mensajes.MensajeInformacion("Ya tiene la licencia por 10 días activa", "Entendido");
                        result = false;
                    }
                    else
                    {
                        int diasLicencia10 = ConfigLicencias.Default.ConteoLicencia10;
                        diasRestantes = (10 - diasLicencia10);
                        if (diasLicencia10 > 10)
                        {
                            Mensajes.MensajeInformacion("No se puede activar la licencia por 10 días, " +
                                "debido a que ya expiró", "Entendido");
                            result = false;
                        }
                        else
                            result = true;
                    }
                    break;
                case "Licencia8Dias":
                    if (licenciaActual.Equals(licencia))
                    {
                        Mensajes.MensajeInformacion("Ya tiene la licencia por 8 días activa", "Entendido");
                        result = false;
                    }
                    else
                    {
                        int diasLicencia8 = ConfigLicencias.Default.ConteoLicencia8;
                        diasRestantes = (8 - diasLicencia8);
                        if (diasLicencia8 > 8)
                        {
                            Mensajes.MensajeInformacion("No se puede activar la licencia por 8 días, " +
                                "debido a que ya expiró", "Entendido");
                            result = false;
                        }
                        else
                            result = true;
                    }
                    break;
            }

            if (result)
                this.btnGuardar.Enabled = true;
            else
                this.btnGuardar.Enabled = false;

            return result;
        }

        private void Rd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                string licencia = Convert.ToString(rd.Tag);
                switch (licencia)
                {
                    case "LicenciaCompleta":
                        if (this.ComprobarLicencia(licencia, out _))
                        {
                            gbActivarLicencia.Visible = true;
                            gbActivarLicencia.Text = "Digite la clave de licencia completa";
                            this.lblDiasRestantesNuevaLicencia.Text = "Licencia completa";
                        }
                        break;
                    case "Licencia30Dias":
                        if (this.ComprobarLicencia(licencia, out int diasRestantes30))
                        {
                            gbActivarLicencia.Visible = true;
                            gbActivarLicencia.Text = "Digite la clave de licencia por 30 días";
                            this.lblDiasRestantesNuevaLicencia.Text = diasRestantes30 + " días restantes";
                        }
                        break;
                    case "Licencia20Dias":
                        if (this.ComprobarLicencia(licencia, out int diasRestantes20))
                        {
                            gbActivarLicencia.Visible = true;
                            gbActivarLicencia.Text = "Digite la clave de licencia por 20 días";
                            this.lblDiasRestantesNuevaLicencia.Text = diasRestantes20 + " días restantes";
                        }
                        break;
                    case "Licencia10Dias":
                        if (this.ComprobarLicencia(licencia, out int diasRestantes10))
                        {
                            gbActivarLicencia.Visible = true;
                            gbActivarLicencia.Text = "Digite la clave de licencia por 10 días";
                            this.lblDiasRestantesNuevaLicencia.Text = diasRestantes10 + " días restantes";
                        }
                        break;
                    case "Licencia8Dias":
                        if (this.ComprobarLicencia(licencia, out int diasRestantes8))
                        {
                            gbActivarLicencia.Visible = true;
                            gbActivarLicencia.Text = "Digite la clave de licencia por 8 días";
                            this.lblDiasRestantesNuevaLicencia.Text = diasRestantes8 + " días restantes";
                        }
                        break;
                }
            }
        }

        private void BtnCambiarLicencia_Click(object sender, EventArgs e)
        {
            this.gbLicenciasLista.Enabled = true;
        }

        private void FrmGestionarLicencias_Load(object sender, EventArgs e)
        {
            this.ObtenerLicenciaActual();
        }

        private void ObtenerLicenciaActual()
        {
            string licencia = ConfigLicencias.Default.LicenciaActual;

            switch (licencia)
            {
                case "LicenciaCompleta":
                    this.txtLicenciaActual.Text = "Licencia completa";
                    this.lblDiasRestantes.Text = "Licencia completa";
                    this.rdLicenciaCompleta.Checked = true;
                    break;
                case "Licencia30Dias":
                    this.txtLicenciaActual.Text = "Licencia por 30 días";
                    int diasLicencia30 = ConfigLicencias.Default.ConteoLicencia30;
                    this.lblDiasRestantes.Text = (30 - diasLicencia30) + " días restantes.";
                    this.rd30dias.Checked = true;
                    break;
                case "Licencia20Dias":
                    this.txtLicenciaActual.Text = "Licencia por 20 días";
                    int diasLicencia20 = ConfigLicencias.Default.ConteoLicencia20;
                    this.lblDiasRestantes.Text = (20 - diasLicencia20) + " días restantes.";
                    this.rd20dias.Checked = true;
                    break;
                case "Licencia10Dias":
                    this.txtLicenciaActual.Text = "Licencia por 10 días";
                    int diasLicencia10 = ConfigLicencias.Default.ConteoLicencia10;
                    this.lblDiasRestantes.Text = (10 - diasLicencia10) + " días restantes.";
                    this.rd10dias.Checked = true;
                    break;
                case "Licencia8Dias":
                    this.txtLicenciaActual.Text = "Licencia por 8 días";
                    int diasLicencia8 = ConfigLicencias.Default.ConteoLicencia8;
                    this.lblDiasRestantes.Text = (8 - diasLicencia8) + " días restantes.";
                    this.rd8dias.Checked = true;
                    break;
            }
        }
    }
}
