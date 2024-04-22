using CaffeSanGiorgio.Domain.OrderItem;

namespace CaffeSanGiorgio.Application.OrderItem.Queries;

public class OrderItemDto
{
    public string DishId { get; set; }

    public static IEnumerable<OrderItemDto> FromEntity(List<OrderItemEntity> entity)
    {
        return entity.Select(entity => new OrderItemDto()
        {
            DishId = entity.DishId
        });
    }
}