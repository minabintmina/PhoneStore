using System.ComponentModel.DataAnnotations;

namespace Mini_Projet.Models
{
    public class Categorie
    {
        
        
            public int CategorieId { get; set; }
            [Required]
            [Display(Name = "Nom")]
            public string Nom { get; set; }
            public  IList<Produit> Produits { get; set; }
        
    }
}
