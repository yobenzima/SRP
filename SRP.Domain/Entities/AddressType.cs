using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain.Entities
{
    public class AddressType : BaseEntity
    {  
        public string? Name { get; set; }

        public IList<Address> Addresses { get; set; } = new List<Address>();
    }
}
