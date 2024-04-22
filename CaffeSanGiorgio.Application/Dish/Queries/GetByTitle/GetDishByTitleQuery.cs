using CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;
using MediatR;

namespace CaffeSanGiorgio.Application.Dish.Queries.GetByTitle;

public record GetDishByTitleQuery(string Title) : IRequest<DishDto>;