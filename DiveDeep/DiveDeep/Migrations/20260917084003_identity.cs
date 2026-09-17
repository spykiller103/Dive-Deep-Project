using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeep.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Profiles_ProfileId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProfileId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 1,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 2,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 3,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 4,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 5,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 6,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 7,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 8,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 9,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 10,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 11,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 12,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 13,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 14,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 15,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 16,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 17,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 18,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 19,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 20,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 21,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 22,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 23,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 24,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 25,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 26,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 27,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 28,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 29,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 30,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 31,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 32,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: 33,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 1,
                column: "Amount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: 2,
                column: "Amount",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookingId",
                table: "CartItems",
                column: "BookingId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Bookings_BookingId",
                table: "CartItems",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Bookings_BookingId",
                table: "CartItems");

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
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_BookingId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveRents = table.Column<int>(type: "int", nullable: false),
                    CompletedRents = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "ActiveRents", "CompletedRents", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 2, 4, "Test@mail.com", "Nicklas", "Jensen" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProfileId",
                table: "CartItems",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Profiles_ProfileId",
                table: "CartItems",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");
        }
    }
}
