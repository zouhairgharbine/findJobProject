using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindJob.Models
{
    public class Experience
    {
        public int Id {get;set;}
        public string Description { get; set; }
        public string Société { get; set; }
        public DateTime DateDébut { get; set; }
        public DateTime DateFin { get; set; }
        public DateTime dateCreation { get; set; }
        public UserChercheur chercheur { get; set; }

        public Experience()
        {

        }

        public Experience(string Description, string Société, DateTime DateDébut, DateTime DateFin, UserChercheur chercheur)
        {
            this.Description = Description;
            this.Société = Société;
            this.DateDébut = DateDébut;
            this.DateFin = DateFin;
            this.dateCreation = dateCreation;
            this.chercheur = chercheur;
        }

        
    }
}