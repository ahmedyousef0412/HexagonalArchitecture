
using Core.Application.DTOs;

namespace Core.Application.Commands;

public record CreateOrderCommand(List<CreateOrderItemDto> Items);

