using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;
using CaffeSanGiorgio.Application.Category.Common;

namespace CaffeSanGiorgio.Application.Category.Queries.GetByTitle;

public class GetCategoryByTitleQueryHandler(IUnitOfWork unitOfWork) 
    : BaseHandler<GetCategoryByTitleQuery, CategoryDto>(unitOfWork)
{
    public override async Task<CategoryDto> Handle(GetCategoryByTitleQuery request, CancellationToken cancellationToken)
    {
        var result = unitOfWork
            .CategoryRepository
            .GetChangeTrackingQuery()
            .Where(x => x.IsDeleted == false)
            .FirstOrDefault(c => c.Title == request.Title);

        if (result == null)
        {
            Console.WriteLine("No such a Category founded!");
            return default;
        }

        return await Task.FromResult(CategoryDto.FromEntity(result));
    }
}