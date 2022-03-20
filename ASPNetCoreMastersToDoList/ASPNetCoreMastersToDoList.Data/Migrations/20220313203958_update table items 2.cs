using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetCoreMastersToDoList.Data.Migrations
{
    public partial class updatetableitems2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBBy",
                table: "Items",
                newName: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Items",
                newName: "CreatedBBy");
        }
    }
}
