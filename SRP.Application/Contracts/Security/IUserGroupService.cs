using SRP.Domain;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Security;

public interface IUserGroupService
{
    /// <summary>
    /// Gets a value indicating whether a user is in a certain user group.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userGroupSystemName"></param>
    /// <param name="onlyActiveUserGroups"></param>
    /// <param name="isSystem"></param>
    /// <returns></returns>
    Task<bool> IsInUserGroup(User user,
        string userGroupSystemName,
        bool onlyActiveUserGroups = true,
        bool ? isSystem = null);

    /// <summary>
    /// Gets a value indicating whether a user is staff/internal.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> IsStaff(User user);

    /// <summary>
    /// Gets a value indicating whether a user is admin.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> IsAdmin(User user);

    /// <summary>
    /// Gets a value indicating whether a user is guest.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> IsGuest(User user);

    /// <summary>
    /// Gets a value indicating whether a user is registered.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> IsRegistered(User user);

    /// <summary>
    /// Inserts a user group
    /// </summary>
    /// <param name="userGroup">User group</param>
    Task InsertUserGroup(UserGroup userGroup);

    /// <summary>
    /// Updates the user group
    /// </summary>
    /// <param name="userGroup">User group</param>
    Task UpdateUserGroup(UserGroup userGroup);

    /// <summary>
    /// Delete a user group
    /// </summary>
    /// <param name="userGroup">User group</param>
    Task DeleteUserGroup(UserGroup userGroup);

    /// <summary>
    /// Gets a user group
    /// </summary>
    /// <param name="userGroupId">User group identifier</param>
    /// <returns>User group</returns>
    Task<UserGroup?> GetUserGroupById(Guid userGroupId);

    /// <summary>
    /// Gets a user group
    /// </summary>
    /// <param name="systemName">User group system name</param>
    /// <returns>User group</returns>
    Task<UserGroup> GetUserGroupBySystemName(string systemName);

    /// <summary>
    /// Gets all user groups 
    /// </summary>
    /// <param name="ids">Group id's </param>
    /// <returns>User groups</returns>
    Task<IList<UserGroup>> GetAllByIds(Guid[] ids);

    /// <summary>
    /// Gets all user groups
    /// </summary>
    /// <returns>User groups</returns>
    Task<IPagedList<UserGroup>> GetAllUserGroups(string name = "", int pageIndex = 0,
        int pageSize = int.MaxValue, bool showHidden = false);
}
