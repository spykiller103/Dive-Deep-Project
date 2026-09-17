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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActiveRents = table.Column<int>(type: "int", nullable: true),
                    CompletedRents = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
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
                    Amount = table.Column<int>(type: "int", nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId");
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
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "Amount", "Category", "Description", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 5, "BCD", "TEMP", "/Content/Images/Equipment/BCD/NavigatorLite.png", 125, "Scubapro Navigator Lite BCD" },
                    { 2, 5, "BCD", "TEMP", "/Content/Images/Equipment/BCD/GlideBCD.png", 140, "Scubapro BCD Glide" },
                    { 3, 5, "BCD", "TEMP", "/Content/Images/Equipment/BCD/HydrosPro.png", 200, "Scubapro BCD Hydros Pro" },
                    { 4, 5, "BCD", "TEMP", "/Content/Images/Equipment/BCD/Modular.png", 145, "Seac BCD Modular" },
                    { 5, 5, "Dykkerdragt", "Våddragt, 3 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 6, 5, "Dykkerdragt", "Våddragt, 5 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 7, 5, "Dykkerdragt", "Våddragt, 7 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 8, 5, "Dykkerdragt", "Våddragt, 3.5 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/W5.png", 100, "Waterproof W5" },
                    { 9, 5, "Dykkerdragt", "Våddragt, 5 mm", "/Content/Images/Equipment/Divingsuits/Wetsuits/ProteusF.png", 120, "Fourth Element Proteus" },
                    { 10, 5, "Dykkerdragt", "Tørdragt", "/Content/Images/Equipment/Divingsuits/Drysuits/Exodry4.png", 300, "Scubapro Exodry 4.0" },
                    { 11, 5, "Dykkerdragt", "Tørdragt", "/Content/Images/Equipment/Divingsuits/Drysuits/D7Evo.png", 320, "Waterproof D7 Evo" },
                    { 12, 5, "Dykkerdragt", "Tørdragt", "/Content/Images/Equipment/Divingsuits/Drysuits/ELitePlus.png", 350, "Santi E.Lite Plus" },
                    { 13, 5, "Tanke", "N/A", "/Content/Images/Equipment/Tanks/Tank.png", 150, "Scubapro 5 liter" },
                    { 14, 5, "Tanke", "N/A", "/Content/Images/Equipment/Tanks/Tank.png", 160, "Scubapro 10 liter" },
                    { 15, 5, "Tanke", "N/A", "/Content/Images/Equipment/Tanks/Tank.png", 170, "Scubapro 12 liter" },
                    { 16, 5, "Tanke", "N/A", "/Content/Images/Equipment/Tanks/Tank.png", 180, "Scubapro 15 liter" },
                    { 17, 5, "Regulatorsæt", "N/A", "/Content/Images/Equipment/Regulator/MK25EVO.png", 125, "Scubapro Octopus R105/MK25EVO/S600" },
                    { 18, 5, "Regulatorsæt", "N/A", "/Content/Images/Equipment/Regulator/MK17.png", 100, "Scubapro Octopus R095/MK17EVO/C370" },
                    { 19, 5, "Regulatorsæt", "N/A", "/Content/Images/Equipment/Regulator/MK25EVObt.png", 150, "Scubapro Octopus S270/MK25EVO BT/A700 Carbon BT" },
                    { 20, 5, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/Ghost.png", 50, "Scubapro Ghost" },
                    { 21, 5, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/DMask.png", 60, "Scubapro D-Mask" },
                    { 22, 5, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/SpectraMini.png", 50, "Scubapro Spectra Mini" },
                    { 23, 5, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/CrystalVu.png", 75, "Scubapro Crystal VU" },
                    { 24, 5, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/Scout.png", 75, "Fourth Element Scout Kontrast" },
                    { 25, 5, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/ScoutEnchance.png", 75, "Fourth Element Scout Enchance" },
                    { 26, 5, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/Element.png", 75, "Tusa Element" },
                    { 27, 5, "Finner", "N/A", "/Content/Images/Equipment/Fins/JetFin.png", 50, "Scubapro Jet Fin" },
                    { 28, 5, "Finner", "N/A", "/Content/Images/Equipment/Fins/TravelFins.png", 50, "Scubapro GO travel" },
                    { 29, 5, "Finner", "N/A", "/Content/Images/Equipment/Fins/SeawingSupernova.png", 60, "Scubapro Seawing Supernova" },
                    { 30, 5, "Finner", "N/A", "/Content/Images/Equipment/Fins/Propulsion.png", 50, "Seac Propulsion" },
                    { 31, 5, "Finner", "N/A", "/Content/Images/Equipment/Fins/ALA.png", 50, "Seac ALA" },
                    { 32, 5, "Finner", "N/A", "/Content/Images/Equipment/Fins/TechFins.png", 75, "Fourth Element Tech" },
                    { 33, 5, "Finner", "N/A", "/Content/Images/Equipment/Fins/RecFins.png", 80, "Fourth Element Rec Fin" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "Amount", "Category", "Equipment", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 5, "Pakke", "[\"BCD\",\"Dykkerdragt\",\"Regulators\\u00E6t\",\"Tank\",\"Finner\",\"Maske\",\"Snorkel\"]", "/Content/Images/Packages/Package1.png", 750, "Komplet dykkersæt" },
                    { 2, 5, "Pakke", "[\"Finner\",\"Maske\",\"Snorkel\"]", "/Content/Images/Packages/Package2.png", 100, "Komplet snorkelsæt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookingId",
                table: "CartItems",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_EquipmentId",
                table: "CartItems",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PackageId",
                table: "CartItems",
                column: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
