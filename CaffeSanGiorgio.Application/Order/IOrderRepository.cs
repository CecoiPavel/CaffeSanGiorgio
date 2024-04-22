using CaffeSanGiorgio.Domain.Order;

namespace CaffeSanGiorgio.Application.Order;

public interface IOrderRepository
{
    Task<OrderEntity> AddOrderAsync(OrderEntity order);
}