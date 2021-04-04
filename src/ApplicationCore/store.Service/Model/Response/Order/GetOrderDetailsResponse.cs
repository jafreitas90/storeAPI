using System.Collections.Generic;

namespace store.Service.Model.Response.Order
{
    public class GetOrderDetailsResponse
    {
        public int RequiredBinWidth { get; private set; }
        public int OrderNumber { get; private set; }
        public IEnumerable<ProductItemDetailsResponse> ProductItems { get; private set; }

        public GetOrderDetailsResponse(int requiredBinWidth, int orderNumber, IEnumerable<ProductItemDetailsResponse> productItems)
        {
            RequiredBinWidth = requiredBinWidth;
            OrderNumber = orderNumber;
            ProductItems = productItems;
        }
    }
}
