using Microsoft.EntityFrameworkCore;

namespace Mini_Projet.Models.Repositories
{
    public class CategorieRepository : ICatRepository<Categorie>
    {
        private readonly AppDbContext context;
        public CategorieRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Categorie Add(Categorie c)
        {
            context.Categorie.Add(c);
            context.SaveChanges();
            return c;
        }
        public Categorie Delete(int Id)
        {
            Categorie P = context.Categorie.Find(Id);
            if (P != null)
            {
                context.Categorie.Remove(P);
                context.SaveChanges();
            }
            return P;
        }
        public IList<Categorie> GetAll()
        {
            
                return context.Categorie.ToList();
           
                
        }
        public Categorie Get(int CategorieID)
        {
            return context.Categorie.Find(CategorieID);
        }
        public Categorie Update(Categorie P)
        {
            var categorie =
            context.Categorie.Attach(P);
            categorie.State = EntityState.Modified;
            context.SaveChanges();
            return P;
        }
        public IList<Categorie> FindByName(string name)
        {
            return context.Categorie.Where(s =>
            s.Nom.Contains(name)).ToList();
        }
        public Categorie GetProduitsByCateg(string cat)
        {
            return context.Categorie.Include("Produits")
        .Single(g => g.Nom == cat);
        }

    }
}
