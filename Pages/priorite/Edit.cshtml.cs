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

namespace CourrierDocker_MBDS_31.Pages.priorite
{
    public class EditModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public EditModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Priorite Priorite { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Priorite == null)
            {
                return NotFound();
            }

            var priorite =  await _context.Priorite.FirstOrDefaultAsync(m => m.Id == id);
            if (priorite == null)
            {
                return NotFound();
            }
            Priorite = priorite;
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

            _context.Attach(Priorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrioriteExists(Priorite.Id))
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

        private bool PrioriteExists(int id)
        {
          return (_context.Priorite?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
