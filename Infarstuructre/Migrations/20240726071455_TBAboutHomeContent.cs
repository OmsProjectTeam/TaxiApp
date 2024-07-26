using System;
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBAboutHomeContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAboutHomeContents",
                columns: table => new
                {
                    IdAboutHomeContent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearsExperience = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DescriptionYearsExperienceEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DescriptionYearsExperienceAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DescriptionYearsExperienceKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DescriptionYearsExperienceKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelOneEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelOneAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelOneKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelOneKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelTwoEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelTwoAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelTwoKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitelTwoKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstDescriptionEN = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    FirstDescriptionAr = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    FirstDescriptionKr1 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    FirstDescriptionKr2 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    SecandDescriptionEn = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    SecandDescriptionAr = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    SecandDescriptionKr1 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    SecandDescriptionKr2 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    PhoneDescriptionEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneDescriptionAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneDescriptionKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneDescriptionKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAboutHomeContents", x => x.IdAboutHomeContent);
                });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAboutHomeContents");
        }
    }
}
