using LabForWeb.MVC.Data.Models;
using LabForWeb.MVC.Models;

namespace LabForWeb.MVC.Extensions;

public static class Modelsextensions
{
    public static CategoriaModel ToCategoriaModel(this Categoria item)
    {
        return new CategoriaModel
        {
            Id = item.Id,
            Nome = item.Nome,
            Slug = item.Slug
        };
    }

    public static ProdottoModel ToProdottoModle(this Prodotto prodotto)
    {
        return new ProdottoModel
        {
            Id = prodotto.Id,
            Nome = prodotto.Nome,
            Descrizione = prodotto.Descrizione,
            DescrizioneBreve = prodotto.DescrizioneBreve,
            Giacenza = prodotto.Giacenza,
            Prezzo = prodotto.Prezzo,
            Visibile = prodotto.Visibile,
            Attivo = prodotto.Attivo,
            ImageUrl = prodotto.ImageUrl
        };
    }
}

