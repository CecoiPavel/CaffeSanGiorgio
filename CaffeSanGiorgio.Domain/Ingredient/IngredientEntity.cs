using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Domain.Common;

namespace CaffeSanGiorgio.Domain.Ingredient;

public class IngredientEntity : EntityFullAudited
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public virtual ICollection<DishIngredientEntity> Dishes { get; set; }
}