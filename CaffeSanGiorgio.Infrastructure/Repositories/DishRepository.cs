using CaffeSanGiorgio.Application.Dish;
using CaffeSanGiorgio.Application.OrderItem.Common;
using CaffeSanGiorgio.Domain.Dish;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class DishRepository(SanGiorgioContext dbContext)
    : Repository<DishEntity>(dbContext), IDishRepository
{
    public Task<decimal> CalculatePrice(IEnumerable<ItemOrderDto> dtoList)
    {
        var total = 0m;

        foreach (var item in dtoList)
        {
            total += item.Subtotal;
        }

        return Task.FromResult(total * 1.2m); // add 20%
    }
}