using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Grupp9.Models
{
    public class FormellaInläggViewModell
    {
        [StringLength(300, ErrorMessage = "Texten kan inte vara längre än 300 tecken") ]
        public string text { get; set; }
        [StringLength(50, ErrorMessage = "Texten kan inte vara längre än 50 tecken")]
        public string titel { get; set; }
    }
}