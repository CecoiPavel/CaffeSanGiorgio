using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;
using CaffeSanGiorgio.Application.Category.Common;

namespace CaffeSanGiorgio.Application.Category.Queries.GetAll;

public class GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork) 
    : BaseHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>(unitOfWork)
{
    public override async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var result = await unitOfWork.CategoryRepository.GetAll();

        return result.Select(entity => new CategoryDto(entity)).ToList();
    }
}