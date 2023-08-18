using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.DocumentTypes
{
    public interface IDocumentTypeDto
    {
        public int SortIndex { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
