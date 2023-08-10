using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Exceptions.Base
{
    public abstract class NotFoundException : ApplicationException
    {
        public NotFoundException()
        {
        }
    
        protected NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(Guid id, string name) : base($"Item with identifier {id} and {name} was not found!")
        {
        }

        protected NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
