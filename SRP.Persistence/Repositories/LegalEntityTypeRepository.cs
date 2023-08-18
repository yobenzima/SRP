using Microsoft.EntityFrameworkCore;

using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories;

public class LegalEntityTypeRepository : RepositoryBase<LegalEntityType>, ILegalEntityTypeRepository
{
    private readonly SRPDbContext mDbContext;

    public LegalEntityTypeRepository(SRPDbContext dbContext) : base(dbContext)
    {
        mDbContext = dbContext;
    }

    public async Task<bool> CheckDescriptionExistsAsync(string description)
    {
        return await mDbContext.LegalEntityType
             .Where(d => d.Description.ToLowerInvariant() == description.ToLowerInvariant())
             .AnyAsync();
    }
}
