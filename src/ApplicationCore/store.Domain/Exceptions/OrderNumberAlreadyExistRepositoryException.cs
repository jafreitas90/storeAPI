using System;
using System.Runtime.Serialization;

namespace store.Domain.Exceptions
{
    public class OrderNumberAlreadyExistRepositoryException : Exception
    {
        public OrderNumberAlreadyExistRepositoryException()
        {
        }

        public OrderNumberAlreadyExistRepositoryException(string message)
            : base(message)
        {
        }

        public OrderNumberAlreadyExistRepositoryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected OrderNumberAlreadyExistRepositoryException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }
    }
}
