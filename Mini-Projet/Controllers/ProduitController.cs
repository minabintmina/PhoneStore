using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using Mini_Projet.Models;
using Mini_Projet.Models.Repositories;
using Mini_Projet.ViewModel;


namespace Mini_Projet.Controllers
{
    public class ProduitController : Controller
    {
        readonly IRepository<Produit> Repository;
        readonly ICatRepository<Categorie> catRepository;
        readonly IWebHostEnvironment hostingEnvironment;
        public ProduitController(IRepository<Produit> Repository , ICatRepository<Categorie> catRepository, IWebHostEnvironment hostingEnvironment)
        {
            this.Repository = Repository;
            this.catRepository = catRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: ProduitController
        public ActionResult Index()
        {
            
            var prod = Repository.GetAll();
            return View(prod);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            var prod = Repository.Get(id);
            return View(prod);
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(catRepository.GetAll(), "CategorieId", "Nom");
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string? uniqueFileName = null;

                if (model.Image != null)
                {

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Produit newProduct = new()
                {
                    Nom = model.Nom,
                    Prix = model.Prix,
                    Quantite = model.Quantite,
                    CategorieId = model.CategorieId,
                    Image = uniqueFileName
                };
                Repository.Add(newProduct);
                return RedirectToAction("details", new { id = newProduct.ProduitId });
            }
            return View();
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            Produit product = Repository.Get(id);
            if (product == null)
            {
                return NotFound(); // or any other appropriate response
            }
#pragma warning disable CS8601 // Possible null reference assignment.
            EditViewModel productEditViewModel = new()
            {
                ProduitId = product.ProduitId,
                Nom = product.Nom,
               
                Prix = product.Prix,
                Quantite = product.Quantite,
                CategorieId = product.CategorieId,
                ExistingImagePath = product.Image
            };
#pragma warning restore CS8601 // Possible null reference assignment.
            return View(productEditViewModel);
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditViewModel model )
        {
            ViewBag.CategorieId = new SelectList(catRepository.GetAll(), "CategorieId", "Nom");
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the product being edited from the database
                Produit product = Repository.Get(model.ProduitId);
                // Update the product object with the data in the model object
                product.Nom = model.Nom;
                product.Prix = model.Prix;
                product.Quantite = model.Quantite;
                product.CategorieId = model.CategorieId;
                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.Image != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingImagePath != null)

                    {

                        string filePath = Path.Combine(@"C:\Users\Moetaz\source\repos\Mini-Projet\Mini-Projet\wwwroot\images", model.ExistingImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the product object which will be
                    // eventually saved in the database
                    product.Image = ProcessUploadedFile(model);
                }
                // Call update method on the repository service passing it the
                // product object to update the data in the database table
                Produit updatedProduct = Repository.Update(product);
                if (updatedProduct != null)
                    return RedirectToAction("Index");
                else
                    return NotFound();
            }
            return View(model);
        }
        private string ProcessUploadedFile(EditViewModel model)
        {
            string? uniqueFileName = null;
            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.Image.CopyTo(fileStream);
            }
#pragma warning disable CS8603 // Possible null reference return.
            return uniqueFileName;
#pragma warning restore CS8603 // Possible null reference return.
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produit p)
        {
            try
            {
                p.ProduitId = id;
                Repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string name , string CatName )
        {
            var result = Repository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = Repository.FindByName(name);
            else
            if (CatName != null)
                result = Repository.FindByName(name);
            ViewBag.ProduitId = new SelectList(Repository.GetAll(), "ProduitId", "Nom");
            return View("Index", result);
        }

    }
}
