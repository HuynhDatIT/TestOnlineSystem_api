using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatHT8_Mini_project_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnlyAnswer = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDay = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 14, 22, 13, 9, 392, DateTimeKind.Local).AddTicks(6948)),
                    Minute = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MaxScores = table.Column<long>(type: "bigint", nullable: false, defaultValue: 10L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Istrue = table.Column<bool>(type: "bit", nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scores = table.Column<int>(type: "int", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAccounts_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "ContentQuestion", "PathImage" },
                values: new object[,]
                {
                    { 1, "1 + 1", "" },
                    { 2, "1 + 2", "" },
                    { 3, "1 + 3", "" },
                    { 4, "1 + 4", "" },
                    { 5, "em + anh", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "teacher" },
                    { 3, "student" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Minute", "Title" },
                values: new object[,]
                {
                    { 1, 100m, "Final C#" },
                    { 2, 100m, "Final Sql" },
                    { 3, 100m, "Final Web Api" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Fullname", "Password", "RoleId", "Username" },
                values: new object[] { 5, "Hoc sinh C", "e10adc3949ba59abbe56e057f20f883e", 3, "studentC" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Fullname", "IsActive", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 4, "Hoc sinh B", true, "e10adc3949ba59abbe56e057f20f883e", 3, "studentB" },
                    { 3, "Hoc sinh A", true, "e10adc3949ba59abbe56e057f20f883e", 3, "studentA" },
                    { 2, "Giao vien A", true, "e10adc3949ba59abbe56e057f20f883e", 2, "teacherA" },
                    { 1, "Huynh Tan Dat", true, "e10adc3949ba59abbe56e057f20f883e", 1, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "ContentAnswer", "Istrue", "PathImage", "QuestionId" },
                values: new object[,]
                {
                    { 1, "1", false, "", 1 },
                    { 18, "0", true, "", 5 },
                    { 16, "5", true, "", 4 },
                    { 15, "3", false, "", 4 },
                    { 14, "2", false, "", 4 },
                    { 13, "1", false, "", 4 },
                    { 17, "1", true, "", 5 },
                    { 11, "3", false, "", 3 },
                    { 12, "4", true, "", 3 },
                    { 3, "3", false, "", 1 },
                    { 4, "4", false, "", 1 },
                    { 5, "1", false, "", 2 },
                    { 6, "2", false, "", 2 },
                    { 2, "2", true, "", 1 },
                    { 8, "4", false, "", 2 },
                    { 9, "1", false, "", 3 },
                    { 10, "2", false, "", 3 },
                    { 7, "3", true, "", 2 }
                });

            migrationBuilder.InsertData(
                table: "TestQuestions",
                columns: new[] { "Id", "QuestionId", "TestId" },
                values: new object[,]
                {
                    { 10, 5, 3 },
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 1, 2 },
                    { 7, 5, 2 },
                    { 8, 3, 2 },
                    { 9, 2, 3 },
                    { 11, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TestAccounts",
                columns: new[] { "Id", "AccountId", "IsComplete", "Scores", "TestId" },
                values: new object[,]
                {
                    { 1, 3, true, 10, 1 },
                    { 2, 3, true, 9, 2 },
                    { 3, 4, true, 5, 1 },
                    { 4, 4, false, 0, 3 },
                    { 5, 4, true, 8, 1 },
                    { 6, 5, true, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAccounts_AccountId",
                table: "TestAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAccounts_TestId",
                table: "TestAccounts",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_QuestionId",
                table: "TestQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TestId",
                table: "TestQuestions",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "TestAccounts");

            migrationBuilder.DropTable(
                name: "TestQuestions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
