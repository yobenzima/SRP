﻿using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Persistence;

public interface ILegalEntityTypeRepository : IRepositoryBase<LegalEntityType>
{
    Task<bool> CheckDescriptionExistsAsync(string description);
}
