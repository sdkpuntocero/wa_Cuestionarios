using System;
using System.Web.UI;

namespace wa_Cuestionarios
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            string striNombre = Request.Form["iNombres"];
            string striApaterno = Request.Form["iApaterno"];
            string striAmaterno = Request.Form["iAmaterno"];
            string striEmailPersonal = Request.Form["iCorrePersonal"];
            string striCodigoinvitacion = Request.Form["iCodigoinvitacion"];


            if (ControlUsuarios.AltaUsuario(5, 3, striNombre, striApaterno, striAmaterno, striEmailPersonal, striCodigoinvitacion))
            {

                iNombres.Value = String.Empty;
                iApaterno.Value = String.Empty;
                iAmaterno.Value = String.Empty;
                iCorrePersonal.Value = String.Empty;
                iCodigoinvitacion.Value = String.Empty;
                Mensaje("Datos guardados con éxito, revisa el buzón de tu correo, si no aparece el mensaje de Notificaciones Itelimundo, busca en tu bandeja de SPAM y selecciónalo como correo seguro ya que en la medida del avance que realices seguirán llegando correos de esta cuenta");
            }
            else
            {
                Mensaje("Err.");
            }
        }

        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "Intelimundo";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}