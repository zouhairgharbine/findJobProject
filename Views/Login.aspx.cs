using FindJob.Models.Database;
using System;
using System.Web;
using System.Web.UI;

namespace FindJob.Views
{
    public partial class Connexion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["UserId"];
                if (cookie != null)
                {
                    if (cookie["type"] == "Chercheur")
                    {
                        Response.Redirect("Chercheur/profile.aspx");
                    }
                    else
                    {
                        Response.Redirect("Entreprise/profile.aspx");
                    }
                }
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {

            
            string reselt = Ado.Login(UserName.Text, Mot_de_passe.Text);

            if (reselt == "enterprise")
            {
                HttpCookie cookie = new HttpCookie("UserId");
                cookie["Id"] = Ado.getId(UserName.Text, Mot_de_passe.Text, "Entreprise").ToString();
                cookie["type"] = "Entreprise";
                Response.Cookies.Add(cookie);
                Response.Redirect("Entreprise/profile.aspx");
            }
            else if (reselt == "chercheur")
            {
                HttpCookie cookie = new HttpCookie("UserId");
                cookie["Id"] = Ado.getId(UserName.Text, Mot_de_passe.Text, "Chercheur").ToString();
                cookie["type"] = "Chercheur";
                Response.Cookies.Add(cookie);
                Response.Redirect("Chercheur/profile.aspx");
            }
            else
            {
                Alertbox.InnerHtml = @"
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