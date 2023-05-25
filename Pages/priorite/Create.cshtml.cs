using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.courrier;

namespace CourrierDocker_MBDS_31.Pages.priorite
{
    public class CreateModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public CreateModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Priorite Priorite { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Priorite == null || Priorite == null)
            {
                return Page();
            }

            _context.Priorite.Add(Priorite);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
