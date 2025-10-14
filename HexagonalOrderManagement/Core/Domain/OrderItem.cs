
using Core.Application.Exceptions;

namespace Core.Domain;

public class OrderItem
{
    public int Id { get; private set; }
    public string ProductName { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem(string productName, decimal price, int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("Quantity must be greater than zero.");

        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
}
