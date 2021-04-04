using Ardalis.GuardClauses;
using store.Domain.Contracts.Markers;

namespace store.Domain.Entities
{
    public class ProductType : BaseEntity, IAggregateRoot
    {
        public string Type { get; private set; }
        public float Width { get; private set; }
        public int MaxStackQuantity { get; private set; }

        public ProductType(string type, float width, int maxStackQuantity)
        {
            Guard.Against.Null(type, nameof(type));
            Guard.Against.OutOfRange(width, nameof(width), 1, int.MaxValue);
            Guard.Against.OutOfRange(maxStackQuantity, nameof(maxStackQuantity), 1, int.MaxValue);

            Type = type;;
            Width = width;
            MaxStackQuantity = maxStackQuantity;
        }
    }
}
