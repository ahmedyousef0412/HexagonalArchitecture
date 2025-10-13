using Core.Application.Commands;
using Core.Application.Exceptions;
using Core.Application.Ports;
using Core.Domain;

namespace Core.Application.Handlers;

public class UpdateOrderCommandHandler(IOrderRepository orderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;


    public async Task HandleAsync(UpdateOrderCommand command ,CancellationToken cancellationToken = default)
    {
      var order = await _orderRepository.GetByIdAsync(command.OrderId, cancellationToken);


        if (order is null)
            throw new NotFoundException($"Order with Id {command.OrderId} not found.");


        var orderItems = command
            .Items
            .Select(i => new OrderItem(i.ProductName, i.Price, i.Quantity)).ToList();


        order.UpdateItems(orderItems);
    }
}
