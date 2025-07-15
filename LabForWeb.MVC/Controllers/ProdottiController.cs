using LabForWeb.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabForWeb.MVC.Controllers;

public class ProdottiController : Controller
{
    public IActionResult Index()
    {
        // Dictionary che mappa CodiceFiscale => Nome Utente
        //var users = new Dictionary<string, string>();
        //users.Add("XYZ", "Matteo");
        //users.Add("BLL", "Bullo");

        //var matteo = users["XYZ"];

        //users["XYZ"] = "Franco";


        ViewData["Messaggio"] = "Ciao sono io!";

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

        return View(prodotti);
    }
}
