﻿using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Net.Mail;

using System.Configuration;

using System.IO;
using System.Globalization;

namespace wa_Cuestionarios
{
    public class EnviarCorreo
    {
        public static bool AltaNotificacion(string iEmail, string iUsuario, string iClave, string iAsunto, string iSMTP, int iPuerto)
        {
            Guid iNotificacionID = Guid.NewGuid();
            var i_registro = new imDesarrolloEntities();
            TextInfo t_asunto = new CultureInfo("es-MX", false).TextInfo;
            string strAsunto = t_asunto.ToTitleCase(iAsunto);
            var d_emp = new tblCorreoNotificacion
            {
                CorreoNotificacionID = iNotificacionID,
                email = iEmail,
                Usuario = iUsuario,
                Clave = iClave,
                Asunto = strAsunto,
                SMTP = iSMTP,
                Puerto = iPuerto,
                EstatusRegistroID = 1,
                FechaRegistro = DateTime.Now
            };

            i_registro.tblCorreoNotificacion.Add(d_emp);

            i_registro.SaveChanges();

            return true;
        }
        public static string Cuerpo(string Titulo, string Detalle, string NombreUsuario, string Usuario, string Clave, string RutaTemplate, DateTime FechaRegistro, string Contacto)

        {
            string body = string.Empty;

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(RutaTemplate)))

            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{titulo_envio}", Titulo);

            body = body.Replace("{detalle_envio}", Detalle);

            body = body.Replace("{nombrecompleto_reg}", NombreUsuario);

            body = body.Replace("{usuario_reg}", Usuario);

            body = body.Replace("{clave_reg}", Clave);

            body = body.Replace("{registro}", FechaRegistro.ToShortDateString());

            body = body.Replace("{correo_contacto}", Contacto);

            return body;
        }

        public static bool Enviar(string To, string From, string Subject, string Body, string Usuario, string Clave, string Host, int Port, bool EnableSsl, bool UseDefaultCredentials)
        {
            using (MailMessage mailMessage = new MailMessage())

            {
                mailMessage.From = new MailAddress(From);

                mailMessage.Subject = Subject;

                mailMessage.Body = Body;

                mailMessage.IsBodyHtml = true;

                mailMessage.To.Add(new MailAddress(To));

                SmtpClient smtp = new SmtpClient();

                smtp.Host = Host;

                smtp.EnableSsl = EnableSsl;

                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();

                NetworkCred.UserName = Usuario;

                NetworkCred.Password = Clave;
                smtp.UseDefaultCredentials = UseDefaultCredentials;

                smtp.Credentials = NetworkCred;

                smtp.Port = Port;

                try
                {
                    smtp.Send(mailMessage);


                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}