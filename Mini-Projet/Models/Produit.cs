using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mini_Projet.Models
{
    public class Produit
    {
        public int ProduitId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Nom { get; set; }
        [Required]
        [Display(Name = "Prix en Dinars :")]
        public float Prix { get; set; }
        [Required(ErrorMessage = "Erreur categorie !")]
        [Display(Name = "Catégorie")]
        public int CategorieId { get; set; }
        public  Categorie? Categorie { get; set; }
        [Required]
        [Display(Name = "Quantité en unité :")]
        public int Quantite { get; set; }
        [Required]
        [Display(Name = "Image :")]
        public string Image { get; set; }
    }
}
