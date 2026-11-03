using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace reservehub.Pages.Admin.Ajustes
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string NombreSistema { get; set; } = "ReserveHub";

        [BindProperty]
        public string CorreoSoporte { get; set; } = "soporte@reservehub.cl";

        [BindProperty]
        public bool ModoMantenimiento { get; set; } = false;

        public string? MensajeExito { get; set; }

        public IActionResult OnGet()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Admin") return RedirectToPage("/Index");
            return Page();
        }

        public IActionResult OnPost()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Admin") return RedirectToPage("/Index");

            // Lógica simulada de guardado de configuraciones generales
            MensajeExito = "¡Configuraciones del sistema actualizadas exitosamente!";
            return Page();
        }
    }
}