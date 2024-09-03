using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBDrivingLicenseCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBDrivingLicenseCategorys",
                columns: table => new
                {
                    IdDrivingLicenseCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrivingLicenseCategoryAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DrivingLicenseCategoryEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DrivingLicenseCategoryKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DrivingLicenseCategoryKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDrivingLicenseCategorys", x => x.IdDrivingLicenseCategory);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBDrivingLicenseCategorys");
        }
    }
}
