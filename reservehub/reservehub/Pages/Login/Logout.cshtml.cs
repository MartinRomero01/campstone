using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace reservehub.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Usa HttpContext en lugar de Context
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}