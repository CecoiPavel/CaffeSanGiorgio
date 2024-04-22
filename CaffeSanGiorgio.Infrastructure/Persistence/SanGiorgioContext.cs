using CaffeSanGiorgio.Domain.Category;
using CaffeSanGiorgio.Domain.Common;
using CaffeSanGiorgio.Domain.Cook;
using CaffeSanGiorgio.Domain.Customer;
using CaffeSanGiorgio.Domain.Dish;
using CaffeSanGiorgio.Domain.Feedback;
using CaffeSanGiorgio.Domain.Ingredient;
using CaffeSanGiorgio.Domain.Order;
using CaffeSanGiorgio.Domain.OrderItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CaffeSanGiorgio.Infrastructure.Persistence;

public class SanGiorgioContext(DbContextOptions<SanGiorgioContext> options, IConfiguration configuration)
    : DbContext(options)
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CookEntity> Cookers { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<DishEntity> Dishes { get; set; }
    public DbSet<FeedbackEntity> Feedbacks { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<DishIngredientEntity> DishIngredients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
}