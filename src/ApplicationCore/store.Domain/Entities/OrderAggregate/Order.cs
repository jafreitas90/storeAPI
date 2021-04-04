using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using store.Domain.Contracts.Markers;

namespace store.Domain.Entities.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public int OrderNumber { get; private set; }
        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        // required by EF
        private Order()
        {
        }

        public Order(int orderNumber, List<OrderItem> items)
        {
            Guard.Against.Null(items, nameof(items));
            Guard.Against.OutOfRange(orderNumber, nameof(orderNumber), 1, int.MaxValue);

            _orderItems = items;
            OrderNumber = orderNumber;
        }

        public IEnumerable<OrderItem> GetOrderItemsGroupedByProductId()
        {
            return _orderItems.GroupBy(x => x.ProductId)
                .Select(x => new OrderItem(x.Key, x.Sum(s => s.Quantity)));
        }
    }
}
