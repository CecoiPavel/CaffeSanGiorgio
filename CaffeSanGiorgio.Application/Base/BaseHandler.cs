using CaffeSanGiorgio.Application.Abstractions.Repositories;
using MediatR;

namespace CaffeSanGiorgio.Application.Base;

public abstract class BaseHandler<TRequest, TResponse>(IUnitOfWork unitOfWork) : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected readonly IUnitOfWork UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}