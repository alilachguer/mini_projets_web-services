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
            
        }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<UtilisateurAbonne> Users { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }



    }
}
