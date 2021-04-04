using System;
using System.Collections.Generic;
using store.Domain.Entities.OrderAggregate;
using Xunit;

namespace store.Domain.UnitTests.Entities.OrderAggregate
{
    public class OrderTests
    {
        [Fact]
        public void NewOrder_CorrectInputParameters_Success()
        {
            // Arrange
            var orderNumber = 1;
            var items = new List<OrderItem>()
            { new OrderItem(1,1) };

            // Act
            var order = new Order(orderNumber, items);

            // Assert
            Assert.NotNull(order.OrderItems);
            Assert.True(order.OrderItems.Count == 1);
            Assert.Equal(orderNumber, order.OrderNumber);
        }

        [Fact]
        public void NewOrder_NegativeOrderNumber_ArgumentOutOfRangeException()
        {
            // Arrange
            var orderNumber = -1;
            var items = new List<OrderItem>()
            { new OrderItem(1,1) };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Order(orderNumber, items));
        }

        [Fact]
        public void NewOrder_itemsNull_ArgumentNullException()
        {
            // Arrange
            var orderNumber = 1;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Order(orderNumber, null));
        }
    }
}