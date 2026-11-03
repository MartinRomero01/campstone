using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace reservehub.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public string? Rol { get; set; }

        public void OnGet()
        {
            // Usa HttpContext en lugar de Context
            Rol = HttpContext.Session.GetString("Rol");
        }
    }
}