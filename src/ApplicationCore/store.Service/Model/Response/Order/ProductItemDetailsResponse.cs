namespace store.Service.Model.Response.Order
{
    public class ProductItemDetailsResponse
    {
        public int ProductNumber { get; private set; }
        public float Width { get; private set; }
        public int MaxStackQuantity { get; private set; }
        public int Quantity { get; private set; }
        public string Type { get; private set; }

        public ProductItemDetailsResponse(int productNumber, float width, int maxStackQuantity, int quantity, string type)
        {
            ProductNumber = productNumber;
            Width = width;
            MaxStackQuantity = maxStackQuantity;
            Quantity = quantity;
            Type = type;
        }
    }
}
