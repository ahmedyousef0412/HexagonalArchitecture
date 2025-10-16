
using Core.Application.Commands;
using Core.Application.DTOs;
using Core.Application.Handlers;
using Core.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    //I will refactor this to use MediatR in the future

    private readonly GetOrdersQueryHandler _getOrdersHandler;
    private readonly GetOrderByIdQueryHandler _getOrderByIdHandler;
    private readonly CreateOrderCommandHandler _createOrderHandler;
    private readonly UpdateOrderCommandHandler _updateOrderHandler;
    private readonly DeleteOrderCommandHandler _deleteOrderHandler;

    public OrdersController(GetOrdersQueryHandler getOrdersHandler, GetOrderByIdQueryHandler getOrderByIdHandler,
        CreateOrderCommandHandler createOrderHandler, UpdateOrderCommandHandler updateOrderHandler,
        DeleteOrderCommandHandler deleteOrderHandler
    )
    {
        _getOrdersHandler = getOrdersHandler;
        _getOrderByIdHandler = getOrderByIdHandler;
        _createOrderHandler = createOrderHandler;
        _updateOrderHandler = updateOrderHandler;
        _deleteOrderHandler = deleteOrderHandler;
    }

    // GET: api/orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll(CancellationToken cancellationToken)
    {
        var orders = await _getOrdersHandler.HandleAsync(new GetOrdersQuery(), cancellationToken);
        return Ok(orders);
    }

    // GET: api/orders/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var order = await _getOrderByIdHandler.HandleAsync(new GetOrderByIdQuery(id), cancellationToken);
        return Ok(order);
    }

    // POST: api/orders
    [HttpPost]
    public async Task<ActionResult<OrderDto>> Create([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var createdOrder = await _createOrderHandler.HandleAsync(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new {id =  createdOrder }, createdOrder);
    }


    // PUT: api/orders/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        if (id != command.OrderId)
            return BadRequest("Order ID in URL must match Order ID in body.");

        await _updateOrderHandler.HandleAsync(command, cancellationToken);
        return NoContent();
    }

    // DELETE: api/orders/{id}
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        var command = new DeleteOrderCommand(id);
        await _deleteOrderHandler.HandleAsync(command, ct);
        return NoContent();
    }

}
