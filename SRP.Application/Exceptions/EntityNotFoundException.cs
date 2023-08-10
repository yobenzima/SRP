
using SRP.Application.Exceptions.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Exceptions
{
    public sealed class EntityNotFoundException : NotFoundException
    {
        public EntityNotFoundException(Guid id) : base($"Item with identifier {id} was not found!")
        {
        }

        public EntityNotFoundException(Guid id, string name) : base(id, name)
        {
        }
    }
}
