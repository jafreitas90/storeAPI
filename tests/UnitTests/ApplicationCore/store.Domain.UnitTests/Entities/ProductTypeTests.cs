using System;
using store.Domain.Entities;
using Xunit;

namespace store.Domain.UnitTests.Entities
{
    public class ProductTypeTests
    {
        [Fact]
        public void NewProductType_CorrectInputParameters_Success()
        {
            // Arrange
            var type = "calendar";
            var width = 1;
            var maxStackQuantity = 1;

            // Act
            var productType = new ProductType(type, width, maxStackQuantity);

            // Assert
            Assert.Equal(maxStackQuantity, productType.MaxStackQuantity);
            Assert.Equal(width, productType.Width);
            Assert.Equal(type, productType.Type);
        }

        [Fact]
        public void NewProductType_NegativeWidth_ArgumentOutOfRangeException()
        {
            // Arrange
            var type = "calendar";
            var width = -1;
            var maxStackQuantity = 1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProductType(type, width, maxStackQuantity));
        }

        [Fact]
        public void NewProductType_NegativeMaxStackQuantity_ArgumentOutOfRangeException()
        {
            // Arrange
            var type = "calendar";
            var width = 1;
            var maxStackQuantity = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProductType(type, width, maxStackQuantity));
        }

        [Fact]
        public void NewProductType_TypeNull_ArgumentNullException()
        {
            // Arrange
            string type = null;
            var width = 1;
            var maxStackQuantity = 1;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProductType(type, width, maxStackQuantity));
        }
    }
}
