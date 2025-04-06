using System.Linq.Expressions;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.DataAccess.Data.Interfaces;

public interface IRepository<T> where T : BaseEntity 
{
    Task<List<T>> GetAllAsync(); // return List 
    Task<T?> GetByIdAsync(object id); // return Entity
    Task AddAsync(T entity); // void
    void Update(T entity); // void
    void Delete(T entity); // void 
    Task<T> GetByFilter(Expression<Func<T,bool>> predicate,bool AsNoTracking = false); // order by yapabiliriz en basitinden
    Task<List<T>> ListByFilter(Expression<Func<T,bool>> predicate,bool AsNoTracking = false);
    
    IQueryable<T> GetQuery();
}