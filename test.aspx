<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="wa_Cuestionarios.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <link href="Content/fontawesome-free-5.12.1-web/css/all.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary form-control" OnClick="LinkButton1_Click">
                                <i class="fas fa-save"></i> 
                    </asp:LinkButton>
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                </div>
            </div>
            <div class="row">
                <asp:Label CssClass="alert alert-light" ID="lblTipoPregunta" runat="server"></asp:Label>
                <br />
                <asp:Label CssClass="alert alert-light" ID="lblPreguntaF" runat="server"></asp:Label>
            </div>
            <div class="row">
                <br />
                <div class="col-md-6" runat="server">
                    <asp:UpdatePanel ID="upRespDiag001" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:RadioButton runat="server" ID="rbRespDiag001" GroupName="radioA" AutoPostBack="True" />
                            <label for="rbRespDiag001">
                                <asp:Label CssClass="alert alert-light" ID="lblRespDiag001" runat="server" Text="">
                                </asp:Label><asp:Label ID="lblRespDiagID001" runat="server" Text="" Visible="false"></asp:Label></label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <asp:UpdatePanel ID="upRespDiag002" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:RadioButton runat="server" ID="rbRespDiag002" GroupName="radioA" AutoPostBack="True" />
                            <label for="rbRespDiag002">
                                <asp:Label CssClass="alert alert-light" ID="lblRespDiag002" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblRespDiagID002" runat="server" Text="" Visible="false"></asp:Label></label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </div>
                <div class="col-md-6" runat="server">
                    <asp:UpdatePanel ID="upRespDiag003" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:RadioButton runat="server" ID="rbRespDiag003" GroupName="radioA" AutoPostBack="True" />
                            <label for="rbRespDiag003">
                                <asp:Label CssClass="alert alert-light" ID="lblRespDiag003" runat="server" Text="">
                                </asp:Label><asp:Label ID="lblRespDiagID003" runat="server" Text="" Visible="false"></asp:Label></label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <asp:UpdatePanel ID="upRespDiag004" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:RadioButton runat="server" ID="rbRespDiag004" GroupName="radioA" AutoPostBack="True" />
                            <label for="rbRespDiag004">
                                <asp:Label CssClass="alert alert-light" ID="lblRespDiag004" runat="server" Text="">
                                </asp:Label><asp:Label ID="lblRespDiagID004" runat="server" Text="" Visible="false"></asp:Label></label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </div>
                <asp:UpdatePanel ID="upGuardaDiagnostico" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnGuardaDiagnostico" runat="server" Text="Guardar" TabIndex="18" OnClick="btnGuardaDiagnostico_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="upCarga" runat="server" DynamicLayout="true">
                    <ProgressTemplate>
                        <div id="overlay">
                            <div class="center">
                                <img alt="" src="Imagenes/ajax-loader.gif" />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

    </form>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</body>
</html>
