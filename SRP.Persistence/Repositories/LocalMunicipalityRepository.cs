using Microsoft.EntityFrameworkCore;

using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories;

public class LocalMunicipalityRepository : RepositoryBase<LocalMunicipality>, ILocalMunicipalityRepository
{
    private readonly SRPDbContext mDbContext;

    public LocalMunicipalityRepository(SRPDbContext dbContext) : base(dbContext)
    {
        mDbContext = dbContext;
    }

    public async Task<bool> CheckNameExistsAsync(string name)
    {
        return await mDbContext.LocalMunicipality
            .Where(d => d.Name == name)
            .AnyAsync();
    }

    public async Task<bool> IsCodeUnique(string code)
    {
        var tLocalMunicipality = await mDbContext.LocalMunicipality
            .Where(d => d.Code == code)
            .SingleOrDefaultAsync();

        return tLocalMunicipality == null;
    }
}
