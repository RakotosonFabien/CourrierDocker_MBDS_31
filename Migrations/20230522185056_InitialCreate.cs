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
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDepartement = table.Column<int>(type: "int", nullable: false),
                    UserDepartementId = table.Column<int>(type: "int", nullable: true),
                    IdPoste = table.Column<int>(type: "int", nullable: false),
                    UserPostId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_MyUser_Poste_UserPostId",
                        column: x => x.UserPostId,
                        principalTable: "Poste",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courrier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    objet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdExpediteur = table.Column<int>(type: "int", nullable: false),
                    ExpediteurId = table.Column<int>(type: "int", nullable: true),
                    IdCreateur = table.Column<int>(type: "int", nullable: false),
                    CreateurId = table.Column<int>(type: "int", nullable: true),
                    IdPriorite = table.Column<int>(type: "int", nullable: false),
                    prioriteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courrier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courrier_MyUser_CreateurId",
                        column: x => x.CreateurId,
                        principalTable: "MyUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courrier_MyUser_ExpediteurId",
                        column: x => x.ExpediteurId,
                        principalTable: "MyUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courrier_Priorite_prioriteId",
                        column: x => x.prioriteId,
                        principalTable: "Priorite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Commentaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateCommentaire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCourrier = table.Column<int>(type: "int", nullable: false),
                    courrierId = table.Column<int>(type: "int", nullable: true),
                    IdCommentateur = table.Column<int>(type: "int", nullable: false),
                    commentateurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaire_Courrier_courrierId",
                        column: x => x.courrierId,
                        principalTable: "Courrier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commentaire_MyUser_commentateurId",
                        column: x => x.commentateurId,
                        principalTable: "MyUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Destinataire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTransmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateReceptionSecretaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateReceptionDirecteur = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDepartementDestinataire = table.Column<int>(type: "int", nullable: false),
                    departementDestinataireId = table.Column<int>(type: "int", nullable: true),
                    IdCourrier = table.Column<int>(type: "int", nullable: false),
                    courrierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinataire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinataire_Courrier_courrierId",
                        column: x => x.courrierId,
                        principalTable: "Courrier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Destinataire_Departement_departementDestinataireId",
                        column: x => x.departementDestinataireId,
                        principalTable: "Departement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FichierJoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCourrier = table.Column<int>(type: "int", nullable: false),
                    courrierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichierJoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichierJoint_Courrier_courrierId",
                        column: x => x.courrierId,
                        principalTable: "Courrier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_commentateurId",
                table: "Commentaire",
                column: "commentateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_courrierId",
                table: "Commentaire",
                column: "courrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_CreateurId",
                table: "Courrier",
                column: "CreateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_ExpediteurId",
                table: "Courrier",
                column: "ExpediteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_prioriteId",
                table: "Courrier",
                column: "prioriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinataire_courrierId",
                table: "Destinataire",
                column: "courrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinataire_departementDestinataireId",
                table: "Destinataire",
                column: "departementDestinataireId");

            migrationBuilder.CreateIndex(
                name: "IX_FichierJoint_courrierId",
                table: "FichierJoint",
                column: "courrierId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_UserDepartementId",
                table: "MyUser",
                column: "UserDepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_UserPostId",
                table: "MyUser",
                column: "UserPostId");
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
