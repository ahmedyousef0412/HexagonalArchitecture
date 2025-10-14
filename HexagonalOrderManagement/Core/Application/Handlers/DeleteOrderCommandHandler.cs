
using Core.Application.Commands;
using Core.Application.Exceptions;
using Core.Application.Ports;
using System.Threading.Tasks;

namespace Core.Application.Handlers;

public class DeleteOrderCommandHandler(IOrderRepository orderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task HandleAsync(DeleteOrderCommand command, CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(command.OrderId, cancellationToken);

        if (order is null)
            throw new NotFoundException($"Order with Id {command.OrderId} not found.");

         _orderRepository.Delete(order, cancellationToken);

    }
}
