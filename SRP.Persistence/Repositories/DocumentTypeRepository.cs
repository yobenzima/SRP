using Microsoft.EntityFrameworkCore;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.DocumentTypes;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories;

public class DocumentTypeRepository : RepositoryBase<DocumentType>, IDocumentTypeRepository
{
    private readonly SRPDbContext mDbContext;

    public DocumentTypeRepository(SRPDbContext dbContext) : base(dbContext)
    {
        mDbContext = dbContext;
    }

    public async Task<bool> CheckNameExistsAsync(string name)
    {
        return await mDbContext.DocumentType
             .Where(d => d.Name.ToLowerInvariant() == name.ToLowerInvariant())
             .AnyAsync();
    }

    public async Task<bool> CheckSortIndexExistsAsync(int sortIndex)
    {
        return await mDbContext.DocumentType
             .Where(d => d.SortIndex == sortIndex)
             .AnyAsync();
    }

    public async Task<List<DocumentType>> GetAllSortedAsync()
    {
        return await mDbContext.DocumentType
             .OrderBy(d => d.SortIndex)
             .ToListAsync();
    }
}
