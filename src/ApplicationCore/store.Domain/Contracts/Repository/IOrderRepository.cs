using System.Threading;
using System.Threading.Tasks;
using store.Domain.Entities.OrderAggregate;

namespace store.Domain.Contracts.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByOrderNumberAsync(int orderNumber, CancellationToken cancellationToken = default);
    }
}
