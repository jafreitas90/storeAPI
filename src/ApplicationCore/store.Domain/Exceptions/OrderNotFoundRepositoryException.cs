using System;
using System.Runtime.Serialization;

namespace store.Domain.Exceptions
{
    public class OrderNotFoundRepositoryException : Exception
    {
        public OrderNotFoundRepositoryException()
        {
        }

        public OrderNotFoundRepositoryException(string message)
            : base(message)
        {
        }

        public OrderNotFoundRepositoryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected OrderNotFoundRepositoryException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }
    }
}
