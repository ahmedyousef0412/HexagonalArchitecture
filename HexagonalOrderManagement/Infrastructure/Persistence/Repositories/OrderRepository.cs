using Core.Application.Ports;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
   
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Orders.Include(o => o.Items)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Orders.Include(o => o.Items)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
    public async Task AddAsync(Order? order, CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(order!, cancellationToken);
    }
    public void Update(Order? order, CancellationToken cancellationToken = default) => _context.Orders.Update(order!);

    public void Delete(Order? order, CancellationToken cancellationToken = default) => _context.Orders.Remove(order!);

}
