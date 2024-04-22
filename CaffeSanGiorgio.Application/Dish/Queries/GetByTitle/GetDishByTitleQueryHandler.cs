using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;
using MediatR;

namespace CaffeSanGiorgio.Application.Dish.Queries.GetByTitle;

public class GetDishByTitleQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetDishByTitleQuery, DishDto>
{
    public Task<DishDto> Handle(GetDishByTitleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var dishEntity = unitOfWork
                .DishRepository
                .GetChangeTrackingQuery()
                .FirstOrDefault(d => d.Title == request.Title);

            return Task.FromResult(new DishDto(dishEntity));
        }
        catch (Exception e)
        {
            Console.WriteLine($"No dish found with the title '{request.Title}'.");
            return null;
        }
    }
}