using CourrierDocker_MBDS_31.modeles.account;
using CourrierDocker_MBDS_31.modeles.courrier;
using CourrierDocker_MBDS_31.modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CourrierDocker_MBDS_31.Pages.courrier
{
    public class ValidationModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public ValidationModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }
        [BindProperty]
        private MyUser myUser { get; set; } = default!;
        public async Task<IActionResult> OnGet(int id)
        {
            if (HttpContext.Session.GetString("userID") != null)
            {
                var u = await _context.MyUser.FirstOrDefaultAsync(m => m.Id == int.Parse(HttpContext.Session.GetString("userID")));
                if (u == null)
                    return NotFound();
                myUser = u;
                Destinataire destinataire = _context.Destinataire.FirstOrDefault(
                    d => d.CourrierID == id && d.DepDestID == myUser.UserDepartementID
                );
                if (destinataire != null && myUser != null)
                {
                    if (myUser.UserPosteID == Donnees.DirecteurID)
                    {
                        destinataire.DateRecepDr = DateTime.Now;
                    }
                    else if (myUser.UserPosteID == Donnees.SecretaireID)
                    {
                        destinataire.DateRecepSec = DateTime.Now;
                    }
                    else if (myUser.UserPosteID == Donnees.ReceptionnisteID)
                    {
                        destinataire.DateRecepLiv = DateTime.Now;
                    }
                    _context.Attach(destinataire).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DestinataireExists(destinataire.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            return RedirectToPage("/courrier/Details", new { id = id });
        }
        private bool DestinataireExists(int id)
        {
            return (_context.Destinataire?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
