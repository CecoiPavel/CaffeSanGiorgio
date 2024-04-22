using CaffeSanGiorgio.Application.OrderItem.Common;
using MediatR;

namespace CaffeSanGiorgio.Application.OrderItem.Commands.Create;

public record CreateOrderItemCommand(ItemOrderDto Dto) : IRequest<ItemOrderDto>;