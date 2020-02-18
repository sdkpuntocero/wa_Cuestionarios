using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_Cuestionarios
{
    public partial class Panel : System.Web.UI.Page
    {
        public static Guid empf_ID = Guid.Empty, usrID = Guid.Empty;
        public static int FiltroMateriaID = 0, OrdenMateriaTemaID = 0, FiltroMateriaTemaID = 0, FiltroMateriaTemaPreguntaID = 0, FiltroPreguntaDiagnostico = 0, FiltroPreguntaTest = 0, FiltroPreguntaID = 0, FiltroPreguntaIDc = 0;
        public static DataSet ds;
        public static DataTable dtPreguntasDiagnostico, dtRespuestasDiagnostico, dtPreguntasCuestionario, dtRespuestasCuestionario;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
                        UsuarioFiltrado();
                        //DatosMateriasTemas();
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

        protected void lkbPerfil_Click(object sender, EventArgs e)
        {
            WrapperResumen.Visible = false;
            upWrapperResumen.Update();
            DatosPerfil();
            WrapperPerfil.Visible = true;
            upPerfilFiltro.Update();
            divTema.Visible = false;
            upTema.Update();
        }

        private void UsuarioFiltrado()
        {
            try
            {
                usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);

                using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
                {
                    var iModelo = (from a in Modelo.tblUsuarios
                                   where a.UsuarioID == usrID
                                   select new
                                   {
                                       a.UsuarioID,
                                       a.Nombres,
                                       a.ApellidoPaterno,
                                       a.ApellidoMaterno,
                                   }).FirstOrDefault();

                    lblNombreUsuario.Text = iModelo.Nombres;
                    lblNombreApellidos.Text = iModelo.ApellidoPaterno + " " + iModelo.ApellidoMaterno;
                    //lbl_EstatusUsuario.Text = "Conectad@";
                    //i_EstatusUsuario.Attributes["style"] = "color: green";
                }
            }
            catch
            {
                Response.Redirect("acceso.aspx");
            }
        }

        private void DatosPerfil()
        {
            sColonia.Items.Clear();
            sColonia.Items.Insert(0, new ListItem("Seleccionar", string.Empty));

            sGenero.Items.Clear();
            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iModelo = (from c in Modelo.catGenero
                               select c).ToList();

                sGenero.DataSource = iModelo;
                sGenero.DataTextField = "Genero";
                sGenero.DataValueField = "GeneroID";
                sGenero.DataBind();
                sGenero.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
            }

            try
            {
                usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);

                using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
                {
                    var iModelo = (from a in Modelo.tblUsuarios
                                   where a.UsuarioID == usrID
                                   select new
                                   {
                                       a.UsuarioID,
                                       a.Usuario,
                                       a.Nombres,
                                       a.ApellidoPaterno,
                                       a.ApellidoMaterno,
                                       a.GeneroID,
                                       a.FechaNacimiento,
                                       a.CorreoPersonal,
                                       a.CorreInstitucional,
                                       a.Celular,
                                       a.TelefonoContacto,
                                   }).FirstOrDefault();

                    iNombres.Value = iModelo.Nombres;
                    iApaterno.Value = iModelo.ApellidoPaterno;
                    iAmaterno.Value = iModelo.ApellidoMaterno;
                    iWhatsApp.Value = iModelo.Celular;
                    iTelefonoContacto.Value = iModelo.TelefonoContacto;
                    iCorrePersonal.Value = iModelo.CorreoPersonal;
                    iCorreInstitucional.Value = iModelo.Usuario + "@intelimundo.com.mx";

                    sGenero.Value = iModelo.GeneroID.ToString();

                    DateTime f_nac = DateTime.MinValue;
                    if (iModelo.FechaNacimiento == null)
                    {
                    }
                    else
                    {
                        f_nac = Convert.ToDateTime(iModelo.FechaNacimiento);
                        iFechaNacimiento.Value = f_nac.ToString("yyyy-MM-dd");
                    }

                    try
                    {
                        var iModeloU = (from a in Modelo.tblUsuarios
                                        join b in Modelo.tblUbicaciones on a.UbicacionID equals b.UbicacionID
                                        where a.UsuarioID == usrID
                                        select new
                                        {
                                            b.CalleNumero,
                                            b.CodigoPostal,
                                            b.ColoniaID
                                        }).FirstOrDefault();

                        using (DataSet ListCP = CodigoPostal.FiltroCP(iModeloU.CodigoPostal))
                        {
                            if (ListCP.Tables[0].Rows.Count == 0)
                            {
                                sColonia.Items.Clear();

                                sColonia.Items.Insert(0, new ListItem("Colonia", string.Empty));

                                iMunicipio.Value = string.Empty;
                                iEstado.Value = string.Empty;
                                sColonia.Attributes.Add("required", "required");
                            }
                            else
                            {
                                sColonia.DataSource = ListCP;
                                sColonia.DataTextField = "Colonia";
                                sColonia.DataValueField = "ColoniaID";
                                sColonia.DataBind();

                                iMunicipio.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                                iEstado.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                                sColonia.Attributes.Add("required", string.Empty);
                                sColonia.Value = iModeloU.ColoniaID;
                                iCP.Value = iModeloU.CodigoPostal;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        sColonia.Items.Clear();

                        sColonia.Items.Insert(0, new ListItem("Colonia", string.Empty));

                        iMunicipio.Value = string.Empty;
                        iEstado.Value = string.Empty;
                        sColonia.Attributes.Add("required", "required");
                    }
                }
            }
            catch (Exception e)
            {
                Mensaje("Err.");
            }
        }

        protected void btnGuardaPerfil_Click(object sender, EventArgs e)
        {
            int intGeneroID = 0;
            DateTime dtFechaNacimiento = DateTime.Now;
            string strCelular, strCorreoPersonal, strCorreInstitucional, strTelefonoContacto, strCodigoPostal, strColoniaID, strClaveAnterior, strClaveNueva, strClaveConfirma;

            strCelular = iWhatsApp.Value;
            strTelefonoContacto = iTelefonoContacto.Value;
            strCorreoPersonal = iCorrePersonal.Value;
            strCorreInstitucional = iCorreInstitucional.Value;
            strCodigoPostal = iCP.Value;
            strColoniaID = sColonia.Value;
            intGeneroID = int.Parse(sGenero.Value);
            dtFechaNacimiento = DateTime.Parse(iFechaNacimiento.Value);
            strClaveNueva = iClaveNueva.Value;
            strClaveConfirma = iClaveConfirma.Value;

            usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iModelo = (from a in Modelo.tblUsuarios
                               where a.UsuarioID == usrID
                               select new
                               {
                                   a.Clave,
                               }).FirstOrDefault();

                string strClave = Encrypta.Decrypt(iModelo.Clave);
                strClaveAnterior = iClaveAnterior.Value;

                if (strClaveAnterior == strClave)
                {
                    if (strClaveNueva == strClaveConfirma)
                    {
                        usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                        if (ControlUsuarios.ActualizaUsuarioPerfil(usrID, intGeneroID, dtFechaNacimiento, strCorreoPersonal, strCelular, strTelefonoContacto, strCodigoPostal, strColoniaID, strClaveNueva))
                        {
                            Mensaje("Datos actualizados con éxito, ya tienes personalizada tu contraseña, la cual deberás recordar para el siguiente inicio de sesión");
                        }
                        else
                        {
                            Mensaje("Favor de seleccionar una opción");
                        }
                    }
                    else
                    {
                        Mensaje("No coinciden las contraseñas");
                    }
                }
                else
                {
                    Mensaje("No coinciden con la contraseña actual");
                }
            }
        }

        protected void btnLimpiaPerfil_Click(object sender, EventArgs e)
        {
            iNombres.Value = string.Empty;
            iApaterno.Value = string.Empty;
            iAmaterno.Value = string.Empty;
            iWhatsApp.Value = string.Empty;
            iTelefonoContacto.Value = string.Empty;
            iCorrePersonal.Value = string.Empty;
            iCorreInstitucional.Value = string.Empty;
        }

        protected void lkbCP_Click(object sender, EventArgs e)
        {
            using (DataSet ListCP = CodigoPostal.FiltroCP(iCP.Value))
            {
                if (ListCP.Tables[0].Rows.Count == 0)
                {
                    sColonia.Items.Clear();

                    sColonia.Items.Insert(0, new ListItem("Colonia", string.Empty));

                    iMunicipio.Value = string.Empty;
                    iEstado.Value = string.Empty;
                    sColonia.Attributes.Add("required", "required");
                }
                else
                {
                    sColonia.DataSource = ListCP;
                    sColonia.DataTextField = "Colonia";
                    sColonia.DataValueField = "ColoniaID";
                    sColonia.DataBind();

                    iMunicipio.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                    iEstado.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                    sColonia.Attributes.Add("required", string.Empty);
                    sColonia.Items.Insert(0, new ListItem("Colonia", string.Empty));
                }
            }

            sColonia.Focus();
        }

        #region Materia0002

        protected void lkbMateria0002Tema0001_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 1;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema1/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0002_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 2;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema2/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0003_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 3;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema3/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0004_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 4;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema4/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0005_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 5;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema5/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0006_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 6;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema6/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0007_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 7;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema7/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0008_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 8;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema8/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0009_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 9;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema9/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        protected void lkbMateria0002Tema0010_Click(object sender, EventArgs e)
        {
            Session["FMatID"] = 2;
            Session["OMatID"] = 10;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            lblTema.Text = NombreTemasD(FiltroMateriaID, OrdenMateriaTemaID);
            divTema.Visible = true;

            if (EstatusTemasD(FiltroMateriaID, FiltroMateriaTemaID) == 0)
            {
                WrapperResumen.Visible = false;
                upWrapperResumen.Update();

                WrapperPerfil.Visible = false;
                upPerfilFiltro.Update();

                divEbook.Visible = false;
                divPreguntas.Visible = false;
                divResultado.Visible = false;
                divComentario.Visible = false;
                comment1.Value = string.Empty;

                lblPuntDiag.Text = "0";

                lblPuntuacion.Text = "0";

                btnDiagnostico.Visible = true;

                play_video.Visible = true;
                play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema10/VideoClase0001.mp4";

                upResultado.Update();
                upPreguntas.Update();
            }
            upTema.Update();
        }

        #endregion Materia0002

        #region Funciones

        private int EstatusTemasD(int MateriaID, int MateriaTemaID)
        {
            usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join b in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals b.MateriaTemaPreguntaID
                               join c in Modelo.catMateriaTema on b.MateriaTemaID equals c.MateriaTemaID
                               where c.MateriaID == MateriaID
                               where c.MateriaTemaID == MateriaTemaID
                               where a.UsuarioID == usrID
                               where a.TipoPreguntaID == 1
                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    return 0;
                }
                else
                {
                    var iModelof = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                                    join b in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals b.MateriaTemaPreguntaID
                                    join c in Modelo.catMateriaTema on b.MateriaTemaID equals c.MateriaTemaID
                                    where c.MateriaID == MateriaID
                                    where c.MateriaTemaID == MateriaTemaID
                                    where a.MateriaTemaPreguntaRespuestaID != null
                                    where a.UsuarioID == usrID
                                    where a.TipoPreguntaID == 1
                                    select a
                                   ).ToList();

                    if (iModelo.Count == 0)
                    {
                        return 1;
                    }
                    else if (iModelo.Count > 1 && iModelo.Count <= 4)
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
        }

        private string NombreTemasD(int MateriaID, int MateriaTemaID)
        {
            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);
                return fModelo.MateriaTema;
            }
        }

        private static DataTable GetTable(int MateriaIDFiltro, int MateriaTemaIDFiltro, int TipoPregunta, Guid usrIDf)
        {
            DataTable dtff = new DataTable();

            dtff.Columns.Add("NuevoID", typeof(int));
            dtff.Columns.Add("Pregunta", typeof(string));
            dtff.Columns.Add("PreguntaID", typeof(int));

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iMateria = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                                join b in Modelo.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                join c in Modelo.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                where a.TipoPreguntaID == TipoPregunta
                                where a.UsuarioID == usrID
                                where d.MateriaTemaID == MateriaTemaIDFiltro
                                where d.MateriaID == MateriaIDFiltro
                                select a).ToList();

                if (iMateria.Count == 0)
                {
                    var iModelo = (from c in Modelo.PreguntasSP(MateriaIDFiltro, MateriaTemaIDFiltro, TipoPregunta)
                                   select c).ToList();

                    foreach (var item in iModelo)
                    {
                        DataRow row = dtff.NewRow();

                        row["Pregunta"] = item.MateriaTemaPregunta;
                        row["NuevoID"] = item.NuevoID;
                        row["PreguntaID"] = item.MateriaTemaPreguntaID;
                        dtff.Rows.Add(row);

                        var dn_usr = new catMateriaTemaPreguntaRespuestaBitacora
                        {
                            TipoPreguntaID = 1,
                            UsuarioID = usrIDf,
                            MateriaTemaPreguntaID = item.MateriaTemaPreguntaID,
                            FechaRegistro = DateTime.Now
                        };

                        Modelo.catMateriaTemaPreguntaRespuestaBitacora.Add(dn_usr);

                        Modelo.SaveChanges();
                    }

                    return dtff;
                }
                else
                {
                    return dtff;
                }
            }
        }

        protected void btnDiagnostico_Click(object sender, EventArgs e)
        {
            btnDiagnostico.Visible = false;
            upGuardaDiagnostico.Update();

            usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
            dtPreguntasDiagnostico = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 1, usrID);

            DataRow[] foundRows;
            foundRows = dtPreguntasDiagnostico.Select("NuevoID = 1");

            FiltroPreguntaID = int.Parse(foundRows[0][2].ToString());
            divDiagnostico.Visible = true;
            lblTemaDiagnostico.Text = foundRows[0][1].ToString();

            rbRespDiag001.Checked = false;
            rbRespDiag002.Checked = false;
            rbRespDiag003.Checked = false;
            rbRespDiag004.Checked = false;

            using (imDesarrolloEntities mTema = new imDesarrolloEntities())
            {
                var iRespuesta = (from c in mTema.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaID)
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

            upDiagnostico.Update();
        }

        protected void btnGuardaDiagnostico_Click(object sender, EventArgs e)
        {
            if (rbRespDiag001.Checked == false & rbRespDiag002.Checked == false & rbRespDiag003.Checked == false & rbRespDiag004.Checked == false)
            {
                Mensaje("Favor de seleccionar una opción");
            }
            else
            {
                string filtro;

                using (imDesarrolloEntities mTema = new imDesarrolloEntities())
                {
                    var iMateria = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                    join b in mTema.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                    join c in mTema.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                    join d in mTema.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                    where a.MateriaTemaPreguntaRespuestaID != null
                                    where a.TipoPreguntaID == 1
                                    where a.UsuarioID == usrID
                                    where d.MateriaTemaID == FiltroMateriaTemaID
                                    where d.MateriaID == FiltroMateriaID
                                    select a).ToList();

                    if (iMateria.Count != 5)
                    {
                        if (rbRespDiag001.Checked == true || rbRespDiag002.Checked == true || rbRespDiag003.Checked == true || rbRespDiag004.Checked == true)
                        {
                            int intRespuesta = 0;
                            if (rbRespDiag001.Checked)
                            {
                                intRespuesta = int.Parse(lblRespDiagID001.Text);
                            }
                            else if (rbRespDiag002.Checked)
                            {
                                intRespuesta = int.Parse(lblRespDiagID002.Text);
                            }
                            else if (rbRespDiag003.Checked)
                            {
                                intRespuesta = int.Parse(lblRespDiagID003.Text);
                            }
                            else if (rbRespDiag004.Checked)
                            {
                                intRespuesta = int.Parse(lblRespDiagID004.Text);
                            }

                            usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);

                            var iRespuestaF = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora

                                               where a.MateriaTemaPreguntaID == FiltroPreguntaID

                                               select a).First();

                            iRespuestaF.MateriaTemaPreguntaRespuestaID = intRespuesta;

                            mTema.SaveChanges();
                        }

                        var iBitacoraR = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                          join b in mTema.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                          join c in mTema.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                          join d in mTema.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                          where a.MateriaTemaPreguntaRespuestaID != null
                                          where a.TipoPreguntaID == 1
                                          where a.UsuarioID == usrID
                                          where d.MateriaTemaID == FiltroMateriaTemaID
                                          where d.MateriaID == FiltroMateriaID
                                          select a).ToList();

                        FiltroPreguntaDiagnostico = iBitacoraR.Count;
                        FiltroPreguntaDiagnostico += 1;
                        try
                        {
                            filtro = "NuevoID = " + FiltroPreguntaDiagnostico.ToString();
                            DataRow[] foundRows;
                            foundRows = dtPreguntasDiagnostico.Select(filtro);
                            FiltroPreguntaID = int.Parse(foundRows[0][2].ToString());

                            lblTemaDiagnostico.Text = foundRows[0][1].ToString();
                            var iRespuesta = (from c in mTema.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaID)
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

                            rbRespDiag001.Checked = false;
                            rbRespDiag002.Checked = false;
                            rbRespDiag003.Checked = false;
                            rbRespDiag004.Checked = false;

                            upDiagnostico.Update();
                        }
                        catch (Exception)
                        {
                            usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                            var iMateriaff = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                              join b in mTema.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                              join c in mTema.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                              join d in mTema.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                              where a.TipoPreguntaID == 1
                                              where b.Respuesta == true
                                              where a.UsuarioID == usrID
                                              where d.MateriaTemaID == FiltroMateriaTemaID
                                              where d.MateriaID == FiltroMateriaID

                                              select a).ToList();

                            int intPunt = iMateriaff.Count;
                            int intCal = (intPunt * 2);

                            if (FiltroMateriaID == 1)
                            {
                                int MatTemaID = FiltroMateriaTemaID;
                            }
                            if (FiltroMateriaID == 2)
                            {
                                int MatTemaID = OrdenMateriaTemaID;

                                switch (MatTemaID)
                                {
                                    case 1:

                                        iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0001.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema1/index.html";
                                        break;

                                    case 2:

                                        iMateria0002Tema0002.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0002.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema2/index.html";
                                        break;

                                    case 3:

                                        iMateria0002Tema0003.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0003.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema3/index.html";
                                        break;

                                    case 4:

                                        iMateria0002Tema0004.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0004.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema4/index.html";
                                        break;

                                    case 5:

                                        iMateria0002Tema0005.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0005.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema5/index.html";
                                        break;

                                    case 6:

                                        iMateria0002Tema0006.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0006.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema6/index.html";
                                        break;

                                    case 7:

                                        iMateria0002Tema0007.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0007.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema7/index.html";
                                        break;

                                    case 8:

                                        iMateria0002Tema0008.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0008.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema8/index.html";
                                        break;

                                    case 9:

                                        iMateria0002Tema0009.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0009.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema9/index.html";
                                        break;

                                    case 10:

                                        iMateria0002Tema0010.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0010.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema10/index.html";
                                        break;
                                }
                            }

                            lblPuntDiag.Text = intCal.ToString();

                            divDiagnostico.Visible = false;

                            divEbook.Visible = true;
                            divComentario.Visible = true;

                            FiltroPreguntaDiagnostico = 0;

                            upDiagnostico.Update();
                            upComentario.Update();
                            upTema.Update();

                            Mensaje("Diagnostico Terminado");
                        }
                    }
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
            divResultado.Visible = false;
            using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
            {
                var iRespuesta = (from a in mMateria.catMateriaTemaSintesis
                                  where a.UsuarioID == usrID
                                  select a
                                   ).ToList();

                string strcomment1 = Request.Form["comment1"];
                var i_registro = new imDesarrolloEntities();
                usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                var dn_usr = new catMateriaTemaSintesis
                {
                    UsuarioID = usrID,
                    Sintesis = strcomment1,
                    MateriaTemaID = FiltroMateriaTemaID,
                    FechaRegistro = DateTime.Now
                };

                i_registro.catMateriaTemaSintesis.Add(dn_usr);

                i_registro.SaveChanges();

                CargaCuestionario();
            }
        }

        private void CargaCuestionario()
        {
            usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
            divResultado.Visible = false;
            using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
            {
                divComentario.Visible = false;

                divPreguntas.Visible = true;

                dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2, usrID);

                DataRow[] foundRows;
                foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                lblPregunta.Text = foundRows[0][1].ToString();

                radioR1.Checked = false;
                radioR2.Checked = false;
                radioR3.Checked = false;
                radioR4.Checked = false;

                var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                   select c).ToList();

                int f1 = 1;
                foreach (var iResp in iRespuestaf)
                {
                    string strlbl = "lblRespuesta00" + f1;

                    if (strlbl == "lblRespuesta001")
                    {
                        lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta002")
                    {
                        lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta003")
                    {
                        lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta004")
                    {
                        lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }
                    f1 += 1;
                }
                upPreguntas.Update();
            }
        }

        protected void btnGuardaRespuesta_Click(object sender, EventArgs e)
        {
            if (radioR1.Checked == false & radioR2.Checked == false & radioR3.Checked == false & radioR4.Checked == false)
            {
                Mensaje("Favor de seleccionar una opción");
            }
            else
            {
                using (imDesarrolloEntities mTema = new imDesarrolloEntities())
                {
                    var iBitacora = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                     where a.UsuarioID == usrID
                                     where a.TipoPreguntaID == 2
                                     select a
                                      ).ToList();
                    if (iBitacora.Count != dtPreguntasCuestionario.Rows.Count)
                    {
                        if (radioR1.Checked == true || radioR2.Checked == true || radioR3.Checked == true || radioR4.Checked == true)
                        {
                            int intRespuesta = 0;
                            if (radioR1.Checked)
                            {
                                intRespuesta = int.Parse(lblResp001.Text);
                            }
                            else if (radioR2.Checked)
                            {
                                intRespuesta = int.Parse(lblResp002.Text);
                            }
                            else if (radioR3.Checked)
                            {
                                intRespuesta = int.Parse(lblResp003.Text);
                            }
                            else if (radioR4.Checked)
                            {
                                intRespuesta = int.Parse(lblResp004.Text);
                            }

                            using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                            {
                                var iRespuestaf = (from a in mMateria.catMateriaTemaPreguntaRespuesta
                                                   where a.MateriaTemaPreguntaRespuestaID == intRespuesta
                                                   select a
                                                 ).FirstOrDefault();

                                bool vRespuesta = bool.Parse(iRespuestaf.Respuesta.ToString());

                                if (vRespuesta)
                                {
                                    var i_registro = new imDesarrolloEntities();
                                    usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                                    var dn_usr = new catMateriaTemaPreguntaRespuestaBitacora
                                    {
                                        TipoPreguntaID = 2,
                                        UsuarioID = usrID,
                                        MateriaTemaPreguntaRespuestaID = intRespuesta,
                                        MateriaTemaPreguntaID = FiltroPreguntaIDc,
                                        FechaRegistro = DateTime.Now
                                    };

                                    i_registro.catMateriaTemaPreguntaRespuestaBitacora.Add(dn_usr);

                                    i_registro.SaveChanges();
                                }
                                else
                                {
                                    usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                                    var i_registro = new imDesarrolloEntities();

                                    var dn_usr = new catMateriaTemaPreguntaRespuestaBitacora
                                    {
                                        TipoPreguntaID = 2,
                                        UsuarioID = usrID,
                                        MateriaTemaPreguntaRespuestaID = intRespuesta,
                                        MateriaTemaPreguntaID = FiltroPreguntaIDc,
                                        FechaRegistro = DateTime.Now
                                    };

                                    i_registro.catMateriaTemaPreguntaRespuestaBitacora.Add(dn_usr);

                                    i_registro.SaveChanges();
                                }
                            }
                        }

                        var iBitacoraR = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                          where a.UsuarioID == usrID
                                          where a.TipoPreguntaID == 2
                                          select a
                              ).ToList();
                        string filtro;
                        FiltroPreguntaTest = iBitacoraR.Count;

                        FiltroPreguntaTest += 1;

                        try
                        {
                            filtro = "NuevoID = " + FiltroPreguntaTest.ToString();

                            DataRow[] foundRows;
                            foundRows = dtPreguntasCuestionario.Select(filtro);
                            divDiagnostico.Visible = true;
                            lblPregunta.Text = foundRows[0][1].ToString();
                            FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                            var iRespuesta = (from c in mTema.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                              select c).ToList();

                            int f1 = 1;
                            foreach (var iResp in iRespuesta)
                            {
                                string strlbl = "lblRespuesta00" + f1;

                                if (strlbl == "lblRespuesta001")
                                {
                                    lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta002")
                                {
                                    lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta003")
                                {
                                    lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta004")
                                {
                                    lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }
                                f1 += 1;

                                if (iRespuesta.Count == 3)
                                {
                                    radioR4.Visible = false;
                                }
                            }

                            radioR1.Checked = false;
                            radioR2.Checked = false;
                            radioR3.Checked = false;
                            radioR4.Checked = false;

                            upPreguntas.Update();
                        }
                        catch (Exception)
                        {
                            usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                            using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                            {
                                var iMateria = (from a in mMateria.catMateriaTemaPreguntaRespuestaBitacora
                                                join b in mMateria.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                                join c in mMateria.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                                join d in mMateria.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                                where a.TipoPreguntaID == 2
                                                where b.Respuesta == true
                                                where a.UsuarioID == usrID
                                                where d.MateriaTemaID == FiltroMateriaTemaID
                                                where d.MateriaID == FiltroMateriaID
                                                select a).ToList();

                                int intPunt = iMateria.Count;
                                int intCal = (intPunt * 10) / dtPreguntasCuestionario.Rows.Count;

                                if (FiltroMateriaID == 1)
                                {
                                    int MatTemaID = FiltroMateriaTemaID;
                                }
                                if (FiltroMateriaID == 2)
                                {
                                    int MatTemaID = OrdenMateriaTemaID;

                                    switch (MatTemaID)
                                    {
                                        case 1:

                                            iMateria0002Tema0001.Attributes["style"] = "color: green";

                                            upMateria0002Tema0001.Update();
                                            break;

                                        case 2:

                                            iMateria0002Tema0002.Attributes["style"] = "color: green";

                                            upMateria0002Tema0002.Update();
                                            break;

                                        case 3:

                                            iMateria0002Tema0003.Attributes["style"] = "color: green";

                                            upMateria0002Tema0003.Update();
                                            break;

                                        case 4:

                                            iMateria0002Tema0004.Attributes["style"] = "color: green";

                                            upMateria0002Tema0004.Update();
                                            break;

                                        case 5:
                                            iMateria0002Tema0005.Attributes["style"] = "color: green";

                                            upMateria0002Tema0005.Update();
                                            break;

                                        case 6:

                                            iMateria0002Tema0006.Attributes["style"] = "color: green";

                                            upMateria0002Tema0006.Update();
                                            break;

                                        case 7:

                                            iMateria0002Tema0007.Attributes["style"] = "color: green";

                                            upMateria0002Tema0007.Update();
                                            break;

                                        case 8:

                                            iMateria0002Tema0008.Attributes["style"] = "color: green";

                                            upMateria0002Tema0008.Update();

                                            break;

                                        case 9:

                                            iMateria0002Tema0009.Attributes["style"] = "color: green";

                                            upMateria0002Tema0009.Update();

                                            break;

                                        case 10:

                                            iMateria0002Tema0010.Attributes["style"] = "color: green";
                                            iM002.Attributes["style"] = "color: green";
                                            upMateria0002Tema0010.Update();

                                            break;
                                    }
                                }

                                lblPuntuacion.Text = intCal.ToString();

                                divDiagnostico.Visible = false;

                                divPreguntas.Visible = false;
                                usrID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                                var iMateriaf = (from a in mMateria.catMateriaTemaPreguntaRespuestaBitacora
                                                 join b in mMateria.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                                 join c in mMateria.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                                 join d in mMateria.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                                 where a.TipoPreguntaID == 2
                                                 where a.UsuarioID == usrID
                                                 where d.MateriaTemaID == FiltroMateriaTemaID
                                                 where d.MateriaID == FiltroMateriaID

                                                 select new
                                                 {
                                                     c.MateriaTemaPregunta,
                                                     b.MateriaTemaPreguntaRespuesta,
                                                     b.Respuesta,
                                                     b.Justificacion
                                                 }
                                               ).ToList();

                                if (iMateriaf.Count != 0)
                                {
                                    gvResultados.DataSource = iMateriaf;
                                    gvResultados.DataBind();
                                    gvResultados.Visible = true;
                                }

                                divResultado.Visible = true;
                                upResultado.Update();
                                upPreguntas.Update();

                                upTema.Update();
                            }

                            Mensaje("Cuestionario Terminado");
                        }
                    }
                }
            }
        }

        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "Intelimundo";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void lkbSalir_Click(object sender, EventArgs e)
        {
            Response.Cookies["usr_cookie"].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("Default.aspx");
        }

        #endregion Funciones
    }
}