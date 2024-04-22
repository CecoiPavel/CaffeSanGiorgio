using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;

namespace CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;

public class GetAllDishesByCategoryQueryHandler(IUnitOfWork unitOfWork)
    : BaseHandler<GetAllDishesByCategoryQuery, IEnumerable<DishDto>>(unitOfWork)
{
    public override async Task<IEnumerable<DishDto>> Handle(GetAllDishesByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var result = UnitOfWork.DishRepository
            .GetChangeTrackingQuery()
            .Where(x => x.CategoryId == request.categoryId).ToList();

        return await Task.FromResult(DishDto.FromEntity(result));
    }
}