using CaffeSanGiorgio.Domain.OrderItem;

namespace CaffeSanGiorgio.Application.OrderItem.Common;

public class ItemOrderDto
{
    public string Id { get; set; }
    public string DishId { get; set; }
    public string  OrderId { get; set; }
    public string? Title { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
    public int EstimatedDishWaitingTime { get; set; }

    public static OrderItemEntity ToEntity(ItemOrderDto entity)
    {
        return new OrderItemEntity
        {
            Quantity = entity.Quantity,
            Subtotal = entity.Subtotal,
            OrderId = entity.OrderId,
            DishId = entity.DishId
        };
    }
    
    public static ItemOrderDto ToDto(OrderItemEntity entity)
    {
        return new ItemOrderDto
        {
            Quantity = entity.Quantity,
            Subtotal = entity.Subtotal,
            OrderId = entity.OrderId,
            DishId = entity.DishId
        };
    }
}