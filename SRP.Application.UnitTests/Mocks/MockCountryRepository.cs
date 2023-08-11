using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.UnitTests.Mocks
{
    public static class MockCountryRepository
    {
        public static Mock<ICountryRepository> GetCountryRepository()
        {
            var tCountries = new List<Country>
            {
                new Country
                {
                    Id = Guid.Parse("1BE0E8B3-4DDD-4BA9-ABE8-1C8F63B13FD7"),
                    Name = "United States",
                    ISO = 840,
                    A3 = "USA",
                    A2 = "US",
                    DialingCode = 1,
                    BeginDate = DateTime.MinValue,
                },
                new Country
                {
                    Id = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
                    Name = "South Africa",
                    ISO = 710,
                    A3 = "ZAF",
                    A2 = "ZA",
                    DialingCode = 27,
                    BeginDate = DateTime.MinValue,
                },
                new Country
                {
                    Id = Guid.Parse("00204735-6184-4B06-B1B0-4851B80CCD73"),
                    Name = "Malawi",
                    ISO = 454,
                    A3 = "MWI",
                    A2 = "MW",
                    DialingCode = 265,
                    BeginDate = DateTime.MinValue,
                },
                new Country
                {
                    Id = Guid.Parse("08A54309-2CD6-4E5B-8924-9069FC676D29"),
                    Name = "Zimbabwe",
                    ISO = 716,
                    A3 = "ZWE",
                    A2 = "ZW",
                    DialingCode = 263,
                    BeginDate = DateTime.MinValue,
                },
            };

            var tMockCountryRepository = new Mock<ICountryRepository>();
            tMockCountryRepository.Setup(t => t.GetAllAsync()).ReturnsAsync(tCountries);

            return tMockCountryRepository;
        }
    }
}
