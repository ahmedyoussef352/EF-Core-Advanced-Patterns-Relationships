using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore2.Migrations
{
    /// <inheritdoc />
    public partial class TPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Employees_EmployeeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_FullTimeEmployees_Employees_Id",
                table: "FullTimeEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_PartTimeEmployees_Employees_Id",
                table: "PartTimeEmployees");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateSequence<int>(
                name: "EmployeesTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PartTimeEmployees",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR EmployeesTypeId",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MangerId",
                table: "PartTimeEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PartTimeEmployees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "PartTimeEmployees",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FullTimeEmployees",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR EmployeesTypeId",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MangerId",
                table: "FullTimeEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FullTimeEmployees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "FullTimeEmployees",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MangerId",
                table: "PartTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PartTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "PartTimeEmployees");

            migrationBuilder.DropColumn(
                name: "MangerId",
                table: "FullTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FullTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "FullTimeEmployees");

            migrationBuilder.DropSequence(
                name: "EmployeesTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PartTimeEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR EmployeesTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FullTimeEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR EmployeesTypeId");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangerId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Employees_EmployeeId",
                table: "Cars",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FullTimeEmployees_Employees_Id",
                table: "FullTimeEmployees",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartTimeEmployees_Employees_Id",
                table: "PartTimeEmployees",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
