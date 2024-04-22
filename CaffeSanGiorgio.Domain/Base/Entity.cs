namespace CaffeSanGiorgio.Domain.Base;

public abstract class Entity : BaseEntity<string>
{
    protected Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
}