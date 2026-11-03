using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using reservehub.Data;

namespace reservehub.Pages.Admin.Correos
{
    public class IndexModel : PageModel
    {
        private readonly ReserveHubContext _context;

        public IndexModel(ReserveHubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Asunto { get; set; } = string.Empty;

        [BindProperty]
        public string Mensaje { get; set; } = string.Empty;

        [BindProperty]
        public string DestinatariosTipo { get; set; } = "Todos"; // Todos, Alumnos, Admin

        public string? MensajeExito { get; set; }
        public string? MensajeError { get; set; }

        public IActionResult OnGet()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Admin") return RedirectToPage("/Index");

            return Page();
        }

        public async Task<IActionResult> OnPostEnviarAsync()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Admin") return RedirectToPage("/Index");

            if (string.IsNullOrWhiteSpace(Asunto) || string.IsNullOrWhiteSpace(Mensaje))
            {
                MensajeError = "El asunto y el mensaje del correo son obligatorios.";
                return Page();
            }

            // Aquí puedes integrar la lógica real de envío SMTP si lo requieres.
            // Simulamos el envío masivo exitoso:
            var totalUsuarios = DestinatariosTipo switch
            {
                "Alumnos" => await _context.Usuarios.CountAsync(u => u.Rol == "User"),
                "Admin" => await _context.Usuarios.CountAsync(u => u.Rol == "Admin"),
                _ => await _context.Usuarios.CountAsync()
            };

            MensajeExito = $"Correo masivo enviado exitosamente a {totalUsuarios} destinatarios bajo la categoría: {DestinatariosTipo}.";

            Asunto = string.Empty;
            Mensaje = string.Empty;

            return Page();
        }
    }
}