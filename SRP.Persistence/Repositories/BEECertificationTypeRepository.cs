using Microsoft.EntityFrameworkCore;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Exceptions;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories
{
    public class BEECertificationTypeRepository : RepositoryBase<BEECertificationType>, IBEECertificationTypeRepository
    {
        private readonly SRPDbContext mDbContext;

        public BEECertificationTypeRepository(SRPDbContext dbContext) : base(dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<BEECertificationType> CreateBEECertificationTypeAsync(BEECertificationType certificationType)
        {
            var tAddress = await mDbContext.BEECertificationType.AddAsync(certificationType);
            await mDbContext.SaveChangesAsync();

            return tAddress.Entity;
        }

        public async Task<BEECertificationType> GetBEECertificationTypeAsync(Guid id)
        {
            var tAddress = await mDbContext.BEECertificationType
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return tAddress ?? throw new EntityNotFoundException(id);
        }
    }
}
