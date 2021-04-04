using System.Threading;
using System.Threading.Tasks;
using store.Domain.Entities.OrderAggregate;

namespace store.Service.Contracts
{
    public interface IPackageService
    {
        Task<int> CalculateRequiredBinWidthByOrderAsync(Order order, CancellationToken cancellationToken = default);
    }
}
