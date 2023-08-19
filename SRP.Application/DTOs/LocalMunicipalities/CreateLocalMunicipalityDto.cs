using SRP.Application.DTOs.LocalMunicipalities;
using SRP.Application.DTOs.Common;
using SRP.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LocalMunicipalities;

public class CreateLocalMunicipalityDto : ILocalMunicipalityDto
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
