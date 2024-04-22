namespace CaffeSanGiorgio.Domain.Base;

public class EntityAudited : Entity
{
    public DateTimeOffset? LastModificationTime { get; set; }
    public string? LastModifiedByUserId { get; set; }
    public DateTimeOffset CreationTime = DateTimeOffset.Now;
    public string? CreatedByUserId { get; set; }
}