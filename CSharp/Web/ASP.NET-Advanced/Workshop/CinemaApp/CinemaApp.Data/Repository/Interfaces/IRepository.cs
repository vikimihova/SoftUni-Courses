namespace CinemaApp.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId> // for CRUD operations between Services and Database
    {
        TType GetById(TId id); // synchronous
        Task<TType> GetByIdAsync(TId id); // asynchronous


        IEnumerable<TType> GetAll(); // synchronous
        Task<IEnumerable<TType>> GetAllAsync(); // asynchronous ...

        IQueryable<TType> GetAllAttached(); // only synchronous

        void Add(TType item);
        Task AddAsync(TType item);


        bool Delete(TId id);
        Task<bool> DeleteAsync(TId id);


        bool Update(TType item);
        Task<bool> UpdateAsync(TType item);
    }
}
