using SRP.Application.DTOs.Addresses;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.DocumentTypes
{
    public class DocumentTypeDto : BaseDto, IDocumentTypeDto
    { 
        public int SortIndex { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
