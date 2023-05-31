using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.account;

namespace CourrierDocker_MBDS_31.Pages.user
{
    public class SigninModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;
        public IList<SelectListItem> Postes { get; set; } = default!;
        public IList<SelectListItem> Departements { get; set; } = default!;

        public SigninModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Postes = _context.Poste.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Val
            }).ToList();
            Departements = _context.Departement.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Val
            }).ToList();
            return Page();
        }

        [BindProperty]
        public MyUser MyUser { get; set; } = default!;
        [BindProperty]
        public String ConfirmPassword { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.MyUser == null || MyUser == null)
            {
                return Page();
            }
            if (ConfirmPassword.CompareTo(MyUser.Password) != 0)
            {
                return Page();
            }
            MyUser.Password = MyUser.HashPassword(MyUser.Password);
            _context.MyUser.Add(MyUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
