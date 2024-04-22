using CaffeSanGiorgio.Application.Feedback.Common;
using CaffeSanGiorgio.Domain.Cook;
using CaffeSanGiorgio.Domain.Feedback;

namespace CaffeSanGiorgio.Application.Cook.Common;

public sealed class CookDto
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public int Rating { get; set; }
    public int DishesToCook { get; set; }
    public ICollection<FeedbackDto> Feedbacks { get; set; }

    public static CookDto FromEntity(CookEntity entity)
    {
        return new CookDto
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Rating = entity.Rating,
            DishesToCook = entity.DishesToCook,
            Feedbacks = entity.Feedbacks.Select(dishIngredient => new FeedbackDto
            {
                CustomerName = dishIngredient.Customer.FullName,
                Comment = dishIngredient.Comment,
                Rating = dishIngredient.Rating
            }).ToList()
        };
    }
    
    public static CookEntity FromDto(CookDto entity)
    {
        return new CookEntity
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Rating = entity.Rating,
            DishesToCook = entity.DishesToCook,
            Feedbacks = entity.Feedbacks.Select(dishIngredient => new FeedbackEntity
            {
                CustomerId = dishIngredient.CustomerName,
                Comment = dishIngredient.Comment,
                Rating = dishIngredient.Rating
            }).ToList()
        };
    }
}