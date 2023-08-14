using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Countries
{
    public class CountryDto : BaseDto, ICountryDto
    {
        public string? Name { get; set; }
        public int ISO { get; set; }
        public string? A3 { get; set; }
        public string? A2 { get; set; }
        public int DialingCode { get; set; }
    }
}
