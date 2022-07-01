<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="FindJob.Views.Entreprise.Setting" %>

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
    <title>Paramètre</title>
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
                aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link" href="../Home.aspx">Accueil</a>
                    </li>
                    <%
                        HttpCookie cookie = Request.Cookies["UserId"];
                        if (cookie != null)
                        {
                            Response.Write($@"
                                <li class='nav-item'>
                                    <a class='nav-link' href='profile.aspx'>Profile</a>
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
                                <asp:LinkButton CssClass="dropdown-item" ID="dec" runat="server" OnClick="dec_Click">
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
        <div id="alert" runat="server"></div>
    <!-- ---------------- start SignUp ---------------- -->

    <div class=" p-8 container">
      <!--start titlebar -->
      <!--end titlebar -->

      <!--start form -->
      <div runat="server" class="sign-form row container" style="margin-top:20px;">
      <div class="p-3" style="font-size:30px;display:flex;justify-content:space-between; align-items:center;flex-wrap:wrap;">
          Modifier Informations
          <asp:LinkButton ID="HyperLink1" CssClass="report-Link" runat="server" OnClick="HyperLink1_Click">
            <i class="fa-solid fa-cloud-arrow-down"></i>
            Télécharger rapport
          </asp:LinkButton>
      </div>
        <!--start Nom-->
        <div class="col-md-6">
          <label for="Nom" class="form-label">Nom</label>
          <asp:TextBox
            placeholder="Nom"
            class="form-control"
            ID="Nom"
            runat="server"
          ></asp:TextBox>
            <i class="fa-solid fa-user-tie"></i>
            <asp:RequiredFieldValidator ValidationGroup="modifyenterprise" ControlToValidate="Nom"  ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!--end Nom-->

        <!--start Email-->
        <div class="col-md-6">
          <label for="Email" class="form-label">Email</label>
          <asp:TextBox
            TextMode="Email"
            ID="Email"
            class="form-control"
            placeholder="Email"
            runat="server"
          ></asp:TextBox>
        <i class="fa-solid fa-envelope"></i>
        <asp:RequiredFieldValidator ValidationGroup="modifyenterprise" ControlToValidate="Email"  ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!--end Email-->

        <!-- start NomUtilisateur -->
        <div class="col-md-6">
          <label for="NomUtilisateur" class="form-label">Nom Utilisateur</label>
          <asp:TextBox
            TextMode="Email"
            ID="NomUtilisateur"
            class="form-control"
            placeholder="NomUtilisateur"
            runat="server"
            disabled
          ></asp:TextBox>
        <i class="fa-solid fa-at"></i>
        </div>
        <!-- end NomUtilisateur -->
        <!--start  Teléphone-->
        <div class="col-md-6">
          <label for="Teléphone" class="form-label">Téléphone</label>
          <asp:TextBox
            class="form-control"
            type="tel"
            placeholder="Téléphone"
            ID="Téléphone"
            runat="server"
          ></asp:TextBox>
        <i class="fa-solid fa-phone"></i>
        <asp:RequiredFieldValidator ValidationGroup="modifyenterprise" ControlToValidate="Téléphone"  ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>

        </div>
        <!--end Teléphone-->

        <!--start Adresse-->
        <div class="col-md-6">
          <label for="Adresse" class="form-label">Adresse</label>
          <asp:TextBox
            class="form-control"
            placeholder="Adresse"
            ID="Adresse"
            runat="server"
          ></asp:TextBox>
            <i class="fa-solid fa-location-dot"></i>
            <asp:RequiredFieldValidator ValidationGroup="modifyenterprise" ControlToValidate="Adresse"  ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!--end Adresse-->

        <!--end siteWeb-->
        <div class="col-md-6">
          <label for="siteWeb" class="form-label">Site Web</label>
          <asp:TextBox
            class="form-control"
            placeholder="Site Web"
            ID="siteWeb"
            runat="server"
          ></asp:TextBox>
            <i class="fa-brands fa-safari"></i>
            <asp:RequiredFieldValidator ValidationGroup="modifyenterprise" ControlToValidate="siteWeb"  ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>

        </div>
        <!--end siteWeb-->

        <!--end Spécialité-->
        <div class="col-md-6">
          <label for="Spécialité" class="form-label">Spécialité</label>
          <asp:TextBox
            class="form-control"
            placeholder="Spécialité"
            ID="Spécialité"
            runat="server"
          ></asp:TextBox>
            <i class="fa-solid fa-briefcase"></i>
            <asp:RequiredFieldValidator ValidationGroup="modifyenterprise" ControlToValidate="Spécialité"  ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
        </div>
        <!--end Spécialité-->

        <!-- start SendBtn-->
        <div class="col-12">
          <asp:Button
            class="Sign-btn btn btn-primary"
            ID="ButtonSign"
            runat="server"
            Text="S'inscrire" ValidationGroup="modifyenterprise" OnClick="ButtonSign_Click"
          />
        </div>
        <!-- end SendBtn-->
      </div>
      <!--start form -->
    </div>
    <!-- ---------------- end SignUp ---------------- -->

        <!-- ---------------- start SignUp ---------------- -->
        <div class="Modify p-8 container">
          <!-- start form -->
          <div runat="server" class="sign-form row container">
          <div class="p-3" style="font-size:30px;">Supprimer le compte</div>
            <!-- end Password -->
            <div class="col-md-6">
              <label for="inputPassword4" class="form-label">
                  voulez-vous supprimer votre compte ?
              </label>
              <div class="input-group">
                <asp:TextBox
                  class="z-pass form-control"
                  placeholder="Mot de passe"
                  ID="passconfirme"
                  runat="server"
                ></asp:TextBox>
                <i class="fa-solid fa-lock"></i>
              </div>
            </div>
            <!-- end Password -->
            <div class="col-12">
              <asp:Button
                class="Sign-btn btn btn-danger"
                ID="Button2"
                runat="server"
                Text="Supprimer" 
                OnClick="Button2_Click"
              />
            </div>
          </div>
          <!-- start form -->
        </div>
        <!-- ---------------- end SignUp ---------------- -->
    </form>
    <script src="../../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../../Contents/MainStyle/Js/main.js"></script>
    <script src="../../Contents/MainStyle/Js/Upload.js"></script>
    <script src="../../Contents/MainStyle/Js/all.min.js"></script>
</body>
</html>
