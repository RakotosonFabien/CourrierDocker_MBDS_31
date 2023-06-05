using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.courrier;
using CourrierDocker_MBDS_31.modeles.structure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace CourrierDocker_MBDS_31.modeles
{
    public class Utils
    {
        public static IList<SelectListItem> DonneesStatiquesDepartements(CourrierDocker_MBDS_31Context _context)
        {
            IList<SelectListItem> departements = new List<SelectListItem>();
            departements.Add(new SelectListItem
            {
                Value = "",
                Text = "Selectionnez le departement"
            });
            departements.AddRange(_context.Departement.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Val
            }).ToList());
            return departements;
        }
        public static IList<SelectListItem> DonneesStatiquesPostes(CourrierDocker_MBDS_31Context _context)
        {
            IList<SelectListItem> postes = new List<SelectListItem>();
            postes.Add(new SelectListItem
            {
                Value = "",
                Text = "Selectionnez le poste"
            });
            postes.AddRange (_context.Poste.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Val
            }).ToList());
            return postes;
            
        }
        public static IList<SelectListItem> DonneesStatiquesPriorites(CourrierDocker_MBDS_31Context _context)
        {
            IList<SelectListItem> priorites = new List<SelectListItem>();
            priorites.Add(new SelectListItem
            {
                Value = "",
                Text = "Selectionnez flag"
            });
            priorites.AddRange(_context.Priorite.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Val
            }).ToList());
            return priorites;

        }
    }
}
