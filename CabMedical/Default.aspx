<%@  Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CabMedical._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bootstrap Example</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        /* Remove the navbar's default margin-bottom and rounded borders */
        .navbar {
            margin-bottom: 0;
            border-radius: 0;
        }

        /* Add a gray background color and some padding to the footer */
        footer {
            background-color: #f2f2f2;
            padding: 25px;
        }

        .carousel-inner img {
            width: 100%; /* Set width to 100% */
            margin: auto;
            min-height: 200px;
        }

        /* Hide the carousel text when the screen is less than 600 pixels wide */
        @media (max-width: 600px) {
            .carousel-caption {
                display: none;
            }
        }

        hover {
            color: #9ad3e4;
        }

        /* selected link */
        active {
            color: #6c94c5;
        }

        .btn-default {
            border: 1px solid;
            border-color: #f5f5f5;
            background-color: transparent;
            color: #fff;
            padding: 1rem 2rem;
            border-radius: 0;
            margin-top: 10px;
        }

            .btn-default:hover {
                padding-right: 25px;
                background-color: #9ad3e4;
                color: white;
                border-color: #9ad3e4;
                padding-right: 25px;
                font-family: monospace;
            }

        .fa {
            padding: 16px;
            font-size: 30px;
            width: 63px;
            text-align: center;
            text-decoration: none;
            margin: 5px 2px;
            border-radius: 141%;
        }

            .fa:hover {
                opacity: 0.7;
            }

        .fa-facebook {
            background: #4267B2;
            color: white;
            transition: .35s box-shadow;
        }

        .fa-twitter {
            background: #55ACEE;
            color: white;
        }

        .fa-google-plus {
            background: #dd4b39;
            color: white;
        }

        .fa-linkedin {
            background: #2867B2;
            color: white;
        }

        .fa-youtube-play {
            background: #FF0000;
            color: white;
        }

        .fa-instagram {
            background: #fb3958;
            color: white;
        }
    </style>
</head>
<body>
    <script>
        window.onscroll = function () { myFunction() };

        var header = document.getElementById("myHeader");
        var sticky = header.offsetTop;

        function myFunction() {
            if (window.pageYOffset > sticky) {
                header.classList.add("sticky");
            } else {
                header.classList.remove("sticky");
            }
        }
    </script>
    <nav class="navbar navbar-inverse" id="myHeader">
        <div class="container-fluid" style="padding-bottom: 2%;">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">
                    <img src="../Image/logo1.png" style="max-width: 27%;"></a>
                <h3 data-brackets-id="129" style="color: white; margin-left: 104px;">Cabinet Médical </h3>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav">
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="RendezVous_Add.aspx" style="margin-top: 10%; font-size: 152%; color: #e8e8e8;"><span class="glyphicon glyphicon-calendar"></span>Ajouter Rendez-Vous </a></li>
                    <li><a href="Login.aspx" style="margin-top: 25%; font-size: 152%; color: #e8e8e8;"><span class="glyphicon glyphicon-log-in"></span>Login</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div id="myCarousel" class="carousel slide" data-ride="carousel">

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <img src="../image/Accueil-test3.jpg">
        </div>


    </div>

    <div class="container text-center">
        <h3></h3>
        <br>
        <div class="row">



            <div class="col-sm-4" style="background-color: #c2c8d0;">
                <h2>Contact</h2>
                <form runat="server">


                    <div class="form-group">
                        <label for="nom" style="text-align: left;">Votre nom :</label>
                        <%--<input type="text" class="form-control" id="nom" placeholder="Enter nom" name="email">--%>
                        <asp:TextBox ID="TextBox_Nom" runat="server" class="form-control" placeholder="Enter nom" />
                    </div>


                    <div class="form-group">
                        <label for="pwd" style="text-align: left;">Téléphone :</label>
                        <%--<input type="tele" class="form-control" id="tele" placeholder="Enter téléphone" name="pswd">--%>
                        <asp:TextBox ID="TextBox_Tel" runat="server" class="form-control" placeholder="Enter téléphone" />
                    </div>

                    <div class="form-group">
                        <label for="email" style="text-align: left;">Votre mail :</label>
                        <%--<input type="email" class="form-control" id="nom" placeholder="Enter email" name="email">--%>                        
                        <asp:TextBox ID="TextBox_email" runat="server" class="form-control" placeholder="Enter email" />

                    </div>


                    <div class="form-group">
                        <label for="msg" style="text-align: left;">Votre message :</label>
                        <%--<textarea> class="form-control" rows="5" id="comment" placeholder="Enter message"></textarea>--%>
                        <asp:TextBox ID="tb_Message" TextMode="multiline" placeholder="Enter message" Columns="10" Rows="5" runat="server" Height="150px" Width="350px" />
                    </div>


                    <div class="form-group">
                        <%--<button type="submit" class="btn btn-primary">Envoyer</button>--%>
                        <asp:Button ID="Button_Contact" runat="server"  class="btn btn-primary" Text="Envoyer" OnClick="Button_Contact_Click" />
                    </div>
                </form>

            </div>



            <div class="col-sm-4">
                <div class="et_pb_column et_pb_column_1_2 et_pb_column_12    et_pb_css_mix_blend_mode_passthrough">
                    <div class="et_pb_module et_pb_text et_pb_text_5 et_pb_bg_layout_light  et_pb_text_align_left">
                        <div class="et_pb_text_inner">
                            <h2>Le cabinet</h2>
                            <hr class="short">
                            <p class="lead"><b>64 Bvd Sidi Abderrahman, Beauséjour, 3ème étage,<br>
                                résidence Misselma,<br>
                                Casablanca</b></p>
                            <p><strong><u>Repère :</u></strong> <span>Pharmacie de l’aéroport – </span><span>Acima – </span><span>Le CAF<br>
                                <br>
                            </span><strong><span><span style="text-decoration: underline;">Comodités</span> :</span></strong><span> </span><span>Tram station beauséjour<br>
                            </span><span style="text-decoration: underline;"><strong>
                                <br>
                                Tarif consultation générale</strong></span><span> : 300dhs<br>
                                    <br>
                                </span><span></span><span><strong><span style="text-decoration: underline;">Tarifs des actes</span> :</strong> sur demande. </span></p>
                        </div>
                    </div>
                </div>
                <div class="footer-social">
                    <a href="#" class="fa fa-facebook"></a>
                    <a href="#" class="fa fa-google-plus"></a>
                    <a href="#" class="fa fa-linkedin"></a>
                    <a href="#" class="fa fa-youtube-play"></a>
                    <a href="#" class="fa fa-instagram"></a>
                </div>
            </div>




            <div class="col-sm-4">
                <div class="et_pb_row et_pb_row_8 et_pb_equal_columns et_pb_gutters1">
                    <div class="et_pb_column et_pb_column_1_2 et_pb_column_11    et_pb_css_mix_blend_mode_passthrough">
                        <div class="et_pb_module et_pb_code et_pb_code_0">
                            <div class="et_pb_code_inner">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3324.5132352924556!2d-7.654234684070171!3d33.56602125064167!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x0!2zMzPCsDMzJzU3LjciTiA3wrAzOScwNy40Ilc!5e0!3m2!1sfr!2sma!4v1537387907625" width="100%" height="400" frameborder="0" style="border: 0" allowfullscreen=""></iframe>
                            </div>
                        </div>
                    </div>
                </div>
            </div>





        </div>
    </div>
    <br>

    <footer class="container-fluid text-center">
        <p>Copyright © 2020-2021 All right reserved</p>
    </footer>


</body>
</html>
