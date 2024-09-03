using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class IdlatestNewsBlogHomeContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTaxizAppHomeContent",
                table: "TBlatestNewsBlogHomeContents",
                newName: "IdlatestNewsBlogHomeContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdlatestNewsBlogHomeContent",
                table: "TBlatestNewsBlogHomeContents",
                newName: "IdTaxizAppHomeContent");
        }
    }
}
