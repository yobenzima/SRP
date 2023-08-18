using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.DocumentTypes
{
    public class UpdateDocumentTypeDto : BaseDto, IDocumentTypeDto
    {
        public int SortIndex { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
