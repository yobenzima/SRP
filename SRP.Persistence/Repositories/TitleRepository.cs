using Microsoft.EntityFrameworkCore;

using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories;

public class TitleRepository : RepositoryBase<Title>, ITitleRepository
{
    private readonly SRPDbContext mDbContext;

    public TitleRepository(SRPDbContext dbContext) : base(dbContext)
    {
        mDbContext = dbContext;
    }

    public async Task<bool> CheckDescriptionExistsAsync(string description)
    {
        return await mDbContext.Title
            .Where(d => d.Description.ToLowerInvariant() == description.ToLowerInvariant())
            .AnyAsync();
    }

    public async Task<bool> IsCodeUnique(string code)
    {
        return await mDbContext.Title
            .Where(d => d.Code.ToLowerInvariant() == code.ToLowerInvariant())
            .AnyAsync();
    }
}
