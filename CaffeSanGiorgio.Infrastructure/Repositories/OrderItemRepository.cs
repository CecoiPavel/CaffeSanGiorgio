using CaffeSanGiorgio.Application.OrderItem;
using CaffeSanGiorgio.Domain.OrderItem;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class OrderItemRepository(SanGiorgioContext dbContext)
    : Repository<OrderItemEntity>(dbContext), IOrderItemRepository
{
    
}