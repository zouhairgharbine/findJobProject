using FindJob.Models;
using FindJob.Models.Database;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace FindJob.Views.Entreprise
{
    public partial class profile : System.Web.UI.Page
    {
        protected void DesignJob(string Titre, int idJobs, string nomEnterpeise, string Description, double salaire, string Contrat, string Type, DateTime datePoster)
        {
            LinkButton btn = new LinkButton();
            btn.ID = idJobs.ToString();
            btn.Attributes.Add("onClick", "return confirm('Voulez-vous supprimer un élément ?');");
            btn.Click += new EventHandler(Supprime_Job_Btn);
            btn.Text = $@"
                <svg xmlns='http://www.w3.org/2000/svg' color='rgb(108 117 125)' width='20' height='20' fill='currentColor' class='bi bi-trash3-fill' viewBox='0 0 16 16'>
                <path d = 'M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z' />
                </svg>
            ";

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
                    <small class='text-muted'>{datePoster}</small>
                </div>
            ";


            HtmlGenericControl divCard = new HtmlGenericControl("div");
            divCard.Attributes.Add("class", "card");
            HtmlGenericControl divCardbody = new HtmlGenericControl("div");
            divCardbody.Attributes.Add("class", "card-body");
            divCard.Controls.Add(divCardbody);
            HtmlGenericControl h5 = new HtmlGenericControl("h5");
            h5.Attributes.Add("class", "card-title d-flex justify-content-between align-items-center");
            h5.Controls.Add(new LiteralControl(Titre));
            divCardbody.Controls.Add(h5);
            h5.Controls.Add(btn);
            divCardbody.Controls.Add(new LiteralControl(backup1));
            divCard.Controls.Add(new LiteralControl(back2));
            jobsbox.Controls.Add(divCard);

        }
        protected void DesignMessage(int idPost, string NamePost, string NameChercheur,int idchercheur, string Message, string cv, int idMessage)
        {
            HtmlGenericControl divMessage = new HtmlGenericControl("div");
            divMessage.Attributes.Add("class", "contentMesaage");

            HtmlGenericControl title = new HtmlGenericControl("h5");
            title.InnerHtml = $"Messages: <span style='color:gray;'>{NamePost}</sapn>";

            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes.Add("class", "d-inlineblock text-secondary");
            span.Attributes.Add("style", "cursor: pointer;");
            span.InnerText = NameChercheur;

            HtmlGenericControl discription = new HtmlGenericControl("div");
            discription.Attributes.Add("class", "py-2");
            discription.Attributes.Add("style", "font-size: 15px; height:70px; overflow-y:hidden;");
            discription.InnerText = Message;

            HtmlGenericControl boxbtn = new HtmlGenericControl("div");
            boxbtn.Attributes.Add("class", "btns mt-2 d-flex justify-content-between");

            LinkButton supprime = new LinkButton();
            supprime.CssClass = "btn btn-danger btn-sm";
            supprime.Click += new EventHandler(deleteMessage_Click);
            //supprime.ID = idMessage.ToString();
            supprime.Attributes.Add("data-id", idMessage.ToString());
            supprime.Text = "<i class='fa-solid fa-trash-can'></i> Supprimer";
            supprime.Attributes.Add("data-bs-toggle", "tooltip");
            supprime.Attributes.Add("data-bs-placement", "top");
            supprime.Attributes.Add("title", "supprimer");


            HtmlGenericControl Emptydiv = new HtmlGenericControl("div");
            Emptydiv.Attributes.Add("class", "Emptydiv");


            if (cv != null)
            {
                string download = $@"
                <a href='{cv}' type='button' class='btn btn-primary btn-sm' disabled id='Télécharger' download>
                    Téléchager CV
                </a>
            ";
                Emptydiv.Controls.Add(new LiteralControl(download));
            }
            Emptydiv.Controls.Add(supprime);

            //
            LinkButton send = new LinkButton();
            send.Text = "Réponse";
            //send.ID = idPost.ToString();
            send.Attributes.Add("data-id", idPost.ToString());
            send.Attributes.Add("data-idchercheur", idchercheur.ToString());
            send.Click += Send;
            send.CssClass = "btn btn-success btn-sm Sendbtn";

            boxbtn.Controls.Add(send);
            boxbtn.Controls.Add(Emptydiv);

            divMessage.Controls.Add(title);
            divMessage.Controls.Add(span);
            divMessage.Controls.Add(discription);
            divMessage.Controls.Add(boxbtn);

            MessagesBox2.Controls.Add(divMessage);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            profileUpload.Attributes["onchange"] = "UploadFile(this)";
            backImageUpload.Attributes["onchange"] = "UploadFile2(this)";

            HttpCookie cookie = Request.Cookies["UserId"];
            if (cookie != null)
            {
                int Id = Int32.Parse(cookie["Id"]);
                UserEntreprise entreprise = Ado.getWithId(Id);
                nameinnav.InnerText = entreprise.Nom;

                name.InnerText = entreprise.Nom;
                email.Text = entreprise.Email;
                phone.Text = entreprise.Téléphone;
                web.Text = entreprise.Siteweb;
                adresse.InnerText = entreprise.Adresse;
                jobsbox.InnerHtml = "";

                if (entreprise.ShowProfileImage() != "")
                {
                    profimage.ImageUrl = "data:Image/png;base64," + entreprise.ShowProfileImage();
                }

                if (entreprise.ShowBackImage() != "")
                {
                    backImage.ImageUrl = "data:Image/png;base64," + entreprise.ShowBackImage();
                }
                if (entreprise.ShowProfileImage() != "")
                {
                    Image1.ImageUrl = "data:Image/png;base64," + entreprise.ShowProfileImage();
                }

                if (entreprise.Postedjobs.Count > 0)
                {
                    foreach (var Job in entreprise.Postedjobs)
                    {
                        DesignJob(Job.Titre, Job.Id, entreprise.Nom, Job.Description, Job.Salaire, Job.Contrat, Job.Type, Job.dateCreation);
                    }
                }

                if (entreprise.getMessages().Count > 0)
                {
                    foreach (var EnterprisePostule in entreprise.getMessages())
                    {
                        DesignMessage(Jobs.getJob(EnterprisePostule.job.Id).Id, Jobs.getJob(EnterprisePostule.job.Id).Titre, Ado.getChercheur(EnterprisePostule.chercheur.Id).Nom, Ado.getChercheur(EnterprisePostule.chercheur.Id).Id, EnterprisePostule.Message, Ado.getChercheur(EnterprisePostule.chercheur.Id).Cv, EnterprisePostule.id);
                    }
                }
                else
                {
                    MessagesBox2.InnerHtml = @"
                        <div class='MessagesNotFound'>
                            <img src='../../Contents/Images/NoMessages.svg' alt='NotFoundMessages' />
                        </div>
                    ";
                }
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }
        protected void Add_Job_Btn(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserEntreprise entreprise = Ado.getWithId(Id);
            Jobs job = new Jobs(Description.Text, Contrat.Text, Convert.ToDouble(Salaire.Text), Type.Text, Titre.Text, Competences.Text);
            entreprise.AjouteJob(job);
            Response.Redirect(Request.RawUrl);
        }
        protected void Supprime_Job_Btn(object sender, EventArgs e)
        {
            LinkButton clicked = sender as LinkButton;
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserEntreprise entreprise = Ado.getWithId(Id);
            entreprise.SupprimeJob(Convert.ToInt32(clicked.ID));
            Response.Redirect(Request.RawUrl);
        }
        protected void dec_Click2(object sender, EventArgs e)
        {
            if (Request.Cookies["UserId"] != null)
            {
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("../Login.aspx");
            }
        }
        protected void Upload_Profile_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserEntreprise entreprise = Ado.getWithId(Id);
            byte[] bytes = null;
            HttpPostedFile postfile = profileUpload.PostedFile;
            string filename = Path.GetFileName(profileUpload.FileName);
            string fileextension = Path.GetExtension(profileUpload.FileName);

            if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".png")
            {
                Stream stream = postfile.InputStream;
                BinaryReader binaryreader = new BinaryReader(stream);
                bytes = binaryreader.ReadBytes((int)stream.Length);
                entreprise.UploadProfileImage(bytes);
            }
            else
            {
                Response.Write("error upload");
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void Upload_BackImage_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserEntreprise entreprise = Ado.getWithId(Id);
            byte[] bytes = null;
            HttpPostedFile postfile = backImageUpload.PostedFile;
            string filename = Path.GetFileName(backImageUpload.FileName);
            string fileextension = Path.GetExtension(backImageUpload.FileName);

            if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".png")
            {
                Stream stream = postfile.InputStream;
                BinaryReader binaryreader = new BinaryReader(stream);
                bytes = binaryreader.ReadBytes((int)stream.Length);
                entreprise.UploadBackImage(bytes);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Write("error upload");
            }
        }
        protected void deleteMessage_Click(object sender, EventArgs e)
        {
            LinkButton clicked = sender as LinkButton;
            UserEntreprise.deleteMessage(Convert.ToInt32(clicked.Attributes["data-id"]));
            Response.Redirect(Request.RawUrl);
        }
        protected void Send(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            if (cookie != null)
            {
                LinkButton clicked = sender as LinkButton;

                Response.Redirect($"MessagesReponse.aspx?IdPoste={Convert.ToInt32(clicked.Attributes["data-id"])}&idchercheur={clicked.Attributes["data-idchercheur"]}");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}