using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonGarden.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationCriteriaGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    SequenceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriteriaGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    SequenceNumber = table.Column<int>(nullable: false),
                    EvaluationCriterionGroupId = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false),
                    EvaluationCriteriaGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_EvaluationCriteriaGroups_EvaluationCriteriaGroupId",
                        column: x => x.EvaluationCriteriaGroupId,
                        principalTable: "EvaluationCriteriaGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EvaluationTypeId = table.Column<int>(nullable: false),
                    EvaluationStatusId = table.Column<int>(nullable: false),
                    TechniqueId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EducatorId = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_EvaluationStatus_EvaluationStatusId",
                        column: x => x.EvaluationStatusId,
                        principalTable: "EvaluationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_EvaluationType_EvaluationTypeId",
                        column: x => x.EvaluationTypeId,
                        principalTable: "EvaluationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationDetailItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EvaluationId = table.Column<int>(nullable: false),
                    EvaluationCriteriaId = table.Column<int>(nullable: false),
                    AllocatedPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationDetailItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationDetailItem_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriterias_EvaluationCriteriaGroupId",
                table: "EvaluationCriterias",
                column: "EvaluationCriteriaGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationDetailItem_EvaluationId",
                table: "EvaluationDetailItem",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_EvaluationStatusId",
                table: "Evaluations",
                column: "EvaluationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_EvaluationTypeId",
                table: "Evaluations",
                column: "EvaluationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationCriterias");

            migrationBuilder.DropTable(
                name: "EvaluationDetailItem");

            migrationBuilder.DropTable(
                name: "EvaluationCriteriaGroups");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "EvaluationStatus");

            migrationBuilder.DropTable(
                name: "EvaluationType");
        }
    }
}
