using Ardalis.GuardClauses;

namespace store.Domain.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public ProductItemOrdered ItemOrdered { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(ProductItemOrdered itemOrdered, int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 1, int.MaxValue);
            Guard.Against.Null(itemOrdered, nameof(itemOrdered));

            ItemOrdered = itemOrdered;
            Quantity = quantity;
        }
    }
}
