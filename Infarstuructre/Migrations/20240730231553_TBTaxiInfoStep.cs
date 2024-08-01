using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBTaxiInfoStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBTaxiInfoSteps",
                columns: table => new
                {
                    TaxiInfoStep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitelOneEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelOneAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelOneKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelOneKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelTwoEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelTwoAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelTwoKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelTwoKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelThreeEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelThreeAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelThreeKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelThreeKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelForEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelForAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelForKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelForKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelVifeEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelVifeAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelVifeKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelVifeKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelSixEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelSixAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelSixKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelSixKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxiInfoSteps", x => x.TaxiInfoStep);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBTaxiInfoSteps");
        }
    }
}
