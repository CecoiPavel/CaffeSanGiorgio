using CaffeSanGiorgio.Application.Customer;
using CaffeSanGiorgio.Domain.Customer;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class CustomerRepository(SanGiorgioContext dbContext)
    : Repository<CustomerEntity>(dbContext), ICustomerRepository
{
    
}