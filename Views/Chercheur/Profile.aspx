<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs"
Inherits="FindJob.Views.Chercheur.Profile"%>
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
   <form runat="server">
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
                                    <a class='Job-link nav-link' href=''>Profile</a>
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
                    <div class="Messages">
                        <label for="ref">
                            <i style="cursor: pointer; transform: translateY(3px); color: white; font-size: 23px; margin-right: 10px;" class="fa-solid fa-message"></i>
                        </label>
                        <span class="icon-notif position-absolute top-3 start-80 translate-middle badge rounded-pill bg-danger">
                              0  
                        </span>
                    </div>  
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
                          <li><a class="dropdown-item" href="Setting.aspx">
                              <i class="fa-solid fa-gear"></i>
                              Paramètre
                              </a></li>
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
    <!-- end navbar -->

    <!-- start body -->
    <div runat="server" id="formInfo" class="container board">
    <div class="newdes">
        <!-- start backimg -->
        <div class="backImage">
            <asp:FileUpload ID="backImageUpload"  CssClass="d-none" runat="server" />
            <asp:Button ID="Upload_back_Btn" runat="server" Text="" OnClick="Upload_BackImage_Click" style="display:none" />
            <span>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-images" viewBox="0 0 16 16">
                  <path d="M4.502 9a1.5 1.5 0 1 0 0-3 1.5 1.5 0 0 0 0 3z"/>
                  <path d="M14.002 13a2 2 0 0 1-2 2h-10a2 2 0 0 1-2-2V5A2 2 0 0 1 2 3a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2v8a2 2 0 0 1-1.998 2zM14 2H4a1 1 0 0 0-1 1h9.002a2 2 0 0 1 2 2v7A1 1 0 0 0 15 11V3a1 1 0 0 0-1-1zM2.002 4a1 1 0 0 0-1 1v8l2.646-2.354a.5.5 0 0 1 .63-.062l2.66 1.773 3.71-3.71a.5.5 0 0 1 .577-.094l1.777 1.947V5a1 1 0 0 0-1-1h-10z"/>
                </svg>
            </span>
        <asp:Image
            ID="backImage"
            ImageUrl="../../Contents/Images/back.jpg"
            AlternateText="backImage"
            runat="server"
        />
        </div>
        <!-- end backimg -->

        <!-- start content -->
        <div class="content">
        <div class="profile">
            <asp:FileUpload ID="profileUpload" CssClass="d-none" runat="server" />
           <asp:Button ID="Upload_Profile_Btn" runat="server" Text=" " OnClick="Upload_Profile_Click" style="display:none" />
            <asp:Image
            class="profile-img"
            ImageUrl="../../Contents/Images/profile.jpg"
            ID="profile2"
            runat="server"
            />
            <span>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-camera-fill" viewBox="0 0 16 16">
                  <path d="M10.5 8.5a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"/>
                  <path d="M2 4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V6a2 2 0 0 0-2-2h-1.172a2 2 0 0 1-1.414-.586l-.828-.828A2 2 0 0 0 9.172 2H6.828a2 2 0 0 0-1.414.586l-.828.828A2 2 0 0 1 3.172 4H2zm.5 2a.5.5 0 1 1 0-1 .5.5 0 0 1 0 1zm9 2.5a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0z"/>
                </svg>
            </span>
        </div>
        <h3 id="name" runat="server">Name of CHercheur</h3>
        <label>Email:</label>
        <asp:HyperLink
            NavigateUrl="#"
            ID="email"
            runat="server"
            ></asp:HyperLink
        >

        <label for="">Téléphone:</label>
        <asp:HyperLink
            NavigateUrl="mailto:zouhair@gmail.com"
            ID="phone"
            runat="server"
            ></asp:HyperLink
        >
        <label for="">Ville:</label>
        <p runat="server" id="ville">Casablanca</p>
        </div>
        <!-- end content -->
    </div>
        <div class="experiences">
            <div class="titleExp">
                <h3 id="experience" runat="server">Experience</h3>
                <div id="Add" class="Add-Ex Add-Experience btn btn-primary">Ajouter</div>
            </div>
            <div class="boxExp" id="boxExp" runat="server">
                <!--GET ALL EXPERIENCE'S CHERCHEUR FROM DATABASE -->
            </div>
        </div>
      <div class="diplome">
        <div class="titleDip">
          <h3 id="diplome" runat="server">Diplome</h3>
          <div id="adddiplome" class="Add-Diplome btn btn-primary">Ajouter</div>
        </div>
        <div class="boxDip" id="boxDiplome" runat="server">
        <!--GET ALL DIPLOMES'S CHERCHEUR FROM DATABASE -->
        </div>
      </div>
    <!-- start diplome card -->
    <div class="boxdip">
      <div class="Add-Diplome-card body-singin p-8 container">
        <div class="sign-form row container" style="margin-bottom: 50px" ;>
          <div class="Title-login bg-primary p-3">Ajoute Diplome</div>
          <div class="col-md-6">
            <label for="inputPassword4" class="form-label"
              >Nom de diplome</label
            >
              <asp:TextBox class="form-control" placeholder="Nom de diplome" ID="NomDiplome" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ValidationGroup="AddDiplome" ControlToValidate="NomDiplome"  ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>

          </div>
          <div class="col-md-6">
            <label for="inputEmail4" class="form-label">Spécialité</label>
              <asp:TextBox class="form-control" placeholder="Spécialité" ID="Spécialité" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ValidationGroup="AddDiplome" ControlToValidate="Spécialité"  ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
          </div>
          <div class="link-box mb-3"></div>
          <div class="col-12">
            <asp:Button class="Sign-btn btn btn-primary" ValidationGroup="AddDiplome" ID="Button1" runat="server" OnClick="Ajout_Diplome_btn" Text="Ajoute" />
            <div class="Cancel-btn Sign-btn btn btn-danger">cancel</div>
          </div>
        </div>
      </div>
    </div>
    <!-- end diplome card -->

    <!-- start experience card -->
    <div class="boxEXp">
      <div class="Add-Experience-card body-singin p-8 container">
        <div class="sign-form row container" style="margin-bottom: 50px" ;>
          <div class="Title-login bg-primary p-3">Ajoute Experience</div>
          <div class="col-md-12">
            <label for="inputPassword4" class="form-label">Societe</label>
              <asp:TextBox class="form-control" placeholder="Societe" ID="Societe" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ValidationGroup="AddExpirence" ControlToValidate="Societe"  ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
          </div>
          <div class="col-md-6">
            <label for="inputEmail4" class="form-label">DateDebut</label>
            <asp:TextBox TextMode="Date" class="form-control" placeholder="DateDebut" ID="datedebut" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="AddExpirence" ControlToValidate="datedebut"  ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>

          </div>
          <div class="col-md-6">
            <label for="inputEmail4" class="form-label">DateFin</label>
            <asp:TextBox TextMode="Date" class="form-control" placeholder="DateFin" ID="datefin" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="AddExpirence" ControlToValidate="datefin"  ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>

          </div>
          <div class="col-md-12">
            <label for="inputEmail4" class="form-label">Description</label>
          </div>
          <div class="col-12">
           <asp:TextBox class="text-Mltipule form-control" TextMode="MultiLine" placeholder="Description" ID="Description" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="AddExpirence" ControlToValidate="Description"  ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
          </div>
          <div class="col-12">
            <asp:Button ValidationGroup="AddExpirence" class="Sign-btn btn btn-primary" ID="Button2" runat="server" OnClick="Ajout_Experience_btn" Text="Ajoute" />
            <div class="Cancel-Ex-btn Sign-btn btn btn-danger">cancel</div>
          </div>
        </div>
      </div>
    </div>
    <!-- end experience card -->
        <input class="tested" type="checkbox" style="display:none;" id="ref" />
        <div class="boxJobs">
            <div class="Messagebox container Add-Experience-card">
                <h4>Messages
                <label for="ref">
                    <i class="fa-solid fa-xmark"></i>
                </label>
                </h4>
                <div class="MessagesBox" runat="server" id="MessagesBox2">
                    <!-- get data from database -->
                </div>
            </div>
        </div>
    </div>
    <!-- end body -->
      </form>
    <!-- import scripts js -->
    <script src="../../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../../Contents/MainStyle/Js/Upload.js"></script>
    <script src="../../Contents/MainStyle/Js/main.js"></script>
    <script>
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=Upload_Profile_Btn.ClientID%>").click();
            }
        }

        function UploadFile2(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%=Upload_back_Btn.ClientID%>").click();
            }
        }
    </script>
    <script>
        /* start number of navigator icon */

        let contentMesaage = document.querySelectorAll(".contentMesaage");
        let iconNotif = document.querySelector(".icon-notif");

        if (contentMesaage.length == 0) {
            iconNotif.remove();
        } else {
            iconNotif.innerHTML = contentMesaage.length;
        }
        console.log(contentMesaage.length)

        /* end number of navigator icon */
    </script>
  </body>
</html>