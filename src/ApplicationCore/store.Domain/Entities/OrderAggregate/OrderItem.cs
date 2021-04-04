using Ardalis.GuardClauses;

namespace store.Domain.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public OrderItem(int productId, int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 1, int.MaxValue);
            Guard.Against.OutOfRange(productId, nameof(productId), 1, int.MaxValue);

            ProductId = productId;
            Quantity = quantity;
        }
    }
}
