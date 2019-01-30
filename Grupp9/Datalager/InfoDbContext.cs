using System;
using Datalager.Models;
using System.Data.Entity;

namespace Datalager
{
    public class InfoDbContext : DbContext
    {
        public DbSet<Fil> Filer { get; set; }
        public DbSet<FormellaInlägg> FormellaInläggen { get; set; }
        public DbSet<Profil> Profiler { get; set; }
        public DbSet<Kommentar> Kommentarer { get; set; }


        public InfoDbContext() : base("info") {

        }
    }
}
