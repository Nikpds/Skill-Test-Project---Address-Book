using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.Api.Migrations
{
    public partial class multipleAddressOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AddressBook_UserId",
                table: "AddressBook");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "AddressBook");

            migrationBuilder.CreateIndex(
                name: "IX_AddressBook_UserId",
                table: "AddressBook",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AddressBook_UserId",
                table: "AddressBook");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "AddressBook",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressBook_UserId",
                table: "AddressBook",
                column: "UserId",
                unique: true);
        }
    }
}
