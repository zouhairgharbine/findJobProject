using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindJob.Models
{
    public abstract class Utilisateur
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Téléphone { get; set; }
        public byte[] ImageProfile { get; set; }
        public string NomUtilisateur { get; set; }
        public string Mot_de_passe { get; set; }
        public DateTime dateCreation { get; set; }
    }

}