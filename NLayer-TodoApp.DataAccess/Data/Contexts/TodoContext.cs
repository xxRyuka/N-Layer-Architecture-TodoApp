using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayer_TodoApp.DataAccess.Configurations;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.DataAccess.Contexts;

public class TodoContext : DbContext
{
    public DbSet<Work> Works { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryWork> CategoryWorks { get; set; }
    
    public TodoContext(DbContextOptions<TodoContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new WorkConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // new kw kullanmak yerine Assembbly üzerinden cektim
    }

    public void UpdateTimeStamps()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedTime = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedTime = DateTime.Now;
            }
        }
    }

    public override int SaveChanges()
    {
        UpdateTimeStamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateTimeStamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateTimeStamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        UpdateTimeStamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
}