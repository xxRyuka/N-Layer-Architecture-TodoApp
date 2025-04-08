using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLayer_TodoApp.DataAccess.Contexts;
using NLayer_TodoApp.DataAccess.Data.Interfaces;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.DataAccess.Data.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly TodoContext _context;

    public Repository(TodoContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {

// entitylerimi base entityden kalıtıp , id değerini base entitye verdiğim için bu işlemi yapabiliyorum
        var updatedEntity = _context.Set<T>().Find(entity.Id);


        // Bütün alanlari modified olarak işaretlemesini istemiyorum oyüzden aşağıdaki metodu kullandım
        // _context.Update(updatedEntity);



        _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
    }

    public async Task<List<T>> GetAllAsync()
    {
        // asNoTrack?
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByFilter(Expression<Func<T, bool>>? predicate, bool AsNoTracking = false)
    {
        return  AsNoTracking
            ? await _context.Set<T>().Where(predicate!).AsNoTracking().FirstOrDefaultAsync()
            : await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
    }


    public async Task<List<T>> ListByFilter(Expression<Func<T, bool>> predicate, bool AsNoTracking = false)
    {
        return AsNoTracking
            ? await _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync()
            : await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public IQueryable<T> GetQuery()
    {
        return _context.Set<T>().AsQueryable();
    }
}