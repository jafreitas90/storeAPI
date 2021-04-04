using MediatR;
using store.Service.Model.Response.Order;

namespace store.Service.Model.Request.Order
{
    public class GetOrderDetailsRequest : IRequest<GetOrderDetailsResponse>
    {
        public int OrderNumber { get; private set; }

        public GetOrderDetailsRequest(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
