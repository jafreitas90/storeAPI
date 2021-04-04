using System;
using store.Domain.Entities.OrderAggregate;
using Xunit;

namespace store.Domain.UnitTests.Entities.OrderAggregate
{
    public class OrderItemTests
    {
        [Fact]
        public void NewOrderItem_CorrectInputParameters_Success()
        {
            // Arrange
            var quantity = 1;
            var productId = 1;

            // Act
            var orderItem = new OrderItem(productId, quantity);

            // Assert
            Assert.Equal(productId, orderItem.ProductId);
            Assert.Equal(quantity, orderItem.Quantity);
        }

        [Fact]
        public void NewOrder_NegativeQuantity_ArgumentOutOfRangeException()
        {
            // Arrange
            var quantity = -1;
            var productId = 1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(productId, quantity));
        }

        [Fact]
        public void NewOrder_NegativeProductId_ArgumentOutOfRangeException()
        {
            // Arrange
            var quantity = 1;
            var productId = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(productId, quantity));
        }
    }
}
