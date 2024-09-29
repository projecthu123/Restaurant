namespace Restaurant.Models.Repositories
{
    public interface IRepository<T>
    {
        void Add(T Btatata);
        void Update(int Id, T Btatata);
        void Delete(int Id, T Btatata);
        void Active(int Id );
        List<T> View();
        T Find(int Id);
        List<T> ViewClient();

       

    }
}
