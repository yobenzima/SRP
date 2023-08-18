using SRP.Application.DTOs.BEECertificationTypes;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

namespace SRP.Application.DTOs.BEECertificationTypes
{
    public class BEECertificationTypeDto : BaseDto, IBEECertificationTypeDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}