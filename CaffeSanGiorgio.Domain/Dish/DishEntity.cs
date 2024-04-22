using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Domain.Category;
using CaffeSanGiorgio.Domain.Common;
using CaffeSanGiorgio.Domain.OrderItem;

namespace CaffeSanGiorgio.Domain.Dish;

public class DishEntity : EntityFullAudited
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CategoryId { get; set; }
    public decimal Price { get; set; } //We make the set private to control the access
    public int EstimatedCookingTime { get; set; } //Minutes
    
    public virtual CategoryEntity Category { get; set; }
    public virtual ICollection<DishIngredientEntity> Ingredients { get; set; }
    public virtual ICollection<OrderItemEntity> Orders { get; set; }
}