using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupp9.Models
{
    public class MötenViewModel
    {
    public int MöteId { get; set; }
    [Required]
    [StringLength(300, MinimumLength = 10, ErrorMessage = "Texten måste vara mellan 10 och 300 tecken lång")]
    public string Beskrivning { get; set; }
    public string UserId { get; set; }
    public bool AccepteratMöte { get; set; }
    public bool InbjudenTillMöte { get; set; }
    public string InbjudenEmail { get; set; }
    }


    public class DatumViewModel
    {

    public int DatumId { get; set; }
    public DateTime FörslagDatum { get; set; }
    public DateTime ValtDatum { get; set; }
    public int MöteId { get; set; }


    }
}