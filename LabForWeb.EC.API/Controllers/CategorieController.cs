using LabForWeb.EC.API.Extensions;
using LabForWeb.EC.API.Models;
using LabForWeb.EC.DAL;
using LabForWeb.EC.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LabForWeb.EC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategorieController : ControllerBase
{
    private readonly ECContext _dc;

    public CategorieController(ECContext dc)
    {
        _dc = dc;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetAll()
    {
        var data = await _dc.Categorie.Select(c => c.ToCategoriaModel()).ToListAsync();

        // return data;
        return Ok(data);
    }

    [HttpGet("{id}")] // GET /api/categorie/(un numero)
    public async Task<ActionResult<CategoriaModel>> GetById(int id)
    {
        // Esegue una query (attraverso EF) sul database che corrisponde a:
        // SELECT * FROM Categorie Id=76
        var categoria = await _dc.Categorie.SingleOrDefaultAsync(x => x.Id == id); // Trovami l'unico dato che corrisponde o ritorna nullo

        if(categoria==null)
        {
            // Genera automaticamente una RESPONSE HTTP 404
            return NotFound();
        }
        // return data;
        return Ok(categoria.ToCategoriaModel());
    }

    [HttpPost] // POST /api/categorie
    public async Task<ActionResult<CategoriaModel>> Add(CategoriaDTO item)
    {
        // Oggetto da salvare sul DB
        var cat = new Categoria() // Oggetto del DB da DAL
        {
            Nome = item.Nome
        };

        try
        {
            _dc.Categorie.Add(cat); // Lo infilo in categoria
            await _dc.SaveChangesAsync(); // Rendi permamente l'inserimento
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
        catch (Exception ex) 
        {
            return Problem(ex.Message);
        }


        return Ok(cat.ToCategoriaModel()); // Restituisco il model con il metodo di estensione
    }

}
