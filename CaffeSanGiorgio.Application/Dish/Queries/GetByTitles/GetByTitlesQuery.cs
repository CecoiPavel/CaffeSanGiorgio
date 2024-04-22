using CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;
using MediatR;

namespace CaffeSanGiorgio.Application.Dish.Queries.GetByTitles;

public record GetByTitlesQuery(IEnumerable<string> Title) : IRequest<DishDto>;