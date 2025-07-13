using LabForWeb.EC.API.Extensions;
using LabForWeb.EC.API.Models;
using LabForWeb.EC.DAL;
using LabForWeb.EC.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
}
