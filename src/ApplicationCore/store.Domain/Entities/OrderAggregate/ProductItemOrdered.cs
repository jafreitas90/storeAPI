using Ardalis.GuardClauses;

namespace store.Domain.Entities.OrderAggregate
{
    public class ProductItemOrdered // ValueObject
    {
        public int ItemId { get; private set; }
        public string Name { get; private set; }
        public int BinWidth { get; private set; }

        public ProductItemOrdered(int itemId, string name, int binWidth)
        {
            Guard.Against.OutOfRange(itemId, nameof(itemId), 1, int.MaxValue);
            Guard.Against.OutOfRange(binWidth, nameof(binWidth), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(name, nameof(name));

            ItemId = itemId;
            Name = name;
            BinWidth = binWidth;
        }
    }
}
