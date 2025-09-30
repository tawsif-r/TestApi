using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApi.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeyadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "Employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type_of_office = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeId",
                table: "Employees",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Office_OfficeId",
                table: "Employees",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Office_OfficeId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OfficeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Employees");
        }
    }
}
