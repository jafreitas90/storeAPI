using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using store.Domain.Contracts.Repository;
using store.Domain.Entities.OrderAggregate;
using store.Domain.Exceptions;

namespace store.DataAccess.Data
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override async Task<Order> AddAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var exist = await _context.Orders.AnyAsync(x => x.OrderNumber == entity.OrderNumber);
            if (!exist)
            {
                return await base.AddAsync(entity, cancellationToken);
            }
            throw new OrderNumberAlreadyExistRepositoryException();
        }

        public async Task<Order> GetByOrderNumberAsync(int orderNumber, CancellationToken cancellationToken = default)
        {
            var order = await _context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.OrderNumber == orderNumber, cancellationToken);

            if (order == null)
            {
                throw new OrderNotFoundRepositoryException();
            }
            return order;
        }
    }
}