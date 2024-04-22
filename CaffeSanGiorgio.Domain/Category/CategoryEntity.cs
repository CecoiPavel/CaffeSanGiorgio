using CaffeSanGiorgio.Domain.Base;

namespace CaffeSanGiorgio.Domain.Category;

public class CategoryEntity : EntityFullAudited
{
    public string Title { get; set; }
}