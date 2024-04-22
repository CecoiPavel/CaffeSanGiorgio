using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Application.Base;

namespace CaffeSanGiorgio.Application.Customer.Commands.Create;

public class CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
    : BaseHandler<CreateCustomerCommand, CustomerDto>(unitOfWork)
{
    public override async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await UnitOfWork.CustomerRepository.Create(CustomerDto.ToEntity(request.Name, request.Email));

        await UnitOfWork.SaveChangesAsync();

        return CustomerDto.ToDto(customer);
    }
}