using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.Api.Migrations
{
    public partial class AddressModelLatLon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "AddressBook");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "AddressBook",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "AddressBook",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "AddressBook");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "AddressBook");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "AddressBook",
                nullable: true);
        }
    }
}
