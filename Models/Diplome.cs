using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindJob.Models
{
    public class Diplome
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Specialité { get; set; }
        public DateTime DateCreation { get; set; }
        public UserChercheur ChercheurDiplome { get; set; }

        public Diplome(string Nom,string Specialité,UserChercheur chercheur)
        {
            this.Nom = Nom;
            this.Specialité = Specialité;
            this.ChercheurDiplome = chercheur;
        }
        public Diplome()
        {

        }
    }
}