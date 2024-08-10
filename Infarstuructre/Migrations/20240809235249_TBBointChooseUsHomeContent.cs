using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBBointChooseUsHomeContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBBointChooseUsHomeContents",
                columns: table => new
                {
                    IdBointChooseUsHomeContent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitelOneAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstDescriptionAr = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    TitelOneEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstDescriptionEn = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    TitelOneKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstDescriptionKr1 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    TitelOneKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstDescriptionKr2 = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneDescriptionKr2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBBointChooseUsHomeContents", x => x.IdBointChooseUsHomeContent);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBBointChooseUsHomeContents");
        }
    }
}
