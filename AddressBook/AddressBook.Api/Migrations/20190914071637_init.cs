using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressBook",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressBook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Lastname = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AddressBook_AddressInfoId",
                        column: x => x.AddressInfoId,
                        principalTable: "AddressBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressInfoId",
                table: "User",
                column: "AddressInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AddressBook");
        }
    }
}
