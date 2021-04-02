using System.Collections.Generic;
using Ardalis.GuardClauses;
using store.Domain.Contracts;

namespace store.Domain.Entities.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order(List<OrderItem> items)
        {
            Guard.Against.Null(items, nameof(items));

            _orderItems = items;
        }
    }
}
