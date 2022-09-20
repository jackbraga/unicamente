namespace LanchoneteUDV.Application.Interfaces
{
    public interface IBaseService<T> where T : class 
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetByName(string texto);

        T GetById(int? id);

        void Add(T objeto);
        void Update(T objeto);
        void Remove(int id);
    }
}
