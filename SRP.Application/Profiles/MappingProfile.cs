using AutoMapper;
using SRP.Application.DTOs.Addresses;
using SRP.Application.DTOs.AddressTypes;
using SRP.Application.DTOs.Countries;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();
            CreateMap<Address, AddressListDto>().ReverseMap();

            CreateMap<AddressType, AddressTypeDto>().ReverseMap();
            CreateMap<AddressType, AddressTypeListDto>().ReverseMap();
            CreateMap<AddressType, CreateAddressTypeDto>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryListDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
        }
    }
}
