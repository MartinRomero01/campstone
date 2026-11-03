using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace reservehub.Models;

[Index("CarreraId", Name = "IX_Usuarios_CarreraId")]
public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    public string Rut { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? CarreraId { get; set; }

    [ForeignKey("CarreraId")]
    [InverseProperty("Usuarios")]
    public virtual Carrera? Carrera { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();
    [InverseProperty("Usuario")]
    public virtual ICollection<ChatMensaje> ChatMensajes { get; set; } = new List<ChatMensaje>();
}
