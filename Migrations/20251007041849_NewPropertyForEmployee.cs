using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApi.Migrations
{
    /// <inheritdoc />
    public partial class NewPropertyForEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Office_OfficeId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office",
                table: "Office");

            migrationBuilder.RenameTable(
                name: "Office",
                newName: "Offices");

            migrationBuilder.AddColumn<bool>(
                name: "IsMarried",
                table: "Employees",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offices",
                table: "Offices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_OfficeId",
                table: "Employees",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_OfficeId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offices",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "IsMarried",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Offices",
                newName: "Office");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office",
                table: "Office",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Office_OfficeId",
                table: "Employees",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id");
        }
    }
}
