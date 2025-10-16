
using Core.Application.Commands;
using Core.Application.Exceptions;
using Core.Application.Ports;

namespace Core.Application.Handlers;

public class DeleteOrderCommandHandler(IOrderRepository orderRepository,IUintOfWork uintOfWork)
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IUintOfWork _uintOfWork = uintOfWork;

    public async Task HandleAsync(DeleteOrderCommand command, CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(command.OrderId, cancellationToken);

        if (order is null)
            throw new NotFoundException($"Order with Id {command.OrderId} not found.");

         _orderRepository.Delete(order, cancellationToken);
        await _uintOfWork.SaveChangesAsync(cancellationToken);

    }
}
 