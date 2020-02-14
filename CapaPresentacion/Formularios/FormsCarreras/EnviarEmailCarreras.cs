using System;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using CapaEntidades;

namespace CapaPresentacion.Formularios.FormsCarreras
{
    public class EnviarEmailCarreras
    {
        public static string concatTemplateEmailWithHeaderBody(string header, string body)
        {
            try
            {
                body = header + body;

                //HTMLTemplate = HTMLTemplate.Replace(@"#_HEADER_MAIL", header);
                //HTMLTemplate = HTMLTemplate.Replace(@"#_BODY_MAIL", body);
            }
            catch (Exception)
            {
                return body;
            }
            return body;
        }

        public static string SendEmail(string informacion, ECorreos eCorreo)
        {
            string rpta = "OK";
            try
            {
                //Este codigo pone la plantilla en el string HTMLTemplate

                string HTMLTemplateMail = ""; //utilitiesService.templateEmail();

                //if (HTMLTemplateMail == null)
                //{
                //    throw new Exception("No se envió el correo, no se encontró la plantilla");
                //}

                StringBuilder headerEmail = new StringBuilder();
                StringBuilder contentEmail = new StringBuilder();

                headerEmail.Append("<h2>");
                headerEmail.Append("Reporte de turno - FECHA: " + DateTime.Now.ToLongDateString() + " HORA: " + DateTime.Now.ToLongTimeString());
                headerEmail.Append("</h2>");

                headerEmail.Append("<h3>");
                headerEmail.Append("Información: ");
                headerEmail.Append("</h3>");

                headerEmail.Append("<p>");
                headerEmail.Append(informacion);
                headerEmail.Append("</p>");

                headerEmail.Append("<br />");
                headerEmail.Append("<br />");

                HTMLTemplateMail = concatTemplateEmailWithHeaderBody(headerEmail.ToString(), contentEmail.ToString());

                MailMessage mail = new MailMessage(eCorreo.Correo_remitente, eCorreo.Correo_destinatario);
                mail.From = new MailAddress(eCorreo.Correo_remitente, "SISTaxi", System.Text.Encoding.UTF8);
                mail.IsBodyHtml = true;
                string fecha = DateTime.Now.ToString("G");
                mail.Subject = "Reporte de turno SISTaxi" + " - " + fecha;
                mail.Body = HTMLTemplateMail;
                if (!eCorreo.Correo_copia.Equals(""))
                {
                    //Línea para enviar una copia del correo
                    mail.Bcc.Add(eCorreo.Correo_copia);
                }              

                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["eMailSMTP"].ToString());
                client.Credentials = new System.Net.NetworkCredential(eCorreo.Correo_remitente, eCorreo.Clave_correo_remitente);
                client.Port = int.Parse(ConfigurationManager.AppSettings["portEmail"].ToString());
                client.EnableSsl = true;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }
}
