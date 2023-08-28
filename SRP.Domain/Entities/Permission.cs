using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain.Entities;

public class Permission : BaseSubEntity
{
    private ICollection<string>? mUserGroups;
    private ICollection<string>? mPermissionActions;

    /// <summary>
    /// Gets or sets the permission name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the permission system name
    /// </summary>
    public string SystemName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the area name
    /// </summary>
    public string Area { get; set; } = null!;

    /// <summary>
    /// Gets or sets the permission category
    /// </summary>
    public string Category { get; set; } = null!;

    /// <summary>
    /// Gets or sets user groups
    /// </summary>
    public virtual ICollection<string> UserGroups
    {
        get { return mUserGroups ??= new List<string>(); }
        protected set { mUserGroups = value; }
    }

    /// <summary>
    /// Gets or sets actions
    /// </summary>
    public virtual ICollection<string> PermissionActions
    {
        get { return mPermissionActions ??= new List<string>(); }
        set { mPermissionActions = value; }
    }
}
