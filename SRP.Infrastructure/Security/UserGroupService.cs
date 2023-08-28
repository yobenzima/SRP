using SRP.Application.Contracts.Security;
using SRP.Domain;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure.Security;

public class UserGroupService : IUserGroupService
{
    public Task DeleteUserGroup(UserGroup userGroup)
    {
        throw new NotImplementedException();
    }

    public Task<IList<UserGroup>> GetAllByIds(string[] ids)
    {
        throw new NotImplementedException();
    }

    public Task<IPagedList<UserGroup>> GetAllUserGroups(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
    {
        throw new NotImplementedException();
    }

    public Task<UserGroup> GetUserGroupById(string userGroupId)
    {
        throw new NotImplementedException();
    }

    public Task<UserGroup> GetUserGroupBySystemName(string systemName)
    {
        throw new NotImplementedException();
    }

    public Task InsertUserGroup(UserGroup userGroup)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsAdmin(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsGuest(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInUserGroup(User user, string userGroupSystemName, bool onlyActiveUserGroups = true, bool? isSystem = null)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsRegistered(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsStaff(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserGroup(UserGroup userGroup)
    {
        throw new NotImplementedException();
    }
}
