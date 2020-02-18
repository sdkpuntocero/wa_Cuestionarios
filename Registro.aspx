<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="wa_Cuestionarios.Registro" %>

<!DOCTYPE html>

<html lang="es-mx">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Porque Intelimundo es el complemento perfecto para mejorar la vida académica del alumno, desarrollando y favoreciendo habilidades, aptitudes y actitudes ...">
    <title>\ Aula - UNAM</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />


    <script src="Scripts/jquery-3.4.1.min.js"></script>

    <script src="Scripts/bootstrap.min.js"></script>
    <link rel="shortcut icon" href="images/favicon.png" />
</head>

<body>
    <form runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-scroller">
            <div class="container-fluid page-body-wrapper full-page-wrapper">
                <div class="content-wrapper d-flex align-items-center auth px-0">
                    <div class="row w-100 mx-0">
                        <div class="col-lg-6 mx-auto">
                            <div class="auth-form-light text-left py-5 px-4 px-sm-5">
                                <div class="brand-logo">
                                    <img src="Imagenes/im02.png" alt="logo">
                                </div>
                                <h4>¿Nuevo aquí?</h4>
                                <h6 class="font-weight-light">Registrarse es fácil. Solo toma unos pocos pasos</h6>
                                <div class="row">
                                    <div class="col-lg-4 mx-auto">
                                        <div class="form-group">
                                            <input type="text" class="form-control form-control-lg" runat="server" id="iNombres" placeholder="Nombre(s)" required="required" tabindex="1" onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                    <div class="col-lg-4 mx-auto">
                                        <div class="form-group">
                                            <input type="text" class="form-control form-control-lg" runat="server" id="iApaterno" placeholder="Apellido Paterno" required="required" tabindex="2" onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                    <div class="col-lg-4 mx-auto">

                                        <div class="form-group">
                                            <input type="text" class="form-control form-control-lg" runat="server" id="iAmaterno" placeholder="Apellido Paterno" required="required" tabindex="3" onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-8 mx-auto">
                                        <div class="form-group">
                                            <input type="email" class="form-control form-control-lg" runat="server" id="iCorrePersonal" placeholder="Correo Electronico Personal" required="required" tabindex="4">
                                        </div>
                                    </div>
                                    <div class="col-lg-4 mx-auto">

                                        <div class="form-group">
                                            <input type="text" class="form-control form-control-lg" runat="server" id="iCodigoinvitacion" placeholder="Codigo de Invitacion" required="required" tabindex="5" onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                </div>

                                <div class="mt-3">
                                    <asp:Button CssClass="btn btn-block btn-info btn-lg font-weight-medium auth-form-btn" ID="btnRegistro" runat="server" Text="Registrar" TabIndex="6" OnClick="btnRegistro_Click" />
                                </div>
                                <div class="text-center mt-4 font-weight-light">
                                    ¿Ya tienes una cuenta? <a href="Default.aspx" class="text-primary">Inicia sesión</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- content-wrapper ends -->
            </div>
            <!-- page-body-wrapper ends -->
        </div>
         <div class="modal" id="myModal">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label ID="lblModalTitle" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                <button type="button" class="close" data-dismiss="modal"><span>×</span> </button>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" CssClass="login100-form-title" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        
    </form>

</body>
</html>