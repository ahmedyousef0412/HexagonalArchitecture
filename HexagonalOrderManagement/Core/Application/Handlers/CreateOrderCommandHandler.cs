using Core.Application.Commands;
using Core.Application.Ports;
using Core.Domain;

namespace Core.Application.Handlers;

public class CreateOrderCommandHandler(IOrderRepository orderRepository,IUintOfWork uintOfWork)
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IUintOfWork _uintOfWork = uintOfWork;

    public async Task<int> HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var order = new Order();

        foreach (var item in command.Items)
            order.AddItem(item.Name, item.Price, item.Quantity);

        await _orderRepository.AddAsync(order, cancellationToken);
        await _uintOfWork.SaveChangesAsync(cancellationToken);
        return order.Id;
    }
}
 