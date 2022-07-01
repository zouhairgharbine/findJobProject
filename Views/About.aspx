<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FindJob.Views.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- import bootstrap css -->
    <link rel="stylesheet" href="../../Contents/Bootstrap/bootstrap.min.css" />
    <!-- import main css -->
    <link rel="stylesheet" href="../../Contents/MainStyle/Css/main.css" />
    <!-- import fontawsome css -->
    <link rel="stylesheet" href="../Contents/MainStyle/Css/all.min.css" />
    <title>S'inscrire</title>
</head>
<body>
    <form runat="server">
    <!-- start navbar -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
      <div class="container">
        <div class="d-flex justify-content-center align-items-center">
            <img src="../Contents/Images/logo.png" class="logo"  alt="logo"/>
            <a class="navbar-brand mb-0 h1" href="#">FindJob</a>
        </div>
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <a class="nav-link" href="Home.aspx">Accueil</a>
            </li>
        <%
            HttpCookie cookie = Request.Cookies["UserId"];
            if(cookie != null)
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
            <a class="nav-link" href="Jobs.aspx">Emplois</a>
        </li>
        <li class="nav-item">
            <a class="Job-link nav-link" href="About.aspx">à propos</a>
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
                    aria-expanded="false"
                    >
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
                    aria-expanded="false"
                    >
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
    <!-- start boardAbout -->
    <div class="container">
      <div class="Aboutboard">
        <img src="../Contents/Images/profile.jpg" alt="LogoImage" />
        <h4>ZOUHAIR GHARBINE</h4>
        <span>programmeur débutant</span>
        <p>
bonjour je m'appelle zouhair et je suis développeur débutant je fais ce projet (trouver des emplois) pour mon projet de fin d'études je suis très content et j'espère que vous aimerez mon projets
        </p>
        <a href="https://github.com/zouhairgharbine" class="btn btn-dark my-3">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            class="bi bi-github"
            viewBox="0 0 16 16"
          >
            <path
              d="M8 0C3.58 0 0 3.58 0 8c0 3.54 2.29 6.53 5.47 7.59.4.07.55-.17.55-.38 0-.19-.01-.82-.01-1.49-2.01.37-2.53-.49-2.69-.94-.09-.23-.48-.94-.82-1.13-.28-.15-.68-.52-.01-.53.63-.01 1.08.58 1.23.82.72 1.21 1.87.87 2.33.66.07-.52.28-.87.51-1.07-1.78-.2-3.64-.89-3.64-3.95 0-.87.31-1.59.82-2.15-.08-.2-.36-1.02.08-2.12 0 0 .67-.21 2.2.82.64-.18 1.32-.27 2-.27.68 0 1.36.09 2 .27 1.53-1.04 2.2-.82 2.2-.82.44 1.1.16 1.92.08 2.12.51.56.82 1.27.82 2.15 0 3.07-1.87 3.75-3.65 3.95.29.25.54.73.54 1.48 0 1.07-.01 1.93-.01 2.2 0 .21.15.46.55.38A8.012 8.012 0 0 0 16 8c0-4.42-3.58-8-8-8z"
            />
          </svg>
          Mon github
        </a>
      </div>
    </div>

    <!-- end boardAbout -->

    </form>
    <!-- import scripts js -->
    <script src="../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../Contents/MainStyle/Css/main.js"></script>
    <script src="../Contents/MainStyle/Js/all.min.js"></script>
  </body>
</html>
