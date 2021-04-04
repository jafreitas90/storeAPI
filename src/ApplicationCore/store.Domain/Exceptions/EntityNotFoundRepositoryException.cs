using System;
using System.Runtime.Serialization;

namespace store.Domain.Exceptions
{
    public class EntityNotFoundRepositoryException : Exception
    {
        public EntityNotFoundRepositoryException()
        {
        }

        public EntityNotFoundRepositoryException(string message)
            : base(message)
        {
        }

        public EntityNotFoundRepositoryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected EntityNotFoundRepositoryException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }
    }
}
