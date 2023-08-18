using Microsoft.EntityFrameworkCore;

using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories
{
    public class ApplicantTypeRepository : RepositoryBase<ApplicantType>, IApplicantTypeRepository
    {
        private readonly SRPDbContext mDbContext;

        public ApplicantTypeRepository(SRPDbContext dbContext) : base(dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<List<ApplicantType>> GetWithDetailsAsync()
        {
            return await mDbContext.ApplicantType.ToListAsync();
        }
    }
}
