using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatatowalk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "walks",
                columns: new[] { "Id", "Description", "DifficultyId", "Name", "RegionId", "WalkImageUrl", "lengthInKm" },
                values: new object[,]
                {
                    { new Guid("0f17ddd8-9ff3-4c3d-a019-c878e536ab1b"), "I was going to dubai to make myself enjoy", new Guid("e28f4960-9de0-4116-a162-bb23540167f9"), "Going to London", new Guid("c742ff73-bacb-46e9-ac30-51b1eae05746"), "Walk.png", 1.0 },
                    { new Guid("12f84c68-121f-4394-a649-569b4321be10"), "I was going to dubai to make myself enjoy", new Guid("0483b46d-c8c0-44af-ab9c-bb828395875e"), "Going to Elias", new Guid("1b283634-abe1-4710-b00c-9cd0a4d8b294"), "Walk.png", 1.0 },
                    { new Guid("8e682712-2833-46d0-b705-1aa52ee39f20"), "I was going to dubai to make myself enjoy", new Guid("0483b46d-c8c0-44af-ab9c-bb828395875e"), "Going to Nework", new Guid("166702ef-0511-458b-a360-ce44344cc87a"), "Walk.png", 1.0 },
                    { new Guid("c3e30540-dc77-4064-98f3-773b57bea500"), "I was going to dubai to make myself enjoy", new Guid("f0f60887-3722-46b7-9712-6080d50b643a"), "Going to dubai", new Guid("7fff524e-6eb8-4d15-a00d-90057ef127a0"), "Walk.png", 19090.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "walks",
                keyColumn: "Id",
                keyValue: new Guid("0f17ddd8-9ff3-4c3d-a019-c878e536ab1b"));

            migrationBuilder.DeleteData(
                table: "walks",
                keyColumn: "Id",
                keyValue: new Guid("12f84c68-121f-4394-a649-569b4321be10"));

            migrationBuilder.DeleteData(
                table: "walks",
                keyColumn: "Id",
                keyValue: new Guid("8e682712-2833-46d0-b705-1aa52ee39f20"));

            migrationBuilder.DeleteData(
                table: "walks",
                keyColumn: "Id",
                keyValue: new Guid("c3e30540-dc77-4064-98f3-773b57bea500"));
        }
    }
}
