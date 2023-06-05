using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourrierDocker_MBDS_31.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDestInterne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestInterneID",
                table: "Destinataire",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinataire_DestInterneID",
                table: "Destinataire",
                column: "DestInterneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinataire_Poste_DestInterneID",
                table: "Destinataire",
                column: "DestInterneID",
                principalTable: "Poste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinataire_Poste_DestInterneID",
                table: "Destinataire");

            migrationBuilder.DropIndex(
                name: "IX_Destinataire_DestInterneID",
                table: "Destinataire");

            migrationBuilder.DropColumn(
                name: "DestInterneID",
                table: "Destinataire");
        }
    }
}
