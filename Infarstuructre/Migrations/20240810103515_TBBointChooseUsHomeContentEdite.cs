using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBBointChooseUsHomeContentEdite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneDescriptionKr2",
                table: "TBBointChooseUsHomeContents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneDescriptionKr2",
                table: "TBBointChooseUsHomeContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
