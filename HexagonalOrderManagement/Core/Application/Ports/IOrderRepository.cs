
using Core.Domain;

namespace Core.Application.Ports;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Order?> GetByIdAsync(int id ,CancellationToken cancellationToken = default);

    Task AddAsync(Order? order, CancellationToken cancellationToken = default);

    void Update(Order? order, CancellationToken cancellationToken = default);

    void Delete(Order? order, CancellationToken cancellationToken = default);

}
//Why EF Core’s Update() and Remove() are synchronous
// . EF Core's Update() and Remove() methods are synchronous because they
// primarily involve modifying the state of the in-memory entity
// tracking system rather than performing any I/O-bound operations.
// These methods mark entities as modified or deleted in the context,
// which is a quick operation that doesn't require waiting for external resources
// like a database. The actual database operations occur when SaveChangesAsync() is called,
// which is asynchronous to efficiently handle I/O operations without blocking the calling thread.
