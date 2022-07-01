<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessagesReponse.aspx.cs" Inherits="FindJob.Views.Entreprise.MessagesReponse" %>

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
    <link rel="stylesheet" href="../../Contents/MainStyle/Css/all.min.css" />
    <title>Message</title>
</head>
<body>
    <form id="form1" runat="server">
    <!-- start navbar -->
            <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
      <div class="container">
        <div class="d-flex justify-content-center align-items-center">
            <img src="../../Contents/Images/logo.png" class="logo" alt="logo" />
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
              <a class="nav-link" href="../Home.aspx">Accueil</a>
            </li>
            <%
                HttpCookie cookie = Request.Cookies["UserId"];
                if(cookie != null)
                {
                    Response.Write($@"
                    <li class='nav-item'>
                        <a class='nav-link' href=''>Profile</a>
                    </li>
                    ");
                }
            %>
            <li class="nav-item">
              <a class="nav-link" href="../Jobs.aspx">Emplois</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="../About.aspx">à propos</a>
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
                <div class="nav-box d-flex align-items-center">
                    <div class="dropdown">
                        <button
                            class="btn btn-dark dropdown-toggle zselect-bar"
                            type="button"
                            id="dropdownMenuButton2"
                            data-bs-toggle="dropdown"
                            aria-expanded="false">
                            <asp:Image CssClass="min-UserImage" ID="Image1" runat="server" ImageUrl="~/Contents/Images/profile.jpg" />
                            <span class="min-Username" runat="server" id="nameinnav"></span>
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                            <li>
                                <asp:LinkButton Onclick="dec_Click2" CssClass="dropdown-item" ID="dec" runat="server">
                                    <i class="fa-solid fa-right-from-bracket"></i>                                    
                                    Déconnecter
                                </asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
          <%
            }
          %>  
        </div>
      </div>
    </nav>
    <!-- end navbar -->

    <!-- end navbar -->
        <div id="alert" runat="server"></div>
    <div class="container">
        <div id="bord" class="experiences">
            <!--strat title-->
            <div class="titleExp">
                <h3>Envoyer un Message</h3>
            </div>
            <div class="col-md-12">
                <label for="inputEmail4" class="form-label">Message</label>
            </div>
            <div class="col-12">
                <asp:TextBox Rows="4" class="text-Mltipule form-control" TextMode="MultiLine" placeholder="Message" ID="Messagebox" runat="server"></asp:TextBox>
            </div>
            <div class="col-12">
                <asp:Button CssClass="Envoyer-btn Sign-btn btn btn-primary" ID="Send" runat="server" Text="Envoyer" OnClick="Send_Click" />
            </div>
        </div>
    </div>
    </form>
    <script src="../../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../../Contents/MainStyle/Css/main.js"></script>
    <script src="../../Contents/MainStyle/Js/all.min.js"></script>
</body>
</html>
