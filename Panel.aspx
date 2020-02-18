<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="wa_Cuestionarios.Panel" %>

<!DOCTYPE html>

<html lang="es-mx">

<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Content/fontawesome-free-5.12.1-web/css/all.min.css" rel="stylesheet" />
    <title>/ Aula intelimundo</title>
    <!-- base:css -->
    <link rel="stylesheet" href="Estilos/Admin/vendors/mdi/css/materialdesignicons.min.css">
    <link rel="stylesheet" href="Estilos/Admin/vendors/feather/feather.css">
    <link rel="stylesheet" href="Estilos/Admin/vendors/base/vendor.bundle.base.css">
    <!-- endinject -->
    <!-- plugin css for this page -->
    <link rel="stylesheet" href="Estilos/Admin/vendors/flag-icon-css/css/flag-icon.min.css" />
    <%--    <link rel="stylesheet" href="Estilos/Admin/vendors/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="Estilos/Admin/vendors/jquery-bar-rating/fontawesome-stars-o.css">
    <link rel="stylesheet" href="Estilos/Admin/vendors/jquery-bar-rating/fontawesome-stars.css">--%>
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="Estilos/Admin/css/style.css">

    <!-- endinject -->
    <link rel="shortcut icon" href="Imagenes/favicon.png" />
</head>
<body>
    <form id="FormContenido" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="container-scroller">
            <!-- partial:partials/_navbar.html -->
            <nav class="navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
                <div class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">
                    <a class="navbar-brand brand-logo" href="Default.aspx">
                        <img src="Imagenes/im02.png" alt="logo" /></a>
                    <a class="navbar-brand brand-logo-mini" href="Default.aspx">
                        <img src="Imagenes/favicon.png" alt="logo" /></a>
                </div>
                <div class="navbar-menu-wrapper d-flex align-items-center justify-content-end">
                    <button class="navbar-toggler navbar-toggler align-self-center" type="button" data-toggle="minimize">
                        <span class="icon-menu"></span>
                    </button>
                    <ul class="navbar-nav mr-lg-2">
                        <li class="nav-item nav-search d-none d-lg-block">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                </div>
                            </div>
                        </li>
                    </ul>
                    <ul class="navbar-nav navbar-nav-right">

                        <li class="nav-item dropdown d-flex mr-4 ">
                            <a class="nav-link count-indicator dropdown-toggle d-flex align-items-center justify-content-center" id="notificationDropdown" href="#" data-toggle="dropdown">
                                <i class="icon-cog"></i>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right navbar-dropdown preview-list" aria-labelledby="notificationDropdown">
                                <p class="mb-0 font-weight-normal float-left dropdown-header">Configuraciones</p>
                                <asp:UpdatePanel ID="upPerfil" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:LinkButton CssClass="dropdown-item preview-item" ID="lkbPerfil" runat="server" OnClick="lkbPerfil_Click">
                                    <i class="icon-head"></i>Perfil
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:LinkButton CssClass="dropdown-item preview-item" ID="lkbSalir" runat="server" OnClick="lkbSalir_Click">
                        <i class="fa fa-power-off"></i>Salir
                                </asp:LinkButton>

                            </div>
                        </li>
                    </ul>
                    <button class="navbar-toggler navbar-toggler-right d-lg-none align-self-center" type="button" data-toggle="offcanvas">
                        <span class="icon-menu"></span>
                    </button>
                </div>
            </nav>
            <!-- partial -->
            <div class="container-fluid page-body-wrapper">
                <!-- partial:partials/_sidebar.html -->
                <nav class="sidebar sidebar-offcanvas" id="sidebar">
                    <div class="user-profile">
                        <div class="user-image">
                            <img src="https://raw.githubusercontent.com/azouaoui-med/pro-sidebar-template/gh-pages/src/img/user.jpg">
                        </div>
                        <div class="user-name">
                            <span class="user-name">
                                <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
                                <strong>

                                    <asp:Label ID="lblNombreApellidos" runat="server" Text=""></asp:Label>
                                </strong>
                            </span>
                        </div>
                        <div class="user-designation">
                            Alumno
                        </div>
                    </div>
                    <ul class="nav">
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="icon-box menu-icon"></i>
                                <span class="menu-title">Resumen</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-microscope menu-icon" runat="server" id="iM001"></i>
                                <span class="menu-title">Biología</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="collapse" href="#ui-basic" aria-expanded="false" aria-controls="ui-basic">
                                <i class="fas fa-spell-check menu-icon" runat="server" id="iM002"></i>
                                <span class="menu-title">Español</span>
                                <i class="menu-arrow"></i>
                            </a>
                            <div class="collapse" id="ui-basic">
                                <ul class="nav flex-column sub-menu">
                                    <asp:UpdatePanel ID="upMateria0002Tema0001" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0001" runat="server" OnClick="lkbMateria0002Tema0001_Click">
                                                    <span>Tema 1 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0001" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0002" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0002" runat="server" OnClick="lkbMateria0002Tema0002_Click">
                                                    <span>Tema 2 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0002" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0003" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0003" runat="server" OnClick="lkbMateria0002Tema0003_Click">
                                                    <span>Tema 3 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0003" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0004" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0004" runat="server" OnClick="lkbMateria0002Tema0004_Click">
                                                    <span>Tema 4 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0004" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0005" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0005" runat="server" OnClick="lkbMateria0002Tema0005_Click">
                                                    <span>Tema 5 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0005" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0006" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0006" runat="server" OnClick="lkbMateria0002Tema0006_Click">
                                                    <span>Tema 6 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0006" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0007" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0007" runat="server" OnClick="lkbMateria0002Tema0007_Click">
                                                    <span>Tema 7 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0007" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0008" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0008" runat="server" OnClick="lkbMateria0002Tema0008_Click">
                                                    <span>Tema 8 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0008" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0009" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0009" runat="server" OnClick="lkbMateria0002Tema0009_Click">
                                                    <span>Tema 9 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0009" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upMateria0002Tema0010" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li class="nav-item">
                                                <asp:LinkButton CssClass="nav-link" ID="lkbMateria0002Tema0010" runat="server" OnClick="lkbMateria0002Tema0010_Click">
                                                    <span>Tema 10 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0010" style="color: #dc3545"></i></span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ul>
                            </div>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-university menu-icon"></i>
                                <span class="menu-title">Filosofía</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-atom menu-icon"></i>
                                <span class="menu-title">Física</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-globe menu-icon"></i>
                                <span class="menu-title">Geografía</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-globe-americas menu-icon"></i>
                                <span class="menu-title">Historia: México</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-globe-europe menu-icon"></i>
                                <span class="menu-title">Historia: Universal</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-feather-alt menu-icon"></i>
                                <span class="menu-title">Literatura</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-square-root-alt menu-icon"></i>>
                            <span class="menu-title">Matemáticas</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="fas fa-vials menu-icon"></i>
                                <span class="menu-title">Química</span>
                            </a>
                        </li>
                    </ul>
                </nav>
                <!-- partial -->
                <div class="main-panel">
                    <asp:UpdatePanel ID="upWrapperResumen" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="content-wrapper" id="WrapperResumen" runat="server">
                                <div class="row">
                                    <div class="col-sm-12 mb-4 mb-xl-0">
                                        <h4 class="font-weight-bold text-dark">Hola, bienvenid@ de nuevo.</h4>
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-xl-3 flex-column d-flex grid-margin stretch-card">
                                        <div class="row flex-grow">
                                            <div class="col-sm-12 grid-margin stretch-card">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <h4 class="card-title">Aciertos</h4>
                                                        <p>23% increase in conversion</p>
                                                        <h4 class="text-dark font-weight-bold mb-2">43,981</h4>
                                                        <canvas id="customers"></canvas>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 stretch-card">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <h4 class="card-title">Errores</h4>
                                                        <p>6% decrease in earnings</p>
                                                        <h4 class="text-dark font-weight-bold mb-2">55,543</h4>
                                                        <canvas id="orders"></canvas>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-9 d-flex grid-margin stretch-card">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4 class="card-title">Métricas</h4>
                                                <div class="row">
                                                    <div class="col-lg-5">
                                                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit amet cumque cupiditate</p>
                                                    </div>
                                                    <div class="col-lg-7">
                                                        <div class="chart-legends d-lg-block d-none" id="chart-legends"></div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <canvas id="web-audience-metrics-satacked" class="mt-3"></canvas>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xl-4 grid-margin stretch-card">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="d-flex justify-content-between mb-3">
                                                    <h4 class="card-title">Market Trends</h4>
                                                    <div class="dropdown">
                                                        <button class="btn btn-sm dropdown-toggle text-dark pt-0 pr-0" type="button" id="dropdownMenuSizeButton3" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            This week
                                                        </button>
                                                        <div class="dropdown-menu" aria-labelledby="dropdownMenuSizeButton3">
                                                            <h6 class="dropdown-header">This week</h6>
                                                            <h6 class="dropdown-header">This month</h6>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="chart-legends-market-trend" class="chart-legends mt-1">
                                                </div>
                                                <div class="row mt-2 mb-2">
                                                    <div class="col-6">
                                                        <div class="text-small"><span class="text-success">18.2%</span> higher </div>
                                                    </div>
                                                    <div class="col-6">
                                                        <div class="text-small"><span class="text-danger">0.7%</span> higher </div>
                                                    </div>
                                                </div>
                                                <div class="marketTrends mt-4">
                                                    <canvas id="marketTrendssatacked"></canvas>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 grid-margin stretch-card">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4 class="card-title">Traffic Sources</h4>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="d-flex justify-content-between mt-2 text-dark mb-2">
                                                            <div><span class="font-weight-bold">4453</span> Leads</div>
                                                            <div>Goal: 2000</div>
                                                        </div>
                                                        <div class="progress progress-md grouped mb-2">
                                                            <div class="progress-bar  bg-danger" role="progressbar" style="width: 30%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                            <div class="progress-bar bg-info" role="progressbar" style="width: 20%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                            <div class="progress-bar  bg-primary" role="progressbar" style="width: 10%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                            <div class="progress-bar bg-warning" role="progressbar" style="width: 10%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                            <div class="progress-bar bg-success" role="progressbar" style="width: 5%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                            <div class="progress-bar bg-light" role="progressbar" style="width: 25%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="traffic-source-legend">
                                                            <div class="d-flex justify-content-between mb-1 mt-2">
                                                                <div class="font-weight-bold">SOURCE</div>
                                                                <div class="font-weight-bold">TOTAL</div>
                                                            </div>
                                                            <div class="d-flex justify-content-between legend-label">
                                                                <div><span class="bg-danger"></span>Google Search</div>
                                                                <div>30%</div>
                                                            </div>
                                                            <div class="d-flex justify-content-between legend-label">
                                                                <div><span class="bg-info"></span>Social Media</div>
                                                                <div>20%</div>
                                                            </div>
                                                            <div class="d-flex justify-content-between legend-label">
                                                                <div><span class="bg-primary"></span>Referrals</div>
                                                                <div>10%</div>
                                                            </div>
                                                            <div class="d-flex justify-content-between legend-label">
                                                                <div><span class="bg-warning"></span>Organic Traffic</div>
                                                                <div>10%</div>
                                                            </div>
                                                            <div class="d-flex justify-content-between legend-label">
                                                                <div><span class="bg-success"></span>Google Search</div>
                                                                <div>5%</div>
                                                            </div>
                                                            <div class="d-flex justify-content-between legend-label">
                                                                <div><span class="bg-light"></span>Email Marketing</div>
                                                                <div>25%</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-4 grid-margin stretch-card">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4 class="card-title mb-3">Recent Activity</h4>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="text-dark">
                                                            <div class="d-flex pb-3 border-bottom justify-content-between">
                                                                <div class="mr-3"><i class="mdi mdi-signal-cellular-outline icon-md"></i></div>
                                                                <div class="font-weight-bold mr-sm-4">
                                                                    <div>Deposit has updated to Paid</div>
                                                                    <div class="text-muted font-weight-normal mt-1">32 Minutes Ago</div>
                                                                </div>
                                                                <div>
                                                                    <h6 class="font-weight-bold text-info ml-sm-2">$325</h6>
                                                                </div>
                                                            </div>
                                                            <div class="d-flex pb-3 pt-3 border-bottom justify-content-between">
                                                                <div class="mr-3"><i class="mdi mdi-signal-cellular-outline icon-md"></i></div>
                                                                <div class="font-weight-bold mr-sm-4">
                                                                    <div>Your Withdrawal Proceeded</div>
                                                                    <div class="text-muted font-weight-normal mt-1">45 Minutes Ago</div>
                                                                </div>
                                                                <div>
                                                                    <h6 class="font-weight-bold text-info ml-sm-2">$4987</h6>
                                                                </div>
                                                            </div>
                                                            <div class="d-flex pb-3 pt-3 border-bottom justify-content-between">
                                                                <div class="mr-3"><i class="mdi mdi-signal-cellular-outline icon-md"></i></div>
                                                                <div class="font-weight-bold mr-sm-4">
                                                                    <div>Deposit has updated to Paid                              </div>
                                                                    <div class="text-muted font-weight-normal mt-1">1 Days Ago</div>
                                                                </div>
                                                                <div>
                                                                    <h6 class="font-weight-bold text-info ml-sm-2">$5391</h6>
                                                                </div>
                                                            </div>
                                                            <div class="d-flex pt-3 justify-content-between">
                                                                <div class="mr-3"><i class="mdi mdi-signal-cellular-outline icon-md"></i></div>
                                                                <div class="font-weight-bold mr-sm-4">
                                                                    <div>Deposit has updated to Paid</div>
                                                                    <div class="text-muted font-weight-normal mt-1">3 weeks Ago</div>
                                                                </div>
                                                                <div>
                                                                    <h6 class="font-weight-bold text-info ml-sm-2">$264</h6>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xl-9 grid-margin-lg-0 grid-margin stretch-card">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4 class="card-title">Top Sellers</h4>
                                                <div class="table-responsive mt-3">
                                                    <table class="table table-header-bg">
                                                        <thead>
                                                            <tr>
                                                                <th>Country
                                                                </th>
                                                                <th>Revenue
                                                                </th>
                                                                <th>Vs Last Month
                                                                </th>
                                                                <th>Goal Reached
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <i class="flag-icon flag-icon-us mr-2" title="us" id="us"></i>United States
                                                                </td>
                                                                <td>$911,200
                                                                </td>
                                                                <td>
                                                                    <div class="text-success"><i class="icon-arrow-up mr-2"></i>+60%</div>
                                                                </td>
                                                                <td>
                                                                    <div class="row">
                                                                        <div class="col-sm-10">
                                                                            <div class="progress">
                                                                                <div class="progress-bar bg-info" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            25%
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <i class="flag-icon flag-icon-at mr-2" title="us" id="at"></i>Austria
                                                                </td>
                                                                <td>$821,600
                                                                </td>
                                                                <td>
                                                                    <div class="text-danger"><i class="icon-arrow-down mr-2"></i>-40%</div>
                                                                </td>
                                                                <td>
                                                                    <div class="row">
                                                                        <div class="col-sm-10">
                                                                            <div class="progress">
                                                                                <div class="progress-bar bg-info" role="progressbar" style="width: 50%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            50%
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <i class="flag-icon flag-icon-fr mr-2" title="us" id="fr"></i>France
                                                                </td>
                                                                <td>$323,700
                                                                </td>
                                                                <td>
                                                                    <div class="text-success"><i class="icon-arrow-up mr-2"></i>+40%</div>
                                                                </td>
                                                                <td>
                                                                    <div class="row">
                                                                        <div class="col-sm-10">
                                                                            <div class="progress">
                                                                                <div class="progress-bar bg-info" role="progressbar" style="width: 10%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            10%
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="py-1">
                                                                    <i class="flag-icon flag-icon-de mr-2" title="us" id="de"></i>Germany
                                                                </td>
                                                                <td>$833,205
                                                                </td>
                                                                <td>
                                                                    <div class="text-danger"><i class="icon-arrow-down mr-2"></i>-80%</div>
                                                                </td>
                                                                <td>
                                                                    <div class="row">
                                                                        <div class="col-sm-10">
                                                                            <div class="progress">
                                                                                <div class="progress-bar bg-info" role="progressbar" style="width: 70%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            70%
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="pb-0">
                                                                    <i class="flag-icon flag-icon-ae mr-2" title="ae" id="ae"></i>united arab emirates
                                                                </td>
                                                                <td class="pb-0">$232,243
                                                                </td>
                                                                <td class="pb-0">
                                                                    <div class="text-success"><i class="icon-arrow-up mr-2"></i>+80%</div>
                                                                </td>
                                                                <td class="pb-0">
                                                                    <div class="row">
                                                                        <div class="col-sm-10">
                                                                            <div class="progress">
                                                                                <div class="progress-bar bg-info" role="progressbar" style="width: 60%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            0%
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-3 grid-margin-lg-0 grid-margin stretch-card">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4 class="card-title mb-3">Overall rating</h4>
                                                <div class="d-flex">
                                                    <div>
                                                        <h4 class="text-dark font-weight-bold mb-2 mr-2">4.3</h4>
                                                    </div>
                                                    <div>
                                                        <select id="over-all-rating" name="rating" autocomplete="off">
                                                            <option value="1">1</option>
                                                            <option value="2">2</option>
                                                            <option value="3">3</option>
                                                            <option value="4">4</option>
                                                            <option value="5">5</option>
                                                        </select>
                                                    </div>
                                                </div>
                                                <p class="mb-4">Based on 186 reviews</p>
                                                <div class="row">
                                                    <div class="col-sm-2 pr-0">
                                                        <div class="d-flex">
                                                            <div>
                                                                <div class="text-dark font-weight-bold mb-2 mr-2">5</div>
                                                            </div>
                                                            <div>
                                                                <i class="fa fa-star text-warning"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-9 pl-2">
                                                        <div class="row">
                                                            <div class="col-sm-10">
                                                                <div class="progress progress-lg mt-1">
                                                                    <div class="progress-bar bg-warning" role="progressbar" style="width: 80%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-2 p-lg-0">
                                                                80%
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row mt-2">
                                                    <div class="col-sm-2 pr-0">
                                                        <div class="d-flex">
                                                            <div>
                                                                <div class="text-dark font-weight-bold mb-2 mr-2">4</div>
                                                            </div>
                                                            <div>
                                                                <i class="fa fa-star text-warning"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-9 pl-2">
                                                        <div class="row">
                                                            <div class="col-sm-10">
                                                                <div class="progress progress-lg mt-1">
                                                                    <div class="progress-bar bg-warning" role="progressbar" style="width: 45%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-2 p-lg-0">
                                                                45%
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row mt-2">
                                                    <div class="col-sm-2 pr-0">
                                                        <div class="d-flex">
                                                            <div>
                                                                <div class="text-dark font-weight-bold mb-2 mr-2">3</div>
                                                            </div>
                                                            <div>
                                                                <i class="fa fa-star text-warning"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-9 pl-2">
                                                        <div class="row">
                                                            <div class="col-sm-10">
                                                                <div class="progress progress-lg mt-1">
                                                                    <div class="progress-bar bg-warning" role="progressbar" style="width: 30%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-2 p-lg-0">
                                                                30%
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row mt-2">
                                                    <div class="col-sm-2 pr-0">
                                                        <div class="d-flex">
                                                            <div>
                                                                <div class="text-dark font-weight-bold mb-2 mr-2">2</div>
                                                            </div>
                                                            <div>
                                                                <i class="fa fa-star text-warning"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-9 pl-2">
                                                        <div class="row">
                                                            <div class="col-sm-10">
                                                                <div class="progress progress-lg mt-1">
                                                                    <div class="progress-bar bg-warning" role="progressbar" style="width: 8%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-2 p-lg-0">
                                                                8%
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row mt-2">
                                                    <div class="col-sm-2 pr-0">
                                                        <div class="d-flex">
                                                            <div>
                                                                <div class="text-dark font-weight-bold mb-2 mr-2">5</div>
                                                            </div>
                                                            <div>
                                                                <i class="fa fa-star text-warning"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-9 pl-2">
                                                        <div class="row">
                                                            <div class="col-sm-10">
                                                                <div class="progress progress-lg mt-1">
                                                                    <div class="progress-bar bg-warning" role="progressbar" style="width: 1%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-2 p-lg-0">
                                                                1%
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <p class="mb-2 mt-3 mb-3 text-dark font-weight-bold">Rating by category</p>
                                                        <div class="d-flex">
                                                            <div>
                                                                <div class="text-dark font-weight-bold mb-2 mr-2">4.3</div>
                                                            </div>
                                                            <div class="mr-2">
                                                                <i class="fa fa-star text-warning"></i>
                                                            </div>
                                                            <div>
                                                                <p>Work/Management</p>
                                                            </div>
                                                        </div>
                                                        <div class="d-flex">
                                                            <div>
                                                                <div class="text-dark font-weight-bold mb-2 mr-2">3.5</div>
                                                            </div>
                                                            <div class="mr-2">
                                                                <i class="fa fa-star text-warning"></i>
                                                            </div>
                                                            <div>
                                                                <p>Salary/Culture</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upPerfilFiltro" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="content-wrapper" id="WrapperPerfil" runat="server">
                                <div class="container bootstrap snippet">

                                    <div class="row">
                                        <div class="col-sm-3">
                                            <!--left col-->

                                            <div class="text-center">
                                                <img src="http://ssl.gstatic.com/accounts/ui/avatar_2x.png" class="avatar img-circle img-thumbnail" alt="avatar">
                                                <h6>Sube una foto diferente ...</h6>
                                                <input type="file" class="text-center center-block file-upload">
                                            </div>
                                            </hr><br>
                                        </div>
                                        <!--/col-3-->
                                        <div class="col-sm-9">
                                            <div class="row">
                                                <div class="col-lg-4 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Nombre(s)</h4>
                                                        </label>
                                                        <input type="text" class="form-control" runat="server" id="iNombres" tabindex="1" disabled="disabled">
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Apellido Paterno</h4>
                                                        </label>
                                                        <input type="text" class="form-control" runat="server" id="iApaterno" tabindex="2" disabled="disabled">
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Apellido Paterno</h4>
                                                        </label>
                                                        <input type="text" class="form-control" runat="server" id="iAmaterno" tabindex="3" disabled="disabled">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Genero</h4>
                                                        </label>
                                                        <select class="form-control" runat="server" id="sGenero" required="required" tabindex="4">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Fecha de Nacimiento</h4>
                                                        </label>
                                                        <input type="date" class="form-control" runat="server" id="iFechaNacimiento" required="required" tabindex="5">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*WhatsApp</h4>
                                                        </label>
                                                        <input type="text" class="form-control" runat="server" id="iWhatsApp" required="required" tabindex="6">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>Teléfono de Contacto Alterno</h4>
                                                        </label>
                                                        <input type="text" class="form-control" runat="server" id="iTelefonoContacto" tabindex="7">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 mx-auto">
                                                    <div class="form-group">
                                                        <label for="email">
                                                            <h4>*Correo Electrónico Personal</h4>
                                                        </label>
                                                        <input type="email" class="form-control" runat="server" id="iCorrePersonal" required="required" tabindex="8">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>Correo Electrónico Institucional</h4>
                                                        </label>
                                                        <input type="text" class="form-control" runat="server" id="iCorreInstitucional" required="required" disabled="disabled" tabindex="9">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">

                                                <div class="col-md-6">
                                                    <label>
                                                        <h4>*Código Postal</h4>
                                                    </label>
                                                    <div class="input-group">
                                                        <input type="text" class="form-control" runat="server" id="iCP" required="required" tabindex="10" />
                                                        <span class="input-group-btn">
                                                            <asp:LinkButton ID="lkbCP" runat="server" CssClass="btn btn-danger form-control" TabIndex="11" OnClick="lkbCP_Click">
                                                            <i class="fas fa-search"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Colonia</h4>
                                                        </label>
                                                        <select class="form-control" runat="server" id="sColonia" tabindex="12">
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>Municipio</h4>
                                                        </label>
                                                        <input type="text" class="form-control" runat="server" id="iMunicipio" placeholder="Municipio" disabled="disabled" />
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>Estado</h4>
                                                        </label>
                                                        <input type="text" class="form-control" runat="server" id="iEstado" placeholder="Estado" disabled="disabled" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Contraseña Anterior</h4>
                                                        </label>
                                                        <input type="password" class="form-control" runat="server" id="iClaveAnterior" required="required" tabindex="15">
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Contraseña Nueva</h4>
                                                        </label>
                                                        <input type="password" class="form-control" runat="server" id="iClaveNueva" required="required" tabindex="16">
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 mx-auto">
                                                    <div class="form-group">
                                                        <label>
                                                            <h4>*Confirmar Contraseña</h4>
                                                        </label>
                                                        <input type="password" class="form-control" runat="server" id="iClaveConfirma" required="required" tabindex="17">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-xs-12">
                                                    <br>
                                                    <asp:Button CssClass="btn btn-success" ID="btnGuardaPerfil" runat="server" Text="Guardar" TabIndex="18" OnClick="btnGuardaPerfil_Click" />
                                                    <asp:Button CssClass="btn btn-info" ID="btnLimpiaPerfil" runat="server" Text="Limpiar" TabIndex="19" OnClick="btnLimpiaPerfil_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/col-9-->
                                </div>
                                <!--/row-->
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upTema" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="container-fluid" id="divTema" runat="server" visible="false">
                                <div class="card ">
                                    <div class="card-header ">
                                        <h5>
                                            <asp:Label ID="lblTema" CssClass="modal-title" runat="server" Text=""></asp:Label></h5>
                                    </div>
                                    <div class="card-body">

                                        <div class="row no-gutters">
                                            <div class="col-md-4 text-center">
                                                <video width="250" height="150" id="play_video" runat="server" visible="false" class="img-thumbnail" controls="controls" controlslist="nodownload">
                                                    <source src="" type='video/mp4;codecs="avc1.42E01E, mp4a.40.2"' />
                                                </video>
                                            </div>
                                            <div class="col-md-8">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-10">

                                                            <p class="card-text">Instrucciones Diagnostico</p>
                                                            <p class="card-text"><small class="text-muted">* <strong>Primero: </strong>Debes escuchar con atención tu vídeo clase, la puedes pausar y ver las veces que sean necesarias</p>
                                                            </small>
                                                            <p class="card-text"><small class="text-muted"><a>* <strong>Segundo: </strong>Toma apuntes, serán importantes para realizar tus evaluaciones o cuestionarios</a></small></p>
                                                            <br />
                                                            <asp:UpdatePanel ID="upComenzar" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnDiagnostico" runat="server" Text="Comenzar" TabIndex="2" OnClick="btnDiagnostico_Click" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <p class="card-text text-center"><small class="text-muted"><strong>Puntuación</strong></p>
                                                            <h1 class="text-center">
                                                                <asp:Label ID="lblPuntDiag" runat="server" Text="0"></asp:Label></h1>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row no-gutters" runat="server" id="divEbook" visible="false">
                                            <div class="col-md-4">

                                                <iframe width="250" height="150" runat="server" id="iframeTema" class="card-img" src=""></iframe>
                                            </div>
                                            <div class="col-md-8">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-10">

                                                            <p class="card-text">Instrucciones Cuestionario</p>
                                                            <p class="card-text">* <strong>Primero: </strong>Debes de leer con atención tu Ebook y tomar apuntes que serán necesarios para la realización de tu síntesis</p>

                                                            <p class="card-text">
                                                                <a>* <strong>Segundo: </strong>Tu síntesis debe ser de un mínimo de 1800 caracteres equivalente a un poco mas de media cuartilla</a>
                                                                <br />
                                                                <a><strong>¡ Recuerda ! </strong>Sólo puedes realizar una vez el cuestionario de cada tema, así que toma apuntes... te servirán de repaso.</a>
                                                            </p>
                                                            <br />
                                                        </div>
                                                        <div class="col-md-2">
                                                            <p class="card-text text-center"><strong>Puntuación</strong></p>
                                                            <h1 class="text-center">
                                                                <asp:Label ID="lblPuntuacion" runat="server" Text="0"></asp:Label></h1>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upDiagnostico" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="container-fluid" id="divDiagnostico" runat="server" visible="false">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 runat="server" id="H2" title="uno">
                                            <asp:Label ID="lblTemaDiagnostico" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                        </h5>

                                        <div class="row">
                                            <br />
                                            <div class="col-md-6" runat="server">
                                                <asp:UpdatePanel ID="upRespDiag001" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:RadioButton runat="server" ID="rbRespDiag001" GroupName="radioA" AutoPostBack="True" />
                                                        <label for="rbRespDiag001">
                                                            <asp:Label ID="lblRespDiag001" runat="server" Text="">
                                                            </asp:Label><asp:Label ID="lblRespDiagID001" runat="server" Text="" Visible="false"></asp:Label></label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                                <asp:UpdatePanel ID="upRespDiag002" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:RadioButton runat="server" ID="rbRespDiag002" GroupName="radioA" AutoPostBack="True" />
                                                        <label for="rbRespDiag002">
                                                            <asp:Label ID="lblRespDiag002" runat="server" Text=""></asp:Label>
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
                                                            <asp:Label ID="lblRespDiag003" runat="server" Text="">
                                                            </asp:Label><asp:Label ID="lblRespDiagID003" runat="server" Text="" Visible="false"></asp:Label></label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                                <asp:UpdatePanel ID="upRespDiag004" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:RadioButton runat="server" ID="rbRespDiag004" GroupName="radioA" AutoPostBack="True" />
                                                        <label for="rbRespDiag004">
                                                            <asp:Label ID="lblRespDiag004" runat="server" Text="">
                                                            </asp:Label><asp:Label ID="lblRespDiagID004" runat="server" Text="" Visible="false"></asp:Label></label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                            </div>
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
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upComentario" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="container-fluid" id="divComentario" runat="server" visible="false">
                                <div class="card ">
                                    <div class="card-header ">
                                        <h4>
                                            <label for="comment">Síntesis:</label></h4>
                                    </div>
                                    <div class="card-body">
                                        <textarea class="form-control" rows="4" id="comment1" runat="server" required="required" tabindex="1"></textarea>
                                        <br />
                                        <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnEnviar" runat="server" Text="Enviar" TabIndex="2" OnClick="btnEnviar_Click" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upPreguntas" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="container-fluid" id="divPreguntas" runat="server" visible="false">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 runat="server" id="PreguntaID" title="uno">
                                            <asp:Label ID="lblPregunta" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                        </h5>
                                        <div class="row">

                                            <div class="col-md-6" runat="server">
                                                <asp:UpdatePanel ID="upR1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:RadioButton runat="server" ID="radioR1" GroupName="radioA" AutoPostBack="True" />
                                                        <label for="radioR1">
                                                            <asp:Label ID="lblRespuesta001" runat="server" Text=""></asp:Label><asp:Label ID="lblResp001" runat="server" Text="" Visible="false"></asp:Label></label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                                <asp:UpdatePanel ID="upR2" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:RadioButton runat="server" ID="radioR2" GroupName="radioA" AutoPostBack="True" />
                                                        <label for="radioR2">
                                                            <asp:Label ID="lblRespuesta002" runat="server" Text=""></asp:Label><asp:Label ID="lblResp002" runat="server" Text="" Visible="false"></asp:Label></label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                            </div>
                                            <div class="col-md-6" runat="server">
                                                <asp:UpdatePanel ID="upR3" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:RadioButton runat="server" ID="radioR3" GroupName="radioA" AutoPostBack="True" />
                                                        <label for="radioR3">
                                                            <asp:Label ID="lblRespuesta003" runat="server" Text=""></asp:Label><asp:Label ID="lblResp003" runat="server" Text="" Visible="false"></asp:Label></label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                                <asp:UpdatePanel ID="upR4" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:RadioButton runat="server" ID="radioR4" GroupName="radioA" AutoPostBack="True" />
                                                        <label for="radioR4">
                                                            <asp:Label ID="lblRespuesta004" runat="server" Text=""></asp:Label><asp:Label ID="lblResp004" runat="server" Text="" Visible="false"></asp:Label></label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                            </div>
                                        </div>

                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnGuardaRespuesta" runat="server" Text="Guardar" TabIndex="18" OnClick="btnGuardaRespuesta_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
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
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upResultado" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="container-fluid" id="divResultado" runat="server" visible="false">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 runat="server" id="H1" title="uno">
                                            <asp:Label ID="lblResultado" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                        </h5>
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-6 col-md-12 col-lg-12">
                                                <div class="card rounded-0 p-0 shadow-sm">
                                                    <div class="table-responsive">
                                                        <asp:GridView
                                                            CssClass="table table-bordered table-condensed"
                                                            ID="gvResultados"
                                                            runat="server"
                                                            AutoGenerateColumns="False"
                                                            AllowPaging="True"
                                                            CellPadding="3"
                                                            ForeColor="Black"
                                                            GridLines="Vertical"
                                                            TabIndex="5"
                                                            BackColor="White"
                                                            BorderColor="#999999"
                                                            BorderStyle="Solid"
                                                            BorderWidth="1px"
                                                            PageSize="20"
                                                            Font-Size="Smaller"
                                                            AllowSorting="True">

                                                            <AlternatingRowStyle BackColor="#bcbdc1" />
                                                            <Columns>

                                                                <asp:BoundField DataField="MateriaTemaPregunta" HeaderText="Pregunta" SortExpression="MateriaTemaPregunta" Visible="true" />

                                                                <asp:BoundField DataField="MateriaTemaPreguntaRespuesta" HeaderText="Respuesta" SortExpression="MateriaTemaPreguntaRespuesta" ItemStyle-HorizontalAlign="Justify">

                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="Respuesta" HeaderText="Estatus" SortExpression="Respuesta" Visible="true" DataFormatString="{0:$ 0,0.000000}">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Justificacion" HeaderText="Justificacion" SortExpression="Justificacion" Visible="true" DataFormatString="{0:$ 0,0.000000}">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#bcbdc1" />
                                                            <HeaderStyle BackColor="#797a7c" ForeColor="White" Font-Bold="false" />
                                                            <PagerSettings FirstPageText="Inicio" LastPageText="Final" />
                                                            <PagerStyle BackColor="#bcbdc1" ForeColor="Black" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#bcbdc1" ForeColor="White" />
                                                            <SortedAscendingCellStyle BackColor="#bcbdc1" />
                                                            <SortedAscendingHeaderStyle BackColor="#bcbdc1" />
                                                            <SortedDescendingCellStyle BackColor="#bcbdc1" />
                                                            <SortedDescendingHeaderStyle BackColor="#bcbdc1" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- content-wrapper ends -->
                    <!-- partial:partials/_footer.html -->
                    <footer class="footer">
                        <div class="d-sm-flex justify-content-center justify-content-sm-between">
                            <span class="text-muted text-center text-sm-left d-block d-sm-inline-block">Copyright © 2020 <a href="#" target="_blank" class="text-muted">Intelimundo</a>. Todos los derechos reservados.</span>
                            <span class="float-none float-sm-right d-block mt-1 mt-sm-0 text-center">Desarrollo Intelimundo <i class="icon-heart"></i></span>
                        </div>
                    </footer>
                    <!-- partial -->
                </div>
                <!-- main-panel ends -->
            </div>
            <!-- page-body-wrapper ends -->
        </div>
        <!-- container-scroller -->
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
    <!-- base:js -->
    <script src="Estilos/Admin/vendors/base/vendor.bundle.base.js"></script>
    <!-- endinject -->
    <!-- Plugin js for this page-->
    <!-- End plugin js for this page-->
    <!-- inject:js -->
    <script src="Estilos/Admin/js/off-canvas.js"></script>
    <script src="Estilos/Admin/js/hoverable-collapse.js"></script>
    <script src="Estilos/Admin/js/template.js"></script>
    <!-- endinject -->
    <!-- plugin js for this page -->
    <script src="Estilos/Admin/vendors/chart.js/Chart.min.js"></script>
    <script src="Estilos/Admin/vendors/jquery-bar-rating/jquery.barrating.min.js"></script>
    <!-- End plugin js for this page -->
    <!-- Custom js for this page-->
    <script src="Estilos/Admin/js/dashboard.js"></script>
    <!-- End custom js for this page-->
</body>
</html>
