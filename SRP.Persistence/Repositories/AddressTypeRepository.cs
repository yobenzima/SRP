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
    public class AddressTypeRepository : RepositoryBase<AddressType>, IAddressTypeRepository
    {
        private readonly SRPDbContext mDbContext;

        public AddressTypeRepository(SRPDbContext dbContext) : base(dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<AddressType> CreateAddressTypeAsync(AddressType addressType)
        {
            var tAddressType = await mDbContext.AddressType.AddAsync(addressType);
            await mDbContext.SaveChangesAsync();

            return tAddressType.Entity;
        }

        public async Task<List<AddressType>> GetAllAddressTypes()
        {
            var tAddressType = await mDbContext.AddressType
                .ToListAsync();

            return tAddressType;
        }

        public async Task<List<AddressType>> GetAddressTypesWithDetailsAsync()
        {
            var tAddressType = await mDbContext.AddressType
                .Include(a => a.Address)
                .ToListAsync();

            return tAddressType;
        }

        public async Task<AddressType> GetAddressTypeWithDetailsAsync(Guid id)
        {
            var tAddressType = await mDbContext.AddressType
                .Include(a => a.Address)
                .FirstOrDefaultAsync(a => a.Id == id);
            
            return tAddressType ?? throw new EntityNotFoundException(id);
        }
    }
}
