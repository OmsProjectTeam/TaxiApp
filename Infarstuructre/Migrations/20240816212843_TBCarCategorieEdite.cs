using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TBCarCategorieEdite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceKr2",
                table: "TBCarCategories",
                newName: "CarCategorieKr2");

            migrationBuilder.RenameColumn(
                name: "ServiceKr1",
                table: "TBCarCategories",
                newName: "CarCategorieKr1");

            migrationBuilder.RenameColumn(
                name: "ServiceEn",
                table: "TBCarCategories",
                newName: "CarCategorieEn");

            migrationBuilder.RenameColumn(
                name: "ServiceAr",
                table: "TBCarCategories",
                newName: "CarCategorieAr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarCategorieKr2",
                table: "TBCarCategories",
                newName: "ServiceKr2");

            migrationBuilder.RenameColumn(
                name: "CarCategorieKr1",
                table: "TBCarCategories",
                newName: "ServiceKr1");

            migrationBuilder.RenameColumn(
                name: "CarCategorieEn",
                table: "TBCarCategories",
                newName: "ServiceEn");

            migrationBuilder.RenameColumn(
                name: "CarCategorieAr",
                table: "TBCarCategories",
                newName: "ServiceAr");
        }
    }
}
