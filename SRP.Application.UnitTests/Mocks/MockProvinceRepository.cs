using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.UnitTests.Mocks
{
    public static class MockProvinceRepository
    {
        public static Mock<IProvinceRepository> GetProvinceRepository()
        {
            var tProvinces = new List<Province>()
            {
                new Province
                {
                    Id = Guid.Parse("1DA1D26D-8D64-4535-8767-DC41D85F9A6C"),
                    Name = "Gauteng",
                    CountryId = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
                    BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                },
                new Province
                {
                    Id = Guid.Parse("83945B05-C501-4D63-BABA-A4E8459D92F6"),
                    Name = "Eastern Cape",
                    CountryId = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
                    BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                },
                new Province
                {
                    Id = Guid.Parse("F9321D1E-D8CB-407D-B254-5E12621DA734"),
                    Name = "KwaZulu-Natal",
                    CountryId = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
                    BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                },
                new Province
                {
                    Id = Guid.Parse("D3B8181C-C6DC-4814-B7AC-4B7A1024FC78"),
                    Name = "North West",
                    CountryId = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
                    BeginDate = DateTime.Parse("2023-08-08 15:57:13.3474922"),
                },
            };

            var tMockRepository = new Mock<IProvinceRepository>();
            tMockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tProvinces);

            return tMockRepository;
        }
    }
}
