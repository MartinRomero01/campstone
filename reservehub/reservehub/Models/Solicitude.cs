using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reservehub.Models
{
    public class Solicitude
    {
        [Key]
        public int Id { get; set; }

        public string? Asunto { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Estado { get; set; }

        public int? UsuarioId { get; set; }

        public int? ServicioId { get; set; }

        public string? Motivo { get; set; }

        // Propiedades de Navegación limpias
        [ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; }

        [ForeignKey("ServicioId")]
        public virtual Servicio? Servicio { get; set; }
    }
}