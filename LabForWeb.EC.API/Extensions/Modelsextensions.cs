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
}
