using SRP.Application.Contracts.Persistence;
using SRP.Application.Contracts.Security;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure.Security;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository mPermissionRepository;
    private readonly IPermissionActionRepository mPermissionActionRepository;
    private readonly IUserGroupService mUserGroupService;

    public PermissionService(IPermissionRepository permissionRepository, IPermissionActionRepository permissionActionRepository, IUserGroupService userGroupService)
    {
        mPermissionRepository = permissionRepository;
        mPermissionActionRepository = permissionActionRepository;
        mUserGroupService = userGroupService;
    }

    public Task<bool> Authorize(Permission permission)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Authorize(Permission permission, UserGroup userGroup)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Authorize(string permissionSystemName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Authorize(string permissionSystemName, UserGroup userGroup)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AuthorizeAction(string permissionSystemName, string permissionActionName)
    {
        throw new NotImplementedException();
    }

    public Task DeletePermission(Permission permission)
    {
        throw new NotImplementedException();
    }

    public Task DeletePermissionAction(PermissionAction permissionAction)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Permission>> GetAllPermissions()
    {
        throw new NotImplementedException();
    }

    public Task<IList<PermissionAction>> GetPermissionActions(string systemName, Guid userGroupId)
    {
        throw new NotImplementedException();
    }

    public Task<Permission> GetPermissionById(string permissionId)
    {
        throw new NotImplementedException();
    }

    public Task<Permission> GetPermissionBySystemName(string systemName)
    {
        throw new NotImplementedException();
    }

    public Task InsertPermission(Permission permission)
    {
        throw new NotImplementedException();
    }

    public Task InsertPermissionAction(PermissionAction permissionAction)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePermission(Permission permission)
    {
        throw new NotImplementedException();
    }
}
