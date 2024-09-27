using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBCarInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCarInformations",
                columns: table => new
                {
                    IdCarInformation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDriverInformation = table.Column<int>(type: "int", nullable: false),
                    IdCarCategories = table.Column<int>(type: "int", nullable: false),
                    CarNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeCar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YearManufacture = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCarInformations", x => x.IdCarInformation);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCarInformations");
        }
    }
}
