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
using CaffeSanGiorgio.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CaffeSanGiorgio.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositoriesConfig();
        services.AddDbContextConfig(configuration);
    }

    private static void AddRepositoriesConfig(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork>(provider =>
        {
            var dbContext = provider.GetRequiredService<SanGiorgioContext>();

            const bool disposed = false;

            return new UnitOfWork(dbContext, disposed);
        });

        //Repos
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICookRepository, CookRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IDishRepository, DishRepository>();
        services.AddTransient<IFeedbackRepository, FeedbackRepository>();
        services.AddTransient<IIngredientRepository, IngredientRepository>();
        services.AddTransient<IOrderItemRepository, OrderItemRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
    }

    private static void AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SanGiorgioContext>(options =>
        {
            options.UseLazyLoadingProxies(); // Enabled lazy loading
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        });
    }
}