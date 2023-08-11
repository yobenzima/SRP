using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.UnitTests.Mocks
{
    public static class MockAddressTypeRepository
    {
        public static Mock<IAddressTypeRepository> GetMockAddressType()
        {
            var tAddresses = new List<AddressType>() {
                new AddressType()
                {
                    Id = Guid.Parse("2E5262EC-B18A-47C5-BAFD-1BBF4B5D10FE"),
                    Name = "Home",
                    BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                },
                new AddressType()
                {
                    Id = Guid.Parse("FFDBD18C-CE41-4E00-B9FB-313761C3EFFA"),
                    Name = "Office",
                    BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                },
            };

            var tMockRepository = new Mock<IAddressTypeRepository>();
            tMockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tAddresses);

            return tMockRepository;
        }
    }
}
