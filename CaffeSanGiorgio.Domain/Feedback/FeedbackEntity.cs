using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Domain.Cook;
using CaffeSanGiorgio.Domain.Customer;
using CaffeSanGiorgio.Domain.Order;

namespace CaffeSanGiorgio.Domain.Feedback;

public class FeedbackEntity : EntityFullAudited
{
    public string CustomerId { get; set; }
    public string? OrderId { get; set; }
    public string CookId { get; set; }
    public int Rating { get; set; } // Usually from 1 to 10
    public string Comment { get; set; }

    public virtual CookEntity Cook { get; set; }
    public virtual OrderEntity? Order { get; set; }
    public virtual CustomerEntity Customer{ get; set; }
}