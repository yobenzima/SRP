using SRP.Application.Contracts.Security;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure.Security;

public class PermissionProvider : IPermissionProvider
{
    public IEnumerable<Permission> GetPermissions()
    {
        return null!;   
    }

    public IEnumerable<DefaultPermission> GetDefaultPermissions()
    {
        return null!;
    }
}
