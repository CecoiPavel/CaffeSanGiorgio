using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Domain.Cook;
using CaffeSanGiorgio.Domain.Customer;
using CaffeSanGiorgio.Domain.Feedback;
using CaffeSanGiorgio.Domain.OrderItem;

namespace CaffeSanGiorgio.Domain.Order;

public class OrderEntity : EntityFullAudited
{
    public string CustomerId { get; set; }
    public string CookId { get; set; }
    public int TableNumber { get; set; }
    public DateTimeOffset OrderTime { get; set; }
    public decimal TotalPrice { get; set; }
    public int WaitingTime { get; set; }
    
    public virtual CustomerEntity Customer { get; set; }
    public virtual CookEntity Cook { get; set; }
    
    public virtual ICollection<OrderItemEntity> Items { get; set; }
    public virtual ICollection<FeedbackEntity> Feedbacks { get; set; }
    
}