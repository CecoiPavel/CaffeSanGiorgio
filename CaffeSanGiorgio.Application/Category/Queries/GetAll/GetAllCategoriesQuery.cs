using CaffeSanGiorgio.Application.Category.Common;
using MediatR;

namespace CaffeSanGiorgio.Application.Category.Queries.GetAll;

public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;