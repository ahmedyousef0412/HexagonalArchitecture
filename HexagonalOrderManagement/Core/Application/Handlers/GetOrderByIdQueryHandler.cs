using Core.Application.DTOs;
using Core.Application.Exceptions;
using Core.Application.Ports;
using Core.Application.Queries;


namespace Core.Application.Handlers;

public class GetOrderByIdQueryHandler(IOrderRepository orderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;


    public async Task<OrderDto> HandleAsync(GetOrderByIdQuery query, CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(query.OrderId, cancellationToken);

        if (order is null)
            throw new NotFoundException($"Order with Id {query.OrderId} not found.");


        var items= order?.Items
            .Select(i => new OrderItemDto(i.Id,i.ProductName, i.Quantity, i.Price)) ?? [];


        return new OrderDto(order.Id, order.CreatedAt, [.. items]);
    }
}
