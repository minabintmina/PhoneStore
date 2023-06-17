using Microsoft.AspNetCore.Mvc;
using Mini_Projet.Models;
using Mini_Projet.Models.Repositories;
using System.Diagnostics;

namespace Mini_Projet.Controllers
{
    public class HomeController : Controller

    {
        private readonly ICatRepository<Categorie> Repository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , ICatRepository<Categorie> Repository)
        {
            this.Repository = Repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        public ActionResult DetailsCategorie(string cat)
        {
            var produitListe = Repository.GetProduitsByCateg(cat);
            return View(produitListe);
        }
    }
}