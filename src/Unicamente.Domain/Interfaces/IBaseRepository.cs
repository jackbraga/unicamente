namespace Unicamente.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
        IEnumerable<T> GetByName(string texto);
        int Add(T classe);
        void Update(T classe);
        void Remove(int id);
    }
}
