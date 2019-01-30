using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datalager.Models
{
    public class Kommentar
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int BloggId { get; set; }
    }
}
