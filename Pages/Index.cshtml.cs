using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourrierDocker_MBDS_31.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            bool connected = HttpContext.Session.GetString("userID")!=null?true:false;
            string redirection = connected ? "/courrier/Index" : "/user/Login";
            return RedirectToPage(redirection);
        }
    }
}