using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;
using CaffeSanGiorgio.Application.Cook.Common;

namespace CaffeSanGiorgio.Application.Cook.Queries.GetAllAvailable;

public class GetAvailableCookerQueryHandler(IUnitOfWork unitOfWork)
    : BaseHandler<GetAvailableCookerQuery, CookDto>(unitOfWork)
{
    public override async Task<CookDto> Handle(GetAvailableCookerQuery request,
        CancellationToken cancellationToken)
    {
        var cookEntity =
            UnitOfWork
                .CookRepository
                .GetReadOnlyQuery()
                .FirstOrDefault(c => c.DishesToCook < 5);

        if (cookEntity is null)
        {
            return null;
        }

        return await Task.FromResult(CookDto.FromEntity(cookEntity));
    }
}