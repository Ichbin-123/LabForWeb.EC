using LabForWeb.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LabForWeb.MVC.Data.Models;

namespace LabForWeb.MVC.Controllers;

public class CarrelloController : Controller
{
    private readonly ApplicationDbContext _dc;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public CarrelloController(ApplicationDbContext dc, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _dc = dc;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Add(int prodottoId)
    {

        // Scrittura DB
        // 1. Recupero l'utente loggato
        var user =  await _userManager.GetUserAsync(User);
        //var userId = user?.Id; // a21a214d-7a39-4aa9-8c38-8804a0736db9

        // 2. cerco se esiste già un carrello NON chiuso dell'utente loggato
        // Include carica in autonomia tutti i carrelli di Dettagli in JOIN con carrello
        var carrelloAttivo = await _dc.Carrelli.Include(c=>c.Dettaglio).SingleOrDefaultAsync(c => c.Utente == user && !c.DataChiusura.HasValue); // c => c.Utente!.Id == userId && !c.DataChiusura.HasValue


        // 3. Se non o trovo ne creo uno nuovo
        if (carrelloAttivo == null)
        {
            carrelloAttivo = new Carrello(); // 
            carrelloAttivo.Utente = user;
            carrelloAttivo.DataCreazione = DateTime.Now;
            _dc.Carrelli.Add(carrelloAttivo); // Carica sul DB
        }

        // 4. Recupero il prodotto che voglio inserire
        var prodotto = await _dc.Prodotti.SingleAsync(p=> p.Id == prodottoId);

        // 5. Cerco se esiste già tra i Dettaglidel Carrello il prodotto che voglio inserire
        var dettaglio = carrelloAttivo.Dettaglio.SingleOrDefault(cd => cd.Prodottto == prodotto);

        // Se non esiste lo creo
        if(dettaglio == null)
        {
            dettaglio = new Carrello_Dettaglio { Prodottto = prodotto, Quantita = 1, Carrello = carrelloAttivo};
            carrelloAttivo.Dettaglio.Add(dettaglio);
        }

        // Se esiste aumento di uno la quantità
        else 
        {
            dettaglio.Quantita++;
         }


        try
        {
            _dc.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }



        return RedirectToAction("Index", "Home");
    }
}
