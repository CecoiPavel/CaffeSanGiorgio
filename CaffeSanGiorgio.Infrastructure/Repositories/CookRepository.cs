using CaffeSanGiorgio.Application.Cook;
using CaffeSanGiorgio.Domain.Cook;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class CookRepository(SanGiorgioContext dbContext)
    : Repository<CookEntity>(dbContext), ICookRepository
{
    
}