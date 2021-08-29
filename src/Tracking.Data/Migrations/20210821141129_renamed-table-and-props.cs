using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Data.Migrations
{
    public partial class renamedtableandprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "people");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "people",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "people",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "people",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_people",
                table: "people",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_people",
                table: "people");

            migrationBuilder.RenameTable(
                name: "people",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "People",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "People",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "People",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");
        }
    }
}
