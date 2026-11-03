using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace reservehub.Models;

[Index("UsuarioId", Name = "IX_Notificaciones_UsuarioId")]
public partial class Notificacione
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Titulo { get; set; } = null!;

    [StringLength(500)]
    public string Mensaje { get; set; } = null!;

    public bool Leida { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int UsuarioId { get; set; }

    [StringLength(50)]
    public string Tipo { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Notificaciones")]
    public virtual Usuario Usuario { get; set; } = null!;
}
