using CaffeSanGiorgio.Application.Ingredient.Common;
using CaffeSanGiorgio.Domain.Dish;

namespace CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;

public sealed class DishDto
{
    public string Id { get; set; }
    public string Title { get; private init; }
    public string Description { get; private init; }
    public decimal Price { get; private init; }
    public int EstimatedCookingTime { get; private init; } //Minutes
    public ICollection<IngredientDto> Ingredients { get; private init; }
    
    public DishDto(DishEntity entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        Description = entity.Description;
        Price = entity.Price;
        EstimatedCookingTime = entity.EstimatedCookingTime;
        Ingredients = entity.Ingredients.Select(dishIngredient => new IngredientDto
        {
            Name = dishIngredient.Ingredient.Name
            // Price = dishIngredient.Ingredient.Price
        }).ToList();
    }
    
    //Not the best approach :: this is just for testing::
    public string IngredientNames => string.Join(", ", Ingredients.Select(i => i.Name));


    private DishDto()
    {
    }

    public static IEnumerable<DishDto> FromEntity(IEnumerable<DishEntity>? entities)
    {
        if (entities == null)
            return Enumerable.Empty<DishDto>();
        
        return entities.Select(entity => new DishDto
        {
            Title = entity.Title,
            Description = entity.Description,
            Ingredients = entity.Ingredients.Select(dishIngredient => new IngredientDto
            {
                Name = dishIngredient.Ingredient.Name
                // Price = dishIngredient.Ingredient.Price
            }).ToList(),
            EstimatedCookingTime = entity.EstimatedCookingTime,
            Price = entity.Price
        });
    }
}