using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Persistence;

public interface IAddressTypeRepository : IRepositoryBase<AddressType>
{
    Task<AddressType> GetAddressTypeWithDetailsAsync(Guid id);
    Task<List<AddressType>> GetAddressTypesWithDetailsAsync();
}
