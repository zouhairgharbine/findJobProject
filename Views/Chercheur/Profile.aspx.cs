using FindJob.Models;
using FindJob.Models.Database;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FindJob.Views.Chercheur
{
    public partial class Profile : System.Web.UI.Page
    {
        // Return Design Experience //
        protected void DesignExperience(int idExp, string nameCompany, string description, DateTime dateDébut, DateTime datefin)
        {
            LinkButton btn = new LinkButton();
            btn.ID = idExp.ToString();
            btn.Click += new EventHandler(Supprime_Experience_btn);
            btn.Attributes.Add("onClick", "return confirm('Voulez-vous supprimer un élément ?');");
            btn.Text = $@"
                <i style='color:gray;' class='fa-solid fa-trash-can'></i>
            ";

            HtmlGenericControl divExp = new HtmlGenericControl("div");
            HtmlGenericControl divCard = new HtmlGenericControl("div");
            divCard.Attributes.Add("class", "card-header d-flex justify-content-between align-items-center");
            divExp.Attributes.Add("class", "exp");
            divExp.Controls.Add(divCard);
            string divImag = @"
                       <div>
                            <img src = '../../Contents/Images/experience.png' alt='iconExp' />
                            Experience           
                        </div>
            ";
            divCard.Controls.Add(new LiteralControl(divImag));
            divCard.Controls.Add(btn);
            string back = $@"
                  <label>Name Company:</label>
                  <p id='nameCompany' runat='server'>
                   {nameCompany}
                  </p>
                  <label>description</label>
                  <p id = 'description' runat= 'server'>
                  {description}
                  </p>
                  <label>Date débute:</label>
                  <p id='dateStart' runat= 'server'> {dateDébut} </p>
                  <label> Date fin:</label>
                  <p id = 'dateEnd' runat= 'server'> {datefin} </p>
            ";
            divExp.Controls.Add(new LiteralControl(back));
            boxExp.Controls.Add(divExp);
        }
        // Return Design Diplome //
        protected void DesignDiplome(int IdDiplome, string NameDiplome, string SpecDiplome)
        {
            LinkButton btn = new LinkButton();
            btn.ID = IdDiplome.ToString();
            btn.Click += new EventHandler(Supprime_Diplome_btn);
            btn.Attributes.Add("onClick", "return confirm('Voulez-vous supprimer un élément ?');");
            btn.Text = $@"
                    <i style='color:gray;' class='fa-solid fa-trash-can'></i>
            ";
            HtmlGenericControl div = new HtmlGenericControl("div");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div.Attributes.Add("class", "exp diplome");
            boxDiplome.Controls.Add(div);
            div1.Attributes.Add("class", "card-header d-flex justify-content-between align-items-center");
            div.Controls.Add(div1);
            div1.InnerHtml = $@"
            <div>
                <img src = '../../Contents/Images/diplome.png' alt='iconDiplome' />
                Diplome
            </div>
            ";
            div1.Controls.Add(btn);
            string html = $@"
                  <label>Nom de diplome:</label>
                  <p>{NameDiplome}</p>
                  <label>Specialité diplome:</label>
                  <p>{SpecDiplome}</p>
            ";
            div.Controls.Add(new LiteralControl(html));
        }
        // Loading Page //
        protected void DesignMessage(string NamePost, string NameEnterprise, string Message, int idMessage)
        {
            HtmlGenericControl divMessage = new HtmlGenericControl("div");
            divMessage.Attributes.Add("class", "contentMesaage");

            HtmlGenericControl title = new HtmlGenericControl("h5");
            title.InnerHtml = $"Messages: <span style='color:gray;'>{NamePost}</sapn>";

            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes.Add("class", "d-inlineblock text-secondary");
            span.Attributes.Add("style", "cursor: pointer;");
            span.InnerText = NameEnterprise;

            HtmlGenericControl discription = new HtmlGenericControl("div");
            discription.Attributes.Add("class", "py-2");
            discription.Attributes.Add("style", "font-size: 15px; height:70px; overflow-y:hidden;");
            discription.InnerText = Message;

            HtmlGenericControl boxbtn = new HtmlGenericControl("div");
            boxbtn.Attributes.Add("class", "btns mt-2 d-flex justify-content-between");

            LinkButton supprime = new LinkButton();
            supprime.CssClass = "btn btn-danger btn-sm";
            supprime.Click += new EventHandler(deleteMessage_Click);
            supprime.Attributes.Add("data-id", idMessage.ToString());
            supprime.Text = "<i class='fa-solid fa-trash-can'></i> Supprimer";
            supprime.Attributes.Add("data-bs-toggle", "tooltip");
            supprime.Attributes.Add("data-bs-placement", "top");
            supprime.Attributes.Add("title", "supprimer");


            HtmlGenericControl Emptydiv = new HtmlGenericControl("div");
            Emptydiv.Attributes.Add("class", "Emptydiv");

            Emptydiv.Controls.Add(supprime);

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

                UserChercheur chercheur = Ado.getChercheur(Id);
                name.InnerText = $"{chercheur.Prenom} {chercheur.Nom}";
                email.Text = chercheur.Email;
                phone.Text = chercheur.Téléphone;
                ville.InnerText = chercheur.ville;
                nameinnav.InnerText = $"{chercheur.Prenom} {chercheur.Nom}";

                if (chercheur.ShowProfileImage() != "")
                {
                    profile2.ImageUrl = "data:Image/png;base64," + chercheur.ShowProfileImage();
                }

                if (chercheur.ShowBackImage() != "")
                {
                    backImage.ImageUrl = "data:Image/png;base64," + chercheur.ShowBackImage();
                }

                if (chercheur.ShowBackImage() != "")
                {
                    Image1.ImageUrl = "data:Image/png;base64," + chercheur.ShowProfileImage();
                }

                if (chercheur.Diplomes.Count > 0)
                {
                    foreach (var Dep in chercheur.Diplomes)
                    {
                        DesignDiplome(Dep.Id, Dep.Nom, Dep.Specialité);
                    }
                }
                else
                {
                    boxDiplome.Attributes.Add("style", "display:block;");
                    boxDiplome.InnerHtml = @"
                            <div style='position: relative; opacity:.5; left: 50%;transform: translateX(-50%);width:fit-content;' class='dox-data-nfount'>
                                 <img style='height:7rem;' src='../../Contents/Images/NoData.svg' alt='NoDataImage' />
                                 <p style='text-align:center;color:black;'>No Diplome</p>
                            </div>
                    ";
                }

                if (chercheur.Experiences.Count > 0)
                {

                    foreach (var Exp in chercheur.Experiences)
                    {
                        DesignExperience(Exp.Id, Exp.Société, Exp.Description, Exp.DateDébut, Exp.DateFin);
                    }
                }
                else
                {
                    boxExp.Attributes.Add("style", "display:block;");
                    boxExp.InnerHtml = @"
                            <div style='position: relative;opacity:.5;left: 50%;transform: translateX(-50%);width:fit-content;' class='dox-data-nfount'>
                                 <img style='height:7rem;' src='../../Contents/Images/NoData.svg' alt='NoDataImage' />
                                 <p style='text-align:center;color:black;'>No Experience</p>
                            </div>
                    ";
                }

                if (chercheur.getMessages().Count > 0)
                {
                    foreach (var messageRepondre in chercheur.getMessages())
                    {
                        DesignMessage(Jobs.getJob(messageRepondre.Répondre_Job.Id).Titre, Ado.getWithId(messageRepondre.Répondre_Enterprise.Id).Nom, messageRepondre.Message, messageRepondre.Id);
                    }
                }

                if (cookie["type"] == "Entreprise")
                {
                    int id = Int32.Parse(cookie["Id"]);
                    UserEntreprise entreprise = Ado.getWithId(id);
                    nameinnav.InnerText = entreprise.Nom;

                }
                else
                {
                    int id = Int32.Parse(cookie["Id"]);
                    nameinnav.InnerText = $"{chercheur.Prenom} {chercheur.Nom}";
                }
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }
        protected void Ajout_Diplome_btn(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserChercheur chercheur = Ado.getChercheur(Id);

            chercheur.AjouteDiplome(NomDiplome.Text, Spécialité.Text);

            Response.Redirect(Request.RawUrl);
        }
        protected void Supprime_Diplome_btn(object sender, EventArgs e)
        {
            LinkButton clicked = sender as LinkButton;
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserChercheur chercheur = Ado.getChercheur(Id);
            chercheur.SupprimeDiplome(Convert.ToInt32(clicked.ID));
            Response.Redirect(Request.RawUrl);
        }
        protected void Ajout_Experience_btn(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserChercheur chercheur = Ado.getChercheur(Id);
            chercheur.AjouteExperience(Description.Text, Societe.Text, Convert.ToDateTime(datedebut.Text), Convert.ToDateTime(datefin.Text));
            Response.Redirect(Request.RawUrl);
        }
        protected void Supprime_Experience_btn(object sender, EventArgs e)
        {
            LinkButton clicked = sender as LinkButton;
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserChercheur chercheur = Ado.getChercheur(Id);
            chercheur.SupprimeExperience(Convert.ToInt32(clicked.ID));
            Response.Redirect(Request.RawUrl);
        }
        protected void Upload_Profile_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserId"];
            int Id = Int32.Parse(cookie["Id"]);
            UserChercheur chercheur = Ado.getChercheur(Id);
            byte[] bytes = null;
            HttpPostedFile postfile = profileUpload.PostedFile;
            string filename = Path.GetFileName(profileUpload.FileName);
            string fileextension = Path.GetExtension(profileUpload.FileName);

            if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".png")
            {
                Stream stream = postfile.InputStream;
                BinaryReader binaryreader = new BinaryReader(stream);
                bytes = binaryreader.ReadBytes((int)stream.Length);
                chercheur.UploadProfileImage(bytes);
                Response.Redirect(Request.RawUrl);
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
            UserChercheur chercheur = Ado.getChercheur(Id);
            byte[] bytes = null;
            HttpPostedFile postfile = backImageUpload.PostedFile;
            string filename = Path.GetFileName(backImageUpload.FileName);
            string fileextension = Path.GetExtension(backImageUpload.FileName);

            if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".png")
            {
                Stream stream = postfile.InputStream;
                BinaryReader binaryreader = new BinaryReader(stream);
                bytes = binaryreader.ReadBytes((int)stream.Length);
                chercheur.UploadBackImage(bytes);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Write("error upload");
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void dec_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserId"] != null)
            {
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("../Login.aspx");
            }
        }
        protected void deleteMessage_Click(object sender, EventArgs e)
        {
            LinkButton clicked = sender as LinkButton;
            UserEntreprise.deleteMessage(Convert.ToInt32(clicked.Attributes["data-id"]));
            Response.Redirect(Request.RawUrl);
        }
    }
}