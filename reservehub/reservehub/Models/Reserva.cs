using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reservehub.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public int? UsuarioId { get; set; }

        [StringLength(200)]
        public string? Servicio { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; }

        // Propiedad de navegación hacia la entidad Usuario
        [ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; }
    }
}