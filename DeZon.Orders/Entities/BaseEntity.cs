namespace DeZon.Orders.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Created = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset Created { get; private set; }
}