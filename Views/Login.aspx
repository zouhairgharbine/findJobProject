<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
Inherits="FindJob.Views.Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- import bootstrap css -->
    <link rel="stylesheet" href="../Contents/Bootstrap/bootstrap.min.css" />
    <!-- import main css -->
    <link rel="stylesheet" href="../Contents/MainStyle/Css/main.css" />
    <!-- import fontawsome css -->
    <link rel="stylesheet" href="../Contents/MainStyle/Css/all.min.css" />
    <title>Connexion</title>
  </head>
  <body runat="server" id="body">
    <!-- ---------------- start navbar ---------------- -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
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
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <a class="nav-link" href="Home.aspx">Accueil</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="Jobs.aspx">Emplois</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="About.aspx">à propos</a>
            </li>
          </ul>
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
              <li>
                <a class="dropdown-item" href="Chercheur/SignIn.aspx"
                  >Chercheur</a
                >
              </li>
              <li>
                <a class="dropdown-item" href="Entreprise/SignIn.aspx"
                  >Entreprise</a
                >
              </li>
            </ul>
          </div>
        </div>
      </div>
    </nav>
    <!-- ---------------- end navbar ---------------- -->

    <!-- ---------------- start login ---------------- -->
    <div class="body-login container">
      <!-- start from -->
      <form runat="server" id="loginform">
      <div class="Title-login bg-primary p-3">Connexion</div>
        <!-- start UserName -->
        <div class="mb-3">
          <label for="Email" class="form-label">Email</label>
          <asp:TextBox
            required="required"
            id="UserName"
            aria-describedby="emailHelp"
            TextMode="Email"
            class="form-control"
            placeholder="Email"
            runat="server"
          ></asp:TextBox>
        <i class="fa-solid fa-user" style="left: 14px !important;"></i>
        </div>
        <!-- end UserName -->
        <!-- start password -->
        <div class="mb-3">
          <label for="Mot_de_passe" class="form-label">Mot de passe</label>
          <div class="input-group">
            <asp:TextBox
              required="required"
              class="z-pass form-control"
              TextMode="Password"
              placeholder="Mot de passe"
              ID="Mot_de_passe"
              runat="server"
            ></asp:TextBox>
            <i class="fa-solid fa-lock"></i>
            <div class="eye-h input-group-text">
              <i class="fa-solid fa-eye"></i>
            </div>
          </div>
        </div>
        <!-- end password -->
        <div class="link-box mb-3"></div>
          <asp:HyperLink style="color:gray;text-decoration:none;" NavigateUrl="RestPassword.aspx" ID="HyperLink1" runat="server">Mot de passe oublié?</asp:HyperLink>
          <br />
        <asp:Button
          class="Sign-btn btn btn-primary"
          ID="LoginBtn"
          runat="server"
          Text="Connexion" OnClick="LoginBtn_Click"/>
      </form>
      <div id="Alertbox" runat="server"></div>
      <!-- end form -->
    </div>
    <!-- ---------------- end login ---------------- -->

    <!-- import scripts js -->
    <script src="../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../Contents/MainStyle/Js/main.js"></script>
    <script src="../Contents/MainStyle/Js/all.min.js"></script>
    <script>
        let eye = document.querySelector(".eye-h");
        let passbox = document.querySelector(".z-pass");
        let ishide = true;
        eye.style.cursor = "pointer";
        eye.addEventListener("click", function () {
            if (ishide) {
                ishide = false;
                this.innerHTML = "<i class='fa-solid fa-eye-slash'></i>";
                passbox.setAttribute("type", "text");
            } else {
                ishide = true;
                this.innerHTML = "<i class='fa-solid fa-eye'></i>";
                passbox.setAttribute("type", "password");
            }
        });
    </script>
  </body>
</html>