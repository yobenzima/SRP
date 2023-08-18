using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Titles;

public class UpdateTitleDto : BaseDto, ITitleDto
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;
}
