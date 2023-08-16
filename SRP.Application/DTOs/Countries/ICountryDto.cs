using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Countries
{
    public interface ICountryDto
    {
        string? Name { get; set; }
        int ISO { get; set; }
        string? A3 { get; set; }
        string? A2 { get; set; }
        int DialingCode { get; set; }
    }
}
