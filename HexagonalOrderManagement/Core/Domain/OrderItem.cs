
using Core.Application.Exceptions;

namespace Core.Domain;

public class OrderItem
{
    public int Id { get;  }
    public string ProductName { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public OrderItem(string productName, decimal price, int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("Quantity must be greater than zero.");

        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
}
