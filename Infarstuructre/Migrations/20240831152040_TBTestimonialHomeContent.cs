using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBTestimonialHomeContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBTestimonialHomeContents",
                columns: table => new
                {
                    IdTestimonialHomeContent = table.Column<int>(type: "int", nullable: false)
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
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTestimonialHomeContents", x => x.IdTestimonialHomeContent);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBTestimonialHomeContents");
        }
    }
}
