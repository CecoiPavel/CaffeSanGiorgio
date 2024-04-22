using CaffeSanGiorgio.Application.Cook.Common;
using MediatR;

namespace CaffeSanGiorgio.Application.Cook.Queries.GetAllAvailable;

public class GetAvailableCookerQuery : IRequest<CookDto>;