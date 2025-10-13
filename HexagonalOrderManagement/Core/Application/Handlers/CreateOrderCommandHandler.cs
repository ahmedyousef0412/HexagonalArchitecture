using Core.Application.Commands;
using Core.Application.Ports;
using Core.Domain;

namespace Core.Application.Handlers;

public class CreateOrderCommandHandler(IOrderRepository orderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<int> HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var order = new Order();

        foreach (var item in command.Items)
            order.AddItem(item.Name, item.Price, item.Quantity);

        await _orderRepository.AddAsync(order, cancellationToken);
        return order.Id;
    }
}
 