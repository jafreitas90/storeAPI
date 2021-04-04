using System.Collections.Generic;
using MediatR;
using store.Service.Model.Response.Order;

namespace store.Service.Model.Request.Order
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public int OrderNumber { get; private set; }
        public IEnumerable<ProductItemsRequest> Items { get; private set; }

        public CreateOrderRequest(int orderNumber, IEnumerable<ProductItemsRequest> items)
        {
            OrderNumber = orderNumber;
            Items = items;
        }
    }
}
