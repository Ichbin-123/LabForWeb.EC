namespace LabForWeb.MVC.Models;

public class ProdottiGalleryPartialModel
{
    public string Titolo { get; set; } = string.Empty;
    public IEnumerable<ProdottoModel> Prodotti { get; set; } = [];
}
