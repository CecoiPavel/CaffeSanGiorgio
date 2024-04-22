using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Category;
using CaffeSanGiorgio.Application.Cook;
using CaffeSanGiorgio.Application.Customer;
using CaffeSanGiorgio.Application.Dish;
using CaffeSanGiorgio.Application.Feedback;
using CaffeSanGiorgio.Application.Ingredient;
using CaffeSanGiorgio.Application.Order;
using CaffeSanGiorgio.Application.OrderItem;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public sealed class UnitOfWork(SanGiorgioContext context, bool isDisposed) : IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get; } = new CategoryRepository(context);
    public ICookRepository CookRepository { get; } = new CookRepository(context);
    public ICustomerRepository CustomerRepository { get; } = new CustomerRepository(context);
    public IDishRepository DishRepository { get; } = new DishRepository(context);
    public IFeedbackRepository FeedbackRepository { get; } = new FeedbackRepository(context);
    public IIngredientRepository IngredientRepository { get; } = new IngredientRepository(context);
    public IOrderItemRepository OrderItemRepository { get; } = new OrderItemRepository(context);
    public IOrderRepository OrderRepository { get; } = new OrderRepository(context);

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    private async Task DisposeAsync(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                await context.DisposeAsync();
            }
        }

        isDisposed = true;
    }

    public async void Dispose()
    {
        await DisposeAsync(true);
    }
}