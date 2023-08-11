

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.UnitTests.Mocks;

public static class MockAddressRepository
{
    public static Mock<IAddressRepository> GetAddressRepository()
    {
        var tAddresses = new List<Address>()
        {
            new Address
            {
                Id = Guid.Parse("6D37EFA3-C94E-4AC3-9AD7-8367A5BB370F"),
                AddressTypeId = Guid.Parse("2E5262EC-B18A-47C5-BAFD-1BBF4B5D10FE"),
                SlotIndex = 1,
                Floor = "1st Floor",
                Building = "Dombea Block",
                Street = "Unit 155",
                City = "Johannesburg",
                PostalCode = "1684",
                LocationId = Guid.Parse("586BF713-A7F9-4EF1-AFF7-BB93499C9B49"),
                ProvinceId = Guid.Parse("1DA1D26D-8D64-4535-8767-DC41D85F9A6C"),
                CountryId = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
                BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                AddressType = new AddressType
                {
                    Id = Guid.Parse("2E5262EC-B18A-47C5-BAFD-1BBF4B5D10FE"),
                    Name = "Home",
                    BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                },
            },
            new Address
            {
                Id = Guid.Parse("6D37EFA3-C94E-4AC3-9AD7-8367A5BB370F"),
                AddressTypeId = Guid.Parse("FFDBD18C-CE41-4E00-B9FB-313761C3EFFA"),
                SlotIndex = 2,
                Floor = "2nd Floor",
                Building = "Tower 2",
                Street = "129 Rivonia Road",
                City = "Johannesburg",
                PostalCode = "2196",
                LocationId = Guid.Parse("061F9A0E-DE82-489D-8C58-D5D7523DBD98"),
                ProvinceId = Guid.Parse("1DA1D26D-8D64-4535-8767-DC41D85F9A6C"),
                CountryId = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
                BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474937"),
                AddressType = new AddressType
                {
                    Id = Guid.Parse("FFDBD18C-CE41-4E00-B9FB-313761C3EFFA"),
                    Name = "Office",
                    BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                },
            },
        };

        var tMockRepository = new Mock<IAddressRepository>();
        tMockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tAddresses);

        return tMockRepository;
    }
}
