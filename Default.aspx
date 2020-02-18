<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="wa_Cuestionarios.Default" %>

<!DOCTYPE html>

<html lang="es-mx">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Aula / Intelimundo</title>
    <meta name="description" content="Porque Intelimundo es el complemento perfecto para mejorar la vida académica del alumno, desarrollando y favoreciendo habilidades, aptitudes y actitudes ...">
    <meta name="keywords" content="Cursos, Educación, Capacitación UNAM, Politecnico, UAM">

       <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Open+Sans|Candal|Alegreya+Sans">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
    
    <link href="Estilos/PaginaAterrizaje/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Estilos/PaginaAterrizaje/css/imagehover.min.css" rel="stylesheet" />
    <link href="Estilos/PaginaAterrizaje/css/style.css" rel="stylesheet" />
    <link href="Estilos/Personal/Video.css" rel="stylesheet" />


    <link rel="shortcut icon" href="Imagenes/favicon.png" />
    <script async data-id="22292" src="https://cdn.widgetwhats.com/script.min.js"></script>
</head>

<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!--Navigation bar-->
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#banner">Inteli<span>mundo</span></a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="#feature">Características</a></li>
                        
                        <li><a href="#pricing">Precios</a></li>
                        <li><a href="TerminosCondiciones.aspx">Pre-Registro</a></li>
                        <li class="btn-trial"><a href="#" data-target="#login" data-toggle="modal">Ir a Aula</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <!--/ Navigation bar-->
        <!--Modal box-->

        <div class="modal fade" id="login" role="dialog">
            <div class="modal-dialog modal-sm">

                <!-- Modal content no 1-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <div class="text-center">

                            <img class="img-responsive img-thumbnail" src="Imagenes/im.png" width="128" />
                        </div>

                    </div>
                    <div class="modal-body padtrbl">

                        <div class="login-box-body">
                            <p class="login-box-msg">Inicia sesión para comenzar</p>
                            <div class="form-group">

                                <div class="form-group has-feedback">
                                    <!----- username -------------->
                                    <input class="form-control" runat="server" placeholder="Usuario" id="loginid" type="text" required />
                                    <span style="display: none; font-weight: bold; position: absolute; color: #f6d738; position: absolute; padding: 4px; font-size: 11px; background-color: rgba(128, 128, 128, 0.26); z-index: 17; right: 27px; top: 5px;" id="span_loginid"></span>
                                    <!---Alredy exists  ! -->
                                    <span class=" form-control-feedback"><i class="fas fa-user-lock" style="color: #f6d738"></i></span>
                                </div>
                                <div class="form-group has-feedback">
                                    <!----- password -------------->
                                    <input class="form-control" runat="server" placeholder="Contraseña" id="loginpsw" type="password" autocomplete="off" required />
                                    <span style="display: none; font-weight: bold; position: absolute; color: grey; position: absolute; padding: 4px; font-size: 11px; background-color: rgba(128, 128, 128, 0.26); z-index: 17; right: 27px; top: 5px;" id="span_loginpsw"></span>
                                    <!---Alredy exists  ! -->
                                    <span class=" form-control-feedback"><i class="fas fa-key" style="color: #f6d738"></i></span>
                                </div>
                                <div class="row">

                                    <div class="col-xs-12">
                                        <asp:Button CssClass="btn btn-green btn-block btn-flat" ID="btnAcceso" runat="server" Text="Iniciar sesión" TabIndex="3" OnClick="btnAcceso_Click"  />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!--/ Modal box-->
        <header>
            <div class="overlay"></div>
            <video playsinline="playsinline" autoplay="autoplay" loop="loop">
                <source src="Material/PromoIntelimundo.mp4" type="video/mp4">
            </video>
            <div class="container h-100">
                <div class="d-flex h-100 text-center align-items-center">
                    <div class="w-100 text-white">
                    </div>
                </div>
            </div>
        </header>
        <!--Feature-->
        <section id="feature" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2>Características</h2>

                        <hr class="bottom-line">
                    </div>
                    <div class="feature-info">
                        <div class="fea">
                            <div class="col-md-3">
                                <div class="heading pull-right">
                                    <h4>¡Viaja con tu aula!</h4>
                                    <p>Accede desde cualquier parte del mundo tan sólo necesitas un dispositivo con conexión a Internet.</p>
                                </div>
                                <div class="fea-img pull-left">
                                    <i class="fas fa-suitcase-rolling"></i>
                                </div>
                            </div>
                        </div>
                        <div class="fea">
                            <div class="col-md-3">
                                <div class="heading pull-right">
                                    <h4>¡Nosotros te ayudamos!</h4>
                                    <p>Tienes dudas o necesitas apoyo, te apoyamos a través de foros o chat en línea, estamos al pendiente de ti.</p>
                                </div>
                                <div class="fea-img pull-left">
                                    <i class="fas fa-hands-helping"></i>
                                </div>
                            </div>
                        </div>
                        <div class="fea">
                            <div class="col-md-3">
                                <div class="heading pull-right">
                                    <h4>¡Contenido clasificado!</h4>
                                    <p>Por áreas del conocimiento, escuelas y nivel académico, elige la más adecuada para tu preparación.</p>
                                </div>
                                <div class="fea-img pull-left">
                                    <i class="fas fa-certificate"></i>
                                </div>
                            </div>
                        </div>
                        <div class="fea">
                            <div class="col-md-3">
                                <div class="heading pull-right">
                                    <h4>¡Libera tu horario!</h4>
                                    <p>El aula está a tu disposición las 24/7, decide cuando programarás tus horarios de estudio.</p>
                                </div>
                                <div class="fea-img pull-left">
                                    <i class="fas fa-user-clock"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--/ feature-->


        <!--Pricing-->
        <section id="pricing" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2>Por lanzamiento</h2>
                        <p>
                            Aprovéchalo es por corta temporada
                        </p>
                        <hr class="bottom-line">
                    </div>
                    <div class="col-md-4 col-sm-4">
          
                    </div>
                    <div class="col-md-4 col-sm-4">
                        <div class="price-table">
                            <!-- Plan  -->
                            <div class="pricing-head">
                                <h4>Aula UNAM</h4>
                                <span class="fa fa-usd curency"></span><span class="amount">$ 500.00</span>
                            </div>

                            <!-- Plean Detail -->
                            <div class="price-in mart-15">
                                <a href="#" class="btn btn-bg yellow btn-block"></a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-4">
                      
                    </div>
                </div>
            </div>
        </section>
        <!--/ Pricing-->

        <!--Footer-->
        <footer id="footer" class="footer">
            <div class="container text-center">

                <!-- End newsletter-form -->
                <ul class="social-links">
                    <li><a href="#link"><i class="fab fa-twitter-square"></i></a></li>
                    <li><a href="#link"><i class="fab fa-facebook-square"></i></a></li>
                    <li><a href="#link"><i class="fab fa-youtube-square"></i></a></li>
                    <li><a href="#link"><i class="fab fa-linkedin"></i></a></li>
                </ul>
                ©2020. Todos los derechos reservados
      <div class="credits">
          Diseñada por <a href="#">Intelimundo</a>
      </div>
            </div>
        </footer>
        <!--/ Footer-->
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
        
        <script src="Estilos/PaginaAterrizaje/js/jquery.min.js"></script>
        <script src="Estilos/PaginaAterrizaje/js/jquery.easing.min.js"></script>
        <script src="Estilos/PaginaAterrizaje/js/bootstrap.min.js"></script>
        <script src="Estilos/PaginaAterrizaje/js/custom.js"></script>

        
    </form>
</body>

</html>
