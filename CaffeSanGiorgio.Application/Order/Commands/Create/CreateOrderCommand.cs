using CaffeSanGiorgio.Application.Order.Common;
using MediatR;

namespace CaffeSanGiorgio.Application.Order.Commands.Create;

public record CreateOrderCommand(OrderDto Dto) : IRequest<OrderDto>;