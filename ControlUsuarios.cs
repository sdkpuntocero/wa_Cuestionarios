using System;
using System.Globalization;
using System.Linq;

namespace wa_Cuestionarios
{
    public class ControlUsuarios
    {
        public static bool AltaUsuario(int i_TipoUsuarioID, int i_PerfilUsuarioID, string Nombre, string Apaterno, string Amaterno, string striEmailPersonal, string striCodigoinvitacion)
        {
            Guid i_UsuarioID, EmpresaID = Guid.NewGuid(), CorporativoID = Guid.NewGuid();
            string i_CodigoUsuario = string.Empty, i_nombres = string.Empty, i_apaterno = string.Empty, i_amaterno = string.Empty, i_usuario = string.Empty, i_clave = string.Empty;

            TextInfo CINombre = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIApaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIAmaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompania = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompaniaNombre = new CultureInfo("es-MX", false).TextInfo;

            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            string strNombreUsuario = CINombre.ToTitleCase(Nombre.ToLower());
            string strApaternoUsuario = CIApaterno.ToTitleCase(Apaterno.ToLower());
            string strAmaternoUsuario = CIAmaterno.ToTitleCase(Amaterno.ToLower());

            try
            {
                i_nombres = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Nombre.Trim().ToLower()));
                string[] separados;

                separados = Nombre.Split(" ".ToCharArray());

                i_apaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Apaterno.Trim().ToLower()));
                i_amaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Amaterno.Trim().ToLower()));

                i_usuario = IzquierdaMedioDerecha.Izquierda(i_nombres, 1) + Apaterno.ToLower() + IzquierdaMedioDerecha.Izquierda(i_amaterno, 1);
            }
            catch
            {
                //"Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.";
            }

            try
            {
                i_clave = Encrypta.Encrypt("poc123");
                i_UsuarioID = Guid.NewGuid();
                i_CodigoUsuario = GeneraCodigoUsuario();

                var i_registro = new imDesarrolloEntities();

                var dn_usr = new tblUsuarios
                {
                    UsuarioID = i_UsuarioID,
                    TipoUsuarioID = i_TipoUsuarioID,
                    PerfilID = i_PerfilUsuarioID,
                    CodigoUsuario = i_CodigoUsuario,
                    Usuario = i_usuario,
                    Clave = i_clave,
                    Nombres = Nombre,
                    ApellidoPaterno = Apaterno,
                    ApellidoMaterno = Amaterno,
                    CorreoPersonal = striEmailPersonal,
                    CodigoPromo = striCodigoinvitacion,
                    EstatusRegistroID = 1,
                    FechaRegistro = DateTime.Now,
                };

                i_registro.tblUsuarios.Add(dn_usr);
                i_registro.SaveChanges();

                string strBody = EnviarCorreo.Cuerpo("Notificaciones Intelimundo", "Alta de Usuario", Nombre + " " + Apaterno + " " + Amaterno, i_usuario, "poc123", "~/HtmlTemplate.html", DateTime.Now, "informacion@intelimundo.com.mx");

                using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
                {
                    var iModelo = (from a in Modelo.tblCorreoNotificacion
                                   select a).FirstOrDefault();

                    string strFROM = iModelo.email;
                    string strUsuario = iModelo.Usuario;
                    string strClave = iModelo.Clave;
                    string strHost = iModelo.SMTP;
                    int strPort = int.Parse(iModelo.Puerto.ToString());

                    if (EnviarCorreo.Enviar(striEmailPersonal, strFROM, "Notificaciones Intelimundo", strBody, strUsuario, strClave, strHost, strPort, false, true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static string GeneraCodigoUsuario()
        {
            string CodigoUsuarios = string.Empty;

            using (imDesarrolloEntities mCodigoUsuarios = new imDesarrolloEntities())
            {
                var iCodigoUsuarios = (from c in mCodigoUsuarios.tblUsuarios
                                       select c).ToList();

                if (iCodigoUsuarios.Count == 0)
                {
                    CodigoUsuarios = "USR0001";
                }
                else
                {
                    CodigoUsuarios = "USR" + string.Format("{0:0000}", iCodigoUsuarios.Count + 1);
                }
            }

            return CodigoUsuarios;
        }

        public static string GeneraUsuario(string Nombre, string Apaterno, string Amaterno)
        {
            Guid i_UsuarioID, EmpresaID = Guid.NewGuid();
            string i_CodigoUsuario = string.Empty, i_nombres = string.Empty, i_apaterno = string.Empty, i_amaterno = string.Empty, i_usuario = string.Empty, i_clave = string.Empty;
            try
            {
                i_nombres = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Nombre.Trim().ToLower()));
                string[] separados;

                separados = Nombre.Split(" ".ToCharArray());

                i_apaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Apaterno.Trim().ToLower()));
                i_amaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Amaterno.Trim().ToLower()));

                i_usuario = IzquierdaMedioDerecha.Izquierda(i_nombres, 1) + Apaterno.ToLower() + IzquierdaMedioDerecha.Izquierda(i_amaterno, 1);
            }
            catch
            {
                //"Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.";
            }

            return i_usuario;
        }

        public static bool ActualizaUsuarioPerfil(Guid iUsuarioID, int intGeneroID, DateTime dtFechaNacimiento, string strCorreoPersonal, string strCelular, string strTelefonoContacto, string strCodigoPostal, string intColoniaID,string strClaveNueva)
        {
            Guid UbicacionID = Guid.NewGuid();

            string ClaveNueva = Encrypta.Encrypt(strClaveNueva);

            using (var Modelo = new imDesarrolloEntities())
            {
                var iModeloU = (from a in Modelo.tblUsuarios
                                join b in Modelo.tblUbicaciones on a.UbicacionID equals b.UbicacionID
                                where a.UsuarioID == iUsuarioID
                                select a).ToList();
                Guid ubicacionIDn = Guid.Parse(iModeloU[0].UbicacionID.ToString());
                if (iModeloU.Count == 0)
                {
                    var ModeloCP = new imDesarrolloEntities();

                    var iModeloCP = new tblUbicaciones
                    {
                        UbicacionID = UbicacionID,
                        TipoUbicacionID = 1,
                        CalleNumero = string.Empty,
                        CodigoPostal = strCodigoPostal,
                        ColoniaID = intColoniaID,
                        EstatusRegistroID = 1,
                        FechaRegistro = DateTime.Now,
                    };

                    ModeloCP.tblUbicaciones.Add(iModeloCP);
                    ModeloCP.SaveChanges();
                }
                else
                {
                   
                    var iModeloUU = (from c in Modelo.tblUbicaciones
                                     where c.UbicacionID == ubicacionIDn
                                     select c).FirstOrDefault();

                    iModeloUU.CalleNumero = string.Empty;
                    iModeloUU.CodigoPostal = strCodigoPostal;
                    iModeloUU.ColoniaID = intColoniaID;
                }


                var iModelo = (from c in Modelo.tblUsuarios
                               where c.UsuarioID == iUsuarioID
                               select c).FirstOrDefault();

                iModelo.GeneroID = intGeneroID;
                iModelo.FechaNacimiento = dtFechaNacimiento;
                iModelo.CorreoPersonal = strCorreoPersonal;
                iModelo.Celular = strCelular;
                iModelo.TelefonoContacto = strTelefonoContacto;
                iModelo.UbicacionID = ubicacionIDn;
                iModelo.Clave = ClaveNueva;

                Modelo.SaveChanges();
            }
            return true;
        }
    }
}