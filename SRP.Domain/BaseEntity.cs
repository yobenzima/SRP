using SRP.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain
{
    public abstract partial class BaseEntity : ParentEntity
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int64 SyncTS { get; set; }
    }
}
