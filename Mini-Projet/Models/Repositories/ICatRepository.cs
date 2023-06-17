namespace Mini_Projet.Models.Repositories
{
    public interface ICatRepository<T>
    {
        T Get(int id);
        IList<T> GetAll();
        T Add(T t);
        T Update(T t);
        T Delete(int Id);
        T GetProduitsByCateg(string cat);

    }
}
