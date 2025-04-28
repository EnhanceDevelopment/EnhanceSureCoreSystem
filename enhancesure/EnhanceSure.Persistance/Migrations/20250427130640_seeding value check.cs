using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnhanceSure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class seedingvaluecheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "RoleName" },
                values: new object[,]
                {
                    { new Guid("538e0449-fb03-446e-9bb7-03d53c3d5590"), new DateTime(2025, 4, 27, 13, 6, 40, 47, DateTimeKind.Utc).AddTicks(5333), new Guid("36673f44-bc5c-4a36-a81e-730edd9c9c60"), new DateTime(2025, 4, 27, 13, 6, 40, 47, DateTimeKind.Utc).AddTicks(5336), new Guid("36673f44-bc5c-4a36-a81e-730edd9c9c60"), "User" },
                    { new Guid("9ea0339d-ec5a-4a2d-af3c-e018939d4271"), new DateTime(2025, 4, 27, 13, 6, 40, 47, DateTimeKind.Utc).AddTicks(5348), new Guid("36673f44-bc5c-4a36-a81e-730edd9c9c60"), new DateTime(2025, 4, 27, 13, 6, 40, 47, DateTimeKind.Utc).AddTicks(5349), new Guid("36673f44-bc5c-4a36-a81e-730edd9c9c60"), "Admin" },
                    { new Guid("adc04a70-c8af-4a68-831e-2ac33dc9852f"), new DateTime(2025, 4, 27, 13, 6, 40, 47, DateTimeKind.Utc).AddTicks(5352), new Guid("36673f44-bc5c-4a36-a81e-730edd9c9c60"), new DateTime(2025, 4, 27, 13, 6, 40, 47, DateTimeKind.Utc).AddTicks(5353), new Guid("36673f44-bc5c-4a36-a81e-730edd9c9c60"), "SuperAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: new Guid("538e0449-fb03-446e-9bb7-03d53c3d5590"));

            migrationBuilder.DeleteData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: new Guid("9ea0339d-ec5a-4a2d-af3c-e018939d4271"));

            migrationBuilder.DeleteData(
                table: "tbl_Roles",
                keyColumn: "Id",
                keyValue: new Guid("adc04a70-c8af-4a68-831e-2ac33dc9852f"));
        }
    }
}
