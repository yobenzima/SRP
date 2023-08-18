using SRP.Application.DTOs.Statuses;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

namespace SRP.Application.DTOs.Statuses
{
    public class StatusDto : BaseDto, IStatusDto
    {
        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}