using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories;

public class PermissionActionRepository : RepositoryBase<PermissionAction>, IPermissionActionRepository
{
    public PermissionActionRepository(SRPDbContext dbContext) : base(dbContext)
    {
    }
}
