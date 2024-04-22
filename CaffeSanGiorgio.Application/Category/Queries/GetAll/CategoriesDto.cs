using CaffeSanGiorgio.Application.Category.Common;

namespace CaffeSanGiorgio.Application.Category.Queries.GetAll;

public class CategoriesDto
{
    public IEnumerable<CategoryDto> Categories { get; set; }
}