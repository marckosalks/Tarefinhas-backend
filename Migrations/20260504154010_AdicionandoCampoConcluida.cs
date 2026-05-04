using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefinhas.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoConcluida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Concluida",
                table: "Tarefinhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluida",
                table: "Tarefinhas");
        }
    }
}
