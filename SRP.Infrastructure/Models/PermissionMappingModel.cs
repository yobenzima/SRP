using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure.Models;

public partial class PermissionMappingModel : BaseModel
{
    public PermissionMappingModel(IList<PermissionRecordModel> availablePermissions, IList<UserGroup> availableUserGroups)
    {
        AvailablePermissions = availablePermissions;
        AvailableUserGroups = availableUserGroups;
        Allowed = new Dictionary<string, IDictionary<string, bool>>();
    }

    public IList<PermissionRecordModel> AvailablePermissions { get; set; }
    public IList<UserGroup> AvailableUserGroups { get; set; }

    /// <summary>
    /// Gets or sets the allowed permissions
    /// 
    /// [permission system name] => [user group id] => [allowed]   
    /// </summary>
    public IDictionary<string, IDictionary<string, bool>> Allowed { get; set; }     
}
