using SRP.Application.DTOs.LocalMunicipalities;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

namespace SRP.Application.DTOs.LocalMunicipalities
{
    public class LocalMunicipalityDto : BaseDto, ILocalMunicipalityDto
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}