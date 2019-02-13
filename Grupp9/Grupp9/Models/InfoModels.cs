using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Grupp9.Models
{
    public class Fil
    {
        [Key]
        public int Id { get; set; }
        public int BloggInläggId { get; set; }
        public string FilUrl { get; set; }
    }

    public class FormellaInlägg
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Titel { get; set; }
        public string Text { get; set; }
    }

    public class Kategorier
    {
        [Key]
        public int Id { get; set; }
        public string Namn { get; set; }
        public int BloggInläggId { get; set; }
        public string UserId { get; set; }

    }


    public class Kommentar
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int BloggId { get; set; }
    }
    public class Profil
    {
        [Key]
        public string UserId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Roll { get; set; }
        public bool Admin { get; set; }
    }

    public class Möten
    {
        [Key]
        public int MöteId { get; set; }
        public string UserId { get; set; }
        public string MötesBeskrivning { get; set; }      
    }

    public class Datum
    {
        [Key]
        public int DatumId { get; set; }
        public DateTime FörslagDatum { get; set; }
        public DateTime ValtDatum { get; set; }
        public int MöteId {get; set;}
    }

        public class InfoDbContext : DbContext
    {
        public DbSet<Fil> Filer { get; set; }
        public DbSet<FormellaInlägg> FormellaInläggen { get; set; }
        public DbSet<Profil> Profiler { get; set; }
        public DbSet<Kommentar> Kommentarer { get; set; }
        public DbSet<Kategorier> Kategori { get; set; }
        public DbSet<Möten> Möte { get; set; }
        public DbSet<Datum> Datumen{ get; set; }

        public InfoDbContext() : base("info")
        {

        }
    }

}