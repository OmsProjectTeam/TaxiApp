using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBServices",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ServiceEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ServiceKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ServiceKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UrlServiceAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UrlServiceEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UrlServiceKr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UrlServiceKr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEntry = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBServices", x => x.IdService);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBServices");
        }
    }
}
