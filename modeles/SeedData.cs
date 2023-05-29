using CourrierDocker_MBDS_31.Data;
using Microsoft.EntityFrameworkCore;

namespace CourrierDocker_MBDS_31.modeles
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CourrierDocker_MBDS_31Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CourrierDocker_MBDS_31Context>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any priorites.
                if (!context.Priorite.Any())
                    context.Priorite.AddRange(Donnees.priorites);
                // Look for any departements.
                if (!context.Departement.Any())
                    context.Departement.AddRange(Donnees.departements);
                // Look for any postes.
                if (!context.Poste.Any())
                    context.Poste.AddRange(Donnees.postes);
                if(!context.MyUser.Any())
                    context.MyUser.AddRange(Donnees.myUsers);
                //donnees par defaut des priorites
                context.SaveChanges();
            }
        }
    }
}
