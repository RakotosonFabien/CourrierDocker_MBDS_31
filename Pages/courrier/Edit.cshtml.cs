using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.courrier;
using CourrierDocker_MBDS_31.modeles;

namespace CourrierDocker_MBDS_31.Pages.courrier
{
    public class EditModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public EditModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Courrier Courrier { get; set; } = default!;

        public IList<SelectListItem> Priorites { get; set; } = default!;
        public IList<SelectListItem> Departements { get; set; } = default!;
        public IList<SelectListItem> Postes { get; set; } = default!;
        public IList<SelectListItem> Statuts { get; set; } = default!;
        public bool RechercheAvancee = true;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //Initialisation des donnees
            Departements = Utils.DonneesStatiquesDepartements(_context);
            Postes = Utils.DonneesStatiquesPostes(_context);
            Priorites = Utils.DonneesStatiquesPriorites(_context);
            Statuts = Donnees.Statuts;
            //Fin initialisation des donnees
            if (id == null || _context.Courrier == null)
            {
                return NotFound();
            }

            var courrier =  await _context.Courrier.FirstOrDefaultAsync(m => m.Id == id);
            if (courrier == null)
            {
                return NotFound();
            }
            Courrier = courrier;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Courrier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourrierExists(Courrier.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CourrierExists(int id)
        {
          return (_context.Courrier?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
