namespace Mini_Projet.Models.Repositories
{
    public interface IPanier<T>
    {
        T Get(int id);
       
        T Add(T t);
        T Update(T t);
        T Delete(int Id);
       
    }
}
