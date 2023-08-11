using SRP.Application.DTOs.AddressType;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

namespace SRP.Application.DTOs.Address
{
    public class AddressDto : BaseDto, IAddressDto
    {
        public Guid AddressTypeId { get; set; }
        public int SlotIndex { get; set; }
        public string? Floor { get; set; }
        public string? Building { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? ProvinceId { get; set; }
        public Guid? CountryId { get; set; }
        public AddressTypeListDto? AddressType { get; set; }
    }
}