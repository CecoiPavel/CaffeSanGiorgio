namespace CaffeSanGiorgio.Domain.Base;

public class EntityFullAudited : EntityAudited
{
    public string? DeletedByUserId { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnDateTime { get; set; }
}