using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.courrier;
using Microsoft.EntityFrameworkCore;

namespace CourrierDocker_MBDS_31.Pages.courrier
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
            //ViewData["priorites"] = _context.Priorite.ToList<Priorite>();
            Priorites = _context.Priorite.Select(p => new SelectListItem { 
                Value = p.Id.ToString(),
                Text = p.Val
            }).ToList();
            return Page();
        }

        [BindProperty]
        public Courrier Courrier { get; set; } = default!;
        public int PrioriteId { get; set; } = default;
        public IList<SelectListItem> Priorites { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Courrier.Priorite = new Priorite();
            Courrier.Priorite.Id = PrioriteId;
            Courrier.Priorite.Id = PrioriteId;
            Courrier.Priorite.Id = PrioriteId;
          if (!ModelState.IsValid || _context.Courrier == null || Courrier == null)
            {
                return Page();
            }

            _context.Courrier.Add(Courrier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
