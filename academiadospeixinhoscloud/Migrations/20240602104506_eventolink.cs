using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace academiadospeixinhoscloud.Migrations
{
    /// <inheritdoc />
    public partial class eventolink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Evento");
        }
    }
}
