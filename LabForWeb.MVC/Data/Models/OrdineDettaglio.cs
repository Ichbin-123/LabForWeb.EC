using System.ComponentModel.DataAnnotations;

namespace LabForWeb.MVC.Data.Models;

public class OrdineDettaglio
{
    public int Id { get; set; }

    [Required]
    public short Quantita { get; set; } = 0;

    public int OrdineId { get; set; }

    [Required]
    public virtual Ordine? Ordine { get; set; }

    public int ProdottoId { get; set; }

    [Required]
    public virtual Prodotto? Prodotto { get; set; }
}
