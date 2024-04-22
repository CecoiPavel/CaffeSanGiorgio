using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Domain.Dish;
using CaffeSanGiorgio.Domain.Order;

namespace CaffeSanGiorgio.Domain.OrderItem;

public class OrderItemEntity : EntityFullAudited
{
    public string OrderId { get; set; }
    public string DishId { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
    
    public virtual OrderEntity Order { get; set; }
    public virtual DishEntity Dish { get; set; }
}