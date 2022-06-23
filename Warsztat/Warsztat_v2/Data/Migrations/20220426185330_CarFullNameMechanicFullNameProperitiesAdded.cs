using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarsztatAuthentication.Data.Migrations
{
    public partial class CarFullNameMechanicFullNameProperitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Orders",
                newName: "MechanicId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                newName: "IX_Orders_MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_MechanicId",
                table: "Orders",
                column: "MechanicId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_MechanicId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "MechanicId",
                table: "Orders",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_MechanicId",
                table: "Orders",
                newName: "IX_Orders_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
