using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindJob.Models
{
    public class Répondre
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreation { get; }
        public UserEntreprise Répondre_Enterprise { get; set; }
        public UserChercheur Répondre_Chercheur { get; set; }
        public Jobs Répondre_Job { get; set; }
    }
}