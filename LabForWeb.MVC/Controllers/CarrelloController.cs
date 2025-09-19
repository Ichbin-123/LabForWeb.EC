using Microsoft.AspNetCore.Mvc;

namespace LabForWeb.MVC.Controllers;

public class CarrelloController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
