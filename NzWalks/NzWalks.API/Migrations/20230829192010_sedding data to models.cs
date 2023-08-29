using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class seddingdatatomodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0483b46d-c8c0-44af-ab9c-bb828395875e"), "Medium" },
                    { new Guid("e28f4960-9de0-4116-a162-bb23540167f9"), "Easy" },
                    { new Guid("f0f60887-3722-46b7-9712-6080d50b643a"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "region",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("166702ef-0511-458b-a360-ce44344cc87a"), "BM", "Bagladish", "image.png" },
                    { new Guid("1b283634-abe1-4710-b00c-9cd0a4d8b294"), "AJ", "AJerbaja", "image.png" },
                    { new Guid("7fff524e-6eb8-4d15-a00d-90057ef127a0"), "AM", "Amhara", "image.png" },
                    { new Guid("c742ff73-bacb-46e9-ac30-51b1eae05746"), "DW", "Dirediwa", "image.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulty",
                keyColumn: "Id",
                keyValue: new Guid("0483b46d-c8c0-44af-ab9c-bb828395875e"));

            migrationBuilder.DeleteData(
                table: "difficulty",
                keyColumn: "Id",
                keyValue: new Guid("e28f4960-9de0-4116-a162-bb23540167f9"));

            migrationBuilder.DeleteData(
                table: "difficulty",
                keyColumn: "Id",
                keyValue: new Guid("f0f60887-3722-46b7-9712-6080d50b643a"));

            migrationBuilder.DeleteData(
                table: "region",
                keyColumn: "Id",
                keyValue: new Guid("166702ef-0511-458b-a360-ce44344cc87a"));

            migrationBuilder.DeleteData(
                table: "region",
                keyColumn: "Id",
                keyValue: new Guid("1b283634-abe1-4710-b00c-9cd0a4d8b294"));

            migrationBuilder.DeleteData(
                table: "region",
                keyColumn: "Id",
                keyValue: new Guid("7fff524e-6eb8-4d15-a00d-90057ef127a0"));

            migrationBuilder.DeleteData(
                table: "region",
                keyColumn: "Id",
                keyValue: new Guid("c742ff73-bacb-46e9-ac30-51b1eae05746"));
        }
    }
}
