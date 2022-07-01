<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jobs.aspx.cs" Inherits="FindJob.Views.Emplois" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- import bootstrap css -->
    <link rel="stylesheet" href="../Contents/Bootstrap/bootstrap.min.css" />
    <!-- import main css -->
    <link rel="stylesheet" href="../Contents/MainStyle/Css/main.css" />
    <!-- import fontawsome css -->
    <link rel="stylesheet" href="../Contents/MainStyle/Css/all.min.css" />
    <title>Emplois</title>
  </head>
  <body>
   <form runat="server" id="send">
    <!-- start navbar -->
        <nav id="nav" runat="server" class="navbar navbar-expand-lg navbar-dark bg-primary">
            <div class="container">
                <div class="d-flex justify-content-center align-items-center">
                    <img src="../Contents/Images/logo.png" class="logo" alt="logo" />
                    <a class="navbar-brand mb-0 h1" href="#">FindJob</a>
                </div>
                <button
                    class="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent"
                    aria-expanded="false"
                    aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="Home.aspx">Accueil</a>
                        </li>
                        <%
                            HttpCookie cookie = Request.Cookies["UserId"];
                            if (cookie != null)
                            {
                                if (cookie["type"] == "Entreprise")
                                {
                                    Response.Write($@"
                                        <li class='nav-item'>
                                            <a class='nav-link' href='{cookie["type"]}/profile.aspx'>Profile</a>
                                        </li>
                                    ");
                                }
                                else
                                {
                                    Response.Write($@"
                                        <li class='nav-item'>
                                            <a class='nav-link' href='{cookie["type"]}/profile.aspx'>Profile</a>
                                        </li>
                                    ");
                                }
                            }
                        %>
                        <li class="nav-item">
                            <a class="Job-link nav-link" href="Jobs.aspx">Emplois</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="About.aspx">à propos</a>
                        </li>
                    </ul>
                    <% 
                        HttpCookie cookie2 = Request.Cookies["UserId"];
                        if (cookie2 == null)
                        {
                    %>
                    <div class="d-flex" style="column-gap: 5px">
                        <a href="Login.aspx" class="btn btn-light">Connexion</a>
                        <div class="dropdown">
                            <button
                                class="btn btn-outline-light dropdown-toggle"
                                type="button"
                                id="dropdownMenuButton1"
                                data-bs-toggle="dropdown"
                                aria-expanded="false">
                                S'inscrire
                            </button>
                            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                <li><a class="dropdown-item" href="Chercheur/SignIn.aspx">Chercheur</a></li>
                                <li><a class="dropdown-item" href="Entreprise/SignIn.aspx">Entreprise</a></li>
                            </ul>
                        </div>
                    </div>
                    <%
                        }
                        else
                        {
                    %>
                    <div class="dropdown">
                        <button
                            class="btn btn-dark dropdown-toggle zselect-bar"
                            type="button"
                            id="dropdownMenuButton2"
                            data-bs-toggle="dropdown"
                            aria-expanded="false">
                            <asp:Image CssClass="min-UserImage" ID="Image1" runat="server" ImageUrl="~/Contents/Images/back.jpg" />
                            <span class="min-Username" runat="server" id="nameinnav"></span>
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                            <li>
                                <asp:LinkButton OnClick="dec_Click" CssClass="dropdown-item" ID="dec" runat="server">
                                  <i class="fa-solid fa-right-from-bracket"></i>                                    
                                    Déconnecter
                                </asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                    <%
                        }
                    %>
                </div>
            </div>
        </nav>
    <!-- end navbar -->
    <!-- start jobs -->

    <!-- start search & filter -->
        <div class="container">
            <div id="form1" class="experiences">
                <!--strat title-->
                <div class="titleExp">
                    <h3>Recherche</h3>
                </div>
                <!--end title-->

                <!--start search-->
                <div class="input-group mb-3">
                    <asp:TextBox class="form-control py-2" placeholder="Recherche Emplois et Enterprise" type="text" ID="Recherchetextbox" runat="server"></asp:TextBox>
                    <i class="fa-solid fa-magnifying-glass" style="top: 15px !important;"></i>
                    <asp:Button type="button" aria-label="Recipient's username" aria-describedby="button-addon2" class="btn btn-primary" ID="Recherchebtn" runat="server" Text="Recherche" OnClick="Recherchebtn_Click" />
                </div>
                <!--end search-->
        </div>
        <div class="Poste experiences">
                <div class="titleExp">
                    <h3>Emplois</h3>
                    <asp:LinkButton OnClick="LinkButton1_Click" CssClass="btn btn-primary" ID="LinkButton1" runat="server">
                        <i class="fa-solid fa-file-code"></i>
                        Emplois (XML) 
                    </asp:LinkButton>
                </div>
                <div class="container">
                    <div class="board">
                        <div class="jobs" runat="server" id="boardjobs">
                            <!--return All Jobs from Database-->
                        </div>
                    </div>
                </div>
            </div>

    <!-- end search & filter -->
    <!-- import scripts js -->
    </form>
    <script src="../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../Contents/MainStyle/Css/main.js"></script>
    <script src="../Contents/MainStyle/Js/all.min.js"></script>
  </body>
</html>
