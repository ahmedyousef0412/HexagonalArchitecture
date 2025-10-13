using Core.Application.DTOs;

namespace Core.Application.Commands;

public record UpdateOrderCommand(int OrderId ,IEnumerable<UpdateOrderItemDto> Items );

