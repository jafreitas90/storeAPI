using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using store.Domain.Contracts.Repository;
using store.Domain.Contracts.Services;
using store.Domain.Entities.OrderAggregate;
using store.Domain.Exceptions;
using store.Service.Exceptions;
using store.Service.Model.Request.Order;
using store.Service.Model.Response.Order;

namespace store.Service.Features.Commands.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductItemRepository _productItemRepository;
        private readonly IPackageService _packageService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductItemRepository productItemRepository, IPackageService packageService)
        {
            _orderRepository = orderRepository;
            _productItemRepository = productItemRepository;
            _packageService = packageService;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var orderNumber = request.OrderNumber;                
                var productItemsFromRepository = await _productItemRepository
                    .GetListByProductNumberAsync(request.Items.Select(x => x.ItemNumber), cancellationToken);
                var orderItems = new List<OrderItem>();
                foreach (var item in request.Items)
                {
                    var productItem = productItemsFromRepository.FirstOrDefault(x=> x.ProductNumber == item.ItemNumber);
                    orderItems.Add(new OrderItem(productItem.Id, item.Quantity));
                }

                var order = new Order(orderNumber, orderItems);

                await _orderRepository.AddAsync(order);
                var requiredBinWidth = await _packageService.CalculateRequiredBinWidthByOrderAsync(order, cancellationToken);

                return new CreateOrderResponse(requiredBinWidth);
            }
            catch(OrderNumberAlreadyExistRepositoryException ex)
            {
                throw new OrderNumberAlreadyExistServiceException($"Order {request.OrderNumber} already exist.");
            }
            catch (ProductItemFoundRepositoryException ex)
            {
                throw new EntityNotFoundServiceException(ex.Message, ex);
            }            
        }
    }
}
