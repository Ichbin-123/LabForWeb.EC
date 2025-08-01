﻿using LabForWeb.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using LabForWeb.MVC.Data;
using LabForWeb.MVC.Extensions;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LabForWeb.MVC.Controllers;

public class ProdottiController : Controller
{

    private readonly ApplicationDbContext _context;
    public ProdottiController(ApplicationDbContext context)
    {
        _context= context;
    }
    public IActionResult Index()
    {
        // Dictionary che mappa CodiceFiscale => Nome Utente
        //var users = new Dictionary<string, string>();
        //users.Add("XYZ", "Matteo");
        //users.Add("BLL", "Bullo");

        //var matteo = users["XYZ"];

        //users["XYZ"] = "Franco";


        ViewData["Messaggio"] = "Ciao sono io!";

        //// POCO class
        //List<ProdottoModel> prodotti = [
        //    new ProdottoModel{
        //        Id = 1,
        //        Nome = "Ciabatte col pelo"
        //    },
        //    new ProdottoModel{
        //        Id = 2,
        //        Nome = "Bicicletta"
        //    }
        //];

        var prodotti= _context.Prodotti
            .OrderByDescending(x => x.Id)
            .Select(p => p.ToProdottoModle()).ToList();

        return View(prodotti);
    }

    public async Task<IActionResult> GetFakeData()
    {

        if (_context.Prodotti.Any()) return Ok(new {message = "Tutto già riempito"});

        var client = new HttpClient();

        var responseCategories = await client.GetFromJsonAsync<IEnumerable<DummyCategory>>("https://dummyjson.com/products/categories");

        var responseProducts = await client.GetFromJsonAsync<DammyJsonProductsResponse>("https://dummyjson.com/products");

        foreach (var c in responseCategories)
        {
            _context.Categorie.Add(new Data.Models.Categoria
            {
                Nome = c.Name,
                Slug = c.Slug
            });
        }

        await _context.SaveChangesAsync();

        foreach (var p in responseProducts.Products)
        {
            var prodotto = new Data.Models.Prodotto
            {
                Attivo = true,
                Descrizione = p.Description,
                DescrizioneBreve = p.Description,
                Giacenza = (short)p.Stock,
                ImageUrl = p.Thumbnail,
                Nome = p.Title,
                Prezzo = (decimal)p.Price,
                Visibile = true,
            };

            // Cerco la categoria che ha come Slug p.Category
            var cat = _context.Categorie.Single(c => c.Slug == p.Category);
            prodotto.Categorie.Add(cat);

            _context.Prodotti.Add(prodotto);
        }

        try
        {
           await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine(responseProducts);



        // return View(await _context.Prodotti.Select(s=>s.ToProdottoModle()).ToListAsync());
        return Ok(await _context.Prodotti.Select(s => s.ToProdottoModle()).ToListAsync());

    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var categorie = await _context.Categorie.Select(c => c.ToCategoriaModel()).ToListAsync();
        ViewData["Categorie"] = new SelectList(categorie, "Id", "Nome").ToList(); // guarda struttura Categoria Model 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProdottoDTO prodotto)
    {

        if (ModelState.IsValid)
        {
            // Salva su DB

            try
            {
                var nuovoProdotto = new Data.Models.Prodotto
                {
                    Nome = prodotto.Nome,
                    Descrizione = prodotto.Descrizione,
                    DescrizioneBreve = prodotto.DescrizioneBreve,
                    Giacenza = prodotto.Giacenza,
                    Prezzo = prodotto.Prezzo,
                    Attivo = prodotto.Attivo,
                    Visibile = prodotto.Visibile,
                };

                var cat = await _context.Categorie.SingleAsync(c => c.Id == prodotto.CategoriaID);
                nuovoProdotto.Categorie.Add(cat);

                _context.Prodotti.Add(nuovoProdotto);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(prodotto);
            }

            // return RedirectToAction("Index");
        }
        else
        {
            return View(prodotto);
        }
    }

}
