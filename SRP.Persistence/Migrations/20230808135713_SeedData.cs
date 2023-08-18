using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

 // #pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SRP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressTypeId", "BeginDate", "Building", "City", "CountryId", "EndDate", "Floor", "LocationId", "PostalCode", "ProvinceId", "SlotIndex", "Street", "SyncTS" },
                values: new object[,]
                {
                    { new Guid("6d37efa3-c94e-4ac3-9ad7-8367a5bb370f"), new Guid("6dc8d3ea-660b-4b4e-825e-cfa1a098077d"), new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(4937), null, "Johannesburg", new Guid("94fc7c1d-15bf-4238-9616-46675beafab2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("061f9a0e-de82-489d-8c58-d5d7523dbd98"), "2196", new Guid("1da1d26d-8d64-4535-8767-dc41d85f9a6c"), 1, "129 Rivonia Road", 638271070333474938L },
                    { new Guid("ce0c97b0-961e-4179-bb66-9113b5ad4716"), new Guid("2e5262ec-b18a-47c5-bafd-1bbf4b5d10fe"), new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(4922), "Dombea Block", "Johannesburg", new Guid("94fc7c1d-15bf-4238-9616-46675beafab2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1st Floor", new Guid("586bf713-a7f9-4ef1-aff7-bb93499c9b49"), "1684", new Guid("1da1d26d-8d64-4535-8767-dc41d85f9a6c"), 1, "Unit 155", 638271070333474931L }
                });

            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "Id", "BeginDate", "EndDate", "Description", "SyncTS" },
                values: new object[,]
                {
                    { new Guid("16a4335e-9504-4e54-9673-3b2a438ad349"), new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(5910), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physical", 638271070333475911L },
                    { new Guid("d0021e61-acec-4a5c-b947-a34f060632e3"), new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(5923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domicilium", 638271070333475924L },
                    { new Guid("ffdbd18c-ce41-4e00-b9fb-313761c3effa"), new DateTime(2023, 8, 8, 15, 57, 13, 347, DateTimeKind.Local).AddTicks(5914), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Postal", 638271070333475914L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
