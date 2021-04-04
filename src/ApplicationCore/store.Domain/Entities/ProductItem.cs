using Ardalis.GuardClauses;
using store.Domain.Contracts.Markers;

namespace store.Domain.Entities
{
    public class ProductItem : BaseEntity, IAggregateRoot
    {
        public int ProductTypeId { get; private set; }
        public ProductType ProductType { get; private set; }
        public int ProductNumber { get; private set; }

        public ProductItem(int productTypeId, int productNumber)
        {
            Guard.Against.OutOfRange(productTypeId, nameof(productTypeId), 1, int.MaxValue);
            Guard.Against.OutOfRange(productNumber, nameof(productNumber), 1, int.MaxValue);

            ProductTypeId = productTypeId;
            ProductNumber = productNumber;
        }

        public ProductItem(ProductType productType, int productNumber)
        {
            Guard.Against.Null(productType, nameof(productType));
            Guard.Against.OutOfRange(productType.Id, nameof(productType.Id), 1, int.MaxValue);
            Guard.Against.OutOfRange(productNumber, nameof(productNumber), 1, int.MaxValue);

            ProductType = productType;
            ProductNumber = productNumber;
        }
    }
}
