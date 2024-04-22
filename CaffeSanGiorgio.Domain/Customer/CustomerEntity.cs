using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Domain.Feedback;

namespace CaffeSanGiorgio.Domain.Customer;

public class CustomerEntity : EntityFullAudited
{
    public string FullName { get; set; }
    public string Email { get; set; }
    
    public virtual ICollection<FeedbackEntity> Feedbacks { get; set; }
}