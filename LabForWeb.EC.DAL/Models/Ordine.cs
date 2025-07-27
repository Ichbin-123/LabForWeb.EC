using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LabForWeb.EC.DAL.Models;

//[Index(nameof(Stato))]
//[Index(nameof(Data))]
//[Index(nameof(Numero), nameof(Anno), IsUnique = true) ]
public class Ordine
{
    public int Id { get; set; }

    [Required]
    public StatoOrdine Stato { get; set; }

    // public int MetodoPagamento { get; set; }

    [Required]
    public int Numero  { get; set; }

    [Required]
    public int Anno { get; set; }

    [Required]
    public DateTime Data { get; set; }= DateTime.Now;

    public int IndirizzoId { get; set; }
    
    public virtual Indirizzo? Indirizzo { get; set; }

    public virtual ICollection<OrdineDettaglio> Dettagli { get; set; } = [];

}

public enum StatoOrdine: short
{
    CREATO =1,         // Ordine appena creato
    CONFERMATO = 2,     // Ordine confermato dal cliente
    IN_PREPARAZIONE = 3,// Il venditore sta preparando l'ordine
    SPEDITO = 4,        // Ordine spedito al cliente
    CONSEGNATO = 5,     // Ordine consegnato con successo
    ANNULLATO = 6,      // Ordine annullato
    RESO = 7            // Cliente ha restituito l'ordine
}