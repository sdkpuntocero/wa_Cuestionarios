using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_Cuestionarios
{
    public partial class TerminosCondiciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
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
            if (RadioButton1.Checked)
            {
                Session["UsuarioAcepta"] = 1;
                Response.Redirect("Registro.aspx");
            }
            else if(RadioButton2.Checked)
            {
                Session["UsuarioNoAcepta"] = 2;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton2.Checked = false;
            upR1.Update();
            upR2.Update();
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Checked = false;
            upR1.Update();
            upR2.Update();
        }
    }
}