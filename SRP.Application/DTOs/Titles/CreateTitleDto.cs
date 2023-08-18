using SRP.Application.DTOs.Titles;
using SRP.Application.DTOs.Common;
using SRP.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Titles;

public class CreateTitleDto : ITitleDto
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;
}
