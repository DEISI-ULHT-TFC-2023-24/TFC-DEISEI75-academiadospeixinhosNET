using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace academiadospeixinhoscloud.Migrations
{
    /// <inheritdoc />
    public partial class link_ementas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Ementa",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Ementa");
        }
    }
}
