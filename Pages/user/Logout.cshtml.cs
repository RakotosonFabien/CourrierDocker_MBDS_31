using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourrierDocker_MBDS_31.Pages.user
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("userID") != null)
            {
                HttpContext.Session.Remove("userID");
            }
            return RedirectToPage("/user/Login");
        }
    }
}
