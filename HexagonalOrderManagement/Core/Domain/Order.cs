

using Core.Application.Exceptions;

namespace Core.Domain;

public class Order
{
    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<OrderItem> Items { get; private set; } = [];

    public bool IsShipped { get; private set; }

    public Order()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void AddItem(string name ,decimal price , int qty = 1)
    {
        if (price < 0)
            throw new DomainException($"Price cannot be negative , { nameof(price)} ");

        if (qty <= 0)
            throw new DomainException($"Quantity must be at least 1 {nameof(qty)}");

        Items.Add(new OrderItem(name, price, qty));
    }

    public void UpdateItems(List<OrderItem> items)
    {
        if (IsShipped)
            throw new DomainException("Cannot update shipped orders.");

        Items = items;
    }
}
