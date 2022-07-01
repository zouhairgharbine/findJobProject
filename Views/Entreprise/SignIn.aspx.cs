using FindJob.Models;
using FindJob.Models.Database;
using System;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Xml;

namespace FindJob.Views.Entreprise
{
    public partial class Inscrire : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            profileUpload.Attributes["onchange"] = "UploadFile(this)";
        }
        protected void ButtonSign_Click(object sender, EventArgs e)
        {
            UserEntreprise entreprise = new UserEntreprise(NomUtilisateur.Text, Password.Text, Nom.Text, Email.Text, siteWeb.Text, Spécialité.Text, Téléphone.Text, Adresse.Text);
            try
            {
                entreprise.SignIn();

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
            //Response.Redirect("~/Views/Login.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            ////-------------------------//
            string folderPath = Server.MapPath($"~/xmlReader/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            ////Save the File to the Directory (Folder).
            if (profileUpload.HasFile)
            {
                profileUpload.SaveAs(folderPath + Path.GetFileName(profileUpload.FileName));
            }

            ////--------------------------//

            DataTable Apptable = new DataTable();
            XmlDocument Xdoc = new XmlDocument();
            Xdoc.Load(folderPath + Path.GetFileName(profileUpload.FileName));

            XmlNodeList nodelist = Xdoc.SelectNodes("Entreprises/Entreprise");
            int NodeListCount = nodelist.Count;
            int pass = 0;

            foreach (XmlNode node in nodelist)
            {
                UserEntreprise entreprise = new UserEntreprise
                {
                    Nom = node.SelectSingleNode("Nom").InnerText,
                    Email = node.SelectSingleNode("Email").InnerText,
                    NomUtilisateur = node.SelectSingleNode("username").InnerText,
                    Mot_de_passe = node.SelectSingleNode("password").InnerText,
                    Téléphone = node.SelectSingleNode("phone").InnerText,
                    Adresse = node.SelectSingleNode("Adresse").InnerText,
                    Siteweb = node.SelectSingleNode("Siteweb").InnerText,
                    Specialité = node.SelectSingleNode("Specialité").InnerText,
                };
                try
                {
                    entreprise.SignIn();
                    pass++;
                }
                catch
                {
                    
                }

                alert.InnerHtml = $@"
                <div class='Login-Alert alert alert-info  alert-dismissible fade show' role='alert'>
                    <div class='d-flex'>
                    <i style='font-size:28px;' class='fa-solid fa-circle-info'></i>
                    <h4 class='mx-2' style='color:#276347 !important;'> MessageInfo</h4> 
                    </div>
                        insérer {pass} sur {NodeListCount}       
                    <a href='../Login.aspx'>
                        <i style='color:#276347;' class='fa-solid fa-xmark'></i>
                    </a>
                </div>";
            }


        }
    }
}