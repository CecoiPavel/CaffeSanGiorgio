using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Category.Common;
using CaffeSanGiorgio.Application.Category.Queries.GetAll;
using CaffeSanGiorgio.Application.Category.Queries.GetByTitle;
using CaffeSanGiorgio.Application.Cook.Common;
using CaffeSanGiorgio.Application.Cook.Queries.GetAllAvailable;
using CaffeSanGiorgio.Application.Customer.Commands.Create;
using CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;
using CaffeSanGiorgio.Application.Dish.Queries.GetByTitle;
using CaffeSanGiorgio.Application.Manager.Interface;
using CaffeSanGiorgio.Application.Order.Commands.Create;
using CaffeSanGiorgio.Application.Order.Common;
using CaffeSanGiorgio.Application.OrderItem.Commands.Create;
using CaffeSanGiorgio.Application.OrderItem.Common;
using MediatR;

namespace CaffeSanGiorgio.Infrastructure.Manager;

public class SanGiorgioManager(IMediator mediator) : ISanGiorgioManager
{

    private readonly IUnitOfWork unitOfWork;
    public async Task<ICollection<CategoryDto>> GetAllCategories()
    {
        return (ICollection<CategoryDto>)await mediator.Send(new GetAllCategoriesQuery());
    }

    public async Task<IEnumerable<DishDto>?> GetAllDishesByCategory(string? categoryTitle)
    {
        var category = await mediator.Send(new GetCategoryByTitleQuery(categoryTitle));

        if (category is null)
        {
            return null;
        }

        return await mediator.Send(new GetAllDishesByCategoryQuery(category.Id));
    }

    public async Task<OrderDto> CreateOrderAsync(OrderDetailsDto detailsDto)
    {
        if (detailsDto is null)
        {
            return default;
        }

        var customer = await mediator.Send(new CreateCustomerCommand(detailsDto.FullName, detailsDto.Email));

        var dishesList = detailsDto.Items;

        var availableCookDto = await mediator.Send(new GetAvailableCookerQuery());

        availableCookDto.DishesToCook += detailsDto.Items.Sum(x => x.Quantity);

        if (availableCookDto.DishesToCook > 5)
        {
            Console.WriteLine("No Cooker available at the moment. (5 dishes)");
            return new OrderDto();
        }


        var totalPrice = detailsDto.Items.Sum(item => (item.Subtotal * item.Quantity));
        var waitingTime = detailsDto.Items.Sum(item => (item.EstimatedDishWaitingTime * item.Quantity));

        var order = new OrderDto
        {
            Id = Guid.NewGuid().ToString(),
            Items = dishesList,
            TableNumber = detailsDto.TableNumber,
            CookId = availableCookDto.Id,
            CustomerId = customer.Id,
            OrderTime = DateTimeOffset.Now,
            TotalPrice = totalPrice,
            EstimatedWaitingTime = waitingTime
        };

        var createOrderCommand = await mediator.Send(new CreateOrderCommand(order));

        foreach (var item in dishesList)
        {
            await mediator.Send(new CreateOrderItemCommand(new ItemOrderDto
            {
                Id = Guid.NewGuid().ToString(),
                Quantity = item.Quantity,
                EstimatedDishWaitingTime = item.EstimatedDishWaitingTime,
                Subtotal = item.Subtotal,
                Title = item.Title,
                DishId = item.DishId,
                OrderId = createOrderCommand.Id
            }));
        }

        return order;
    }

    public async Task<OrderDetailsDto> AddOrderDetails(IEnumerable<ItemOrderDto> items)
    {
        try
        {
            var itemOrderList = new List<ItemOrderDto>();

            foreach (var item in items)
            {
                var dish = await mediator.Send(new GetDishByTitleQuery(item.Title));

                if (dish is null)
                {
                    return null;
                }

                itemOrderList =
                [
                    new ItemOrderDto
                    {
                        Title = item.Title,
                        Quantity = item.Quantity,
                        EstimatedDishWaitingTime = dish.EstimatedCookingTime,
                        Subtotal = dish.Price,
                        DishId = dish.Id
                    }
                ];
            }

            return new OrderDetailsDto
            {
                Items = itemOrderList
            };
        }
        catch (Exception)
        {
            return null;
        }
    }
}