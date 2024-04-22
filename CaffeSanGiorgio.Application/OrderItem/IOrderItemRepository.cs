using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Domain.OrderItem;

namespace CaffeSanGiorgio.Application.OrderItem;

public interface IOrderItemRepository : IRepository<OrderItemEntity>
{
    
}