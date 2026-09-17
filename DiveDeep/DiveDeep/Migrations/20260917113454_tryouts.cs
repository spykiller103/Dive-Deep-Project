using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeep.Migrations
{
    /// <inheritdoc />
    public partial class tryouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedSize",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedSize",
                table: "CartItems");
        }
    }
}
