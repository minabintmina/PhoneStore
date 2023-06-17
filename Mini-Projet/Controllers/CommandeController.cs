using Microsoft.AspNetCore.Mvc;
using Mini_Projet.Models.Repositories;
using Mini_Projet.Models;


namespace Mini_Projet.Controllers
{
    public class CommandeController : Controller
    {
        readonly   ICommande<Commande> CommandeRepository;
        public CommandeController(ICommande<Commande> CommandeRepository)
        {
            this.CommandeRepository = CommandeRepository;

        }
        // GET: CommandeController
        public ActionResult Index()
        {
            var commande = CommandeRepository.GetAll();
            return View(commande);
        }

        // GET: CommandeController/Details/5
        public ActionResult Details(int id)
        {
            var commande = CommandeRepository.Get(id);
            return View(commande);
        }

        // GET: CommandeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommandeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Commande c)
        {
            try
            {

                CommandeRepository.Add(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommandeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommandeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Commande c)
        {
            try
            {
                CommandeRepository.Update(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommandeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommandeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
               CommandeRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
