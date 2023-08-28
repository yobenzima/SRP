using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories;

public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
{
    public PermissionRepository(SRPDbContext dbContext) : base(dbContext)
    {
    }
}
