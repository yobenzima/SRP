using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain.Entities
{
    public class BaseSubEntity : ParentEntity
    {
        public Int64 SyncTS { get; set; }
    }
}
