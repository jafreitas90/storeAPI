namespace store.Service.Model.Response.Order
{
    public class CreateOrderResponse
    {
        public int RequiredBinWidth { get; private set; }

        public CreateOrderResponse(int requiredBinWidth)
        {
            RequiredBinWidth = requiredBinWidth;
        }
    }
}