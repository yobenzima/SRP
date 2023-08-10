using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain.Data
{
    public static class UniqueIdentifier
    {
        public static Guid New => Guid.NewGuid();
    }
}
