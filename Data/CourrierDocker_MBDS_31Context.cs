using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.modeles;

namespace CourrierDocker_MBDS_31.Data
{
    public class CourrierDocker_MBDS_31Context : DbContext
    {
        public CourrierDocker_MBDS_31Context (DbContextOptions<CourrierDocker_MBDS_31Context> options)
            : base(options)
        {
        }

        public DbSet<CourrierDocker_MBDS_31.modeles.Movie> Movie { get; set; } = default!;
        public DbSet<CourrierDocker_MBDS_31.modeles.account.MyUser> MyUser { get; set; } = default!;
        public DbSet<CourrierDocker_MBDS_31.modeles.courrier.Commentaire> Commentaire { get; set; } = default!;
        public DbSet<CourrierDocker_MBDS_31.modeles.courrier.Courrier> Courrier { get; set; } = default!;
        public DbSet<CourrierDocker_MBDS_31.modeles.courrier.Destinataire> Destinataire { get; set; } = default!;
        public DbSet<CourrierDocker_MBDS_31.modeles.courrier.FichierJoint> FichierJoint { get; set; } = default!;
        public DbSet<CourrierDocker_MBDS_31.modeles.courrier.Priorite> Priorite { get; set; } = default!;
        public DbSet<CourrierDocker_MBDS_31.modeles.structure.Departement> Departement { get; set; } = default!;
        public DbSet<CourrierDocker_MBDS_31.modeles.structure.Poste> Poste { get; set; } = default!;
    }
}
