using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Configurations.Entities
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                new Address
                {
                    Id = Guid.Parse("CE0C97B0-961E-4179-BB66-9113B5AD4716"),
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
                    BeginDate = DateTime.Now,
                    SyncTS = DateTime.Now.Ticks
                },
                new Address
                {
                    Id = Guid.Parse("6D37EFA3-C94E-4AC3-9AD7-8367A5BB370F"),
                    AddressTypeId = Guid.Parse("6DC8D3EA-660B-4B4E-825E-CFA1A098077D"),                    
                    SlotIndex = 1,
                    Street = "129 Rivonia Road",
                    City = "Johannesburg",
                    PostalCode = "2196",
                    LocationId = Guid.Parse("061F9A0E-DE82-489D-8C58-D5D7523DBD98"),
                    ProvinceId = Guid.Parse("1DA1D26D-8D64-4535-8767-DC41D85F9A6C"),
                    CountryId = Guid.Parse("94FC7C1D-15BF-4238-9616-46675BEAFAB2"),
                    BeginDate = DateTime.Now,
                    SyncTS = DateTime.Now.Ticks
                }
             );
        }
    }
}
