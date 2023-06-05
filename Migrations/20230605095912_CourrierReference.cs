using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourrierDocker_MBDS_31.Migrations
{
    /// <inheritdoc />
    public partial class CourrierReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourrierRef",
                table: "Courrier",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourrierRef",
                table: "Courrier");
        }
    }
}
