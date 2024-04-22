using CaffeSanGiorgio.Application.Category.Common;
using CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;
using CaffeSanGiorgio.Application.Order.Common;
using CaffeSanGiorgio.Application.OrderItem.Common;

namespace CaffeSanGiorgio.Application.Manager.Interface;

public interface ISanGiorgioManager
{
    Task<ICollection<CategoryDto>> GetAllCategories();
    Task<IEnumerable<DishDto>?> GetAllDishesByCategory(string? categoryTitle);
    Task<OrderDto> CreateOrderAsync(OrderDetailsDto detailsDto);
    Task<OrderDetailsDto> AddOrderDetails(IEnumerable<ItemOrderDto> items);
}