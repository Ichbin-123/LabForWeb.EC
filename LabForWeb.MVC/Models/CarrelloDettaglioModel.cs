namespace LabForWeb.MVC.Models;

public class CarrelloDettaglioModel
{

    public long Id {  get; set; }
    public string? NomeProdotto  { get; set; }

    public int Quantita { get; set; }

    public string? ImmageUrl { get; set; }

    public decimal Prezzo   { get; set; }

}