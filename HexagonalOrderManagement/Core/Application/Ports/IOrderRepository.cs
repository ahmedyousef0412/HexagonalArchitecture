
using Core.Domain;

namespace Core.Application.Ports;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Order?> GetByIdAsync(int id ,CancellationToken cancellationToken = default);

    Task AddAsync(Order? order, CancellationToken cancellationToken = default);

    Task UpdateAync(Order? order, CancellationToken cancellationToken = default);

    Task DeleteAsync(Order? order, CancellationToken cancellationToken = default);

}
