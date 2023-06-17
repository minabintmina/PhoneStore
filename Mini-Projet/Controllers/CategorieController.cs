using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Projet.Models;
using Mini_Projet.Models.Repositories;
using NuGet.Protocol.Core.Types;

namespace Mini_Projet.Controllers
{
    public class CategorieController : Controller

    {
        readonly ICatRepository<Categorie> categorie;
        public CategorieController(ICatRepository<Categorie> categorie)
        {
            this.categorie = categorie;
        }
        // GET: CategorieController
        public ActionResult Index()
        {
            var cat = categorie.GetAll();
            return View(cat);
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {

            var cat = categorie.Get(id);
            return View(cat);
        }

        // GET: CategorieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie cat)
        {
            try
            {
                Categorie newCat = new Categorie
                {
                    Nom = cat.Nom
                };
                categorie.Add(newCat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categorie cat)
        {
            try
            {
                categorie.Update(cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategorieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                categorie.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DetailsCategorie(string cat)
        {
            var produitListe = categorie.GetProduitsByCateg(cat);
            return View(produitListe);
        }
    }
}
