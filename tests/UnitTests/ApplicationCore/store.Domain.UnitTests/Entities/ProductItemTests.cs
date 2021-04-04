using System;
using store.Domain.Entities;
using Xunit;

namespace store.Domain.UnitTests.Entities
{
    public class ProductItemTests
    {
        [Fact]
        public void NewProductItem_CorrectInputParameters_Success()
        {
            // Arrange
            var productTypeId = 1;
            var productNumber = 1;

            // Act
            var productItem = new ProductItem(productTypeId, productNumber);

            // Assert
            Assert.Equal(productTypeId, productItem.ProductTypeId);
            Assert.Equal(productNumber, productItem.ProductNumber);
        }

        [Fact]
        public void NewProductItem_NegativeProductTypeId_ArgumentOutOfRangeException()
        {
            // Arrange
            var productTypeId = -1;
            var productNumber = 1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProductItem(productTypeId, productNumber));
        }

        [Fact]
        public void NewProductItem_NegativeProductNumber_ArgumentOutOfRangeException()
        {
            // Arrange
            var productTypeId = 1;
            var productNumber = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProductItem(productTypeId, productNumber));
        }
    }
}
