using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using store.Domain.Contracts.Repository;
using store.Domain.Entities;
using store.Domain.Exceptions;

namespace store.DataAccess.Data
{
    public class ProductItemRepository : BaseRepository<ProductItem>, IProductItemRepository
    {
        public ProductItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ProductItem>> GetListByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        {
            return await _context.ProductItem
                .Where(x => ids.Contains(x.Id))
                .Include(x => x.ProductType)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<ProductItem>> GetListByProductNumberAsync(IEnumerable<int> productsNumber, CancellationToken cancellationToken = default)
        {
            var productItems = await _context.ProductItem
                .Where(x => productsNumber.Contains(x.ProductNumber))
                .Include(x => x.ProductType)
                .ToListAsync(cancellationToken);

            if(productItems == null || productItems.Count() != productsNumber.Count())
            {
                var itemsNotFound = productsNumber.Except(productItems.Select(x => x.ProductNumber));
                throw new ProductItemFoundRepositoryException(
                    $"Items not found: {string.Join(",",itemsNotFound)}");
            }
            return productItems;
        }
    }
}