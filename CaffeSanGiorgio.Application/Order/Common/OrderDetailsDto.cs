using CaffeSanGiorgio.Application.OrderItem.Common;

namespace CaffeSanGiorgio.Application.Order.Common;

public class OrderDetailsDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public int TableNumber { get; set; }
    public IEnumerable<ItemOrderDto> Items { get; set; }
}