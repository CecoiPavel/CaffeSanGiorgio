using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Domain.Feedback;

namespace CaffeSanGiorgio.Domain.Cook;

public class CookEntity : EntityFullAudited
{
    public string FullName { get; set; }
    public int Rating { get; set; }
    public int DishesToCook { get; set; }
    
    public virtual ICollection<FeedbackEntity> Feedbacks { get; set; }
}