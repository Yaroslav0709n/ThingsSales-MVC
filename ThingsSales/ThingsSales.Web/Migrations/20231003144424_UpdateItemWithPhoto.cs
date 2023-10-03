using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThingsSales.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemWithPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoData",
                table: "Items",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "PhotoMimeType",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoData",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PhotoMimeType",
                table: "Items");
        }
    }
}
