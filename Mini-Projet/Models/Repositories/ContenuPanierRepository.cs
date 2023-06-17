using Microsoft.EntityFrameworkCore;
using Mini_Projet.Models.Repositories;
using Mini_Projet.Models;

namespace Mini_Projet.Models.Repositories
{
    public class ContenuPanierRepository : IPanier<ContenuPanier>
    {
        private readonly AppDbContext context;
        public ContenuPanierRepository(AppDbContext context)
        {
            this.context = context;
        }
        public ContenuPanier Add(ContenuPanier CP)
        {
            context.contenuPaniers.Add(CP);
            context.SaveChanges();
            return CP;
        }
        public ContenuPanier Delete(int Id)
        {
            ContenuPanier CP = context.contenuPaniers.Find(Id);
            if (CP != null)
            {
                context.contenuPaniers.Remove(CP);
                context.SaveChanges();
            }
            return CP;
        }
        public IEnumerable<ContenuPanier> GetAll()
        {
            return context.contenuPaniers;
        }
        public ContenuPanier Get(int Id)
        {
            return context.contenuPaniers.Find(Id);
        }
        public ContenuPanier Update(ContenuPanier CP)
        {
            var ContenuPanier =
            context.contenuPaniers.Attach(CP);
            ContenuPanier.State = EntityState.Modified;
            context.SaveChanges();
            return CP;
        }
    }
}
