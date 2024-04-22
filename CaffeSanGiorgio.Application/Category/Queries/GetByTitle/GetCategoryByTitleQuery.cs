using CaffeSanGiorgio.Application.Category.Common;
using CaffeSanGiorgio.Application.Category.Queries.GetAll;
using MediatR;

namespace CaffeSanGiorgio.Application.Category.Queries.GetByTitle;

public record GetCategoryByTitleQuery(string? Title) : IRequest<CategoryDto>;