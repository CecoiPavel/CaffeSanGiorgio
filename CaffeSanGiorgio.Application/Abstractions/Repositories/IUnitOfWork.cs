using CaffeSanGiorgio.Application.Category;
using CaffeSanGiorgio.Application.Cook;
using CaffeSanGiorgio.Application.Customer;
using CaffeSanGiorgio.Application.Dish;
using CaffeSanGiorgio.Application.Feedback;
using CaffeSanGiorgio.Application.Ingredient;
using CaffeSanGiorgio.Application.Order;
using CaffeSanGiorgio.Application.OrderItem;

namespace CaffeSanGiorgio.Application.Abstractions.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
    ICategoryRepository CategoryRepository { get; }
    ICookRepository CookRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IDishRepository DishRepository { get; }
    IFeedbackRepository FeedbackRepository { get; }
    IIngredientRepository IngredientRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderItemRepository OrderItemRepository { get; }
}