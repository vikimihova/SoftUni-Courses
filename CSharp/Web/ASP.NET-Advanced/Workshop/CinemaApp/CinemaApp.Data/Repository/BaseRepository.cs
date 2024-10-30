using CinemaApp.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Repository
{
    public class BaseRepository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly CinemaDbContext context;
        private readonly DbSet<TType> dbSet;

        public BaseRepository(CinemaDbContext _context) // Dependency injection dbContext
        {
            this.context = _context;
            this.dbSet = this.context.Set<TType>();
        }

        // CRUD operations implementation of IRepository

        // Add
        public void Add(TType item)
        {
            this.dbSet.Add(item);
            this.context.SaveChanges();
        }

        public async Task AddAsync(TType item)
        {
            await this.dbSet.AddAsync(item);
            await this.context.SaveChangesAsync();
        }

        // Delete
        public bool Delete(TId id)
        {
            TType item = this.GetById(id);

            if (item == null)
            {
                return false;
            }

            this.dbSet.Remove(item);
            this.context.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            TType item = await this.GetByIdAsync(id);

            if (item == null)
            {
                return false;
            }

            this.dbSet.Remove(item);
            await this.context.SaveChangesAsync();

            return true;
        }

        // GetAll
        public IEnumerable<TType> GetAll() // detached from the database (because of .ToArray())
        {
            return this.dbSet.ToArray();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await this.dbSet.ToArrayAsync();
        }

        public IQueryable<TType> GetAllAttached() // still attached to the database
        {
            return this.dbSet.AsQueryable();
        }

        // GetById
        public TType GetById(TId id)
        {
            return this.dbSet.Find(id);
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            return await this.dbSet.FindAsync(id);
        }

        // Update
        public bool Update(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.context.Entry(item).State = EntityState.Modified;
                this.context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }            
        }

        public async Task<bool> UpdateAsync(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.context.Entry(item).State = EntityState.Modified;
                await this.context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }        
    }
}
