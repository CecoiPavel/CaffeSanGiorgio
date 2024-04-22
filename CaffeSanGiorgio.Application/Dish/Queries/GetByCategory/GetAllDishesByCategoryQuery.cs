using MediatR;

namespace CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;

public record GetAllDishesByCategoryQuery(string categoryId) : IRequest<IEnumerable<DishDto>>;