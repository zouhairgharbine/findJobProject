<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestPassword.aspx.cs" Inherits="FindJob.Views.RestPassword" %>

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
    <title>RestPassword</title>
</head>
<body>
    <form id="form1" runat="server">
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
        <div id="alert" runat="server"></div>
    <!-- ---------------- start rest ---------------- -->
 <div class="Modify p-8 container">
          <!-- start form -->
          <div runat="server" class="sign-form row container">
          <div class="p-3" style="font-size:30px;">changer votre Mot de passe</div>
            <!-- end Password -->
            <div class="col-md-6">
              <label for="inputPassword4" class="form-label">
                  voulez-vous changer votre Mot de passe ?
              </label>
              <div class="input-group">
                <asp:TextBox
                  class="z-pass form-control"
                  placeholder="NomUtilisateur"
                  ID="NomUtilisateur"
                  runat="server"
                ></asp:TextBox>
                <i class="fa-solid fa-at"></i>
              </div>
            </div>
            <!-- end Password -->
            <div class="col-12">
              <asp:Button
                class="Sign-btn btn btn-primary"
                ID="Button2"
                runat="server"
                Text="Send" OnClick="Button2_Click"
              />
            </div>
          </div>
          <!-- start form -->
        </div>
    <!-- ---------------- end rest ---------------- -->

    </form>
    <!-- import scripts js -->
    <script src="../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../Contents/MainStyle/Js/main.js"></script>
    <script src="../Contents/MainStyle/Js/all.min.js"></script>
</body>
</html>
