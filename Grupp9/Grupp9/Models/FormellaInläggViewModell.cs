using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Grupp9.Models
{
    public class FormellaInläggViewModell
    {
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Texten måste vara mellan 10 och 300 tecken lång")]
        public string text { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Texten måste vara mellan 3 och 50 tecken lång")]
        public string titel { get; set; }

        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }

        public int ValdKategori { get; set; }
        public SelectList AllaKategorier { get; set; }
        //public List<Kategorier> AllaKategorier { get; set; }
        
    }

    public class VisaKategorierViewModel

    {
        //public int kategoriId { get; set; }
        public List <LäggTillKategorierViewModel> kategoriLista { get; set; }
    }
    public class ListaKategorierViewModel
    {
        public List<Kategorier> AllaKategorier { get; set; }
    }

    public class LäggTillKategorierViewModel

    {
        public string KategoriNamn { get; set; }

        public int KategoriId { get; set; }

      //  public List<Kategorier> allaKategorier { get; set; }

    }
    

    public class SkrivKommentarViewModel
    {
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Texten måste vara mellan 10 och 300 tecken lång")]
        public string kommentarText { get; set; }

        public int bloggId { get; set; }
    }

    public class LäsaKommenterarViewModel
    {
        public string kommentarText { get; set; }
        public int bloggId { get; set; }

    }
    public class ListaKommenterare
    {
        public List<LäsaKommenterarViewModel> listan { get; set; }
        public int bloggId { get; set; }
    }

    public class FilerViewModel
    {
        public string filNamn { get; set; }
        public int bloggId { get; set; }

    }
    public class ListaFilerViewModel
    {
        public List<FilerViewModel> listanAvFiler { get; set; }
        public int BloggInläggId { get; set; }
    }
}