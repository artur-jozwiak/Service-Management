using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarsztatAuthentication.Data.Migrations
{
    public partial class http : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarModel",
                table: "Cars",
                newName: "VehicleTypeName");

            migrationBuilder.RenameColumn(
                name: "CarMark",
                table: "Cars",
                newName: "Model_Name");

            migrationBuilder.AddColumn<int>(
                name: "FinishedOrder",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MakeName",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishedOrder",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MakeName",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeName",
                table: "Cars",
                newName: "CarModel");

            migrationBuilder.RenameColumn(
                name: "Model_Name",
                table: "Cars",
                newName: "CarMark");
        }
    }
}
