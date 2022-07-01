<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs"
Inherits="FindJob.Views.Chercheur.Inscrire" %>

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
    <title>S'inscrire</title>
  </head>
  <body>
    <!-- ---------------- start navbar ---------------- -->
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
            <li class="nav-item">
              <a class="nav-link" href="../Jobs.aspx">Emplois</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="../About.aspx">à propos</a>
            </li>
          </ul>
          <a href="../Login.aspx" class="btn btn-outline-light">Connexion</a>
        </div>
      </div>
    </nav>
    <!-- ---------------- end navbar ---------------- -->
    <div id="alert" runat="server"></div>
    <!-- ---------------- start SignUp ---------------- -->
    <div class=" p-8 container">
      <!-- start form -->
      <form runat="server" class="sign-form row container">
      <div class="p-3" style="font-size:30px;">Créer un compte</div>
        <!-- start Prenom -->
        <div class="col-md-6">
          <label for="inputPassword4" class="form-label">Prénom</label>
          <asp:TextBox
            class="form-control"
            ID="Prénom"
            runat="server"
            placeholder="Prenom"
          ></asp:TextBox>
        <i class="fa-solid fa-user"></i>
          <asp:RequiredFieldValidator ValidationGroup="Addchercheur" ControlToValidate="Prénom"  ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!-- end Prenom -->

        <!-- start Nom -->
        <div class="col-md-6">
          <label for="inputEmail4" class="form-label">Nom</label>
          <asp:TextBox
            placeholder="Nom"
            class="form-control"
            ID="Nom"
            runat="server"
          ></asp:TextBox>
        <i class="fa-solid fa-user"></i>
          <asp:RequiredFieldValidator  ValidationGroup="Addchercheur" ControlToValidate="Nom"  ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!-- end Nom -->

        <!-- start Email -->
        <div class="col-md-6">
          <label for="inputPassword4" class="form-label">Email</label>
          <asp:TextBox
            TextMode="Email"
            ID="Email"
            class="form-control"
            placeholder="Email"
            runat="server"
          ></asp:TextBox>
         <i class="fa-solid fa-envelope"></i>
          <asp:RequiredFieldValidator ValidationGroup="Addchercheur" ControlToValidate="Email"  ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!-- end Email -->

        <!-- start NomUtilisateur -->
        <div class="col-md-6">
          <label for="NomUtilisateur" class="form-label">Nom Utilisateur</label>
          <asp:TextBox
            TextMode="Email"
            ID="NomUtilisateur"
            class="form-control"
            placeholder="NomUtilisateur"
            runat="server"
          ></asp:TextBox>
          <i class="fa-solid fa-at"></i>
          <asp:RequiredFieldValidator ValidationGroup="Addchercheur" ControlToValidate="NomUtilisateur"  ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!-- end NomUtilisateur -->

        <!-- end Password -->
        <div class="col-md-6">
          <label for="inputPassword4" class="form-label">Mot de passe</label>
          <div class="input-group">
            <asp:TextBox
              class="z-pass form-control"
              placeholder="Mot de passe"
              TextMode="password"
              ID="Mot_de_pass"
              runat="server"
            ></asp:TextBox>
            <i class="fa-solid fa-lock"></i>
            <div class="eye-h input-group-text">
              <i class='fa-solid fa-eye'></i>
            </div>
          </div>
            <asp:RequiredFieldValidator ValidationGroup="Addchercheur" ControlToValidate="Mot_de_pass"  ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!-- end Password -->

        <!-- end Teléphone -->
        <div class="col-md-6">
          <label for="inputtele" class="form-label">Téléphone</label>
          <asp:TextBox
            class="form-control"
            type="tel"
            placeholder="Téléphone"
            ID="Teléphone"
            runat="server"
          ></asp:TextBox>
        <i class="fa-solid fa-phone"></i>
        <asp:RequiredFieldValidator ValidationGroup="Addchercheur" ControlToValidate="Teléphone"  ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!-- end Teléphone -->

        <!-- end Ville -->
        <div class="col-md-6">
          <label for="villezZOZO" class="form-label">Ville</label>
          <asp:TextBox
            class="form-control"
            placeholder="Ville"
            ID="Ville"
            runat="server"
          ></asp:TextBox>
            <i class="fa-solid fa-building"></i>
            <asp:RequiredFieldValidator ValidationGroup="Addchercheur" ControlToValidate="Ville"  ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!-- end Ville -->

        <div class="link-box mb-3"></div>
        <!-- start SendBtn-->
        <div class="col-12">
          <asp:Button
            class="Sign-btn btn btn-primary"
            ID="ButtonSign"
            runat="server"
            Text="S'inscrire" ValidationGroup="Addchercheur" OnClick="ButtonSign_Click"
          />
        </div>
        <!-- end SendBtn-->
      </form>
      <!-- start form -->
    </div>
    <!-- ---------------- end SignUp ---------------- -->

    <!-- import scripts js -->
    <script src="../../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../../Contents/MainStyle/Css/main.js"></script>
    <script src="../../Contents/MainStyle/Js/all.min.js"></script>
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
