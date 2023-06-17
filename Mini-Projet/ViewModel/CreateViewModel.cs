using Mini_Projet.Models;
using System.ComponentModel.DataAnnotations;

namespace Mini_Projet.ViewModel
{
    public class CreateViewModel
    {
        public int ProduitId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Prix en Dinars :")]
        public float Prix { get; set; }
        [Required(ErrorMessage = "The Categorie field is required.")]
        public int CategorieId { get; set; }
        [Required]
        [Display(Name = "Quantité en unité :")]
        public int Quantite { get; set; }
        [Required]
        [Display(Name = "Image :")]
        public IFormFile Image { get; set; }
    }
}
