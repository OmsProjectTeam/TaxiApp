using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBTaxiInfoStepEdite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxiInfoStep",
                table: "TBTaxiInfoSteps",
                newName: "IdTaxiInfoStep");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "TBTaxiInfoSteps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "TBTaxiInfoSteps");

            migrationBuilder.RenameColumn(
                name: "IdTaxiInfoStep",
                table: "TBTaxiInfoSteps",
                newName: "TaxiInfoStep");
        }
    }
}
