using Microsoft.EntityFrameworkCore;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly SRPDbContext mDbContext;

        public RepositoryBase(SRPDbContext dbContext)
        {
            mDbContext = dbContext;
            Table = mDbContext.Set<T>();
        }

        public IQueryable<T> Table { get; }

        public Task ClearAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            mDbContext.Set<T>().Remove(entity);
            mDbContext.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach(var tEntity in entities)
                Delete(tEntity);
        }

        public async Task DeleteAsync(T entity)
        {
            mDbContext.Set<T>().Remove(entity);
            await mDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<T> entities)
        {
            foreach(var tEntity in entities)
                await DeleteAsync(tEntity);
        }

        public Task<IEnumerable<T>> DeleteManyAsync(System.Linq.Expressions.Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByPredicateAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var tEntity = await GetByIdAsync(id);
            return tEntity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await mDbContext.Set<T>().ToListAsync();
        }

        public T GetById(Guid id)
        {
            var tEntity = mDbContext.Set<T>().Find(id);
            return tEntity ?? throw new EntityNotFoundException(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var tEntity = await mDbContext.Set<T>().FindAsync(id);
            return tEntity ?? throw new EntityNotFoundException(id);
        }

        public T Insert(T entity)
        {
            mDbContext.Add(entity);
            mDbContext.SaveChanges();
            return entity;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach(var tEntity in entities)
                Insert(tEntity);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await mDbContext.AddAsync(entity);
            await mDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities)
        {
            foreach(var tEntity in entities)
                await InsertAsync(tEntity);

            return entities;
        }

        public async Task InsertManyAsync(IEnumerable<T> entities)
        {
            await mDbContext.AddRangeAsync(entities);
            await mDbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            mDbContext.Entry(entity).State = EntityState.Modified;
            mDbContext.SaveChanges();
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach(var tEntity in entities)
                Update(tEntity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            mDbContext.Entry(entity).State = EntityState.Modified;
            await mDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities)
        {
            foreach(var tEntity in entities)
                await UpdateAsync(tEntity);

            return entities;
        }
    }
}
