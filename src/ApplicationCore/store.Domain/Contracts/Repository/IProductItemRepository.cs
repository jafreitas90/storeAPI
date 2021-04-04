using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using store.Domain.Entities;

namespace store.Domain.Contracts.Repository
{
    public interface IProductItemRepository : IRepository<ProductItem>
    {
        Task<IReadOnlyList<ProductItem>> GetListByProductNumberAsync(IEnumerable<int> productsNumber, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<ProductItem>> GetListByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default);
    }
}
