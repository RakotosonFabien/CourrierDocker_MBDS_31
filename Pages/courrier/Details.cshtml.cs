using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.courrier;

namespace CourrierDocker_MBDS_31.Pages.courrier
{
    public class DetailsModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public DetailsModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

      public Courrier Courrier { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courrier == null)
            {
                return NotFound();
            }

            var courrier = await _context.Courrier.FirstOrDefaultAsync(m => m.Id == id);
            if (courrier == null)
            {
                return NotFound();
            }
            else 
            {
                Courrier = courrier;
            }
            return Page();
        }
    }
}
