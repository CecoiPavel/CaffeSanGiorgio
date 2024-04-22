using CaffeSanGiorgio.Application.Feedback;
using CaffeSanGiorgio.Domain.Feedback;
using CaffeSanGiorgio.Infrastructure.Persistence;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class FeedbackRepository(SanGiorgioContext dbContext)
    : Repository<FeedbackEntity>(dbContext), IFeedbackRepository
{
    
}