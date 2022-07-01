<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="FindJob.Views.Entreprise.profile" %>

<!DOCTYPE html>
<html lang="en">
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
                    <div class="Messages">
                        <label for="ref">
                            <i style="cursor: pointer; transform: translateY(3px); color: white; font-size: 23px; margin-right: 10px;" class="fa-solid fa-message"></i>
                        </label>
                        <span class="icon-notif position-absolute top-3 start-80 translate-middle badge rounded-pill bg-danger">
                                <span class="visually-hidden">unread messages</span>
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
                                </a>
                            </li>
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
    <div id="contents" runat="server" class="container board">
      <!-- start backimg -->
        <div class="newdes">
            <div class="backImage">
                <asp:FileUpload ID="backImageUpload" CssClass="d-none" runat="server" />
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
            <div class="content">
            <div class="profile">
                <asp:FileUpload ID="profileUpload" CssClass="d-none" runat="server" />
                <asp:Button ID="Upload_Profile_Btn" runat="server" Text=" " OnClick="Upload_Profile_Click" style="display:none" />
                <asp:Image
                class="profile-img"
                ImageUrl="../../Contents/Images/profile.jpg"
                ID="profimage"
                runat="server"
                />
                <span>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-camera-fill" viewBox="0 0 16 16">
                      <path d="M10.5 8.5a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"/>
                      <path d="M2 4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V6a2 2 0 0 0-2-2h-1.172a2 2 0 0 1-1.414-.586l-.828-.828A2 2 0 0 0 9.172 2H6.828a2 2 0 0 0-1.414.586l-.828.828A2 2 0 0 1 3.172 4H2zm.5 2a.5.5 0 1 1 0-1 .5.5 0 0 1 0 1zm9 2.5a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0z"/>
                    </svg>
                </span>
            </div>
            <h3 id="name" runat="server">Name of Entreprise</h3>
            <label>Email:</label>
            <asp:HyperLink
                NavigateUrl="#"
                ID="email"
                runat="server"
                ></asp:HyperLink>
            <label>Téléphone:</label>
            <asp:HyperLink
                NavigateUrl="#"
                ID="phone"
                runat="server"
                ></asp:HyperLink
            >
            <label for="">adresse:</label>
            <span id="adresse" style="color:gray;display:block;" runat="server"></span>
            <label>site web:</label>
            <asp:HyperLink
                NavigateUrl="#"
                ID="web"
                runat="server"
                ></asp:HyperLink
            >
            </div>
        </div>
      <div class="experiences">
        <div class="titleExp">
          <h3>Postes</h3>
          <button type="button" class="Add-new-job btn btn-primary">Ajoute</button>
        </div>
        <div class="container">
          <div class="board">
            <div class="jobs" id="jobsbox" runat="server">
              <%-- RETURNED JOBS CODE FROM SERVER --%>
            </div>
          </div>
        </div>
    <!-- start jobs card -->
    <div class="boxJobs">
      <div class="Add-Experience-card body-singin p-8 container">
        <div class="sign-form row container" style="margin-bottom: 50px" ;>
          <div class="Title-login bg-primary p-3">Ajoute Emplois</div>
          <div class="col-md-6">
            <label for="inputPassword4" class="form-label">Titre</label>
              <asp:TextBox class="form-control" placeholder="Titre" ID="Titre" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ValidationGroup="addPost" ControlToValidate="Titre"  ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
          </div>
          <div class="col-md-6">
            <label for="inputEmail4" class="form-label">Salaire</label>
            <asp:TextBox class="form-control" placeholder="Salaire" ID="Salaire" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator  ValidationGroup="addPost" ControlToValidate="Salaire"  ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
          </div>
          <div class="col-md-6">
            <label for="inputEmail4" class="form-label">Type</label>
            <asp:DropDownList class="form-select" ID="Type" runat="server">
                  <asp:ListItem Enabled="true" Text="Travail" value="Travail"></asp:ListItem>
                  <asp:ListItem Text="Stage" value="Stage"></asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator  ValidationGroup="addPost" ControlToValidate="Type"  ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
          </div>
           <div class="col-md-6">
            <label for="inputEmail4" class="form-label">Contrat</label>
              <asp:DropDownList class="form-select" ID="Contrat" runat="server">
                  <asp:ListItem Enabled="true" Text="CDI" value="CDI"></asp:ListItem>
                  <asp:ListItem Text="CDD" value="CDD"></asp:ListItem>
              </asp:DropDownList>
            <asp:RequiredFieldValidator  ValidationGroup="addPost" ControlToValidate="Contrat"  ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>

          </div>
          <div class="col-md-12">
            <label for="inputEmail4" class="form-label">Description</label>
          </div>
          <div class="col-12">
           <asp:TextBox class="text-Mltipule form-control" TextMode="MultiLine" placeholder="Description" ID="Description" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator  ValidationGroup="addPost" ControlToValidate="Description"  ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>

          </div>
          <div class="col-md-12">
            <label for="inputEmail4" class="form-label">Competences</label>
          </div>
          <div class="col-12">
           <asp:TextBox class="text-Mltipule form-control" TextMode="MultiLine" placeholder="Competences" ID="Competences" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator  ValidationGroup="addPost" ControlToValidate="Competences"  ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="champ vide" Display="Dynamic" ></asp:RequiredFieldValidator>
          </div>
          <div class="col-12">
            <asp:Button class="Sign-btn btn btn-primary"  ValidationGroup="addPost" ID="Button2" OnClick="Add_Job_Btn" runat="server" Text="Ajoute" />
            <div class="Cancel-Jobs-btn Sign-btn btn btn-danger">cancel</div>
          </div>
        </div>
      </div>
    </div>
    <!-- end jobs card -->
     </div>
        <input class="tested" type="checkbox" style="display:none;" id="ref" />
        <div class="boxJobs">
            <div class="Messagebox container Add-Experience-card">
            <h4>
                Messages
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
      </form>
    <!-- start body-->

    <!-- import scripts js -->
    <script src="../../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../../Contents/MainStyle/Js/Upload.js"></script>
    <script src="../../Contents/MainStyle/Js/Eventhandel.js"></script>
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
  </body>
</html>


