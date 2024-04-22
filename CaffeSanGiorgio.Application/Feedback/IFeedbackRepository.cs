using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Domain.Feedback;

namespace CaffeSanGiorgio.Application.Feedback;

public interface IFeedbackRepository : IRepository<FeedbackEntity>
{
    
}