using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabForWeb.EC.DAL.Models;

public class PartitaIVA
{
    [Key]
    public int Id { get; set; } // Specificare che è PK nel fluent API

    [Required]
    [Column(TypeName = "char(11)")]
    public string? NumeroPIVA { get; set; }

    [Required]
    [Column(TypeName = "char(7)")]
    public string?  NumeroUnico { get; set; }

    [Required]
    [MaxLength(100)]
    public string? PEC { get; set; }

    [Required]
    public virtual Utente?  Utente { get; set; }

}
