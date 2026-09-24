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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sizes = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    SelectedSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, 5, "BCD", "Let og komfortabel BCD med god pasform og stabilitet, velegnet til både begyndere og erfarne dykkere.", "/Content/Images/Equipment/BCD/NavigatorLite.png", 125, "Scubapro Navigator Lite BCD" },
                    { 2, 5, "BCD", "En SCUBAPRO Glide BCD kombinerer komfort, stabilitet og nem opdriftskontrol. Det frontjusterbare design, Y-Fit-skuldre og integrerede vægtsystem sikrer en stabil og behagelig pasform under hele dykket.", "/Content/Images/Equipment/BCD/GlideBCD.png", 140, "Scubapro BCD Glide" },
                    { 3, 5, "BCD", "SCUBAPRO Hydros Pro er en avanceret BCD med et fleksibelt og modulært design, der giver høj komfort, stabilitet og præcis opdriftskontrol under dykket.", "/Content/Images/Equipment/BCD/HydrosPro.png", 200, "Scubapro BCD Hydros Pro" },
                    { 4, 5, "BCD", "SEAC Modular BCD er designet med fokus på fleksibilitet, komfort og stabilitet. Det modulære design giver en god pasform og gør den velegnet til både rekreativ dykning og forskellige dykkersituationer.", "/Content/Images/Equipment/BCD/Modular.png", 145, "Seac BCD Modular" },
                    { 5, 5, "Dykkerdragt", "SCUBAPRO Definition er en 3 mm våddragt designet til høj komfort og bevægelsesfrihed. Det fleksible neoprenmateriale giver god pasform og hjælper med at holde kroppen varm under dykket.", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 6, 5, "Dykkerdragt", "SCUBAPRO Definition er en 5 mm våddragt, der kombinerer varmeisolering, komfort og bevægelsesfrihed. Det fleksible neoprenmateriale sikrer en behagelig pasform og god beskyttelse mod koldt vand.", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 7, 5, "Dykkerdragt", "SCUBAPRO Definition er en 7 mm våddragt designet til dykning i koldere vand. Det tykkere neopren giver effektiv varmeisolering, mens den fleksible konstruktion sikrer god komfort og bevægelsesfrihed under dykket.", "/Content/Images/Equipment/Divingsuits/Wetsuits/Definition.png", 100, "Scubapro Definition" },
                    { 8, 5, "Dykkerdragt", "Waterproof W5 er en 3,5 mm våddragt, der kombinerer god varmeisolering med fleksibilitet og komfort. Det elastiske neoprenmateriale giver en behagelig pasform og god bevægelsesfrihed under dykket.", "/Content/Images/Equipment/Divingsuits/Wetsuits/W5.png", 100, "Waterproof W5" },
                    { 9, 5, "Dykkerdragt", "Fourth Element Proteus er en 5 mm våddragt designet til effektiv varmeisolering og høj komfort. Det fleksible neoprenmateriale giver god bevægelsesfrihed og en tæt, behagelig pasform under dykket.", "/Content/Images/Equipment/Divingsuits/Wetsuits/ProteusF.png", 120, "Fourth Element Proteus" },
                    { 10, 5, "Dykkerdragt", "SCUBAPRO Exodry 4.0 er en robust tørdragt designet til dykning i koldt vand. Den vandtætte konstruktion hjælper med at holde dig tør og varm, mens den komfortable pasform giver god bevægelsesfrihed under dykket.", "/Content/Images/Equipment/Divingsuits/Drysuits/Exodry4.png", 300, "Scubapro Exodry 4.0" },
                    { 11, 5, "Dykkerdragt", "Waterproof D7 Evo er en slidstærk tørdragt designet til krævende dykning i koldt vand. Den vandtætte konstruktion giver effektiv beskyttelse mod vand, mens det fleksible design sikrer god komfort og bevægelsesfrihed under dykket.", "/Content/Images/Equipment/Divingsuits/Drysuits/D7Evo.png", 320, "Waterproof D7 Evo" },
                    { 12, 5, "Dykkerdragt", "SANTI E.Lite Plus er en let og slidstærk tørdragt designet til komfortabel dykning under forskellige forhold. Den robuste konstruktion beskytter mod vand, mens det fleksible materiale giver god bevægelsesfrihed og komfort under dykket.", "/Content/Images/Equipment/Divingsuits/Drysuits/ELitePlus.png", 350, "Santi E.Lite Plus" },
                    { 13, 5, "Tanke", "SCUBAPRO 5 liters dykkertank er en kompakt og robust flaske, der er velegnet til kortere dyk og som ekstra luftforsyning. Den er nem at håndtere og transportere.", "/Content/Images/Equipment/Tanks/Tank.png", 150, "Scubapro 5 liter" },
                    { 14, 5, "Tanke", "SCUBAPRO 10 liters dykkertank er en robust og alsidig flaske med god luftkapacitet til både rekreative og længere dyk. Det kompakte design gør den nem at håndtere og transportere.", "/Content/Images/Equipment/Tanks/Tank.png", 160, "Scubapro 10 liter" },
                    { 15, 5, "Tanke", "SCUBAPRO 12 liters dykkertank er en robust flaske med høj luftkapacitet, velegnet til længere rekreative dyk. Den solide konstruktion sikrer pålidelig ydeevne og gør tanken velegnet til forskellige dykkeforhold.", "/Content/Images/Equipment/Tanks/Tank.png", 170, "Scubapro 12 liter" },
                    { 16, 5, "Tanke", "SCUBAPRO 15 liters dykkertank er en robust flaske med stor luftkapacitet, ideel til længere dyk og dykkere med et højt luftforbrug. Den solide konstruktion sikrer pålidelighed og stabilitet under dykket.", "/Content/Images/Equipment/Tanks/Tank.png", 180, "Scubapro 15 liter" },
                    { 17, 5, "Regulatorsæt", "SCUBAPRO Octopus R105/MK25EVO/S600 er et komplet regulatorsæt med høj ydeevne og pålidelig luftlevering. Sættet er designet til komfortabel vejrtrækning og stabil funktion under forskellige dykkeforhold.", "/Content/Images/Equipment/Regulator/MK25EVO.png", 125, "Scubapro Octopus R105/MK25EVO/S600" },
                    { 18, 5, "Regulatorsæt", "SCUBAPRO Octopus R095/MK17EVO/C370 er et pålideligt regulatorsæt, der giver en jævn og komfortabel luftlevering under dykket. Det robuste design sikrer stabil ydeevne og gør sættet velegnet til rekreativ dykning.", "/Content/Images/Equipment/Regulator/MK17.png", 100, "Scubapro Octopus R095/MK17EVO/C370" },
                    { 19, 5, "Regulatorsæt", "SCUBAPRO Octopus S270/MK25EVO BT/A700 Carbon BT er et avanceret regulatorsæt med høj ydeevne og jævn luftlevering. Det robuste design og materialer i høj kvalitet sikrer komfortabel vejrtrækning og pålidelig funktion under dykket.", "/Content/Images/Equipment/Regulator/MK25EVObt.png", 150, "Scubapro Octopus S270/MK25EVO BT/A700 Carbon BT" },
                    { 20, 5, "Maske/Snorkel", "SCUBAPRO Ghost er en komfortabel dykkermaske med lav volumen og et bredt synsfelt. Den tætsluttende silikonefacial giver en behagelig pasform og sikrer klart udsyn under vandet.", "/Content/Images/Equipment/Masks/Ghost.png", 50, "Scubapro Ghost" },
                    { 21, 5, "Maske/Snorkel", "SCUBAPRO D-Mask er en komfortabel dykkermaske med et moderne design og bredt synsfelt. Den bløde silikonefacial sikrer en tæt og behagelig pasform, mens det hærdede glas giver klart udsyn under vandet.", "/Content/Images/Equipment/Masks/DMask.png", 60, "Scubapro D-Mask" },
                    { 22, 5, "Maske/Snorkel", "SCUBAPRO Spectra Mini er en kompakt og komfortabel dykkermaske designet til mindre ansigter. Det brede synsfelt og den bløde silikonefacial sikrer klart udsyn og en tæt, behagelig pasform under vandet.", "/Content/Images/Equipment/Masks/SpectraMini.png", 50, "Scubapro Spectra Mini" },
                    { 23, 5, "Maske/Snorkel", "SCUBAPRO Crystal VU er en komfortabel dykkermaske med stort synsfelt og fremragende udsyn under vandet. Den bløde silikonefacial sikrer en tæt og behagelig pasform, mens det robuste glas giver et klart og naturligt udsyn.", "/Content/Images/Equipment/Masks/CrystalVu.png", 75, "Scubapro Crystal VU" },
                    { 24, 5, "Maske/Snorkel", "Fourth Element Scout Kontrast er en komfortabel dykkermaske designet til klart og præcist udsyn under vandet. Det kontrastfremhævende design og den tætsluttende silikonefacial giver god pasform og komfort under dykket.", "/Content/Images/Equipment/Masks/Scout.png", 75, "Fourth Element Scout Kontrast" },
                    { 25, 5, "Maske/Snorkel", "N/A", "/Content/Images/Equipment/Masks/ScoutEnchance.png", 75, "Fourth Element Scout Enchance" },
                    { 26, 5, "Maske/Snorkel", "TUSA Element er en komfortabel dykkermaske med et enkelt og funktionelt design. Den bløde silikonefacial sikrer en tæt pasform, mens det klare glas giver et godt og naturligt udsyn under vandet.", "/Content/Images/Equipment/Masks/Element.png", 75, "Tusa Element" },
                    { 27, 5, "Finner", "SCUBAPRO Jet Fin er en robust og klassisk dykkerfinne med et kraftfuldt design, der giver effektiv fremdrift og god kontrol i vandet. Den solide konstruktion gør den velegnet til både rekreativ og krævende dykning.", "/Content/Images/Equipment/Fins/JetFin.png", 50, "Scubapro Jet Fin" },
                    { 28, 5, "Finner", "SCUBAPRO GO Travel er en let og kompakt dykkerfinne designet til rejser og nem transport. Det fleksible design giver god fremdrift og komfort, samtidig med at finnerne er nemme at pakke og tage med på farten.", "/Content/Images/Equipment/Fins/TravelFins.png", 50, "Scubapro GO travel" },
                    { 29, 5, "Finner", "SCUBAPRO Seawing Supernova er en kraftfuld dykkerfinne med innovativt design, der giver effektiv fremdrift og god kontrol i vandet. Den fleksible konstruktion sikrer en behagelig og energieffektiv svømning under dykket.", "/Content/Images/Equipment/Fins/SeawingSupernova.png", 60, "Scubapro Seawing Supernova" },
                    { 30, 5, "Finner", "SEAC Propulsion er en kraftfuld dykkerfinne designet til effektiv fremdrift og god kontrol i vandet. Den robuste og fleksible konstruktion giver komfortabel svømning og stabil ydeevne under dykket.", "/Content/Images/Equipment/Fins/Propulsion.png", 50, "Seac Propulsion" },
                    { 31, 5, "Finner", "SEAC ALA er en let og komfortabel dykkerfinne designet til effektiv fremdrift og god manøvredygtighed. Den fleksible konstruktion giver en behagelig svømmeoplevelse og stabil kontrol under dykket.", "/Content/Images/Equipment/Fins/ALA.png", 50, "Seac ALA" },
                    { 32, 5, "Finner", "Fourth Element Tech er en robust dykkerfinne designet til teknisk dykning og krævende forhold. Den stive konstruktion giver kraftfuld fremdrift, præcis kontrol og effektiv svømning under vandet.", "/Content/Images/Equipment/Fins/TechFins.png", 75, "Fourth Element Tech" },
                    { 33, 5, "Finner", "Fourth Element Rec Fin er en alsidig og komfortabel dykkerfinne designet til rekreativ dykning. Den fleksible konstruktion giver effektiv fremdrift, god kontrol og en behagelig svømmeoplevelse under vandet.", "/Content/Images/Equipment/Fins/RecFins.png", 80, "Fourth Element Rec Fin" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "Amount", "Category", "Equipment", "Image", "Price", "Sizes", "Title" },
                values: new object[,]
                {
                    { 1, 5, "Pakke", "[\"BCD\",\"Dykkerdragt\",\"Regulators\\u00E6t\",\"Tank\",\"Finner\",\"Maske\",\"Snorkel\"]", "/Content/Images/Packages/Package1.png", 750, null, "Komplet dykkersæt" },
                    { 2, 5, "Pakke", "[\"Finner\",\"Maske\",\"Snorkel\"]", "/Content/Images/Packages/Package2.png", 100, null, "Komplet snorkelsæt" }
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
                name: "IX_CartItems_ApplicationUserId",
                table: "CartItems",
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
