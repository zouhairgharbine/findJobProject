using FindJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindJob.Views.Chercheur
{
    public partial class Inscrire : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSign_Click(object sender, EventArgs e)
        {
            UserChercheur chercheur = new UserChercheur(NomUtilisateur.Text,Mot_de_pass.Text, Teléphone.Text,Email.Text,Nom.Text, Prénom.Text,Ville.Text);

            try
            {
                chercheur.SignIn();
                alert.InnerHtml = @"
                <div class='Login-Alert alert alert-success  alert-dismissible fade show' role='alert'>
                    <div class='d-flex'>
                    <i style='font-size:28px;color:#276347;' class='fa-solid fa-circle-check'></i>
                    <h4 class='mx-2' style='color:#276347 !important;'> Succès</h4> 
                    </div>
                        Opération avec succès.               
                    <a href='../Login.aspx'>
                        <i style='color:#276347;' class='fa-solid fa-xmark'></i>
                    </a>
                </div>";
            }
            catch
            {
                alert.InnerHtml = @"
                <div class='Login-Alert alert alert-danger  alert-dismissible fade show' role='alert'>
                    <div class='d-flex'>
                    <i style='font-size:28px' class='fa-solid fa-triangle-exclamation'></i>
                    <h4 class='mx-2'> Erreur</h4> 
                    </div>
                        Certains champs erronés.               
                    <a href=''>
                        <i class='fa-solid fa-xmark'></i>
                    </a>
                </div>";
            }
        }
    }
}