using LabForWeb.MVC.Data;
using LabForWeb.MVC.Extensions;
using LabForWeb.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabForWeb.MVC.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategorieController(ApplicationDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            var categorie = _context.Categorie
                .OrderByDescending(x => x.Id)
                .Select(p => p.ToCategoriaModel()).ToList();

            return View(categorie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaDTO categoria)
        {

            if (ModelState.IsValid)
            {
                // Salva su DB

                try
                {
                    var nuovaCategoria = new Data.Models.Categoria
                    {                        
                        Nome = Char.ToUpper(categoria.Nome![0]) + categoria.Nome.Substring(1),
                        Slug = categoria.Nome.ToLower()
                    };

                    foreach (var cat in _context.Categorie)
                    {
                        if (cat.Slug == nuovaCategoria.Slug) throw new Exception("Categoria già esistente");
                    }

                    _context.Categorie.Add(nuovaCategoria);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View(categoria);
                }

                // return RedirectToAction("Index");
            }
            else
            {
                return View(categoria);
            }
        }
    }
}
