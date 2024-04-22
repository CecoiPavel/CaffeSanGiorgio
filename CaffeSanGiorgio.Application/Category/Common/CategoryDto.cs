using CaffeSanGiorgio.Domain.Category;

namespace CaffeSanGiorgio.Application.Category.Common;

public class CategoryDto
{
    public CategoryDto(CategoryEntity entity)
    {
        Id = entity.Id;
        Title = entity.Title;
    }

    private CategoryDto()
    {
    }

    public string Id { get; set; }
    public string? Title { get; set; }

    public static CategoryDto FromEntity(CategoryEntity entity)
    {
        return new CategoryDto
        {
            Title = entity.Title,
            Id = entity.Id
        };
    }
}