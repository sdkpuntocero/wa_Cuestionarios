using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_Cuestionarios
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int int_FiltroMateriaID;
            int int_FiltroMateriaTemaID;
            int int_CantidadPreguntas;
            int int_TipoPreguntas;



            // Save to session state in a Web Forms page class.
            Session["Sess_FiltroMateriaID"] = 2;
            Session["Sess_FiltroMateriaTemaID"] = 13;
            Session["Sess_TipoPreguntas"] = 1;
            Session["Sess_CantidadPreguntas"] = 5;


            // Read from session state in a Web Forms page class.
            int_FiltroMateriaID = (int)(Session["Sess_FiltroMateriaID"]);
            int_FiltroMateriaTemaID = (int)(Session["Sess_FiltroMateriaTemaID"]);
            int_TipoPreguntas = (int)(Session["Sess_TipoPreguntas"]);
        

            if (int_TipoPreguntas == 1)
            {
                int_CantidadPreguntas = (int)(Session["Sess_CantidadPreguntas"]);
            }
            else
            {

                using (imDesarrolloEntities db = new imDesarrolloEntities())
                {
                    var art = db.catMateriaTemaPreguntaRespuestaBitacora
                                .Join(db.Famiglie,
                                      articolo => articolo.CodFamiglia,
                                      famiglia => famiglia.CodFamiglia,
                                      (articolo, famiglia) => new { Articoli = articolo, Famiglie = famiglia })
                                .Where((x) => x.Articoli.CodArt == "ART005")
                                .FirstOrDefault();

                    MessageBox.Show(art.Articoli.DesArt + " - " + art.Famiglie.DesFamiglia);
                }

                int_CantidadPreguntas = (int)(Session["Sess_CantidadPreguntas"]);
            }


        }
    }
}