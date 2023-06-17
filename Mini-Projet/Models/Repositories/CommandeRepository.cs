using Microsoft.EntityFrameworkCore;

namespace Mini_Projet.Models.Repositories
{
    public class CommandeRepository : ICommande<Commande>
    {
        private readonly AppDbContext context;
        public CommandeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Commande Add(Commande C)
        {
            context.Commandes.Add(C);
            context.SaveChanges();
            return C;
        }
        public Commande Delete(int Id)
        {
            Commande C = context.Commandes.Find(Id);
            if (C != null)
            {
                context.Commandes.Remove(C);
                context.SaveChanges();
            }
            return C;
        }
        public IList<Commande> GetAll()
        {
            return (IList<Commande>)context.Commandes;
        }
        public Commande Get(int Id)
        {
            return context.Commandes.Find(Id);
        }
        public Commande Update(Commande C)
        {
            var Commande =
            context.Commandes.Attach(C);
            Commande.State = EntityState.Modified;
            context.SaveChanges();
            return C;
        }
    }
}
