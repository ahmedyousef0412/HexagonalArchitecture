
namespace Core.Application.Ports;

public interface IUintOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
