using MediatR;

using SRP.Application.Caching.Constants;
using SRP.Application.Contracts.Infrastructure;
using SRP.Application.Contracts.Persistence;
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
    private IUserGroupRepository mUserGroupRepository;
    private readonly ICacheBase mCacheBase;
    private readonly IMediator mMediator;

    public UserGroupService(IUserGroupRepository userGroupRepository, ICacheBase cacheBase, IMediator mediator)
    {
        mUserGroupRepository = userGroupRepository;
        mCacheBase = cacheBase;
        mMediator = mediator;
    }

    public virtual Task DeleteUserGroup(UserGroup userGroup)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IList<UserGroup>> GetAllByIds(Guid[] ids)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IPagedList<UserGroup>> GetAllUserGroups(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
    {
        throw new NotImplementedException();
    }

    public virtual Task<UserGroup?> GetUserGroupById(Guid userGroupId)
    {
        if(userGroupId == Guid.Empty )
            return Task.FromResult<UserGroup?>(null);

        var tKey = String.Format(CacheKey.USERGROUP_BY_ID_KEY, userGroupId);
        return mCacheBase.GetAsync(tKey, () => mUserGroupRepository.GetByIdAsync(userGroupId));
    }

    public virtual Task<UserGroup> GetUserGroupBySystemName(string systemName)
    {
        throw new NotImplementedException();
    }

    public virtual Task InsertUserGroup(UserGroup userGroup)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> IsAdmin(User user)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> IsGuest(User user)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> IsInUserGroup(User user, string userGroupSystemName, bool onlyActiveUserGroups = true, bool? isSystem = null)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> IsRegistered(User user)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> IsStaff(User user)
    {
        throw new NotImplementedException();
    }

    public virtual Task UpdateUserGroup(UserGroup userGroup)
    {
        throw new NotImplementedException();
    }
}
