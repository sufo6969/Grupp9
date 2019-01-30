using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datalager.Models
{
    public class Fil
    {
        [Key]
        public int Id { get; set; }
        public int BloggInläggId { get; set; }
        public string FilUrl { get; set; }
    }
}
