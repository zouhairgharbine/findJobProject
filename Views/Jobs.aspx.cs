using FindJob.Models;
using FindJob.Models.Database;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FindJob.Views
{
    public partial class Emplois : System.Web.UI.Page
    {
        protected void DesignJob(int idchercheur, string Titre, string nomEnterpeise, int IdEnterprise, int idPost, string Description, double salaire, string Contrat, string Type, DateTime datePoster,string TypeAccount=null)
        {
            LinkButton send = new LinkButton();
            send.ID = idPost.ToString();
            if (UserChercheur.checkIfSend(Convert.ToInt32(send.ID), idchercheur))
            {
                send.Click += Send;
                send.CssClass = "btn btn-primary Sendbtn";
            }
            else
            {
                send.CssClass = "btn btn-primary disabled Sendbtn";
            }
            send.Text = "Envoyer";

            string backup1 = $@"
            <h6 class='card-subtitle mb-2 text-muted'>
                {nomEnterpeise}
            </h6>
            <p class='card-text'>
            {Description}
            </p>
            <div class='salair-box d-flex'>
                <div class='salair'>Salair: {salaire}DH</div>
                <div class='salair'>Contrat: {Contrat}</div>
                <div class='salair'>Type: {Type}</div>
            </div>

            ";
            string back2 = $@"
                <div class='card-footer'>
                    <small class='text-muted'>date Poster:  {datePoster.ToShortDateString()}</small>
                </div>
            ";


            HtmlGenericControl divCard = new HtmlGenericControl("div");
            divCard.Attributes.Add("class", "card");
            HtmlGenericControl divCardbody = new HtmlGenericControl("div");
            divCardbody.Attributes.Add("class", "card-body");
            divCard.Controls.Add(divCardbody);
            HtmlGenericControl h5 = new HtmlGenericControl("h4");
            h5.Attributes.Add("class", "card-title d-flex justify-content-between align-items-center");
            h5.Controls.Add(new LiteralControl(Titre));
            divCardbody.Controls.Add(h5);
            divCardbody.Controls.Add(new LiteralControl(backup1));
            if (TypeAccount == "Chercheur" || TypeAccount == null)
            {
                divCardbody.Controls.Add(send);
            }
            divCard.Controls.Add(new LiteralControl(back2));
            boardjobs.Controls.Add(divCard);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = 0;

            if (cookie != null)
            {
                Id = Int32.Parse(cookie["Id"]);
                if (cookie["type"] == "Entreprise")
                {
                    UserEntreprise entreprise = Ado.getWithId(Id);
                    nameinnav.InnerText = entreprise.Nom;

                    if (entreprise.ShowProfileImage() != "")
                    {
                        Image1.ImageUrl = "data:Image/png;base64," + entreprise.ShowProfileImage();
                    }
                }
                else
                {
                    UserChercheur chercheur = Ado.getChercheur(Id);
                    nameinnav.InnerText = $"{chercheur.Prenom} {chercheur.Nom}";

                    if (chercheur.ShowBackImage() != "")
                    {
                        Image1.ImageUrl = "data:Image/png;base64," + chercheur.ShowProfileImage();
                    }
                }
                
            }
            List<Jobs> Jobs = Ado.getJobs();

            boardjobs.InnerHtml = "";


            if (Request.Cookies["UserId"] != null)
            {
                foreach (var Job in Jobs)
                {
                    DesignJob(Id, Job.Titre, Job.Entreprise.Nom, Job.Id, Job.Entreprise.Id, Job.Description, Job.Salaire, Job.Contrat, Job.Type, Job.dateCreation,cookie["type"].ToString());
                }
            }
            else
            {
                foreach (var Job in Jobs)
                {
                    DesignJob(Id, Job.Titre, Job.Entreprise.Nom, Job.Id, Job.Entreprise.Id, Job.Description, Job.Salaire, Job.Contrat, Job.Type, Job.dateCreation, null);
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
        protected void Send(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            if (cookie != null)
            {
                LinkButton clicked = sender as LinkButton;

                Response.Redirect($"Message.aspx?IdPoste={clicked.ID}");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Recherchebtn_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            List<Jobs> SercherdJobs = Jobs.getJobsWithName(Recherchetextbox.Text);
            boardjobs.InnerHtml = "";
            if (Request.Cookies["UserId"] != null)
            {
                int Id = Int32.Parse(cookie["Id"]);
                foreach (var Job in SercherdJobs)
                {
                    DesignJob(Id,Job.Titre, Job.Entreprise.Nom, Job.Id, Job.Entreprise.Id, Job.Description, Job.Salaire, Job.Contrat, Job.Type, Job.dateCreation, cookie["type"].ToString());
                }
            }
            else
            {
                //int Id = Int32.Parse(cookie["Id"]);
                foreach (var Job in SercherdJobs)
                {
                    DesignJob(0,Job.Titre, Job.Entreprise.Nom, Job.Id, Job.Entreprise.Id, Job.Description, Job.Salaire, Job.Contrat, Job.Type, Job.dateCreation, null);
                }
            }
        }
        protected void GenerateXML()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlDataAdapter dt = new SqlDataAdapter("SELECT * FROM poste", con);
            DataSet ds = new DataSet();
            ds.DataSetName = "postes";
            dt.Fill(ds, "poste");
            ds.WriteXml(Server.MapPath("~/Api/poste.xml"));
        }

        protected void DownloadFile(string filePath)
        {
            Response.ContentType = "application/xml";
            Response.AddHeader("Content-Disposition", "attachment;filename=Emplois.xml");
            Response.WriteFile(filePath);
            Response.End();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GenerateXML();
            if (File.Exists(Server.MapPath("~/Api/poste.xml")))
            {
                DownloadFile(Server.MapPath("~/Api/poste.xml"));
            }
        }
    }
}
