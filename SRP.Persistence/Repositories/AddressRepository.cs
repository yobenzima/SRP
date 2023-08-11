using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        private readonly SRPDbContext mDbContext;

        public AddressRepository(SRPDbContext dbContext) : base(dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            var tAddress = await mDbContext.Addresses.AddAsync(address);
            await mDbContext.SaveChangesAsync();

            return tAddress.Entity;
        }

        public async Task<Address> GetAddressAsync(Guid id)
        {
            var tAddress = await mDbContext.Addresses
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return tAddress ?? throw new EntityNotFoundException(id);
        }

        public async Task<List<Address>> GetAllAddressTypes()
        {
            var tAddresses = await mDbContext.Addresses.ToListAsync();

            return tAddresses;
        }

        public async Task<List<Address>> GetAddressesWithDetailsAsync()
        {
            var tAddresses = await mDbContext.Addresses
                .Include(a => a.AddressType)
                .ToListAsync();

            return tAddresses;
        }

        public async Task<Address> GetAddressWithDetailsAsync(Guid id)
        {
            var tAddress = await mDbContext.Addresses
                .Include(a => a.AddressType)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            return tAddress ?? throw new EntityNotFoundException(id);
        }
    }
}
