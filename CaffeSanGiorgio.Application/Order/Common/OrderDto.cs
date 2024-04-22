using CaffeSanGiorgio.Application.OrderItem.Common;
using CaffeSanGiorgio.Domain.Order;

namespace CaffeSanGiorgio.Application.Order.Common;

public class OrderDto
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string CookId { get; set; }
    public int TableNumber { get; set; }
    public DateTimeOffset OrderTime { get; set; }
    public decimal TotalPrice { get; set; }
    public int EstimatedWaitingTime { get; set; }
    public IEnumerable<ItemOrderDto> Items { get; set; }

    public static OrderEntity ToEntity(OrderDto dto)
    {
        return new OrderEntity
        {
            Id = dto.Id,
            CustomerId = dto.CustomerId,
            CookId = dto.CookId,
            TableNumber = dto.TableNumber,
            OrderTime = dto.OrderTime,
            TotalPrice = dto.TotalPrice,
            WaitingTime = dto.EstimatedWaitingTime
        };
    }
    
    public static OrderDto ToDto(OrderEntity entity)
    {
        return new OrderDto
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            CookId = entity.CookId,
            TableNumber = entity.TableNumber,
            OrderTime = entity.OrderTime,
            TotalPrice = entity.TotalPrice,
            EstimatedWaitingTime = entity.WaitingTime
        };
    }
}