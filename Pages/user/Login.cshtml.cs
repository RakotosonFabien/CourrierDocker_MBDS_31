using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.account;
using Microsoft.EntityFrameworkCore;

namespace CourrierDocker_MBDS_31.Pages.user
{
    public class LoginModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public LoginModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyUser MyUser { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.MyUser == null || MyUser == null)
            {
                return Page();
            }

            MyUser userConnected = MyUser.Login(_context);
            if (userConnected!=null)
            {
                HttpContext.Session.SetString("userID", userConnected.Id.ToString());
                return RedirectToPage("/courrier");
            }
            return RedirectToPage("/user/Login");
        }
    }
}
