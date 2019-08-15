using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMigration.Migrations
{
    public partial class Hoang4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Product",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Product");
        }
    }
}
