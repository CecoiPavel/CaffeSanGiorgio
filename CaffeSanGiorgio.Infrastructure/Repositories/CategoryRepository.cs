using CaffeSanGiorgio.Application.Category;
using CaffeSanGiorgio.Domain.Category;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class CategoryRepository(SanGiorgioContext dbContext)
    : Repository<CategoryEntity>(dbContext), ICategoryRepository
{
}