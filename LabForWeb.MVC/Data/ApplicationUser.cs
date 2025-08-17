using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabForWeb.MVC.Data.Models;

namespace LabForWeb.MVC.Data;

public class ApplicationUser: IdentityUser
{
    [PersonalData]
    [Required]
    [MaxLength(120)]
    public string? Nome { get; set; }

    [PersonalData]
    [Required]
    [MaxLength(120)]
    public string? Cognome { get; set; }

    [PersonalData]
    [Required]
    [Column(TypeName = "char(16)")]
    public string? CodiceFiscale { get; set; }

    [PersonalData]
    [Required]
    public bool NotificheWA { get; set; } // Bool come tutti i primitivi non sono nullable per default

    public virtual ICollection<Indirizzo> Indirizzi { get; set; } = [];
    // public virtual PartitaIVA? PartitaIVA { get; set; }
}
