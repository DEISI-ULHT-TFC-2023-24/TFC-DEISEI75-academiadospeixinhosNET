using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace academiadospeixinhoscloud.Migrations
{
    /// <inheritdoc />
    public partial class eventolink2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link3",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link2",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "Link3",
                table: "Evento");
        }
    }
}
