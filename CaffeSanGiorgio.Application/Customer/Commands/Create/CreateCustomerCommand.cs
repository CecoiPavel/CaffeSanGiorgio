using MediatR;

namespace CaffeSanGiorgio.Application.Customer.Commands.Create;

public record CreateCustomerCommand(string Name, string Email) : IRequest<CustomerDto>;