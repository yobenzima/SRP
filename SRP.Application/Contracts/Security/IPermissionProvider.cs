using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Security;

public interface IPermissionProvider
{
    /// <summary>
    /// Get default permissions
    /// </summary>
    /// <returns>Default permissions</returns>
    IEnumerable<DefaultPermission> GetDefaultPermissions();

    /// <summary>
    /// Gets or sets the permissions
    /// </summary>
    public IEnumerable<Permission> GetPermissions();
}
