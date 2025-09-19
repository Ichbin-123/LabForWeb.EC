using LabForWeb.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LabForWeb.MVC.Data;
using LabForWeb.MVC.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LabForWeb.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _contex;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _contex = context;
    }

    public async Task<IActionResult> Index()
    {
        var model = new List<ProdottiGalleryPartialModel>();
        //List<ProdottiGalleryPartialModel> model = [];

        // Alternativa OOP style
        var categorieConAlmenoUnProdotto = _contex.Categorie.Where(c => c.Prodotti.Any());
        // Alternativa DB style
        var categorieConAlmenoUnProdotto2 = _contex.Prodotti.SelectMany(s => s.Categorie).Distinct();
       
        foreach (var cat in categorieConAlmenoUnProdotto)
        {
            var prodotti = await _contex.Prodotti
                .Where(p => p.Categorie.Contains(cat))
                .Select(p => p.ToProdottoModle())
                .ToListAsync();

            var gallery = new ProdottiGalleryPartialModel
            {
                Titolo = string.IsNullOrEmpty(cat.Nome) ? "[Categoria senza Nome]" : cat.Nome,
                Prodotti = prodotti
            };

            model.Add(gallery);
        }

        // recupera dati carrello
        ViewData["ProdottiTotaliCarrello"] = DateTime.Now.Second;
        

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
