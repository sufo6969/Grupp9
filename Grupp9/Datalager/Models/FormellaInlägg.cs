using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datalager.Models
{
    public class FormellaInlägg
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Titel { get; set; }
        public string Text { get; set; }
    }
}
