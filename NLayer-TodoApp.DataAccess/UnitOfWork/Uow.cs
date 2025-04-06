using NLayer_TodoApp.DataAccess.Contexts;
using NLayer_TodoApp.DataAccess.Data.Interfaces;
using NLayer_TodoApp.DataAccess.Data.Repositories;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.DataAccess.UnitOfWork;

public class Uow : IUow
{
    private readonly TodoContext _context;

    public Uow(TodoContext context)
    {
        _context = context;
    }

    public IRepository<T> GetRepository<T>() where T : BaseEntity
    {
        return new Repository<T>(_context);
    }

    public async Task SaveAsync()
    {
         await _context.SaveChangesAsync();
    }
}