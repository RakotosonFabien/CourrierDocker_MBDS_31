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
using CourrierDocker_MBDS_31.modeles.account;
using CourrierDocker_MBDS_31.modeles;

namespace CourrierDocker_MBDS_31.Pages.courrier
{
    public class CreateModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;
        public CreateModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }
        
        public IActionResult OnGet(string? type_courrier)
        {
            MyUser myUser = _context.MyUser.FirstOrDefault(u => u.Id == int.Parse(HttpContext.Session.GetString("userID")));
            if (type_courrier != null)
                EstInterne = type_courrier.CompareTo("interne") == 0;
            else
                EstInterne = false;
            //Initialisation des donnees
            Departements = Utils.DonneesStatiquesDepartements(_context);
            Postes = Utils.DonneesStatiquesPostes(_context);
            Priorites = Utils.DonneesStatiquesPriorites(_context);
            Statuts = Donnees.Statuts;
            //Fin initialisation des donnees
            Coursiers = _context.MyUser.
            Where(u => u.UserPosteID == Donnees.CoursierID && u.UserDepartementID == myUser.UserDepartementID).
            Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nom + " " + p.Prenom
            }).ToList();
            return Page();
        }
        [BindProperty]
        public int PosteDest { get; set; }
        [BindProperty]
        public bool EstInterne { get; set; }
        [BindProperty]
        public string[] DepDest { get; set; }
        [BindProperty]
        public Courrier Courrier { get; set; } = default!;
        public int PrioriteId { get; set; } = default;
        public IList<SelectListItem> Priorites { get; set; } = default!;
        public IList<SelectListItem> Departements { get; set; } = default!;
        public IList<SelectListItem> Coursiers { get; set; } = default!;
        public IList<SelectListItem> Postes { get; set; } = default!;
        public IList<SelectListItem> Statuts { get; set; } = default!;
        public bool RechercheAvancee = true;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Courrier.CreateurID = int.Parse(HttpContext.Session.GetString("userID"));
            Courrier.ExpediteurID = int.Parse(HttpContext.Session.GetString("userID"));
            Courrier.DateCreation = DateTime.Now;
            string type_courrier = Request.Query["type_courrier"].ToString();
            if ( type_courrier != null)
                EstInterne = type_courrier.CompareTo("interne") == 0;
            else
                EstInterne = false;
            if (_context.Courrier == null || Courrier == null)
            {
                return Page();
            }
            else
            {
                _context.Courrier.Add(Courrier);
                await _context.SaveChangesAsync();
                if (EstInterne)
                {
                    MyUser myUser = _context.MyUser.FirstOrDefault(u => u.Id == int.Parse(HttpContext.Session.GetString("userID")));
                    //DepDest = new string[1] { myUser.UserDepartementID.ToString() };
                    Destinataire destinataire = new Destinataire(DateTime.Now, myUser.UserDepartementID, Courrier.Id);
                    destinataire.DestInterneID = PosteDest;
                    _context.Destinataire.Add(destinataire);
                }
                else
                {
                    foreach (string destID in DepDest)
                    {
                        Destinataire destinataire = new Destinataire(DateTime.Now, int.Parse(destID), Courrier.Id);
                        _context.Destinataire.Add(destinataire);
                    }
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
