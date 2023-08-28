using SRP.Infrastructure.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure.Models;

public partial class PermissionRecordModel : BaseEntityModel
{
    public string Name { get; set; } = null!;
    public string SystemName { get; set; } = null!;
    public string Area { get; set; } = null!;
    public bool Actions { get; set; }
    public string Category { get; set; } = null!;
}
