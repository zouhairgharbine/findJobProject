using FindJob.Models.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FindJob.Models
{
    public class UserEntreprise : Utilisateur
    {
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Siteweb { get; set; }
        public string Specialité { get; set; }
        public List<Jobs> Postedjobs { get; set; }

        public UserEntreprise(string NomUtilisateur, string Mot_de_passe, string Nom, string Email, string Siteweb, string Specialité, string Téléphone, string Adresse)
        {
            this.Nom = Nom;
            this.Email = Email;
            this.Siteweb = Siteweb;
            this.Téléphone = Téléphone;
            this.Adresse = Adresse;
            this.Specialité = Specialité;
            this.NomUtilisateur = NomUtilisateur;
            this.Mot_de_passe = Mot_de_passe;
        }
        public UserEntreprise()
        {

        }
        public void SignIn()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "INSERTENTERPRISE";
                AppCommande.Parameters.Add("@PNOM", SqlDbType.VarChar).Value = this.Nom;
                AppCommande.Parameters.Add("@PEMAIL", SqlDbType.VarChar).Value = this.Email;
                AppCommande.Parameters.Add("@PNOMUTILISATEUR", SqlDbType.VarChar).Value = this.NomUtilisateur;
                AppCommande.Parameters.Add("@PMOTPASSE", SqlDbType.VarChar).Value = this.Mot_de_passe;
                AppCommande.Parameters.Add("@PTEL", SqlDbType.VarChar).Value = this.Téléphone;
                AppCommande.Parameters.Add("@PADRESSE", SqlDbType.VarChar).Value = this.Adresse;
                AppCommande.Parameters.Add("@PSITE", SqlDbType.VarChar).Value = this.Siteweb;
                AppCommande.Parameters.Add("@PSPESEALITE", SqlDbType.VarChar).Value = this.Specialité;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public void AjouteJob(Jobs job)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "AddJob";
                AppCommande.Parameters.Add("@Titre", SqlDbType.VarChar).Value = job.Titre;
                AppCommande.Parameters.Add("@Description", SqlDbType.VarChar).Value = job.Description;
                AppCommande.Parameters.Add("@Contrat", SqlDbType.VarChar).Value = job.Contrat;
                AppCommande.Parameters.Add("@Salaire", SqlDbType.Money).Value = job.Salaire;
                AppCommande.Parameters.Add("@Type", SqlDbType.VarChar).Value = job.Type;
                AppCommande.Parameters.Add("@Competences", SqlDbType.VarChar).Value = job.Competences;
                AppCommande.Parameters.Add("@IdEnterprise", SqlDbType.Int).Value = this.Id;


                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();

            }
        }
        public void SupprimeJob(int Idjob)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "DeleteJob";
                AppCommande.Parameters.Add("@IdJob", SqlDbType.Int).Value = Idjob;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public List<Postuler> getMessages()
        {

            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                List<Postuler> Messages = new List<Postuler>();
                SqlDataReader AppReader;
                DataTable Apptable = new DataTable();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "GetMessages";
                AppCommande.Parameters.Add("@IdEnterprise", SqlDbType.Int).Value = this.Id;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppReader = AppCommande.ExecuteReader();
                Apptable.Load(AppReader);
                AppConnection.Close();

                for (var i = 0; i < Apptable.Rows.Count; i++)
                {
                    Messages.Add(new Postuler
                    {
                        chercheur = new UserChercheur
                        {
                            Id = Convert.ToInt32(Apptable.Rows[i]["IdChercheur"]),
                        },
                        job = new Jobs
                        {
                            Id = Convert.ToInt32(Apptable.Rows[i]["IdPoste"]),
                        },
                        Message = Apptable.Rows[i]["Message"].ToString(),
                        id = Convert.ToInt32(Apptable.Rows[i]["id"]),
                    });
                }
                return Messages;
            }

        }
        public void UploadProfileImage(byte[] imageProfile)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "UploadImageENTER";
                AppCommande.Parameters.Add("@Image", SqlDbType.Image).Value = imageProfile;
                AppCommande.Parameters.Add("@IdEnterprise", SqlDbType.Int).Value = this.Id;
                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public void UploadBackImage(byte[] imageProfile)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "UploadbackImageENTER";
                AppCommande.Parameters.Add("@Image", SqlDbType.Image).Value = imageProfile;
                AppCommande.Parameters.Add("@IdEnterprise", SqlDbType.Int).Value = this.Id;
                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public string ShowProfileImage()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "returnImageEnter";
                AppCommande.Parameters.Add("@IdEnterprise", SqlDbType.Int).Value = this.Id;

                try
                {
                    if (AppConnection.State != ConnectionState.Open)
                    {
                        AppConnection.Open();
                    }
                    byte[] byteImage = (byte[])AppCommande.ExecuteScalar();
                    string imageString = Convert.ToBase64String(byteImage);
                    AppConnection.Close();
                    return imageString;
                }
                catch
                {
                    string imageString = "";
                    return imageString;
                }
            }
        }
        public string ShowBackImage()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "returnBackImageEnter";
                AppCommande.Parameters.Add("@IdEnterprise", SqlDbType.Int).Value = this.Id;

                try
                {
                    if (AppConnection.State != ConnectionState.Open)
                    {
                        AppConnection.Open();
                    }
                    byte[] byteImage = (byte[])AppCommande.ExecuteScalar();
                    string imageString = Convert.ToBase64String(byteImage);
                    AppConnection.Close();
                    return imageString;
                }
                catch
                {
                    string imageString = "";
                    return imageString;
                }
            }
        }
        public void ModifyInfo()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "ModifyENTERPRISE";
                AppCommande.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;
                AppCommande.Parameters.Add("@Email", SqlDbType.VarChar).Value = this.Email;
                AppCommande.Parameters.Add("@Nom", SqlDbType.VarChar).Value = this.Nom;
                AppCommande.Parameters.Add("@Adresse", SqlDbType.VarChar).Value = this.Adresse;
                AppCommande.Parameters.Add("@SiteWeb", SqlDbType.VarChar).Value = this.Siteweb;
                AppCommande.Parameters.Add("@Specialité", SqlDbType.VarChar).Value = this.Specialité;
                AppCommande.Parameters.Add("@Téléphone", SqlDbType.VarChar).Value = this.Téléphone;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public void DeleteAccount()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "DeleteAccountE";
                AppCommande.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public string getPassword()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "getPasswordE";
                AppCommande.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                string password = AppCommande.ExecuteScalar().ToString();
                AppConnection.Close();
                return password;
            }
        }
        public static void deleteMessage(int idMessage)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "deleteRepondre";
                AppCommande.Parameters.Add("@idrep", SqlDbType.Int).Value = idMessage;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public void sendRepondre(int idposte,string message, int idchercheure,int identerprise)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "sendrepondre";
                AppCommande.Parameters.Add("@idposte", SqlDbType.Int).Value = idposte;
                AppCommande.Parameters.Add("@message", SqlDbType.VarChar).Value = message;
                AppCommande.Parameters.Add("@IdChercheur", SqlDbType.Int).Value = idchercheure;
                AppCommande.Parameters.Add("@IdEnterprise", SqlDbType.Int).Value = identerprise;


                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public DataTable getReport()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataReader AppReader;
                DataTable Apptable = new DataTable();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "getreportEnter";
                AppCommande.Parameters.Add("@idEnterprise", SqlDbType.Int).Value = this.Id;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppReader = AppCommande.ExecuteReader();
                Apptable.Load(AppReader);
                AppConnection.Close();
                return Apptable;
            }
        }
    }
}