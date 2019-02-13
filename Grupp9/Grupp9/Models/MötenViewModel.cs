using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupp9.Models
{
    public class MötenViewModel
    {


        

    public int möteId { get; set; }
    public string beskrivning { get; set; }
    public string userId { get; set; }

    }

      
    


    public class datumViewModel
    {

    public int datumId { get; set; }
    public DateTime FörslagDatum { get; set; }
    public DateTime ValtDatum { get; set; }
    public int MöteId { get; set; }


    }
}