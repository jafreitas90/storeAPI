using System;
using System.Runtime.Serialization;

namespace store.Domain.Exceptions
{
    public class ProductItemFoundRepositoryException : Exception
    {
        public ProductItemFoundRepositoryException()
        {
        }

        public ProductItemFoundRepositoryException(string message)
            : base(message)
        {
        }

        public ProductItemFoundRepositoryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ProductItemFoundRepositoryException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }
    }
}
