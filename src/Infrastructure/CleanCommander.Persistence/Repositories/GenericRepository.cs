using CleanCommander.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CleanCommanderDbContext _dbContext;

        public GenericRepository(CleanCommanderDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().AddAsync(entity);
            _dbContext.SaveChangesAsync();

        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }      

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                .AsQueryable()
                .Where(predicate).ToListAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetPagedReponse(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }
    }
}
