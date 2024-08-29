using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class TaxizAppHomeContentEditeFilde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstDescriptionAr",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstDescriptionEN",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstDescriptionKr1",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstDescriptionKr2",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlAndrAppAr",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlAndrAppEn",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlAndrAppKr1",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlAndrAppKr2",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlAppAr",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlAppEn",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlAppKr1",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlAppKr2",
                table: "TBTaxizAppHomeContents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstDescriptionAr",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "FirstDescriptionEN",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "FirstDescriptionKr1",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "FirstDescriptionKr2",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "UrlAndrAppAr",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "UrlAndrAppEn",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "UrlAndrAppKr1",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "UrlAndrAppKr2",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "UrlAppAr",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "UrlAppEn",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "UrlAppKr1",
                table: "TBTaxizAppHomeContents");

            migrationBuilder.DropColumn(
                name: "UrlAppKr2",
                table: "TBTaxizAppHomeContents");
        }
    }
}
