using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Security;

public interface IPermissionService
{
    /// <summary>
    /// Gets a permission
    /// </summary>
    /// <param name="permissionId">Permission identifier</param>
    /// <returns>Permission</returns>
    Task<Permission> GetPermissionById(string permissionId);

    /// <summary>
    /// Gets a permission
    /// </summary>
    /// <param name="systemName">Permission system name</param>
    /// <returns>Permission</returns>
    Task<Permission> GetPermissionBySystemName(string systemName);

    /// <summary>
    /// Gets all permissions
    /// </summary>
    /// <returns>Permissions</returns>
    Task<IList<Permission>> GetAllPermissions();

    /// <summary>
    /// Inserts a permission
    /// </summary>
    /// <param name="permission">Permission</param>
    Task InsertPermission(Permission permission);

    /// <summary>
    /// Updates the permission
    /// </summary>
    /// <param name="permission">Permission</param>
    Task UpdatePermission(Permission permission);

    /// <summary>
    /// Delete a permission
    /// </summary>
    /// <param name="permission">Permission</param>
    Task DeletePermission(Permission permission);

    /// <summary>
    /// Authorize permission
    /// </summary>
    /// <param name="permission">Permission</param>
    /// <returns>true - authorized; otherwise, false</returns>
    Task<bool> Authorize(Permission permission);

    /// <summary>
    /// Authorize permission
    /// </summary>
    /// <param name="permission">Permission</param>
    /// <param name="userGroup">User Group</param>
    /// <returns>true - authorized; otherwise, false</returns>
    Task<bool> Authorize(Permission permission, UserGroup userGroup);

    /// <summary>
    /// Authorize permission
    /// </summary>
    /// <param name="permissionSystemName">Permission system name</param>
    /// <returns>true - authorized; otherwise, false</returns>
    Task<bool> Authorize(string permissionSystemName);

    /// <summary>
    /// Authorize permission
    /// </summary>
    /// <param name="permissionSystemName">Permission system name</param>
    /// <param name="userGroup">User Group</param>
    /// <returns>true - authorized; otherwise, false</returns>
    Task<bool> Authorize(string permissionSystemName, UserGroup userGroup);

    /// <summary>
    /// Gets a permission actions
    /// </summary>
    /// <param name="systemName">Permission system name</param>
    /// <param name="userGroupId">User Group group ident</param>
    /// <returns>Permission action</returns>
    Task<IList<PermissionAction>> GetPermissionActions(string systemName, Guid userGroupId);

    /// <summary>
    /// Inserts a permission action
    /// </summary>
    /// <param name="permissionAction">Permission</param>
    Task InsertPermissionAction(PermissionAction permissionAction);

    /// <summary>
    /// Inserts a permission action record
    /// </summary>
    /// <param name="permissionAction">Permission</param>
    Task DeletePermissionAction(PermissionAction permissionAction);

    /// <summary>
    /// Authorize permission for action
    /// </summary>
    /// <param name="permissionSystemName">Permission record system name</param>
    /// <param name="permissionActionName">Permission action name</param>
    /// <returns>true - authorized; otherwise, false</returns>
    Task<bool> AuthorizeAction(string permissionSystemName, string permissionActionName);
}
