using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Domain.Customer;

namespace CaffeSanGiorgio.Application.Customer;

public interface ICustomerRepository : IRepository<CustomerEntity>
{
    
}