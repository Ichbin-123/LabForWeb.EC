using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabForWeb.MVC.Models;

public class ProdottoModel
{
    public int Id { get; set; }

    
    public string? Nome { get; set; }

    
    public string? DescrizioneBreve { get; set; }

    
    public string? Descrizione { get; set; }

    
    public short? Giacenza { get; set; } = 0;

    
    public decimal? Prezzo { get; set; }

    
    public bool? Visibile { get; set; } = true;

    
    public bool? Attivo { get; set; } = true;

    public string? ImageUrl { get; set; }
}


