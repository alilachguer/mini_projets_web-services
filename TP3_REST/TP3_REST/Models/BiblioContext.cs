using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP3_REST.Models
{
    public class BiblioContext : DbContext
    {
        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Livre>().Ignore(c => c.Commentaires);
            modelBuilder.Entity<Livre>().ToTable("Livre");
            modelBuilder.Entity<Livre>().HasKey(lvr => lvr.ISBN);

            modelBuilder.Entity<UtilisateurAbonne>().ToTable("Utilisateur");
            modelBuilder.Entity<UtilisateurAbonne>().HasKey(lvr => lvr.Numero);

            modelBuilder.Entity<Commentaire>().ToTable("Commentaire");
            modelBuilder.Entity<Commentaire>().HasKey(lvr => lvr.IdCommentaire);
        }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<UtilisateurAbonne> Users { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }



    }
}
