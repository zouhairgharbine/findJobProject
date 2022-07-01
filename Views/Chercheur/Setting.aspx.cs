using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using FindJob.Models;
using FindJob.Models.Database;

namespace FindJob.Views.Chercheur
{
    public partial class Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["UserId"];
                if (cookie == null)
                {
                    Response.Redirect("Login.aspx");
                }

                int Id = Int32.Parse(cookie["Id"]);
                UserChercheur chercheur = Ado.getChercheur(Id);
                nameinnav.InnerText = $"{chercheur.Prenom} {chercheur.Nom}";

                Prénom.Text = chercheur.Prenom;
                Nom.Text = chercheur.Nom;
                Email.Text = chercheur.Email;
                NomUtilisateur.Text = chercheur.NomUtilisateur;
                Teléphone.Text = chercheur.Téléphone;
                Ville.Text = chercheur.ville;

                if (chercheur.ShowBackImage() != "")
                {
                    Image1.ImageUrl = "data:Image/png;base64," + chercheur.ShowProfileImage();
                }
            }
        }
        protected void ButtonSign_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Idchercheur = Int32.Parse(cookie["Id"]);



            ////-------------------------//
            string folderPath = Server.MapPath($"~/Data/id_{Idchercheur}/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            ////Save the File to the Directory (Folder).
            if (TextBox1.HasFile)
            {
                TextBox1.SaveAs(folderPath + Path.GetFileName(TextBox1.FileName));
            }

            ////--------------------------//

            UserChercheur chercheur = new UserChercheur()
            {
                Id = Idchercheur,
                Prenom = Prénom.Text,
                Nom = Nom.Text,
                Email = Email.Text,
                NomUtilisateur = NomUtilisateur.Text,
                //Mot_de_passe = Mot_de_pass.Text,
                Téléphone = Teléphone.Text,
                ville = Ville.Text,
                //Cv = folderPath + Path.GetFileName(TextBox1.FileName),
                Cv = $"../../Data/id_{Idchercheur}/{TextBox1.FileName}",
            };
            try
            {
                chercheur.ModifyInfo();
                alert.InnerHtml = @"
                <div class='Login-Alert alert alert-success  alert-dismissible fade show' role='alert'>
                    <div class='d-flex'>
                    <i style='font-size:28px;color:#276347;' class='fa-solid fa-circle-check'></i>
                    <h4 class='mx-2' style='color:#276347 !important;'> Succès</h4> 
                    </div>
                        Opération avec succès.               
                    <a href=''>
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
            

            //Response.Redirect(Request.RawUrl);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Idchercheur = Int32.Parse(cookie["Id"]);

            UserChercheur chercheur = new UserChercheur()
            {
                Id = Idchercheur,
            };

            if (passconfirme.Text == chercheur.getPassword())
            {
                chercheur.DeleteAccount();
                if (Request.Cookies["UserId"] != null)
                {
                    Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Redirect("../Login.aspx");
            }
        }
        protected void dec_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserId"] != null)
            {
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("../Login.aspx");
            }
        }
        protected void HyperLink1_Click(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserChercheur chercheur = Ado.getChercheur(Id);

            string id = chercheur.Id.ToString();
            string fullName = $"{chercheur.Prenom} {chercheur.Nom}";
            string Email = chercheur.Email ;
            string Phone = chercheur.Téléphone;
            string Ville = chercheur.ville;

            DataTable dt = chercheur.getReport();

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    ////Generate Invoice (Bill) Header.
                    sb.Append("<br/>");
                    sb.Append("<h2 align='center'>Find jobs report</h2>");
                    sb.Append("<br/>");
                    sb.Append("<br/>");

                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");

                    sb.Append("<tr><td><b>Nom et Prénom: </b>");
                    sb.Append(fullName);

                    sb.Append("</td><td align = 'right' ><b>Email: </b>");
                    sb.Append(Email);
                    sb.Append("</td></tr>");


                    sb.Append("</td><td><b>Ville: </b>");
                    sb.Append(Ville);

                    sb.Append("<tr><td align = 'right' ><b>Téléphone </b>");
                    sb.Append(Phone);
                    sb.Append("</td></tr>");


                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<br />");

                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + id + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}