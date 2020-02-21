<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="wa_Cuestionarios.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/fontawesome-free-5.12.1-web/css/all.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
        </div>

    </form>
</body>
</html>
