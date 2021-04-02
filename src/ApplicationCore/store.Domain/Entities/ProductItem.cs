using store.Domain.Contracts;

namespace store.Domain.Entities
{
    public class ProductItem : BaseEntity, IAggregateRoot
    {
        public int ProductTypeId { get; private set; }
        public ProductType ProductType { get; private set; }
        public int BinWidth { get; private set; }
        public string Name { get; private set; }

        public ProductItem(int productTypeId, int binWidth, string name)
        {
            ProductTypeId = productTypeId;
            BinWidth = binWidth;
            Name = name;
        }
    }
}
