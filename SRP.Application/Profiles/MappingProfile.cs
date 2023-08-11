using AutoMapper;
using SRP.Application.DTOs.Address;
using SRP.Application.DTOs.AddressType;
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
            CreateMap<AddressType, AddressTypeDto>().ReverseMap();
        }
    }
}
