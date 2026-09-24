using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeep.Migrations
{
    /// <inheritdoc />
    public partial class sizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop Sizes from Equipments only if the column exists to avoid failures on databases
            // that already don't have the column.
            migrationBuilder.Sql(@"IF EXISTS(SELECT * FROM sys.columns 
                WHERE Name = N'Sizes' AND Object_ID = Object_ID(N'Equipments'))
            BEGIN
                ALTER TABLE [Equipments] DROP COLUMN [Sizes]
            END");

            migrationBuilder.AddColumn<string>(
                name: "Sizes",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                column: "Sizes",
                value: "S,M,L,XL");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                column: "Sizes",
                value: "S,M,L,XL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sizes",
                table: "Packages");

            migrationBuilder.AddColumn<string>(
                name: "Sizes",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 1,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 2,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 3,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 4,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 5,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 6,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 7,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 8,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 9,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 10,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 11,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 12,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 13,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 14,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 15,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 16,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 17,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 18,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 19,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 20,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 21,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 22,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 23,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 24,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 25,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 26,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 27,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 28,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 29,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 30,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 31,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 32,
                column: "Sizes",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 33,
                column: "Sizes",
                value: null);
        }
    }
}
