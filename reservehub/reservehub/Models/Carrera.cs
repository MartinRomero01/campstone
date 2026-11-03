using System.ComponentModel.DataAnnotations;

namespace reservehub.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la carrera es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        // Relación con Usuarios (un usuario pertenece a una carrera)
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        // Relación con Aranceles (una carrera tiene aranceles asociados)
        public virtual ICollection<Arancele> Aranceles { get; set; } = new List<Arancele>();
    }
}