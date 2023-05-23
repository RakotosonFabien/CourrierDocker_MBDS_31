using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.structure;

namespace CourrierDocker_MBDS_31.Pages.poste
{
    public class DeleteModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public DeleteModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Poste Poste { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Poste == null)
            {
                return NotFound();
            }

            var poste = await _context.Poste.FirstOrDefaultAsync(m => m.Id == id);

            if (poste == null)
            {
                return NotFound();
            }
            else 
            {
                Poste = poste;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Poste == null)
            {
                return NotFound();
            }
            var poste = await _context.Poste.FindAsync(id);

            if (poste != null)
            {
                Poste = poste;
                _context.Poste.Remove(Poste);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
