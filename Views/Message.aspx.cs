using FindJob.Models;
using FindJob.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindJob.Views
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            if (cookie != null)
            {
                if (cookie["type"] == "Entreprise")
                {
                    int Id = Int32.Parse(cookie["Id"]);
                    UserEntreprise entreprise = Ado.getWithId(Id);
                    nameinnav.InnerText = entreprise.Nom;
                    if (entreprise.ShowProfileImage() != "")
                    {
                        Image1.ImageUrl = "data:Image/png;base64," + entreprise.ShowProfileImage();
                    }
                }
                else
                {
                    int Id = Int32.Parse(cookie["Id"]);
                    UserChercheur chercheur = Ado.getChercheur(Id);
                    nameinnav.InnerText = $"{chercheur.Prenom} {chercheur.Nom}";

                    if (chercheur.ShowProfileImage() != "")
                    {
                        Image1.ImageUrl = "data:Image/png;base64," + chercheur.ShowProfileImage();
                    }
                }
            }

        }
        protected void dec_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserId"] != null)
            {
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("Login.aspx");
            }
        }
        protected void Send_Click(object sender, EventArgs e)
        {
            int idPost = Convert.ToInt32(Request.QueryString["IdPoste"]);
            string Message = Messagebox.Text;

            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);

            UserChercheur chercheur = Ado.getChercheur(Id);

            try
            {
                chercheur.Postuler(idPost, Message, Jobs.getEnterwithPost(idPost).Id, "notsend");
                alert.InnerHtml = @"
                <div class='Login-Alert alert alert-success  alert-dismissible fade show' role='alert'>
                    <div class='d-flex'>
                    <i style='font-size:28px;color:#276347;' class='fa-solid fa-circle-check'></i>
                    <h4 class='mx-2' style='color:#276347 !important;'> Succès</h4> 
                    </div>
                        Postuler avec succès.               
                    <a href='Jobs.aspx'>
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
                        Postuler avec erreur.                 
                    <a href=''>
                        <i class='fa-solid fa-xmark'></i>
                    </a>
                </div>";
            }
        }
    }
}