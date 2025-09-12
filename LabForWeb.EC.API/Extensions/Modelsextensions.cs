using LabForWeb.EC.API.Models;
using LabForWeb.EC.DAL.Models;

namespace LabForWeb.EC.API.Extensions;

public static class Modelsextensions
{
    public static CategoriaModel ToCategoriaModel(this Categoria item)
    {
        return new CategoriaModel
        {
            Id = item.Id,
            Nome = item.Nome
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
