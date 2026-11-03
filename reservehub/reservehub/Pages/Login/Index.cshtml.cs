using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using reservehub.Data;
using reservehub.Models;

namespace reservehub.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly ReserveHubContext _context;

        public IndexModel(ReserveHubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string? MensajeError { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Consulta directa a la tabla Usuarios creada en SQL
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == Email && u.Password == Password);

            if (usuario == null)
            {
                MensajeError = "Correo o contraseña incorrectos.";
                return Page();
            }

            // Guarda la sesión del usuario
            HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
            HttpContext.Session.SetString("Nombre", usuario.Nombre ?? "Usuario");
            HttpContext.Session.SetString("Rol", usuario.Rol ?? "Usuario");

            // Redirección según el Rol de la BD
            if (usuario.Rol == "Admin")
            {
                return RedirectToPage("/Admin/Index");
            }

            return RedirectToPage("/Usuario/Index");
        }
    }
}