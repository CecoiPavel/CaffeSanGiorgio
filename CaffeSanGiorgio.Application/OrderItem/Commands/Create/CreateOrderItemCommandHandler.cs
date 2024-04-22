using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;
using CaffeSanGiorgio.Application.OrderItem.Common;

namespace CaffeSanGiorgio.Application.OrderItem.Commands.Create;

public class CreateOrderItemCommandHandler(IUnitOfWork unitOfWork)
    : BaseHandler<CreateOrderItemCommand, ItemOrderDto>(unitOfWork)
{
    public override async Task<ItemOrderDto> Handle(CreateOrderItemCommand request,
        CancellationToken cancellationToken)
    {
        var result = await unitOfWork.OrderItemRepository.Create(ItemOrderDto.ToEntity(request.Dto));

        await unitOfWork.SaveChangesAsync();

        return ItemOrderDto.ToDto(result);
    }
}