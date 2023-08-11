using SRP.Application.Contracts.Infrastructure;
using SRP.Application.Features.Addresses.Requests.Commands;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.UnitTests.Addresses.Commands;

public class CreateAddressCommandHandlerTests
{
    private readonly IMapper mMapper;
    private readonly Mock<IAddressRepository> mMockAddressRepo;
    private readonly Mock<IAddressTypeRepository> mMockAddressTypeRepo;
    private readonly Mock<IProvinceRepository> mMockProvinceRepo;
    private readonly Mock<ICountryRepository> mMockCountryRepo;
    private readonly CreateAddressDto mAddressDto;
    private readonly CreateAddressCommandHandler mHandler;

    public CreateAddressCommandHandlerTests()
    {
        mMockAddressRepo = MockAddressRepository.GetAddressRepository();
        mMockAddressTypeRepo = MockAddressTypeRepository.GetMockAddressType();
        mMockProvinceRepo = MockProvinceRepository.GetProvinceRepository();
        mMockCountryRepo = MockCountryRepository.GetCountryRepository();

        var tMapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        mMapper = tMapperConfiguration.CreateMapper();

        mHandler = new CreateAddressCommandHandler(mMockAddressRepo.Object, 
            mMockAddressTypeRepo.Object, 
            mMockCountryRepo.Object, 
            mMockProvinceRepo.Object, 
            mMapper);

        mAddressDto = new CreateAddressDto
        {
            CountryId = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
            ProvinceId = Guid.Parse("1DA1D26D-8D64-4535-8767-DC41D85F9A6C"),
            AddressTypeId = Guid.Parse("2E5262EC-B18A-47C5-BAFD-1BBF4B5D10FE"),
            SlotIndex = 1,
            Floor = "1st Floor",
            Building = "Dombea Block",
            Street = "Unit 155",
            City = "Johannesburg",
            PostalCode = "1684",
         };
    }

    [Fact]
    public async Task Valid_Address_Created()
    {
        // Arrange
        var tCreateCmd = new CreateAddressCommand { AddressDto = mAddressDto };

        // Act
        var tResult = await mHandler.Handle(tCreateCmd, CancellationToken.None);

        var tAddresses = await mMockAddressRepo.Object.GetAllAsync();
        // Assert
        tResult.ShouldBeOfType<BaseCommandResponse>();

        tAddresses.Count().ShouldBe(3);
    }
}
