using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.modeles;
using CourrierDocker_MBDS_31.modeles.courrier;

namespace CourrierDocker_MBDS_31.Data
{
    public class CourrierDocker_MBDS_31Context : DbContext
    {
        public CourrierDocker_MBDS_31Context (DbContextOptions<CourrierDocker_MBDS_31Context> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<modeles.account.MyUser> MyUser { get; set; } = default!;
        public DbSet<modeles.courrier.Commentaire> Commentaire { get; set; } = default!;
        public DbSet<modeles.courrier.Courrier> Courrier { get; set; } = default!;
        public DbSet<modeles.courrier.Destinataire> Destinataire { get; set; } = default!;
        public DbSet<modeles.courrier.FichierJoint> FichierJoint { get; set; } = default!;
        public DbSet<modeles.courrier.Priorite> Priorite { get; set; } = default!;
        public DbSet<modeles.structure.Departement> Departement { get; set; } = default!;
        public DbSet<modeles.structure.Poste> Poste { get; set; } = default!;
        public DbSet<modeles.courrier.CourrierDetails> CourrierDetails { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration des relations avec DeleteBehavior.Restrict par défaut
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<CourrierDetails>().HasNoKey().ToView("CourrierDetails");
            base.OnModelCreating(modelBuilder);
        }
    }
}
