using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Persistence;

public partial interface IRepositoryBase<T> where T : class
{
    /// <summary>
    /// Get entity by unique identifier.
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Entity</returns>
    T GetById(Guid id);
    /// <summary>
    /// Get async entity by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Entity</returns>
    Task<T> GetByIdAsync(Guid id);
    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns></returns>
    Task<List<T>> GetAllAsync();

    Task<bool> Exists(Expression<Func<T, bool>> predicate);
    Task<bool> Exists(Guid? id);

    /// <summary>
    /// Insert entity.
    /// </summary>
    /// <param name="entity">Entity to insert</param>
    /// <returns></returns>
    T Insert(T entity);
    /// <summary>
    /// Async insert entity.
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <returns></returns>
    Task<T> AddAsync(T entity);
    /// <summary>
    /// Insert entities.
    /// </summary>
    /// <param name="entities"></param>
    void Insert(IEnumerable<T> entities);
    /// <summary>
    /// Async insert entities.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities);
    /// <summary>
    /// Async insert many entities.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task InsertManyAsync(IEnumerable<T> entities);

    /// <summary>
    /// Update entity.
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);
    /// <summary>
    /// Async update entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> UpdateAsync(T entity);
    /// <summary>
    /// Update entities.
    /// </summary>
    /// <param name="entities"></param>
    void Update(IEnumerable<T> entities);
    /// <summary>
    /// Async update entities.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);

    /// <summary>
    /// Delete entity.
    /// </summary>
    /// <param name="entity"></param>
    void Delete(T entity);
    /// <summary>
    /// Async delete entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task DeleteAsync(T entity);
    /// <summary>
    /// Delete entities.
    /// </summary>
    /// <param name="entities"></param>
    void Delete(IEnumerable<T> entities);
    /// <summary>
    /// Async delete entities.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task DeleteAsync(IEnumerable<T> entities);
    /// <summary>
    /// Delete many entities.
    /// </summary>
    /// <param name="filterExpression"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> DeleteManyAsync(Expression<Func<T, bool>> filterExpression);

    /// <summary>
    /// Clear entities.
    /// </summary>
    /// <returns></returns>
    Task ClearAsync();
    /// <summary>
    /// Get a table.
    /// </summary>
    IQueryable<T> Table { get; }
}

