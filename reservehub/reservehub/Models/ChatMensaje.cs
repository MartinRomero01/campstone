using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace reservehub.Models
{
    public partial class ChatMensaje
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [StringLength(50)]
        public string EmisorRol { get; set; } = null!;

        public string Texto { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public bool LeidoPorUsuario { get; set; }

        public bool LeidoPorAdmin { get; set; }

        // Propiedad de navegación hacia la entidad Usuario
        [ForeignKey("UsuarioId")]
        [InverseProperty("ChatMensajes")]
        public virtual Usuario? Usuario { get; set; }
    }
}