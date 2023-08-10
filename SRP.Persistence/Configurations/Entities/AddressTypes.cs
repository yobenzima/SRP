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
    public class AddressTypes : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.HasData(
                 new AddressType
                 {
                     Id = Guid.Parse("16A4335E-9504-4E54-9673-3B2A438AD349"),
                     Name = "Physical",
                     BeginDate = DateTime.Now,
                     SyncTS = DateTime.Now.Ticks
                 },
                 new AddressType
                 {
                     Id = Guid.Parse("FFDBD18C-CE41-4E00-B9FB-313761C3EFFA"),
                     Name = "Postal",
                     BeginDate = DateTime.Now,
                     SyncTS = DateTime.Now.Ticks
                 },
                 new AddressType
                 {
                     Id = Guid.Parse("D0021E61-ACEC-4A5C-B947-A34F060632E3"),
                     Name = "Domicilium",
                     BeginDate = DateTime.Now,
                     SyncTS = DateTime.Now.Ticks
                 }
              );                
        }
    }
}
