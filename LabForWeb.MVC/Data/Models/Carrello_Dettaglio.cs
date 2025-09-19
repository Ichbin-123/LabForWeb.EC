using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabForWeb.MVC.Data.Models;

public class Carrello_Dettaglio
{

    public long Id { get; set; }

    [Required]
    public int Quantita { get; set; } = 0;

    [Required]
    public virtual Carrello? Carrello { get; set; }

    [Required]
    public virtual Prodotto? Prodottto { get; set; }


}
