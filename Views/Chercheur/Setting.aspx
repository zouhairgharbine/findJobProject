<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="FindJob.Views.Chercheur.Setting" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

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
<body id="body" runat="server">
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
                                    <a class='nav-link' href='Profile.aspx'>Profile</a>
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
                                <asp:LinkButton OnClick="dec_Click" CssClass="dropdown-item" ID="dec" runat="server">
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
        <div class="Modify p-8 container">
          <!-- start form -->
          <div runat="server" class="sign-form row container">
          <div class="p-3" style="font-size:30px;display:flex;justify-content:space-between; align-items:center;flex-wrap:wrap;">
              Modifier Informations
              <asp:LinkButton ID="HyperLink1" CssClass="report-Link" runat="server" OnClick="HyperLink1_Click">
                  <i class="fa-solid fa-cloud-arrow-down"></i>
                  Télécharger rapport
              </asp:LinkButton>
          </div>
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
            <asp:RequiredFieldValidator ValidationGroup="modifychercheur" ControlToValidate="Prénom"  ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
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
            <asp:RequiredFieldValidator ValidationGroup="modifychercheur" ControlToValidate="Nom"  ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
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
            <asp:RequiredFieldValidator ValidationGroup="modifychercheur" ControlToValidate="Email"  ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
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
                disabled
              ></asp:TextBox>
              <i class="fa-solid fa-at"></i>
            </div>
            <!-- end NomUtilisateur -->

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
            <asp:RequiredFieldValidator ValidationGroup="modifychercheur" ControlToValidate="Teléphone"  ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ValidationGroup="modifychercheur" ControlToValidate="Ville"  ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
            <!-- end Ville -->

            <!-- start Cv -->
            <div class="col-md-6">
              <label for="villezZOZO" class="form-label">Cv</label>
              <asp:FileUpload
                class="form-control px-2"
                placeholder="Ville"
                ID="TextBox1"
                runat="server"
              ></asp:FileUpload>
            </div>
            <!-- end Cv -->

            <div class="link-box mb-3"></div>
            <!-- start SendBtn-->
            <div class="col-12">
              <asp:Button
                class="Sign-btn btn btn-primary"
                ID="ButtonSign"
                runat="server"
                Text="Modifier" ValidationGroup="modifychercheur" OnClick="ButtonSign_Click"
              />
            </div>
            <!-- end SendBtn-->
          </div>
          <!-- start form -->
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
                  class="deleteA z-pass form-control"
                  placeholder="Mot de passe"
                  TextMode="password"
                  ID="passconfirme"
                  runat="server"
                ></asp:TextBox>
                <i color="#dc3545" class="fa-solid fa-lock"></i>
              </div>
                <asp:RequiredFieldValidator ValidationGroup="deletechercheur" ControlToValidate="passconfirme"  ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
            </div>
            <!-- end Password -->
            <div class="col-12">
              <asp:Button
                class="Sign-btn btn btn-danger"
                ID="Button2"
                runat="server"
                Text="Supprimer" OnClick="Button2_Click"
                ValidationGroup="deletechercheur"
              />
            </div>
          </div>
          <!-- start form -->
        </div>
        <!-- ---------------- end SignUp ---------------- -->
    <script src="../../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../../Contents/MainStyle/Js/main.js"></script>
    <script src="../../Contents/MainStyle/Js/Upload.js"></script>
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
    </form>
    </body>
</html>
