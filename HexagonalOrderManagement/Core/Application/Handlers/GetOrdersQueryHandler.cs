using Core.Application.DTOs;
using Core.Application.Ports;
using Core.Application.Queries;

namespace Core.Application.Handlers;

public class GetOrdersQueryHandler(IOrderRepository orderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;


    public async Task<IEnumerable<OrderDto>> HandleAsync(GetOrdersQuery query, CancellationToken cancellationToken = default)
    {

        var orders = await _orderRepository.GetAllAsync(cancellationToken);


         return orders.Select(order =>
         new OrderDto(
             order.Id,
             order.CreatedAt,
             [.. order.Items.Select(i => new OrderItemDto(i.Id,i.ProductName, i.Quantity, i.Price))]
         ));
    }
}
