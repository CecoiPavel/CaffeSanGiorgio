using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Domain.Dish;
using CaffeSanGiorgio.Domain.Ingredient;

namespace CaffeSanGiorgio.Domain.Common;

public class DishIngredientEntity : EntityFullAudited
{
    public string DishId { get; set; }
    public string IngredientId { get; set; }
    
    public virtual DishEntity Dish { get; set; }
    public virtual IngredientEntity Ingredient { get; set; }
}