using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mini_Projet.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<ContenuPanier> contenuPaniers { get; set; }
        public DbSet<Panier> Panier { get; set; }
    }
}
