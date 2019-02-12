﻿using System;
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
        public string TypAvInlägg { get; set; }
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

    public class InfoDbContext : DbContext
    {
        public DbSet<Fil> Filer { get; set; }
        public DbSet<FormellaInlägg> FormellaInläggen { get; set; }
        public DbSet<Profil> Profiler { get; set; }
        public DbSet<Kommentar> Kommentarer { get; set; }
        public DbSet<Kategorier> Kategori { get; set; }


        public InfoDbContext() : base("info")
        {

        }
    }

}