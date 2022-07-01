using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FindJob.Models
{
    public class UserChercheur : Utilisateur
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Cv { get; set; }
        public string ville { get; set; }
        public List<Jobs> theJobs { get; set; }
        public List<Diplome> Diplomes { get; set; }
        public List<Experience> Experiences { get; set; }

        public UserChercheur() { }
        public UserChercheur(string NomUtilisateur, string Mot_de_passe, string Téléphone, string Email, string Nom, string Prenom, string ville)
        {
            this.NomUtilisateur = NomUtilisateur;
            this.Mot_de_passe = Mot_de_passe;
            this.Téléphone = Téléphone;
            this.Email = Email;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.ville = ville;
        }

        public void SignIn()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "SIGNCHERCHUER";
                AppCommande.Parameters.Add("@PRENOM", SqlDbType.VarChar).Value = this.Nom;
                AppCommande.Parameters.Add("@NOM", SqlDbType.VarChar).Value = this.Prenom;
                AppCommande.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = this.Email;
                AppCommande.Parameters.Add("@NOMUTILISATUER", SqlDbType.VarChar).Value = this.NomUtilisateur;
                AppCommande.Parameters.Add("@MOTDEPASS", SqlDbType.VarChar).Value = this.Mot_de_passe;
                AppCommande.Parameters.Add("@TELEPHONE", SqlDbType.VarChar).Value = this.Téléphone;
                AppCommande.Parameters.Add("@VILLE", SqlDbType.VarChar).Value = this.ville;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public void AjouteExperience(string Description, string Société, DateTime DateDébut, DateTime DateFin)
        {
            Experience MyExperience = new Experience(Description, Société, DateDébut, DateFin, this);
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "AddExperience";
                AppCommande.Parameters.Add("@Description", SqlDbType.VarChar).Value = MyExperience.Description;
                AppCommande.Parameters.Add("@Societe", SqlDbType.VarChar).Value = MyExperience.Société;
                AppCommande.Parameters.Add("@DateDebut", SqlDbType.DateTime).Value = MyExperience.DateDébut;
                AppCommande.Parameters.Add("@DateFin", SqlDbType.DateTime).Value = MyExperience.DateFin;
                AppCommande.Parameters.Add("@idChercheur", SqlDbType.Int).Value = MyExperience.chercheur.Id;


                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();

            }
        }
        public void SupprimeExperience(int IdExperience)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "DeleteExperience";
                AppCommande.Parameters.Add("@IdExp", SqlDbType.Int).Value = IdExperience;


                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();

            }
        }
        public bool AjouteDiplome(string NameDiplome, string Spécialité)
        {
            Diplome MyDiplome = new Diplome(NameDiplome, Spécialité, this);
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "AddDiplome";
                AppCommande.Parameters.Add("@NomDiplome", SqlDbType.VarChar).Value = MyDiplome.Nom;
                AppCommande.Parameters.Add("@Spécialité", SqlDbType.VarChar).Value = MyDiplome.Specialité;
                AppCommande.Parameters.Add("@IdChercheur", SqlDbType.Int).Value = MyDiplome.ChercheurDiplome.Id;
                try
                {
                    if (AppConnection.State != ConnectionState.Open)
                    {
                        AppConnection.Open();
                    }
                    AppCommande.ExecuteNonQuery();
                    AppConnection.Close();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public bool SupprimeDiplome(int IdDiplome)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "DeleteDiplome";
                AppCommande.Parameters.Add("@IdDIPLOME", SqlDbType.Int).Value = IdDiplome;

                try
                {
                    if (AppConnection.State != ConnectionState.Open)
                    {
                        AppConnection.Open();
                    }
                    AppCommande.ExecuteNonQuery();
                    AppConnection.Close();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public void UploadProfileImage(byte[] imageProfile)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "UploadImage";
                AppCommande.Parameters.Add("@Image", SqlDbType.Image).Value = imageProfile;
                AppCommande.Parameters.Add("@Idchercheur", SqlDbType.Int).Value = this.Id;
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
                AppCommande.CommandText = "UploadbackImage";
                AppCommande.Parameters.Add("@Image", SqlDbType.Image).Value = imageProfile;
                AppCommande.Parameters.Add("@Idchercheur", SqlDbType.Int).Value = this.Id;
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
                AppCommande.CommandText = "returnImage";
                AppCommande.Parameters.Add("@Idchercheur", SqlDbType.Int).Value = this.Id;

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
                AppCommande.CommandText = "returnBackImage";
                AppCommande.Parameters.Add("@Idchercheur", SqlDbType.Int).Value = this.Id;

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
        public void Postuler(int IdPoste, string Message, int idEnter, string issend)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "AjoutePostule";
                AppCommande.Parameters.Add("@IdChercheur", SqlDbType.Int).Value = this.Id;
                AppCommande.Parameters.Add("@IdPost", SqlDbType.Int).Value = IdPoste;
                AppCommande.Parameters.Add("@Message", SqlDbType.VarChar).Value = Message;
                AppCommande.Parameters.Add("@IdENter", SqlDbType.VarChar).Value = idEnter;
                AppCommande.Parameters.Add("@issendcv", SqlDbType.VarChar).Value = issend;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public void ModifyInfo()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "ModifyCHERCHUER";
                AppCommande.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;
                AppCommande.Parameters.Add("@PRENOM", SqlDbType.VarChar).Value = this.Prenom;
                AppCommande.Parameters.Add("@NOM", SqlDbType.VarChar).Value = this.Nom;
                AppCommande.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = this.Email;
                AppCommande.Parameters.Add("@TELEPHONE", SqlDbType.VarChar).Value = this.Téléphone;
                AppCommande.Parameters.Add("@VILLE", SqlDbType.VarChar).Value = this.ville;
                if (this.Cv != null)
                {
                    AppCommande.Parameters.Add("@cv", SqlDbType.VarChar).Value = this.Cv;
                }
                else
                {
                    AppCommande.Parameters.Add("@cv", SqlDbType.VarChar).Value = getcv();
                }

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

                AppCommande.CommandText = "DeleteAccount";
                AppCommande.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
        public string getcv()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "getcv";
                AppCommande.Parameters.Add("@Id", SqlDbType.Int).Value = this.Id;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                string cv = AppCommande.ExecuteScalar().ToString();
                AppConnection.Close();
                return cv;
            }
        }
        public string getPassword()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "getPasswordC";
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
        public static bool checkIfSend(int idPosted, int idChercheur)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                DataTable AppTable = new DataTable();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                SqlDataReader AppDataReader;
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "checkIfSend";
                AppCommande.Parameters.Add("@Postid", SqlDbType.Int).Value = idPosted;
                AppCommande.Parameters.Add("@Chercheurid", SqlDbType.Int).Value = idChercheur;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }

                AppDataReader = AppCommande.ExecuteReader();
                AppTable.Load(AppDataReader);
                AppConnection.Close();

                if (AppTable.Rows.Count != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public List<Répondre> getMessages()
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                List<Répondre> Messages = new List<Répondre>();
                SqlDataReader AppReader;
                DataTable Apptable = new DataTable();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.StoredProcedure;

                AppCommande.CommandText = "getreponder";
                AppCommande.Parameters.Add("@idchercheur", SqlDbType.Int).Value = this.Id;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppReader = AppCommande.ExecuteReader();
                Apptable.Load(AppReader);
                AppConnection.Close();

                for (var i = 0; i < Apptable.Rows.Count; i++)
                {
                    Messages.Add(new Répondre
                    {

                        Id = Convert.ToInt32(Apptable.Rows[i]["id"]),
                        Message = Apptable.Rows[i]["Message"].ToString(),
                        Répondre_Enterprise = new UserEntreprise
                        {
                            Id = Convert.ToInt32(Apptable.Rows[i]["IdEntreprise"].ToString()),
                        },
                        Répondre_Job = new Jobs
                        {
                            Id = Convert.ToInt32(Apptable.Rows[i]["IdPoste"].ToString()),
                        }

                    });
                }
                return Messages;
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

                AppCommande.CommandText = "getreportcherch";
                AppCommande.Parameters.Add("@idChercheur", SqlDbType.Int).Value = this.Id;

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