using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LocalMunicipalities;

public class UpdateLocalMunicipalityDto : BaseDto, ILocalMunicipalityDto
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
