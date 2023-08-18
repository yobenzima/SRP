using SRP.Application.DTOs.DocumentTypes;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Persistence;

public interface IDocumentTypeRepository : IRepositoryBase<DocumentType>
{
    Task<bool> CheckNameExistsAsync(string name);
    Task<bool> CheckSortIndexExistsAsync(int sortIndex);
    Task<List<DocumentType>> GetAllSortedAsync();
}
