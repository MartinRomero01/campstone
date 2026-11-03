using Microsoft.AspNetCore.Mvc.RazorPages;

namespace reservehub.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        public string Rol { get; set; } = "Usuario";

        public void OnGet()
        {
            Rol = HttpContext.Session.GetString("Rol") ?? "Usuario";
        }
    }
}