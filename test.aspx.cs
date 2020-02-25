using System;
using System.Data;
using System.Linq;
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
            Guid usrID;
            int int_FiltroMateriaID;
            int int_FiltroMateriaTemaID;
            int int_CantidadPreguntas;
            int int_TipoPreguntas;

            // Save to session state in a Web Forms page class.
            Session["Sess_usrID"] = Guid.Parse("8B80AAE4-394B-4F9D-B44A-5E5B34638DDA");
            Session["Sess_FiltroMateriaID"] = 2;
            Session["Sess_FiltroMateriaTemaID"] = 13;
            Session["Sess_TipoPreguntas"] = 1;

            usrID = (Guid)(Session["Sess_usrID"]);
            // Read from session state in a Web Forms page class.
            int_FiltroMateriaID = (int)(Session["Sess_FiltroMateriaID"]);
            int_FiltroMateriaTemaID = (int)(Session["Sess_FiltroMateriaTemaID"]);
            int_TipoPreguntas = (int)(Session["Sess_TipoPreguntas"]);

            if (int_TipoPreguntas == 1)
            {
                using (var Modelo = new imDesarrolloEntities())
                {
                    var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                                   join b in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals b.MateriaTemaPreguntaID
                                   join c in Modelo.catMateriaTema on b.MateriaTemaID equals c.MateriaTemaID
                                   where c.MateriaID == int_FiltroMateriaID
                                   where c.MateriaTemaID == int_FiltroMateriaTemaID
                                   where a.MateriaTemaPreguntaRespuestaID == null
                                   where a.UsuarioID == usrID
                                   where a.TipoPreguntaID == int_TipoPreguntas
                                   select a
                                 ).ToList();

                    Session["Sess_CantidadPreguntas"] = iModelo.Count();
                    int_CantidadPreguntas = (int)(Session["Sess_CantidadPreguntas"]);

                    if (int_CantidadPreguntas == 0)
                    {
                        DataTable dtff = new DataTable();

                        dtff.Columns.Add("NuevoID", typeof(int));
                        dtff.Columns.Add("Pregunta", typeof(string));
                        dtff.Columns.Add("PreguntaID", typeof(int));

                        var iModeloP = (from c in Modelo.PreguntasSP(int_FiltroMateriaID, int_FiltroMateriaTemaID, int_TipoPreguntas)
                                        select c).ToList();

                        foreach (var item in iModeloP)
                        {
                            DataRow row = dtff.NewRow();

                            row["Pregunta"] = item.MateriaTemaPregunta;
                            row["NuevoID"] = item.NuevoID;
                            row["PreguntaID"] = item.MateriaTemaPreguntaID;
                            dtff.Rows.Add(row);

                            var dn_usr = new catMateriaTemaPreguntaRespuestaBitacora
                            {
                                TipoPreguntaID = 1,
                                UsuarioID = usrID,
                                MateriaTemaPreguntaID = item.MateriaTemaPreguntaID,
                                FechaRegistro = DateTime.Now
                            };

                            Modelo.catMateriaTemaPreguntaRespuestaBitacora.Add(dn_usr);

                            Modelo.SaveChanges();
                        }
                    }
                    else
                    {
                            
                    }
                }
            }
            else
            {
                using (var Modelo = new imDesarrolloEntities())
                {
                    var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                                   join b in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals b.MateriaTemaPreguntaID
                                   join c in Modelo.catMateriaTema on b.MateriaTemaID equals c.MateriaTemaID
                                   where c.MateriaID == int_FiltroMateriaID
                                   where c.MateriaTemaID == int_FiltroMateriaTemaID
                                   where a.UsuarioID == usrID
                                   where a.TipoPreguntaID == int_TipoPreguntas
                                   select a
                                 ).ToList();
                }

                int_CantidadPreguntas = (int)(Session["Sess_CantidadPreguntas"]);
            }
        }
    }
}