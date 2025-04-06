using System.ComponentModel;
using NLayer_TodoApp.DataAccess.Data.Interfaces;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.DataAccess.UnitOfWork;

public interface IUow
{
    IRepository<T> GetRepository<T>() where T : BaseEntity;
    Task SaveAsync();
}