using FindJob.Models;
using FindJob.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindJob.Views.Entreprise
{
    public partial class MessagesReponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserEntreprise entreprise = Ado.getWithId(Id);

            if (cookie == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (entreprise.ShowProfileImage() != "")
            {
                Image1.ImageUrl = "data:Image/png;base64," + entreprise.ShowProfileImage();
            }
            nameinnav.InnerText = entreprise.Nom;
        }
        protected void dec_Click2(object sender, EventArgs e)
        {
            if (Request.Cookies["UserId"] != null)
            {
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("../Login.aspx");
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            int idPost = Convert.ToInt32(Request.QueryString["IdPoste"]);

            int idChercheur = Convert.ToInt32(Request.QueryString["idchercheur"]);
            string Message = Messagebox.Text;
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);

            UserEntreprise enterprise  = Ado.getWithId(Id);


            try
            {

                enterprise.sendRepondre(idPost, Message, idChercheur, Jobs.getEnterwithPost(idPost).Id);
                alert.InnerHtml = @"
                <div class='Login-Alert alert alert-success  alert-dismissible fade show' role='alert'>
                    <div class='d-flex'>
                    <i style='font-size:28px;color:#276347;' class='fa-solid fa-circle-check'></i>
                    <h4 class='mx-2' style='color:#276347 !important;'> Succès</h4> 
                    </div>
                        Postuler avec succès.               
                    <a href='profile.aspx'>
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
                    <a href='profile.aspx'>
                        <i class='fa-solid fa-xmark'></i>
                    </a>
                </div>";
            }
        }
    }
}