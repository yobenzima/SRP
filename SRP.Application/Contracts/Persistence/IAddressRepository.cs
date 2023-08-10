using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Persistence;

public interface IAddressRepository : IRepositoryBase<Address>
{
    Task<Address> GetAddressWithDetailsAsync(Guid id);
    Task<List<Address>> GetAddressesWithDetailsAsync();
}
