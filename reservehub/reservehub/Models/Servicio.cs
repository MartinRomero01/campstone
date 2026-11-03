using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace reservehub.Models;

public partial class Servicio
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Servicio")]
    public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();
}
