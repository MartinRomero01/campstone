using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace reservehub.Models;

[Index("CarreraId", Name = "IX_Aranceles_CarreraId")]
public partial class Arancele
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Monto { get; set; }

    public string? Descripcion { get; set; }

    public int? CarreraId { get; set; }

    [ForeignKey("CarreraId")]
    [InverseProperty("Aranceles")]
    public virtual Carrera? Carrera { get; set; }
}
