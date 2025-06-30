using System.ComponentModel.DataAnnotations;

namespace LabForWeb.EC.DAL.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Nome { get; set; }

    public virtual ICollection<Prodotto> Prodotti { get; set; } = [];
}

