using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.courrier;

namespace CourrierDocker_MBDS_31.Pages.priorite
{
    public class DetailsModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public DetailsModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

      public Priorite Priorite { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Priorite == null)
            {
                return NotFound();
            }

            var priorite = await _context.Priorite.FirstOrDefaultAsync(m => m.Id == id);
            if (priorite == null)
            {
                return NotFound();
            }
            else 
            {
                Priorite = priorite;
            }
            return Page();
        }
    }
}
