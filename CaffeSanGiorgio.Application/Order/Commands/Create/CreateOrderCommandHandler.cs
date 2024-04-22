using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;
using CaffeSanGiorgio.Application.Order.Common;

namespace CaffeSanGiorgio.Application.Order.Commands.Create;

public class CreateOrderCommandHandler(IUnitOfWork unitOfWork)
    : BaseHandler<CreateOrderCommand, OrderDto>(unitOfWork)
{
    public override async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var dto = OrderDto.ToEntity(request.Dto);

        var order = await UnitOfWork.OrderRepository.AddOrderAsync(dto);

        await unitOfWork.SaveChangesAsync();

        return OrderDto.ToDto(order);
    }
}