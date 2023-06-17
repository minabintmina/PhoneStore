namespace Mini_Projet.Models.Repositories
{
    public interface ICommande<T>
    {
        T Get(int id);
        IList<T> GetAll();
        T Add(T t);
        T Update(T t);
        T Delete(int Id);
    }
}
