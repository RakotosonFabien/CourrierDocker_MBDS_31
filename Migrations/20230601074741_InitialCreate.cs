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
                    UserDepartementID = table.Column<int>(type: "int", nullable: false),
                    UserPosteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyUser_Departement_UserDepartementID",
                        column: x => x.UserDepartementID,
                        principalTable: "Departement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyUser_Poste_UserPosteID",
                        column: x => x.UserPosteID,
                        principalTable: "Poste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ExpediteurID = table.Column<int>(type: "int", nullable: false),
                    CreateurID = table.Column<int>(type: "int", nullable: false),
                    CoursierID = table.Column<int>(type: "int", nullable: false),
                    PrioriteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courrier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courrier_MyUser_CoursierID",
                        column: x => x.CoursierID,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courrier_MyUser_CreateurID",
                        column: x => x.CreateurID,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courrier_MyUser_ExpediteurID",
                        column: x => x.ExpediteurID,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courrier_Priorite_PrioriteID",
                        column: x => x.PrioriteID,
                        principalTable: "Priorite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commentaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCommentaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourrierID = table.Column<int>(type: "int", nullable: false),
                    CommentateurID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaire_Courrier_CourrierID",
                        column: x => x.CourrierID,
                        principalTable: "Courrier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaire_MyUser_CommentateurID",
                        column: x => x.CommentateurID,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    DepDestID = table.Column<int>(type: "int", nullable: false),
                    CourrierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinataire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinataire_Courrier_CourrierID",
                        column: x => x.CourrierID,
                        principalTable: "Courrier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Destinataire_Departement_DepDestID",
                        column: x => x.DepDestID,
                        principalTable: "Departement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_CommentateurID",
                table: "Commentaire",
                column: "CommentateurID");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_CourrierID",
                table: "Commentaire",
                column: "CourrierID");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_CoursierID",
                table: "Courrier",
                column: "CoursierID");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_CreateurID",
                table: "Courrier",
                column: "CreateurID");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_ExpediteurID",
                table: "Courrier",
                column: "ExpediteurID");

            migrationBuilder.CreateIndex(
                name: "IX_Courrier_PrioriteID",
                table: "Courrier",
                column: "PrioriteID");

            migrationBuilder.CreateIndex(
                name: "IX_Destinataire_CourrierID",
                table: "Destinataire",
                column: "CourrierID");

            migrationBuilder.CreateIndex(
                name: "IX_Destinataire_DepDestID",
                table: "Destinataire",
                column: "DepDestID");

            migrationBuilder.CreateIndex(
                name: "IX_FichierJoint_CourrierId",
                table: "FichierJoint",
                column: "CourrierId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_UserDepartementID",
                table: "MyUser",
                column: "UserDepartementID");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_UserPosteID",
                table: "MyUser",
                column: "UserPosteID");
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
