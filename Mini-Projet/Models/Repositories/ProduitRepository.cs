using Microsoft.EntityFrameworkCore;

namespace Mini_Projet.Models.Repositories
{
    public class ProduitRepository : IRepository<Produit>
    {
        private readonly AppDbContext context;
        public ProduitRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Produit Add(Produit P)
        {
            context.Produits.Add(P);
            context.SaveChanges();
            return P;
        }
        public Produit Delete(int Id)
        {
            Produit P = context.Produits.Find(Id);
            if (P != null)
            {
                context.Produits.Remove(P);
                context.SaveChanges();
            }
            return P;
        }
        public IList<Produit> GetAll()
        {
            return context.Produits.OrderBy(s => s.Nom).ToList();
        }
        public Produit Get(int ProduitID)
        {
            return context.Produits.Find(ProduitID);
        }
        public Produit Update(Produit P)
        {
           
                var Product =context.Produits.Attach(P);
                Product.State = EntityState.Modified;
                context.SaveChanges();
                return P;
       
            
        }
        public IList<Produit> FindByName(string name)
        {
            return context.Produits.Where(s =>
            s.Nom.Contains(name)).ToList();
        }


    }
}
