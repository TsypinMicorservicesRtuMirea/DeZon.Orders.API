namespace DeZon.Orders.Entities;

public class Order : BaseEntity
{
    private Order()
    {
        Id = Guid.NewGuid();
    }
    
    public Order(string name) : this()
    {
        Name = name;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }
}