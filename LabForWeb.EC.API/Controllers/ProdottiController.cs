using LabForWeb.EC.API.Extensions;
using LabForWeb.EC.API.Models;
using LabForWeb.EC.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabForWeb.EC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdottiController : ControllerBase
{
    private readonly ECContext _dc;
    public ProdottiController(ECContext dc)
    {
        _dc = dc;
    }

    [HttpGet] // GET /api/prodotti
    public async Task<ActionResult<IEnumerable<ProdottoModel>>> GetAll()
    {
        var prodotti = await _dc.Prodotti.Select(s => s.ToProdottoModle()).ToListAsync();
        return Ok(prodotti);
    }
}
