using Microsoft.AspNetCore.Mvc;
using Mini_Projet.Models.Repositories;
using Mini_Projet.Models;
using Mini_Projet.Models.Help;

namespace Mini_Projet.Controllers
{
    public class PanierController : Controller
    {
        readonly ProduitRepository produitRepository;
        public PanierController(ProduitRepository produitRepository)
        {
            this.produitRepository = produitRepository;
        }
        public ActionResult Index()
        {
            ViewBag.Liste = ListCart.Instance.Items;
            ViewBag.total = ListCart.Instance.GetSubTotal();
            return View();
        }
        public ActionResult AjouterProduit(int id)
        {
            Produit pp = produitRepository.Get(id);
            ListCart.Instance.AddItem(pp);
            ViewBag.Liste = ListCart.Instance.Items;
            ViewBag.total = ListCart.Instance.GetSubTotal();
            return View();
        }
        [HttpPost]
        public ActionResult PlusProduit(int id)
        {
            Produit pp = produitRepository.Get(id);
            ListCart.Instance.AddItem(pp);
            Item trouve = null;
            foreach (Item a in ListCart.Instance.Items)
            {
                if (a.Prod.ProduitId == pp.ProduitId)
                    trouve = a;
            }
            var results = new
            {
                ct = 1,
                Total = ListCart.Instance.GetSubTotal(),
                Quatite = trouve.quantite,
                TotalRow = trouve.TotalPrice
            };
            return Json(results);
        }
        [HttpPost]
        public ActionResult MoinsProduit(int id)
        {
            Produit pp = produitRepository.Get(id);
            ListCart.Instance.SetLessOneItem(pp);
            Item trouve = null;
            foreach (Item a in ListCart.Instance.Items)
            {
                if (a.Prod.ProduitId == pp.ProduitId)
                    trouve = a;
            }
            if (trouve != null)
            {
                var results = new
                {
                    Total = ListCart.Instance.GetSubTotal(),
                    Quatite = trouve.quantite,
                    TotalRow = trouve.TotalPrice,
                    ct = 1
                };
                return Json(results);
            }
            else
            {
                var results = new
                {
                    ct = 0
                };
                return Json(results);
            }
            return null;
        }
        public ActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckOut(FormCollection collection)
        {
            ListCart.Instance.Items.Clear();
            ViewBag.Message = "Commande effectuée zvec succès";
            return View();
        }
        [HttpPost]
        public ActionResult SupprimerProduit(int id)
        {
            Produit pp = produitRepository.Get(id);
            ListCart.Instance.RemoveItem(pp);
            var results = new
            {
                Total = ListCart.Instance.GetSubTotal(),
            };
            return Json(results);
        }
    }
}