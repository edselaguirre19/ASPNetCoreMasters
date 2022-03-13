using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCoreMastersToDoList.Data.Migrations
{
    public partial class updatetableitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBBy",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBBy",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Items");
        }
    }
}
