using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using store.Domain.Contracts.Repository;
using store.Domain.Contracts.Services;
using store.Domain.Entities;
using store.Domain.Entities.OrderAggregate;
using store.Domain.Exceptions;
using store.Service.Exceptions;
using store.Service.Features.Commands.Orders;
using store.Service.Model.Request.Order;
using store.Service.Services;
using Xunit;

namespace store.Service.UnitTests.Features.Commands.Orders
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductItemRepository> _mockProductItemRepository;
        private IPackageService _packageService;

        public CreateOrderCommandHandlerTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductItemRepository = new Mock<IProductItemRepository>();
            _packageService = new PackageService(_mockProductItemRepository.Object);
        }

        [Fact]
        public async Task Handle_RequestCorretlyFilled_Success()
        {
            // Arrange
            var requiredBinWidth = 226; //4 - mug, 1 - photoBook
            var orderNumber = 1;
            var productItemsRequest = new List<ProductItemsRequest>()
            {
                new ProductItemsRequest()
                {
                    ItemNumber = 5,
                    Quantity = 5
                },
                new ProductItemsRequest()
                {
                    ItemNumber = 4,
                    Quantity = 2
                },
            };

            MockOrderRepository(orderNumber);
            MockProductItemRepository();

            var commandHandler = new CreateOrderCommandHandler(
                    _mockOrderRepository.Object, 
                    _mockProductItemRepository.Object,
                    _packageService);

            var request = new CreateOrderRequest(orderNumber, productItemsRequest);

            // Act
            var result = await commandHandler.Handle(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(requiredBinWidth, result.RequiredBinWidth);
        }

        [Fact]
        public async Task Handle_IncorrectRequestedItemNumber_EntityNotFoundServiceException()
        {
            // Arrange
            var orderNumber = 1;
            var productItemsRequest = new List<ProductItemsRequest>()
            {
                new ProductItemsRequest()
                {
                    ItemNumber = 5,
                    Quantity = 5
                },
                new ProductItemsRequest()
                {
                    ItemNumber = 4,
                    Quantity = 2
                },
            };

            MockOrderRepository(orderNumber);
            _mockProductItemRepository
                .Setup(x => x.GetListByProductNumberAsync(It.IsAny<IEnumerable<int>>(), default))
                .Throws<ProductItemFoundRepositoryException>();

            var commandHandler = new CreateOrderCommandHandler(
                    _mockOrderRepository.Object,
                    _mockProductItemRepository.Object,
                    _packageService);

            var request = new CreateOrderRequest(orderNumber, productItemsRequest);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundServiceException>(async () => await commandHandler.Handle(request));
        }

        [Fact]
        public async Task Handle_OrderNumberAlreadyExist_OrderNumberAlreadyExistServiceException()
        {
            // Arrange
            var orderNumber = 1;
            var productItemsRequest = new List<ProductItemsRequest>()
            {
                new ProductItemsRequest()
                {
                    ItemNumber = 5,
                    Quantity = 5
                },
                new ProductItemsRequest()
                {
                    ItemNumber = 4,
                    Quantity = 2
                },
            };

            _mockOrderRepository.Setup(x => x.AddAsync(It.IsAny<Order>(), default))
                .Throws<OrderNumberAlreadyExistRepositoryException>();
            MockProductItemRepository();

            var commandHandler = new CreateOrderCommandHandler(
                    _mockOrderRepository.Object,
                    _mockProductItemRepository.Object,
                    _packageService);

            var request = new CreateOrderRequest(orderNumber, productItemsRequest);

            // Act & Assert
            await Assert.ThrowsAsync<OrderNumberAlreadyExistServiceException>(async () => await commandHandler.Handle(request));
        }

        private void MockProductItemRepository()
         {
            var productNumber1 = 5;
            var productNumber2 = 4;

            var productType1 = new Mock<ProductType>("mug", 94, 4);
            productType1.SetupGet(s => s.Id).Returns(2);
            var productType2 = new Mock<ProductType>("photoBook", 19, 1);
            productType2.SetupGet(s => s.Id).Returns(4);

            var productItem1 = new Mock<ProductItem>(productType1.Object, productNumber1);
            productItem1.SetupGet(s => s.Id).Returns(1);
            var productItem2 = new Mock<ProductItem>(productType2.Object, productNumber2);
            productItem2.Setup(s => s.Id).Returns(2);

            var productItems = new List<ProductItem>()
                { productItem1.Object, productItem2.Object };

            _mockProductItemRepository
                .Setup(x => x.GetListByProductNumberAsync(It.IsAny<IEnumerable<int>>(), default))
                .ReturnsAsync(productItems);

            _mockProductItemRepository
               .Setup(x => x.GetListByIdsAsync(It.IsAny<IEnumerable<int>>(), default))
               .ReturnsAsync(productItems);
         }

         private void MockOrderRepository(int orderNumber)
         {
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(2, 5),
                new OrderItem(4, 2)
            };
            var order = new Order(orderNumber, orderItems);

            _mockOrderRepository.Setup(x => x.AddAsync(It.IsAny<Order>(), default)).ReturnsAsync(order);
        }
    }
}
