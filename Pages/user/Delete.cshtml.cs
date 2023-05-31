using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.account;

namespace CourrierDocker_MBDS_31.Pages.user
{
    public class DeleteModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public DeleteModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        [BindProperty]
      public MyUser MyUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MyUser == null)
            {
                return NotFound();
            }

            var myuser = await _context.MyUser.FirstOrDefaultAsync(m => m.Id == id);

            if (myuser == null)
            {
                return NotFound();
            }
            else 
            {
                MyUser = myuser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MyUser == null)
            {
                return NotFound();
            }
            var myuser = await _context.MyUser.FindAsync(id);

            if (myuser != null)
            {
                MyUser = myuser;
                _context.MyUser.Remove(MyUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
