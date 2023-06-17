namespace Mini_Projet.Models.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        IList<T> GetAll();
        T Add(T t);
        T Update(T t);
        T Delete(int Id);
        IList<T> FindByName(string name);
    }
}
