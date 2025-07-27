using System.ComponentModel.DataAnnotations;

namespace LabForWeb.MVC.Models;

// DTO => Data Trasfer Object: Come devonon essere fatti i dati che il client deve inviare a me Server
public class CategoriaDTO
{

    [Required(ErrorMessage = "Il campo {0} è obbligatorio")]
    public string? Nome { get; set; }

    //[Required(ErrorMessage = "Il campo {0} è obbligatorio")]
    //public string? Slug { get; set; }

}
