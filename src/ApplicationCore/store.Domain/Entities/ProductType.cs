using store.Domain.Contracts;

namespace store.Domain.Entities
{
    public class ProductType : BaseEntity, IAggregateRoot
    {
        public string Type { get; private set; }
        public ProductType(string type)
        {
            Type = type;
        }
    }
}
