using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindJob.Models
{
    public class Postuler
    {
        public int id { get; set; }
        public UserChercheur chercheur { get; set; }
        public Jobs job { get; set; }
        public string  Message {get;set;}
    }
}