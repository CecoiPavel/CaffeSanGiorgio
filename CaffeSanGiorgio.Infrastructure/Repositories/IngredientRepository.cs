using CaffeSanGiorgio.Application.Ingredient;
using CaffeSanGiorgio.Domain.Ingredient;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class IngredientRepository(SanGiorgioContext dbContext)
    : Repository<IngredientEntity>(dbContext), IIngredientRepository
{
    
}