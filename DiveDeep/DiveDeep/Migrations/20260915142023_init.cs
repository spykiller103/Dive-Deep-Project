using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeep.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveRents = table.Column<int>(type: "int", nullable: false),
                    CompletedRents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    ProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId");
                    table.ForeignKey(
                        name: "FK_CartItems_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId");
                    table.ForeignKey(
                        name: "FK_CartItems_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "Category", "Description", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "BCD", "TEMP", "/Content/Images/Equipment/BCD/NavigatorLite.png", 125, "Scubapro Navigator Lite BCD" },
                    { 2, "BCD", "TEMP", "/Content/Images/Equipment/BCD/GlideBCD.png", 140, "Scubapro BCD Glide" },
                    { 3, "BCD", "TEMP", "/Content/Images/Equipment/BCD/HydrosPro.png", 200, "Scubapro BCD Hydros Pro" },
                    { 4, "BCD", "TEMP", "/Content/Images/Equipment/BCD/Modular.png", 145, "Seac BCD Modular" },
                    { 5, "Dykkerdragt", "Våddragt, 3 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 6, "Dykkerdragt", "Våddragt, 5 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 7, "Dykkerdragt", "Våddragt, 7 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 8, "Dykkerdragt", "Våddragt, 3.5 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/W5.png", 100, "Waterproof W5" },
                    { 9, "Dykkerdragt", "Våddragt, 5 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/ProteusF.png", 120, "Fourth Element Proteus" },
                    { 10, "Dykkerdragt", "Tørdragt", "/Content/Images/Equipment/Divingsuits/Drysuits/Exodry4.png", 300, "Scubapro Exodry 4.0" },
                    { 11, "Dykkerdragt", "Tørdragt", "/Content/Images/Equipment/Divingsuits/Drysuits/D7Evo.png", 320, "Waterproof D7 Evo" },
                    { 12, "Dykkerdragt", "Tørdragt", "/Content/Images/Equipment/Divingsuits/Drysuits/ELitePlus.png", 350, "Santi E.Lite Plus" },
                    { 13, "Tanke", "N/A", "/Content/Images/Equipment/Tanks/Tank.png", 150, "Scubapro 5 liter" },
                    { 14, "Tanke", "N/A", "/Content/Images/Equipment/Tanks/Tank.png", 160, "Scubapro 10 liter" },
                    { 15, "Tanke", "N/A", "/Content/Images/Equipment/Tanks/Tank.png", 170, "Scubapro 12 liter" },
                    { 16, "Tanke", "N/A", "/Content/Images/Equipment/Tanks/Tank.png", 180, "Scubapro 15 liter" },
                    { 17, "Regulatorsæt", "N/A", "/Content/Images/Equipment/Regulator/MK25EVO.png", 125, "Scubapro Octopus R105/MK25EVO/S600" },
                    { 18, "Regulatorsæt", "N/A", "/Content/Images/Equipment/Regulator/MK17.png", 100, "Scubapro Octopus R095/MK17EVO/C370" },
                    { 19, "Regulatorsæt", "N/A", "/Content/Images/Equipment/Regulator/MK25EVObt.png", 150, "Scubapro Octopus S270/MK25EVO BT/A700 Carbon BT" },
                    { 20, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/Ghost.png", 50, "Scubapro Ghost" },
                    { 21, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/DMask.png", 60, "Scubapro D-Mask" },
                    { 22, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/SpectraMini.png", 50, "Scubapro Spectra Mini" },
                    { 23, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/CrystalVu.png", 75, "Scubapro Crystal VU" },
                    { 24, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/Scout.png", 75, "Fourth Element Scout Kontrast" },
                    { 25, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/ScoutEnchance.png", 75, "Fourth Element Scout Enchance" },
                    { 26, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/Element.png", 75, "Tusa Element" },
                    { 27, "Finner", "N/A", "/Content/Images/Equipment/Fins/JetFin.png", 50, "Scubapro Jet Fin" },
                    { 28, "Finner", "N/A", "/Content/Images/Equipment/Fins/TravelFins.png", 50, "Scubapro GO travel" },
                    { 29, "Finner", "N/A", "/Content/Images/Equipment/Fins/SeawingSupernova.png", 60, "Scubapro Seawing Supernova" },
                    { 30, "Finner", "N/A", "/Content/Images/Equipment/Fins/Propulsion.png", 50, "Seac Propulsion" },
                    { 31, "Finner", "N/A", "/Content/Images/Equipment/Fins/ALA.png", 50, "Seac ALA" },
                    { 32, "Finner", "N/A", "/Content/Images/Equipment/Fins/TechFins.png", 75, "Fourth Element Tech" },
                    { 33, "Finner", "N/A", "/Content/Images/Equipment/Fins/RecFins.png", 80, "Fourth Element Rec Fin" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "Category", "Equipment", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Pakke", "[\"BCD\",\"Dykkerdragt\",\"Regulators\\u00E6t\",\"Tank\",\"Finner\",\"Maske\",\"Snorkel\"]", "/Content/Images/Packages/Package1.png", 750, "Komplet dykkersæt" },
                    { 2, "Pakke", "[\"Finner\",\"Maske\",\"Snorkel\"]", "/Content/Images/Packages/Package2.png", 100, "Komplet snorkelsæt" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "ActiveRents", "CompletedRents", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 2, 4, "Test@mail.com", "Nicklas", "Jensen" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_EquipmentId",
                table: "CartItems",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PackageId",
                table: "CartItems",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProfileId",
                table: "CartItems",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
