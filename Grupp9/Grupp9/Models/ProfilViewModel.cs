using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp9.Models
{
    public class ProfilViewModel
    {
        [Required(ErrorMessage = "Var vänlig fyll i ditt förnamn")]
        [StringLength(50, ErrorMessage = "Förnamnet måste innehålla minst 3 bokstäver", MinimumLength = 3)]
        public string Förnamn { get; set; }
        [Required(ErrorMessage = "Var vänlig fyll i ditt efternamn")]
        [StringLength(50, ErrorMessage = "Efternamnet måste innehålla minst 3 bokstäver", MinimumLength = 3)]
        public string Efternamn { get; set; }
        [Required(ErrorMessage = "Var vänlig fyll i din roll")]
        [StringLength(50, ErrorMessage = "Rollen måste innehålla minst 3 bokstäver", MinimumLength = 3)]
        public string Roll { get; set; }
    }
}