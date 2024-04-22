using CaffeSanGiorgio.Domain.Customer;

namespace CaffeSanGiorgio.Application.Customer.Commands.Create;

public class CustomerDto
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    public static CustomerEntity ToEntity(string fullName, string email)
    {
        return new CustomerEntity
        {
            CreatedByUserId = "Admin",
            FullName = fullName,
            Email = email
        };
    }

    public static CustomerDto ToDto(CustomerEntity entity)
    {
        return new CustomerDto
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Email = entity.Email
        };
    }
}