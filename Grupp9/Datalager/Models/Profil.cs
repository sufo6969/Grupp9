using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datalager.Models
{
    public class Profil
    {
        [Key]
        public string UserId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Roll { get; set; }
        public bool Admin { get; set; }
    }
}
