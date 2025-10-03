using LabForWeb.MVC.Data;
using LabForWeb.MVC.Data.Models;
using LabForWeb.MVC.Extensions;
using LabForWeb.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LabForWeb.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dc;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, SignInManager<ApplicationUser> SignInManager)
    {
        _logger = logger;
        _dc = context;
        _signInManager = SignInManager;
    }

    public async Task<IActionResult> Index()
    {
        var model = new List<ProdottiGalleryPartialModel>();
        //List<ProdottiGalleryPartialModel> model = [];

        // Alternativa OOP style
        var categorieConAlmenoUnProdotto = _dc.Categorie.Where(c => c.Prodotti.Any());
        // Alternativa DB style
        var categorieConAlmenoUnProdotto2 = _dc.Prodotti.SelectMany(s => s.Categorie).Distinct();
       
        foreach (var cat in categorieConAlmenoUnProdotto)
        {
            var prodotti = await _dc.Prodotti
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
        // Da SQL
        //SELECT SUM(cd.Quantita) AS TotaleCarrello
        // FROM Carrelli AS c INNER JOIN CarrelloDettagli AS cd ON c.id = cd.CarrelloId
        // WHERE c.DataChiusura IS NULL AND c.UtenteId =  'a21a214d-7a39-4aa9-8c38-8804a0736db9'

        var utenteId = _signInManager.UserManager.GetUserId(User);
        var contatore = 0;

        // var carrelloAttivo = await _dc.Carrelli.Include(c=>c.Dettaglio).SingleOrDefaultAsync(c => c.Utente == user && !c.DataChiusura.HasValue);
        var carrelloAttivo = await _dc.Carrelli.Include(c => c.Dettaglio).SingleOrDefaultAsync(c => !c.DataChiusura.HasValue && c.Utente!.Id == utenteId);
        if(carrelloAttivo != null)
        {
            contatore = carrelloAttivo.Dettaglio.Sum(d => d.Quantita);
        }

        ViewData["ProdottiTotaliCarrello"] = contatore; // DateTime.Now.Second;
        

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
