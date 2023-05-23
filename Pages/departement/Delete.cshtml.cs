using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.structure;

namespace CourrierDocker_MBDS_31.Pages.departement
{
    public class DeleteModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public DeleteModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Departement Departement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departement == null)
            {
                return NotFound();
            }

            var departement = await _context.Departement.FirstOrDefaultAsync(m => m.Id == id);

            if (departement == null)
            {
                return NotFound();
            }
            else 
            {
                Departement = departement;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Departement == null)
            {
                return NotFound();
            }
            var departement = await _context.Departement.FindAsync(id);

            if (departement != null)
            {
                Departement = departement;
                _context.Departement.Remove(Departement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
