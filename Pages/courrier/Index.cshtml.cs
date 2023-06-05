using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles.courrier;
using System.Drawing.Printing;

namespace CourrierDocker_MBDS_31.Pages.courrier
{
    public class IndexModel : PageModel
    {
        private readonly CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context _context;

        public IndexModel(CourrierDocker_MBDS_31.Data.CourrierDocker_MBDS_31Context context)
        {
            _context = context;
        }

        public IList<CourrierDetails> Courrier { get;set; } = default!;

        public async Task OnGetAsync(string? type_courrier)
        {
            type_courrier = type_courrier == null ? "recu" : type_courrier;
            int userID = int.Parse(HttpContext.Session.GetString("userID"));
            if (_context.CourrierDetails != null)
            {
                if (type_courrier.CompareTo("recu") == 0)
                {
                    //encore a modifier
                    string query = "SELECT * FROM CourrierDetails AS c WHERE c.ExpediteurID != {0} AND c.Id IN (SELECT CourrierID FROM Destinataire AS dest JOIN MyUser AS u ON u.UserDepartementId = dest.DepDestId AND u.Id = {0})";
                    Courrier = await _context.CourrierDetails.
                        FromSqlRaw(query, userID, userID).
                        ToListAsync();
                }
                else
                {
                    Courrier = await _context.CourrierDetails.
                        Where(c => c.ExpediteurID == userID).
                        ToListAsync();
                }
            }
        }
    }
}
