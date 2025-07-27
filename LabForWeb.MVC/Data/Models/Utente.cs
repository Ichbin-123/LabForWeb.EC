using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabForWeb.MVC.Data.Models;

public class Utente
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string? Nome { get; set; }

    [Required]
    [MaxLength(120)]
    public string? Cognome { get; set; }

    [Required]
    [Column(TypeName ="char(16)")]
    public string? CodiceFiscale { get; set; }

    [Required]
    [MaxLength(120)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Telefono { get; set; }

    public bool NotificheWA { get; set; } // Bool come tutti i primitivi non sono nullable per default

    public virtual ICollection<Indirizzo> Indirizzi { get; set; } = []; 
    public virtual PartitaIVA? PartitaIVA { get; set; }

}
