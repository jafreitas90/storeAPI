using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using store.Domain.Contracts.Repository;
using store.Domain.Contracts.Services;
using store.Domain.Entities.OrderAggregate;

namespace store.Service.Services
{
    public class PackageService : IPackageService
    {
        private readonly IProductItemRepository _productItemRepository;
        public PackageService(IProductItemRepository productItemRepository)
        {
            _productItemRepository = productItemRepository;
        }

        public async Task<int> CalculateRequiredBinWidthByOrderAsync(Order order, CancellationToken cancellationToken = default)
        {
            int minWidth = 0;
            var items = order.GetOrderItemsGroupedByProductId();
            var productItems = await _productItemRepository.GetListByIdsAsync(items.Select(x => x.ProductId), cancellationToken);
            foreach (var item in items)
            {
                var productItem = productItems.FirstOrDefault(x=> x.Id == item.ProductId);
                var productWidth = productItem.ProductType.Width;
                var maxStack = productItem.ProductType.MaxStackQuantity;
                var quantity = item.Quantity;
                var occupiedSpaces = Math.Ceiling(decimal.Divide(quantity, maxStack));

                minWidth += ((int)productWidth * (int)occupiedSpaces);
            }
            return minWidth;
        }
    }
}
