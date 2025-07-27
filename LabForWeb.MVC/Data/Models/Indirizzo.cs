using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabForWeb.MVC.Data.Models;

public class Indirizzo
{

    public int Id { get; set; }

    [Required]
    [MaxLength(160)]
    public string? Via { get; set; }

    [Required]
    [Column(TypeName = "char(5)")]
    public string? CAP { get; set; }

    [Required]
    [MaxLength(160)]
    public string? Comune { get; set; }

    [Required]
    [Column(TypeName = "char(2)")]
    public string? ProvinciaSigla { get; set; }

    [Required]
    [MaxLength(12)]
    public string? ScalaInterno { get; set; }

    [Required]
    [MaxLength(100)]
    public string? CognomeCitofono { get; set; }

    [Required]
    public string? InfoIndirizzo { get; set; }

    public int UtenteId { get; set; }

    [Required]
    public virtual Utente? Utente { get; set; }

    public virtual ICollection<Ordine> Ordini { get; set; } = [];
}
