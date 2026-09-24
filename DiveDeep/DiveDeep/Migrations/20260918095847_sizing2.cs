using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeep.Migrations
{
    /// <inheritdoc />
    public partial class sizing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageEquipmentSizeRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSizes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresSize = table.Column<bool>(type: "bit", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageEquipmentSizeRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageEquipmentSizeRequirements_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PackageEquipmentSizeRequirements",
                columns: new[] { "Id", "AvailableSizes", "EquipmentName", "PackageId", "RequiresSize" },
                values: new object[,]
                {
                    { 1, "S,M,L,XL", "BCD", 1, true },
                    { 2, "S,M,L,XL", "Dykkerdragt", 1, true },
                    { 3, "", "Regulatorsæt", 1, false },
                    { 4, "", "Tank", 1, false },
                    { 5, "S,M,L,XL", "Finner", 1, true },
                    { 6, "", "Maske", 1, false },
                    { 7, "", "Snorkel", 1, false },
                    { 8, "S,M,L,XL", "Finner", 2, true },
                    { 9, "", "Maske", 2, false },
                    { 10, "", "Snorkel", 2, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageEquipmentSizeRequirements_PackageId",
                table: "PackageEquipmentSizeRequirements",
                column: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageEquipmentSizeRequirements");
        }
    }
}
