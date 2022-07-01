using FindJob.Models;
using FindJob.Models.Database;
using System;
using System.Web;

namespace FindJob.Views
{
    public partial class Home : System.Web.UI.Page
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
    }
}