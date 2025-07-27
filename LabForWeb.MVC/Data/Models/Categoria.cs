using System.ComponentModel.DataAnnotations;

namespace LabForWeb.MVC.Data.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Nome { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Slug { get; set; }

    public virtual ICollection<Prodotto> Prodotti { get; set; } = [];
}

