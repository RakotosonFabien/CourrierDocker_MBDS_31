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
    public class IndexModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public IndexModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        public IList<MyUser> MyUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MyUser != null)
            {
                MyUser = await _context.MyUser.ToListAsync();
            }
        }
    }
}
