namespace LabForWeb.MVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class ProdottoDTO
{

    [Required(ErrorMessage ="{0} obbligatorio")]
    [MaxLength(400)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "{0} obbligatorio")]
    [MaxLength(2000)]
    public string? DescrizioneBreve { get; set; }

    [Required(ErrorMessage = "{0} obbligatorio")]
    public string? Descrizione { get; set; } // Nvarchar(max) di default

    [Required(ErrorMessage = "{0} obbligatorio")]
    public short Giacenza { get; set; } = 0; // Levato ?

    [Required(ErrorMessage = "{0} obbligatorio")]
    public decimal Prezzo { get; set; }  // Levato ?

    [Required]
    public bool Visibile { get; set; } = true;

    [Required]
    public bool Attivo { get; set; } = true;

    public string? ImageUrl { get; set; }

    [Required]
    public int CategoriaID { get; set; }

    public IFormFile? Immagine { get; set; }
}
