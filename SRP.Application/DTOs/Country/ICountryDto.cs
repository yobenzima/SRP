using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Country
{
    public interface ICountryDto
    {
        public string? Name { get; set; }

        public int ISO { get; set; }

        public string? A3 { get; set; }

        public string? A2 { get; set; }

        public int DialingCode { get; set; }
    }
}
