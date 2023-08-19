using AutoMapper;

using SRP.Application.DTOs.Addresses;
using SRP.Application.DTOs.AddressTypes;
using SRP.Application.DTOs.ApplicantTypes;
using SRP.Application.DTOs.BEECertificationTypes;
using SRP.Application.DTOs.Countries;
using SRP.Application.DTOs.DocumentTypes;
using SRP.Application.DTOs.LegalEntityTypes;
using SRP.Application.DTOs.LocalMunicipalities;
using SRP.Application.DTOs.Locations;
using SRP.Application.DTOs.Provinces;
using SRP.Application.DTOs.Statuses;
using SRP.Application.DTOs.Titles;
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

            CreateMap<Province, ProvinceDto>().ReverseMap();
            CreateMap<Province, ProvinceListDto>().ReverseMap();
            CreateMap<Province, CreateProvinceDto>().ReverseMap();

            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Location, LocationListDto>().ReverseMap();
            CreateMap<Location, CreateLocationDto>().ReverseMap();

            CreateMap<BEECertificationType, BEECertificationTypeDto>().ReverseMap();
            CreateMap<BEECertificationType, BEECertificationTypeListDto>().ReverseMap();
            CreateMap<BEECertificationType, CreateBEECertificationTypeDto>().ReverseMap();

            CreateMap<ApplicantType, ApplicantTypeDto>().ReverseMap();
            CreateMap<ApplicantType, ApplicantTypeListDto>().ReverseMap();
            CreateMap<ApplicantType, CreateApplicantTypeDto>().ReverseMap();

            CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeListDto>().ReverseMap();
            CreateMap<DocumentType, CreateDocumentTypeDto>().ReverseMap();

            CreateMap<LegalEntityType, LegalEntityTypeDto>().ReverseMap();
            CreateMap<LegalEntityType, LegalEntityTypeListDto>().ReverseMap();
            CreateMap<LegalEntityType, CreateLegalEntityTypeDto>().ReverseMap();

            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Status, StatusListDto>().ReverseMap();
            CreateMap<Status, CreateStatusDto>().ReverseMap();

            CreateMap<Title, TitleDto>().ReverseMap();
            CreateMap<Title, TitleListDto>().ReverseMap();
            CreateMap<Title, CreateTitleDto>().ReverseMap();

            CreateMap<LocalMunicipality, LocalMunicipalityDto>().ReverseMap();
            CreateMap<LocalMunicipality, LocalMunicipalityListDto>().ReverseMap();
            CreateMap<LocalMunicipality, CreateLocalMunicipalityDto>().ReverseMap();
        }
    }
}
