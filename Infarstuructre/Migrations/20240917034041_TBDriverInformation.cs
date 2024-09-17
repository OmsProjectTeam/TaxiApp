using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBDriverInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBDriverInformations",
                columns: table => new
                {
                    IdDriverInformation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDriverUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDriverCategory = table.Column<int>(type: "int", nullable: false),
                    IdDrivingLicenseCategory = table.Column<int>(type: "int", nullable: false),
                    DriverNameAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DriverNameEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DriverNameKr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DriverNameKr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    GenderAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenderEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenderKr1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenderKr2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dateOfbirth = table.Column<DateOnly>(type: "date", nullable: false),
                    NationalNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FamilyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrentAddressAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CurrentAddressEn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CurrentAddressKr1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CurrentAddressKr2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDriverInformations", x => x.IdDriverInformation);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBDriverInformations");
        }
    }
}
