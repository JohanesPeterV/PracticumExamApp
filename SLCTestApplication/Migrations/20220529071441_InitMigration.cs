using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLCTestApplication.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choices = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerIndex = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnswerString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => new { x.QuestionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestion",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestion", x => new { x.TestId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_TestQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestQuestion_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "Participant", "Test Participant" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b74ddd14-6340-4840-95c2-db12554543r5", 0, "fb7aa656-45b6-487d-a0c1-847e237f65b4", "st@gmail.com", true, false, null, "ST@GMAIL.COM", "ST@GMAIL.COM", "AQAAAAEAACcQAAAAEPWMRIIKwqCjs2Pcq8NGOx/yX61Flf4JqBpg8ymZOyCYxHhgvFhobPVdjoUhHDu9Qw==", "1234567890", false, "66d2388b-2b28-4058-9a69-1e67e009c79b", false, "st@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554823e9", 0, "a6b37de3-27a5-4017-8dd9-1f82ed9f0620", "ll@gmail.com", true, false, null, "LL@GMAIL.COM", "LL@GMAIL.COM", "AQAAAAEAACcQAAAAEBaZ+3Lr8zwxaoxOO1JWPah0RwrqUKpuISMFsiB9bcHC+cWGjxY6q5hk+qvvacqsBA==", "1234567890", false, "9f9f4fb2-3b28-439b-9308-5e8257121ee7", false, "ll@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554823f5", 0, "ac4bd003-6907-4bec-bdff-eec11c22afeb", "cc@gmail.com", true, false, null, "CC@GMAIL.COM", "CC@GMAIL.COM", "AQAAAAEAACcQAAAAEJZYpSPgYcKfVsMpl7wRHkHYSc90bKctNKIyzBvgiIlyZiJ3CxVysoA3b6k7eRvfZg==", "1234567890", false, "0dfb71ec-03cd-4687-9ca8-7c11343ea188", false, "cc@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554843a5", 0, "28491322-07a9-4791-9839-73116b265fa1", "vn@gmail.com", true, false, null, "VN@GMAIL.COM", "VN@GMAIL.COM", "AQAAAAEAACcQAAAAELglETgr7sz6xMxbYLv6GUMPMWB3C/dXHuJXPYp2H8ZBg4/lZzizxcWgW/Gk6NmSzw==", "1234567890", false, "f4ae600d-b4f8-4ff9-a59d-b61524d2d9e9", false, "vn@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554843e1", 0, "d92b317e-1a8e-4e10-9bb1-8f3454039de5", "jp@gmail.com", true, false, null, "JP@GMAIL.COM", "JP@GMAIL.COM", "AQAAAAEAACcQAAAAEOPU+d4B07+tkar/EAyT16QYgtyTarld7g7jpn4yL03tKE/yFma61xJbP3BzIHGtsw==", "1234567890", false, "07994a7e-00d8-47b6-8a1e-04a9578bf159", false, "jp@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554843e2", 0, "70e99d56-006c-4b6b-b7d0-0143068b4c9f", "ga@gmail.com", true, false, null, "GA@GMAIL.COM", "GA@GMAIL.COM", "AQAAAAEAACcQAAAAEKBstyBy//tLPRs5zpEymGFtZY/cZ+3yQtpISSDUjW57M0G3x3GcIeTGxkSminDwcw==", "1234567890", false, "166e07f7-aef6-423e-94b4-11169803d135", false, "ga@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "c8a00a08-9443-407a-8ff1-8e2889ba771b", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPckIexXkMN0wusZw+p3xr7m4QD9ru6N8nhMDKMcgvfb9Vm9DJL8zC4BMkcen4DPjA==", "1234567890", false, "b922726b-7dbd-48eb-b2bb-0b7093e33191", false, "admin@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12555413e5", 0, "8dc41c12-e38c-4f44-9d3c-301b1caaefb5", "br@gmail.com", true, false, null, "BR@GMAIL.COM", "BR@GMAIL.COM", "AQAAAAEAACcQAAAAEFlzmv4H7mC2O4rVAIQnCGFtuAhD1ritT1Z6XOz1liX76YQhJkenDpkb14N/iCFrWg==", "1234567890", false, "5bb4d4c4-76a2-476d-ae3e-5a4b2b2dc0a5", false, "br@gmail.com" },
                    { "b74ddd23-6340-4840-95c2-db12554843e5", 0, "b5334a4d-0151-4f5c-8abd-60f84f0b1b53", "tc@gmail.com", true, false, null, "TC@GMAIL.COM", "TC@GMAIL.COM", "AQAAAAEAACcQAAAAEMdSxnS+xv+SoPnDYGYENcPwfAvlG8QEDFIaFaZJbfD4EzYjL8yI40C2Sm89genojg==", "1234567890", false, "1719a78d-84f8-4c63-878e-c87881f1f0f4", false, "tc@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerIndex", "Body", "Choices", "QuestionType" },
                values: new object[,]
                {
                    { 1, null, "This is an essay.", null, "Essay" },
                    { 2, 1, "The answer is false.", "True`False", "TrueOrFalse" },
                    { 3, 6, "The Answer is choice number 6", "Choice 1`Choice 2`Choice 3`Choice 4`Choice 5`Choice 6`Choice 7`Choice 8`Choice 9", "ChooseOne" },
                    { 4, 3, "The answer is C.", "a. Answer A`b. Answer B`C. Answer C`d. Answer D", "MultipleChoice" },
                    { 5, null, "Upload a file.", null, "SubmitFile" },
                    { 6, 2, "The answer is true.", "True`False", "TrueOrFalse" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Description", "EndTime", "StartTime", "Title" },
                values: new object[] { 1, "Test to determine if u are worthy", new DateTime(2022, 5, 29, 14, 14, 41, 214, DateTimeKind.Local).AddTicks(9366), new DateTime(2022, 5, 29, 19, 14, 41, 214, DateTimeKind.Local).AddTicks(9323), "NAR Early Test" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "QuestionId", "UserId", "AnswerString" },
                values: new object[] { 2, "b74ddd14-6340-4840-95c2-db12554843e1", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12554543r5" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12554823e9" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12554823f5" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12554843a5" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12554843e1" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12554843e2" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12555413e5" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd23-6340-4840-95c2-db12554843e5" }
                });

            migrationBuilder.InsertData(
                table: "TestQuestion",
                columns: new[] { "QuestionId", "TestId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserId",
                table: "Answers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_QuestionId",
                table: "TestQuestion",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TestQuestion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
