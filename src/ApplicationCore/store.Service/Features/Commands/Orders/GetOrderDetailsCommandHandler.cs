using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using store.Domain.Contracts.Repository;
using store.Domain.Contracts.Services;
using store.Domain.Exceptions;
using store.Service.Exceptions;
using store.Service.Model.Request.Order;
using store.Service.Model.Response.Order;

namespace store.Service.Features.Commands.Orders
{
    public class GetOrderDetailsCommandHandler : IRequestHandler<GetOrderDetailsRequest, GetOrderDetailsResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductItemRepository _productItemRepository;
        private readonly IPackageService _packageService;

        public GetOrderDetailsCommandHandler(IOrderRepository orderRepository, IProductItemRepository productItemRepository, IPackageService packageService)
        {
            _orderRepository = orderRepository;
            _productItemRepository = productItemRepository;
            _packageService = packageService;
        }

        public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var orderNumber = request.OrderNumber;
                var order = await _orderRepository.GetByOrderNumberAsync(orderNumber, cancellationToken);
                var requiredBinWidth = await _packageService.CalculateRequiredBinWidthByOrderAsync(order, cancellationToken);
                var productItemsFromRepository = await _productItemRepository.GetListByIdsAsync(order.OrderItems.Select(x => x.ProductId), cancellationToken);

                var productItems = new List<ProductItemDetailsResponse>();
                foreach (var item in order.GetOrderItemsGroupedByProductId())
                {
                    var productItem = productItemsFromRepository.FirstOrDefault(x=>x.Id == item.ProductId);
                    var productNumber = productItem.ProductNumber;
                    var width = productItem.ProductType.Width;
                    var maxStackQuantity = productItem.ProductType.MaxStackQuantity;
                    var type = productItem.ProductType.Type;
                    var quantity = item.Quantity;
                    productItems.Add(new ProductItemDetailsResponse(productNumber, width, maxStackQuantity, quantity, type));
                }

                return new GetOrderDetailsResponse(requiredBinWidth, orderNumber, productItems);
            }
            catch(OrderNotFoundRepositoryException ex)
            {
                throw new EntityNotFoundServiceException($"Order {request.OrderNumber} not found");
            }
        }
    }
}
