using MediatR;

namespace CaffeSanGiorgio.Application.OrderItem.Queries;

public record GetOrderItemByIdQuery(string OrderId) : IRequest<IEnumerable<OrderItemDto>>;