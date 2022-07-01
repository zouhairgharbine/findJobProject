using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace FindJob.Models.Database
{
    public class Ado
    {
        public static SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static SqlDataReader AppDataReader;


        // GET ALL THE POST TO JOBS PAGE //
        public static List<Jobs> getJobs()
        {

            DataTable dataTable = new DataTable();

            List<Jobs> AllJobs = new List<Jobs>();

            SqlCommand AppCommande = new SqlCommand("GETPOST", AppConnection);

            AppCommande.CommandType = CommandType.StoredProcedure;

            if(AppConnection.State != ConnectionState.Open)
            {
                AppConnection.Open();
            }
            AppDataReader = AppCommande.ExecuteReader();
            dataTable.Load(AppDataReader);
            AppConnection.Close();

            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                AllJobs.Add(new Jobs
                {
                    Id = Convert.ToInt32(dataTable.Rows[i]["Id"]),
                    Titre = dataTable.Rows[i]["Titre"].ToString(),
                    Description = dataTable.Rows[i]["Description"].ToString(),
                    Contrat = dataTable.Rows[i]["Contrat"].ToString(),
                    Salaire = Convert.ToDouble(dataTable.Rows[i]["Salaire"]),
                    Type = dataTable.Rows[i]["type"].ToString(),
                    Competences = dataTable.Rows[i]["Competences"].ToString(),
                    dateCreation = DateTime.Parse(dataTable.Rows[i]["dateCreation"].ToString()),
                    Entreprise = new UserEntreprise()
                    {
                        Id = Convert.ToInt32(dataTable.Rows[i]["Id"]),
                        Nom = dataTable.Rows[i]["Nom"].ToString(),
                        Email = dataTable.Rows[i]["Email"].ToString(),
                        Siteweb = dataTable.Rows[i]["SiteWeb"].ToString(),
                        Téléphone = dataTable.Rows[i]["Téléphone"].ToString(),
                        Adresse = dataTable.Rows[i]["Adresse"].ToString(),
                        ImageProfile = Encoding.ASCII.GetBytes(dataTable.Rows[i]["Img"].ToString()),
                        Specialité = dataTable.Rows[i]["Specialité"].ToString(),
                        NomUtilisateur = dataTable.Rows[i]["NomUtilisateur"].ToString(),
                        dateCreation = DateTime.Parse(dataTable.Rows[i]["dateCreation"].ToString()),
                        Mot_de_passe = dataTable.Rows[i]["Mot_de_passe"].ToString(),
                    },
                });
            }
            return AllJobs;
        }
        public static UserEntreprise getWithId(int id)
        {
            DataTable AppTable = new DataTable();
            SqlCommand AppCommande = new SqlCommand("", AppConnection);
            List<Jobs> EnterJobs = new List<Jobs>();

            AppCommande.CommandType = CommandType.StoredProcedure;
            AppCommande.CommandText = "GETENTERPRISEWITHPOST";
            AppCommande.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
            if (AppConnection.State != ConnectionState.Open)
            {
                AppConnection.Open();
            }
            AppDataReader = AppCommande.ExecuteReader();
            AppTable.Load(AppDataReader);
            AppConnection.Close();

            return new UserEntreprise
            {
                Id = Int32.Parse(AppTable.Rows[0]["Id"].ToString()),
                Email = AppTable.Rows[0]["Email"].ToString(),
                Nom = AppTable.Rows[0]["Nom"].ToString(),
                Adresse = AppTable.Rows[0]["Adresse"].ToString(),
                Siteweb = AppTable.Rows[0]["SiteWeb"].ToString(),
                NomUtilisateur = AppTable.Rows[0]["NomUtilisateur"].ToString(),
                Mot_de_passe = AppTable.Rows[0]["Mot_de_passe"].ToString(),
                Specialité = AppTable.Rows[0]["Specialité"].ToString(),
                Téléphone = AppTable.Rows[0]["Téléphone"].ToString(),
                ImageProfile = Encoding.ASCII.GetBytes(AppTable.Rows[0]["Img"].ToString()),
                dateCreation = Convert.ToDateTime(AppTable.Rows[0]["dateCreation"].ToString()),
                Postedjobs = getJobsCondition(Convert.ToInt32(AppTable.Rows[0]["Id"])),
            }; 
        }
        public static UserChercheur getChercheur(int id)
        {
            DataTable AppTable = new DataTable();
            SqlCommand AppCommande = new SqlCommand("", AppConnection);

            AppCommande.CommandType = CommandType.StoredProcedure;
            AppCommande.CommandText = "GETCHERCHEUREWITHPOST";
            AppCommande.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
            if (AppConnection.State != ConnectionState.Open)
            {
                AppConnection.Open();
            }
            AppDataReader = AppCommande.ExecuteReader();
            AppTable.Load(AppDataReader);
            AppConnection.Close();

            return new UserChercheur
            {
                Id = Int32.Parse(AppTable.Rows[0]["Id"].ToString()),
                Email = AppTable.Rows[0]["Email"].ToString(),
                Nom = AppTable.Rows[0]["Nom"].ToString(),
                Prenom = AppTable.Rows[0]["Prénom"].ToString(),
                ville = AppTable.Rows[0]["Ville"].ToString(),
                Cv = AppTable.Rows[0]["Cv"].ToString(),
                NomUtilisateur = AppTable.Rows[0]["NomUtilisateur"].ToString(),
                Mot_de_passe = AppTable.Rows[0]["Mot_de_passe"].ToString(),
                Téléphone = AppTable.Rows[0]["Téléphone"].ToString(),
                ImageProfile = Encoding.ASCII.GetBytes(AppTable.Rows[0]["Img"].ToString()),
                dateCreation = Convert.ToDateTime(AppTable.Rows[0]["dateCreation"].ToString()),
                Diplomes = getDiplomes(Int32.Parse(AppTable.Rows[0]["Id"].ToString())),
                Experiences = getExpExperiences(Int32.Parse(AppTable.Rows[0]["Id"].ToString())),
            };
        }
        public static List<Diplome> getDiplomes(int IdChercheur)
        {
            DataTable AppTable = new DataTable();
            SqlCommand AppCommande = new SqlCommand("", AppConnection);
            AppCommande.CommandType = CommandType.Text;
            AppCommande.CommandText = $"select * from Diplome where IdChercheur = {IdChercheur}";

            if (AppConnection.State != ConnectionState.Open)
            {
                AppConnection.Open();
            }
            AppDataReader = AppCommande.ExecuteReader();
            AppTable.Load(AppDataReader);
            AppConnection.Close();
            List<Diplome> diplomes = new List<Diplome>();

            for (var i=0;i<AppTable.Rows.Count;i++)
            {
                diplomes.Add(new Diplome
                {
                    Id = Int32.Parse(AppTable.Rows[i]["Id"].ToString()),
                    Nom = AppTable.Rows[i]["NomDiplome"].ToString(),
                    Specialité = AppTable.Rows[i]["Spécialité"].ToString(),
                    DateCreation = Convert.ToDateTime(AppTable.Rows[i]["dateCreation"].ToString()),
                });
            }
            return diplomes;
        }
        public static List<Experience> getExpExperiences(int IdChercheur)
        {
            DataTable AppTable = new DataTable();
            SqlCommand AppCommande = new SqlCommand("", AppConnection);
            AppCommande.CommandType = CommandType.Text;
            AppCommande.CommandText = $"select * from Experience where IdChercheur = {IdChercheur}";

            if (AppConnection.State != ConnectionState.Open)
            {
                AppConnection.Open();
            }
            AppDataReader = AppCommande.ExecuteReader();
            AppTable.Load(AppDataReader);
            AppConnection.Close();
            List<Experience> experience = new List<Experience>();

            for (var i = 0; i < AppTable.Rows.Count; i++)
            {
                experience.Add(new Experience
                {
                    Id = Int32.Parse(AppTable.Rows[i]["Id"].ToString()),
                    Description = AppTable.Rows[i]["Description"].ToString(),
                    Société = AppTable.Rows[i]["Societe"].ToString() ,
                    DateDébut = Convert.ToDateTime(AppTable.Rows[i]["DateDebut"].ToString()),
                    DateFin = Convert.ToDateTime(AppTable.Rows[i]["DateFin"].ToString()),
                    dateCreation = Convert.ToDateTime(AppTable.Rows[i]["dateCreation"].ToString()),
                });
            }
            return experience;
        }
        public static int getId(string Username,string Password,string tableName)
        {
            SqlCommand AppCommande = new SqlCommand("", AppConnection);
            AppCommande.CommandType = CommandType.Text;
            AppCommande.CommandText = $"SELECT Id FROM {tableName} WHERE  NomUtilisateur = '{Username}' and Mot_de_passe = '{Password}'";
            if (AppConnection.State != ConnectionState.Open)
            {
                AppConnection.Open();
            }
            int result = Int32.Parse(AppCommande.ExecuteScalar().ToString());
            AppConnection.Close();
            return result;
        }
        public static string Login(string Username, string Password)
        {
            SqlDataReader AppReader;
            SqlCommand AppCommande = new SqlCommand("", AppConnection);
            DataTable AppTable1 = new DataTable();
            DataTable AppTable2 = new DataTable();

            try
            {
                AppConnection.Open();
            }
            catch
            {
                AppConnection.Close();
                AppConnection.Open();
            }
            
            AppCommande.CommandType = CommandType.StoredProcedure;
            AppCommande.CommandText = "GETLOGINCHERCHEUR";
            AppCommande.Parameters.Add("@NomUtilisateur", SqlDbType.VarChar).Value = Username;
            AppCommande.Parameters.Add("@Mot_de_passe", SqlDbType.VarChar).Value = Password;
            AppReader = AppCommande.ExecuteReader();
            AppTable1.Load(AppReader);
            AppConnection.Close();

            if (AppTable1.Rows.Count != 0)
            {
                return "chercheur";
            }

            AppConnection.Open();
            AppCommande.CommandText = "GETLOGINENTERPRISE";
            AppReader = AppCommande.ExecuteReader();
            AppTable2.Load(AppReader);
            AppConnection.Close();

            if (AppTable2.Rows.Count != 0)
            {
                return "enterprise";
            }
            else
            {
                return "Error";
            }
        }
        public static List<Jobs> getJobsCondition(int idEnterprise)
        {

            DataTable dataTable = new DataTable();

            List<Jobs> AllJobs = new List<Jobs>();

            SqlCommand AppCommande = new SqlCommand("", AppConnection);
            AppCommande.CommandText = $"SELECT * FROM Poste WHERE Poste.IdEntreprise = {idEnterprise}";
            AppCommande.CommandType = CommandType.Text;

            if (AppConnection.State != ConnectionState.Open)
            {
                AppConnection.Open();
            }
            AppDataReader = AppCommande.ExecuteReader();
            dataTable.Load(AppDataReader);
            AppConnection.Close();

            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                AllJobs.Add(new Jobs
                {
                    Id = Convert.ToInt32(dataTable.Rows[i]["Id"]),
                    Titre = dataTable.Rows[i]["Titre"].ToString(),
                    Description = dataTable.Rows[i]["Description"].ToString(),
                    Contrat = dataTable.Rows[i]["Contrat"].ToString(),
                    Salaire = Convert.ToDouble(dataTable.Rows[i]["Salaire"]),
                    Type = dataTable.Rows[i]["type"].ToString(),
                    Competences = dataTable.Rows[i]["Competences"].ToString(),
                    dateCreation = DateTime.Parse(dataTable.Rows[i]["dateCreation"].ToString()),
                });
            }
            return AllJobs;
        }
        public static bool ExecuteNonQuery(SqlCommand AppCommand)
        {
            try
            {
                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommand.ExecuteNonQuery();
                AppConnection.Close();
                return true;
            }
            catch
            {
                AppConnection.Close();
                return false;
            }
        }
        public static string getValue(string NameTable, string NameProp, int Id)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.Text;
                AppCommande.CommandText = $"SELECT {NameProp} FROM {NameTable} WHERE Id = {Id}";
                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                string value = AppCommande.ExecuteScalar().ToString();
                AppConnection.Close();
                return value;
            }
        }
        public static List<string> getEmailWithUsername(string UserName)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                List<string> Result = new List<string>();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "getEmail";
                AppCommande.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                string email = AppCommande.ExecuteScalar().ToString();
                AppConnection.Close();


                if (email != null)
                {
                    Result.Add(email);
                    Result.Add("chercheur");
                    return Result;
                }

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }

                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "getEmail2";
                AppCommande.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                email = AppCommande.ExecuteScalar().ToString();
                AppConnection.Close();

                if (email != null)
                {
                    Result.Add(email);
                    Result.Add("Entreprise");
                    return Result;
                }
                else
                {
                    return null;
                }
            }
        }
        public static string GegnerateXml()
        {
            string xmlString = "";
            SqlCommand AppCommande = new SqlCommand("", AppConnection);
            AppCommande.CommandType = CommandType.Text;
            AppCommande.CommandText = "select * from poste for xml AUTO,ELEMENT";
            AppConnection.Open();
            xmlString = AppCommande.ExecuteScalar().ToString();
            AppConnection.Close();
            return xmlString;
        }
        public static void changePassword(string newPassword,string UserName, string TypeUser)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                AppCommande.CommandType = CommandType.Text;
                if (TypeUser == "chercheur")
                {
                    AppCommande.CommandText = $"update chercheur set Mot_de_passe = '{newPassword}' where NomUtilisateur = '{UserName}' ";
                }
                else
                {
                    AppCommande.CommandText = $"update Entreprise set Mot_de_passe = '{newPassword}' where NomUtilisateur = '{UserName}' ";
                }

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppCommande.ExecuteNonQuery();
                AppConnection.Close();
            }
        }
    }
}