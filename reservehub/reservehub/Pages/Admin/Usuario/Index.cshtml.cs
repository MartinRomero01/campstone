using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using reservehub.Data;
using reservehub.Models;

namespace reservehub.Pages.Admin.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly ReserveHubContext _context;

        public IndexModel(ReserveHubContext context)
        {
            _context = context;
        }

        // Se especifica reservehub.Models.Usuario para evitar el conflicto
        public List<reservehub.Models.Usuario> ListaUsuarios { get; set; } = new();

        [BindProperty]
        public reservehub.Models.Usuario NuevoUsuario { get; set; } = new();

        public string? MensajeExito { get; set; }
        public string? MensajeError { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Admin")
            {
                return RedirectToPage("/Index");
            }

            ListaUsuarios = await _context.Usuarios.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostCrearAsync()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Admin") return RedirectToPage("/Index");

            if (string.IsNullOrWhiteSpace(NuevoUsuario.Correo) || string.IsNullOrWhiteSpace(NuevoUsuario.Password))
            {
                MensajeError = "El correo y la contraseña son obligatorios.";
                ListaUsuarios = await _context.Usuarios.ToListAsync();
                return Page();
            }

            NuevoUsuario.CreadoPor = HttpContext.Session.GetString("Nombre") ?? "Admin";
            NuevoUsuario.FechaCreacion = DateTime.Now;

            _context.Usuarios.Add(NuevoUsuario);
            await _context.SaveChangesAsync();

            MensajeExito = $"Usuario '{NuevoUsuario.Nombre}' creado exitosamente.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Admin") return RedirectToPage("/Index");

            var usr = await _context.Usuarios.FindAsync(id);
            if (usr != null)
            {
                _context.Usuarios.Remove(usr);
                await _context.SaveChangesAsync();
                MensajeExito = "Usuario eliminado correctamente.";
            }

            return RedirectToPage();
        }
    }
}