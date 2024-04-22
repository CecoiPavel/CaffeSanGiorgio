using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;
using CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;

namespace CaffeSanGiorgio.Application.Dish.Queries.GetByTitles;

public class GetByTitlesQueryHandler(IUnitOfWork unitOfWork)
    : BaseHandler<GetByTitlesQuery, DishDto>(unitOfWork)
{
    public override Task<DishDto> Handle(GetByTitlesQuery request, CancellationToken cancellationToken)
    {
        // var result = UnitOfWork.DishRepository
        //     .GetChangeTrackingQuery()
        //     .FirstOrDefault(x => x.Title == request.Title);
        //
        // return Task.FromResult(DishDto.FromEntity(result));
        return null;
    }
}