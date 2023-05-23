using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourrierDocker_MBDS_31.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Val = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDepartementId = table.Column<int>(type: "int", nullable: true),
                    UserPosteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyUser_Departement_UserDepartementId",
                        column: x => x.UserDepartementId,
                        principalTable: "Departement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MyUser_Poste_UserPosteId",
                        column: x => x.UserPosteId,
                        principalTable: "Poste",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courrier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Objet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpediteurId = table.Column<int>(type: "int", nullable: true),
                    CreateurId = table.Column<int>(type: "int", nullable: false),
                    PrioriteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courrier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courrier_MyUser_CreateurId",
                        column: x => x.CreateurId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courrier_MyUser_ExpediteurId",
                        column: x => x.ExpediteurId,
                        principalTable: "MyUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courrier_Priorite_PrioriteId",
                        column: x => x.PrioriteId,
                        principalTable: "Priorite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Commentaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCommentaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourrierId = table.Column<int>(type: "int", nullable: false),
                    CommentateurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaire_Courrier_CourrierId",
                        column: x => x.CourrierId,
                        principalTable: "Courrier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentaire_MyUser_CommentateurId",
                        column: x => x.CommentateurId,
                        principalTable: "MyUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Destinataire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTransmission = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRecepSec = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRecepDr = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepDestId = table.Column<int>(type: "int", nullable: false),
                    CourrierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinataire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinataire_Courrier_CourrierId",
                        column: x => x.CourrierId,
                        principalTable: "Courrier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destinataire_Departement_DepDestId",
                        column: x => x.DepDestId,
                        principalTable: "Departement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichierJoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourrierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichierJoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichierJoint_Courrier_CourrierId",
                        column: x => x.CourrierId,
                        principalTable: "Courrier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_CommentateurId",
                table: "Commentaire",
                column: "CommentateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_CourrierId",
                table: "Commentaire",
                column: "CourrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_CreateurId",
                table: "Courrier",
                column: "CreateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_ExpediteurId",
                table: "Courrier",
                column: "ExpediteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_PrioriteId",
                table: "Courrier",
                column: "PrioriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinataire_CourrierId",
                table: "Destinataire",
                column: "CourrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinataire_DepDestId",
                table: "Destinataire",
                column: "DepDestId");

            migrationBuilder.CreateIndex(
                name: "IX_FichierJoint_CourrierId",
                table: "FichierJoint",
                column: "CourrierId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_UserDepartementId",
                table: "MyUser",
                column: "UserDepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_UserPosteId",
                table: "MyUser",
                column: "UserPosteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaire");

            migrationBuilder.DropTable(
                name: "Destinataire");

            migrationBuilder.DropTable(
                name: "FichierJoint");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Courrier");

            migrationBuilder.DropTable(
                name: "MyUser");

            migrationBuilder.DropTable(
                name: "Priorite");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropTable(
                name: "Poste");
        }
    }
}
