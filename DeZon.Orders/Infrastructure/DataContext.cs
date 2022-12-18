using DeZon.Orders.Entities;
using DeZon.Orders.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DeZon.Orders.Infrastructure;

public class DataContext : DbContext, IRepository
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    #region IQueryable

    public IQueryable<Order> Orders => DbOrders;
    
    #endregion
    
    #region DbSet

    private DbSet<Order> DbOrders { get; set; }

    #endregion
    
    public new async Task AddAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : BaseEntity
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await base.AddAsync(entity, token);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}