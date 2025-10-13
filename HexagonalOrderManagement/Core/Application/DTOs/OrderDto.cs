

namespace Core.Application.DTOs;

public record OrderDto(int Id, DateTime CreatedAt, IEnumerable<OrderItemDto> Items);


