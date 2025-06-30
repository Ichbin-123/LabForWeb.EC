using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabForWeb.EC.DAL.Models;

public class Prodotto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(400)]
    public string? Nome { get; set; }

    [Required]
    [MaxLength(2000)]
    public string? DescrizioneBreve { get; set; }

    [Required]
    public string? Descrizione { get; set; } // Nvarchar(max) di default

    [Required]
    public short? Giacenza { get; set; } = 0;

    [Required]
    [Column(TypeName ="money")]
    public decimal? Prezzo { get; set; }

    [Required]
    public bool? Visibile { get; set; } = true;

    [Required]
    public bool? Attivo { get; set; } = true;

    public virtual ICollection<Categoria> Categorie { get; set; } = [];

    public virtual ICollection<OrdineDettaglio> OrdineDettagli { get; set; } = [];


}
