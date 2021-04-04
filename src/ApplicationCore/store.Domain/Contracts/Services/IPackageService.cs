using System.Threading;
using System.Threading.Tasks;
using store.Domain.Entities.OrderAggregate;

namespace store.Domain.Contracts.Services
{
    public interface IPackageService
    {
        Task<int> CalculateRequiredBinWidthByOrderAsync(Order order, CancellationToken cancellationToken = default);
    }
}
