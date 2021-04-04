using System;
using System.Runtime.Serialization;

namespace store.Service.Exceptions
{
    public class OrderNumberAlreadyExistServiceException : Exception
    {
        public OrderNumberAlreadyExistServiceException()
        {
        }

        public OrderNumberAlreadyExistServiceException(string message)
            : base(message)
        {
        }

        public OrderNumberAlreadyExistServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected OrderNumberAlreadyExistServiceException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }
    }
}
