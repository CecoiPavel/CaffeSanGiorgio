using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;

namespace CaffeSanGiorgio.Application.OrderItem.Queries;

public class GetOrderItemByIdQueryHandler(IUnitOfWork unitOfWork)
    : BaseHandler<GetOrderItemByIdQuery, IEnumerable<OrderItemDto>>(unitOfWork)
{
    public override Task<IEnumerable<OrderItemDto>> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        var items = unitOfWork.OrderItemRepository
            .GetChangeTrackingQuery()
            .Where(x => x.OrderId == request.OrderId).ToList();

        return Task.FromResult(OrderItemDto.FromEntity(items));
    }
}