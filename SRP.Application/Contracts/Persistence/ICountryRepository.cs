using SRP.Application.DTOs.Countries;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Persistence;

public interface ICountryRepository : IRepositoryBase<Country>
{    
    Task<bool> CheckA3CodeExistsAsync(string a3);
    Task<bool> Check2CodeExistsAsync(string a2);
    Task<bool> CheckDialingCodeExistsAsync(int dialingCode);
    Task<bool> CheckISOExistsAsync(int isoNum);
    Task<Country> GetCountryWithDetailsAsync(Guid id);
}
