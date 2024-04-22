using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.OrderItem.Common;
using CaffeSanGiorgio.Domain.Dish;

namespace CaffeSanGiorgio.Application.Dish;

public interface IDishRepository : IRepository<DishEntity>
{
    Task<decimal> CalculatePrice(IEnumerable<ItemOrderDto> dtoList);
}