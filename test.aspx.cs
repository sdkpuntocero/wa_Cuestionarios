using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace wa_Cuestionarios
{
    public partial class test : System.Web.UI.Page
    {
        public static Guid empf_ID = Guid.Empty, usrID = Guid.Empty;
        public static int FiltroMateriaID = 0, OrdenMateriaTemaID = 0, FiltroMateriaTemaID = 0, FiltroMateriaTemaPreguntaID = 0, FiltroPreguntaDiagnostico = 0, FiltroPreguntaTest = 0, FiltroPreguntaID = 0, FiltroPreguntaIDc = 0;

        protected void btnGuardaDiagnostico_Click(object sender, EventArgs e)
        {

        }

        public static DataSet ds;
        public static DataTable dtPreguntasDiagnostico, dtRespuestasDiagnostico, dtPreguntasCuestionario, dtRespuestasCuestionario;
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
                lblTipoPregunta.Text = "Diagnostico";
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

                        int_CantidadPreguntas = 5;

                        var iModeloP = (from c in Modelo.PreguntasSP(int_FiltroMateriaID, int_FiltroMateriaTemaID, int_CantidadPreguntas)
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

                        DataRow[] foundRows;
                        foundRows = dtff.Select("NuevoID = 1");

                        FiltroPreguntaID = int.Parse(foundRows[0][2].ToString());
                    
                        lblPreguntaF.Text = foundRows[0][1].ToString();

                        rbRespDiag001.Checked = false;
                        rbRespDiag002.Checked = false;
                        rbRespDiag003.Checked = false;
                        rbRespDiag004.Checked = false;

                        using (imDesarrolloEntities mTema = new imDesarrolloEntities())
                        {
                            var iRespuesta = (from c in mTema.RespuestasSP(int_FiltroMateriaID, int_FiltroMateriaTemaID, FiltroPreguntaID)
                                              select c).ToList();

                            int f1 = 1;
                            foreach (var iResp in iRespuesta)
                            {
                                string strlbl = "lblRespuesta00" + f1;

                                if (strlbl == "lblRespuesta001")
                                {
                                    lblRespDiag001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblRespDiagID001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta002")
                                {
                                    lblRespDiag002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblRespDiagID002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta003")
                                {
                                    lblRespDiag003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblRespDiagID003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta004")
                                {
                                    lblRespDiag004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblRespDiagID004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }
                                f1 += 1;
                            }
                        }

                        //upDiagnostico.Update();
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