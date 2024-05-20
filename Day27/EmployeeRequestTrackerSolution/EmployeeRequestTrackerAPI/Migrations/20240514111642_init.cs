using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateofBirth", "Image", "Name", "phone" },
                values: new object[] { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Raghav", "1231231231" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateofBirth", "Image", "Name", "phone" },
                values: new object[] { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Raghul", "1231231233" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateofBirth", "Image", "Name", "phone" },
                values: new object[] { 512, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Pandi", "1231231232" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
