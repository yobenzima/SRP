using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Exceptions.Base
{
    public abstract class BadRequestException : ApplicationException
    {
        public BadRequestException() 
        {
        }
    
        protected BadRequestException(string message) : base(message)
        {
        }

        protected BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}
