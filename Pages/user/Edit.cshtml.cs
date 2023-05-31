using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.account;

namespace CourrierDocker_MBDS_31.Pages.user
{
    public class EditModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public EditModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
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

            var myuser =  await _context.MyUser.FirstOrDefaultAsync(m => m.Id == id);
            if (myuser == null)
            {
                return NotFound();
            }
            MyUser = myuser;
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

            _context.Attach(MyUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyUserExists(MyUser.Id))
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

        private bool MyUserExists(int id)
        {
          return (_context.MyUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
