using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FindJob.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Contrat { get; set; }
        public double Salaire { get; set; }
        public string Type { get; set; }
        public string Competences { get; set; }
        public DateTime dateCreation { get; set; }
        public UserEntreprise Entreprise { get; set; }
        public List<UserChercheur> Chercheur { get; set; }


        public Jobs(string Description, string Contrat, double Salaire, string Type, string Titre, string Competences)
        {
            this.Titre = Titre;
            this.Description = Description;
            this.Contrat = Contrat;
            this.Salaire = Salaire;
            this.Type = Type;
            this.Competences = Competences;
        }
        public Jobs()
        {

        }
        public static Jobs getJob(int IdJob)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataReader AppDataReader;
                DataTable AppTable = new DataTable();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);

                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "GetPostWithId";
                AppCommande.Parameters.Add("@Id", SqlDbType.VarChar).Value = IdJob;
                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppDataReader = AppCommande.ExecuteReader();
                AppTable.Load(AppDataReader);
                AppConnection.Close();

                return new Jobs
                {
                    Titre = AppTable.Rows[0]["Titre"].ToString(),
                    Id = Convert.ToInt32(AppTable.Rows[0]["Id"].ToString()),
                };
            }

        }
        public static UserEntreprise getEnterwithPost(int idPost)
        {
            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                DataTable AppTable = new DataTable();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);
                UserEntreprise enterprise = new UserEntreprise();

                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "getEnterwithpost";
                AppCommande.Parameters.Add("@Id", SqlDbType.Int).Value = idPost;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                int value = Convert.ToInt32(AppCommande.ExecuteScalar());
                AppConnection.Close();

                enterprise.Id = value;
                return enterprise;
            }
        }
        public static List<Jobs> getJobsWithName(string NameJob)
        {
            List<Jobs> SearchedJobs = new List<Jobs>();

            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataReader AppDataReader;
                DataTable AppTable = new DataTable();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);

                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "getJobsWithName";
                AppCommande.Parameters.Add("@Titre", SqlDbType.VarChar).Value = NameJob;
                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppDataReader = AppCommande.ExecuteReader();
                AppTable.Load(AppDataReader);
                AppConnection.Close();

                for (var i = 0; i < AppTable.Rows.Count; i++)
                {
                    SearchedJobs.Add(new Jobs {
                        Id = Convert.ToInt32(AppTable.Rows[i]["Id"]),
                        Titre = AppTable.Rows[i]["Titre"].ToString(),
                        Description = AppTable.Rows[i]["Description"].ToString(),
                        Contrat = AppTable.Rows[i]["Contrat"].ToString(),
                        Salaire = Convert.ToDouble(AppTable.Rows[i]["Salaire"]),
                        Type = AppTable.Rows[i]["type"].ToString(),
                        Competences = AppTable.Rows[i]["Competences"].ToString(),
                        dateCreation = DateTime.Parse(AppTable.Rows[i]["dateCreation"].ToString()),
                        Entreprise = new UserEntreprise()
                        {
                            Id = Convert.ToInt32(AppTable.Rows[i]["Id"]),
                        },
                    });
                }
                return SearchedJobs;
            }

        }
        public static List<Jobs> getJobsWithFillter(string Titre,String Type,string Contrat, DateTime mindate ,DateTime maxdate,double maxsalaire,double minsalaire)
        {
            List<Jobs> SearchedJobs = new List<Jobs>();

            using (SqlConnection AppConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataReader AppDataReader;
                DataTable AppTable = new DataTable();
                SqlCommand AppCommande = new SqlCommand("", AppConnection);

                AppCommande.CommandType = CommandType.StoredProcedure;
                AppCommande.CommandText = "getJobsWithFillter";
                AppCommande.Parameters.Add("@Titre", SqlDbType.VarChar).Value = Titre;
                AppCommande.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
                AppCommande.Parameters.Add("@Contrat", SqlDbType.VarChar).Value = Contrat;
                AppCommande.Parameters.Add("@mindate", SqlDbType.Date).Value = mindate;
                AppCommande.Parameters.Add("@maxdate", SqlDbType.Date).Value = maxdate;
                AppCommande.Parameters.Add("@maxSalire", SqlDbType.Money).Value = maxsalaire;
                AppCommande.Parameters.Add("@minSalire", SqlDbType.Money).Value = minsalaire;

                if (AppConnection.State != ConnectionState.Open)
                {
                    AppConnection.Open();
                }
                AppDataReader = AppCommande.ExecuteReader();
                AppTable.Load(AppDataReader);
                AppConnection.Close();

                for (var i = 0; i < AppTable.Rows.Count; i++)
                {
                    SearchedJobs.Add(new Jobs
                    {
                        Id = Convert.ToInt32(AppTable.Rows[i]["Id"]),
                        Titre = AppTable.Rows[i]["Titre"].ToString(),
                        Description = AppTable.Rows[i]["Description"].ToString(),
                        Contrat = AppTable.Rows[i]["Contrat"].ToString(),
                        Salaire = Convert.ToDouble(AppTable.Rows[i]["Salaire"]),
                        Type = AppTable.Rows[i]["type"].ToString(),
                        Competences = AppTable.Rows[i]["Competences"].ToString(),
                        dateCreation = DateTime.Parse(AppTable.Rows[i]["dateCreation"].ToString()),
                        Entreprise = new UserEntreprise()
                        {
                            Id = Convert.ToInt32(AppTable.Rows[i]["Id"]),
                        },
                    });
                }
                return SearchedJobs;
            }

        }
    }
}