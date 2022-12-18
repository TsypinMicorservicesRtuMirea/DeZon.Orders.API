using DeZon.Orders.Entities;

namespace DeZon.Orders.Infrastructure.Abstractions;

public interface IRepository
{
    IQueryable<Order> Orders { get; }
    
    Task AddAsync<TEntity>(TEntity entity, CancellationToken token) where TEntity : BaseEntity;
    
    Task<int> SaveChangesAsync(CancellationToken token);
}