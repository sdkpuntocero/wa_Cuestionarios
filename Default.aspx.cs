using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_Cuestionarios
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcceso_Click(object sender, EventArgs e)
        {
            string strUsuario, strClave, strValClave;

            Guid GuidUsario;

            strUsuario = loginid.Value;
            strClave = Encrypta.Encrypt(loginpsw.Value);

            try

            {
                using (var Modelo = new imDesarrolloEntities())
                {
                    var iModelo = (from a in Modelo.tblUsuarios
                                 where a.Usuario == strUsuario
                                 select new
                                 {
                                     a.UsuarioID,
                                     a.Clave,
                                 }).ToList();

                    GuidUsario = iModelo[0].UsuarioID;
                    strValClave = iModelo[0].Clave;
                    string dos = "fGVifCvpWWGgKTZ46axSOQ==";

                    string pass_de = Encrypta.Decrypt(dos);
                    if (iModelo.Count == 0)
                    {
                        Mensaje("Usuario no existe, favor de re-intentar");
                    }
                    else
                    {
                        if (strClave == strValClave)
                        {
                            HttpCookie usr_cookie = new HttpCookie("usr_cookie", GuidUsario.ToString());
                            usr_cookie.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(usr_cookie);
                            //Session["UsuarioFirmadoID"] = GuidUsario;
                            Response.Redirect("Panel.aspx");
                        }
                        else
                        {
                            Mensaje("Contraseña incorrecta, favor de re-intentar");
                        }
                    }
                }
            }
            catch
            {
                Mensaje("Datos incorrectos, favor de re-intentar");
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