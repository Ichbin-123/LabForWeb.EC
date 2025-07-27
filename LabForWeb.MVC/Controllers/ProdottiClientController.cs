using LabForWeb.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabForWeb.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiClientController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdottoModel>>> GetAll()
        {
            List<ProdottoModel> prodotti = [
            new ProdottoModel{
                Id = 1,
                Nome = "Ciabatte col pelo"
            },
            new ProdottoModel{
                Id = 2,
                Nome = "Bicicletta"
            }
        ];
            return Ok(prodotti);
        }
    }
}
