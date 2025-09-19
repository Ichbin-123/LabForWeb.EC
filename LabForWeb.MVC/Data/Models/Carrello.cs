using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabForWeb.MVC.Data.Models;

public class Carrello
{

    public long Id { get; set; }

    [Required]
    public DateTime DataCreazione{ get; set; }

    public DateTime? DataChiusura { get; set; }

    [Required]
    [Column(TypeName = "money")]
    public decimal Sconto { get; set; } = 0M;

    [Required]
    public virtual ApplicationUser? Utente { get; set; }

    public virtual ICollection<Carrello_Dettaglio> Dettaglio { get; set; } = [];


}
