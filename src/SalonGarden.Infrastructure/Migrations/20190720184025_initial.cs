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
                name: "EvaluationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationStatuses", x => x.Id);
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
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    TechniqueTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechniqueTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniqueTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    SequenceNumber = table.Column<int>(nullable: false),
                    EvaluationCriteriaGroupId = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_EvaluationCriteriaGroups_EvaluationCriteriaGroupId",
                        column: x => x.EvaluationCriteriaGroupId,
                        principalTable: "EvaluationCriteriaGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Evaluations_EvaluationStatuses_EvaluationStatusId",
                        column: x => x.EvaluationStatusId,
                        principalTable: "EvaluationStatuses",
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

            migrationBuilder.InsertData(
                table: "EvaluationCriteriaGroups",
                columns: new[] { "Id", "Description", "SequenceNumber" },
                values: new object[] { 1, "Greeting", 1 });

            migrationBuilder.InsertData(
                table: "EvaluationCriteriaGroups",
                columns: new[] { "Id", "Description", "SequenceNumber" },
                values: new object[] { 2, "Consultation", 2 });

            migrationBuilder.InsertData(
                table: "EvaluationCriteriaGroups",
                columns: new[] { "Id", "Description", "SequenceNumber" },
                values: new object[] { 3, "Technical", 3 });

            migrationBuilder.InsertData(
                table: "EvaluationCriteriaGroups",
                columns: new[] { "Id", "Description", "SequenceNumber" },
                values: new object[] { 4, "Professionalism", 4 });

            migrationBuilder.InsertData(
                table: "EvaluationCriteriaGroups",
                columns: new[] { "Id", "Description", "SequenceNumber" },
                values: new object[] { 5, "Styling", 5 });

            migrationBuilder.InsertData(
                table: "EvaluationStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "EvaluationStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Closed" });

            migrationBuilder.InsertData(
                table: "TechniqueTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Color" });

            migrationBuilder.InsertData(
                table: "TechniqueTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Cut" });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 3, "Double Process", 1 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 1, "Vertical Foil", 1 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 5, "Scissor Over Comb", 2 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 6, "Clipper Cut", 2 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 7, "Horizontal Graduation", 2 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 8, "Vertical Graduation", 2 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 9, "Triangular graduation", 2 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 10, "Short Graduation", 2 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 11, "Short Round Layer", 2 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 12, "Long Layer", 2 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 2, "Diagonal Foil", 1 });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Description", "TechniqueTypeId" },
                values: new object[] { 4, "Single Process", 1 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 1, "Warm Welcome", 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 19, "Sectioning", 5, 2, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 18, "Explanation of Products", 5, 1, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 17, "Ask for Referrals/Rebooks", 4, 3, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 16, "Personal Appearance", 4, 2, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 15, "Appropriate Conversation", 4, 1, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 14, "Completed On Time", 3, 7, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 13, "Cross Check/Balance", 3, 6, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 12, "Control", 3, 5, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 20, "Control of Hair", 5, 3, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 11, "Knowledge of Technique", 3, 4, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 9, "Clean Sections", 3, 2, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 8, "Shampoo/Massage/Cleanup", 3, 1, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 7, "Review/Agreement", 2, 5, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 6, "Maintenance/Product Reccomendations", 2, 4, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 5, "Appropriate Questions", 2, 3, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 4, "Listening Skills", 2, 2, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 3, "Sensory Experience", 2, 1, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 2, "Introduction", 1, 2, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 10, "Body Position", 3, 3, 0 });

            migrationBuilder.InsertData(
                table: "EvaluationCriterias",
                columns: new[] { "Id", "Description", "EvaluationCriteriaGroupId", "SequenceNumber", "TotalPoints" },
                values: new object[] { 21, "Teach Guest How to Recreate", 5, 4, 0 });

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
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "TechniqueTypes");

            migrationBuilder.DropTable(
                name: "EvaluationCriteriaGroups");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "EvaluationStatuses");

            migrationBuilder.DropTable(
                name: "EvaluationType");
        }
    }
}
