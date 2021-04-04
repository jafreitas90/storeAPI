using System;
using System.Runtime.Serialization;

namespace store.Service.Exceptions
{
    public class EntityNotFoundServiceException : Exception
    {
        public EntityNotFoundServiceException()
        {
        }

        public EntityNotFoundServiceException(string message)
            : base(message)
        {
        }

        public EntityNotFoundServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected EntityNotFoundServiceException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }
    }
}
