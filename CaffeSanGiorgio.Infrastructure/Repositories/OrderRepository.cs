using CaffeSanGiorgio.Application.Order;
using CaffeSanGiorgio.Domain.Order;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class OrderRepository(SanGiorgioContext dbContext)
    : Repository<OrderEntity>(dbContext), IOrderRepository
{
    public async Task<OrderEntity> AddOrderAsync(OrderEntity order)
    {
        var entityEntry = await dbContext.Orders.AddAsync(order);
        
        return entityEntry.Entity;
    }
}