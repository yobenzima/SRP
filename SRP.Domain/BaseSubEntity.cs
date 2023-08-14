using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain
{
    public class BaseSubEntity : ParentEntity
    {
        public long SyncTS { get; set; }
    }
}
