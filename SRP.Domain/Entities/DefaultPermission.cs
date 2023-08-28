namespace SRP.Domain.Entities;

/// <summary>
/// Represents a default permission
/// </summary>
public class DefaultPermission
{
    public DefaultPermission()
    {
        Permissions = new List<Permission>();
    }

    /// <summary>
    /// Gets or sets the customer group system name
    /// </summary>
    public string UserGroupSystemName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the permissions
    /// </summary>
    public IEnumerable<Permission> Permissions { get; set; }
}

