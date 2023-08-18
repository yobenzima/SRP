using SRP.Application.DTOs.Titles;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

namespace SRP.Application.DTOs.Titles
{
    public class TitleDto : BaseDto, ITitleDto
    {
        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}