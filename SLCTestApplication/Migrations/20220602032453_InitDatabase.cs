using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLCTestApplication.Migrations
{
    public partial class InitDatabase : Migration
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
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
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
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    AnswerString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => new { x.QuestionId, x.UserId, x.ScheduleId });
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
                    table.ForeignKey(
                        name: "FK_Answers_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleQuestions", x => new { x.ScheduleId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_ScheduleQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleQuestions_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "5a4df4c9-d4a1-4d7b-8ce3-e039263ee4d4", "Participant", "PARTICIPANT" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "cff8b0b4-d86f-4457-a813-b552ad43c959", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b74ddd14-6340-4840-95c2-db12554543r5", 0, "742dbf6a-d682-4060-9516-57c2d4c89ec8", "st@gmail.com", true, false, null, "ST@GMAIL.COM", "ST@GMAIL.COM", "AQAAAAEAACcQAAAAEBmUDZ0vKMIj9KjAEdYyccfWyAJhapRioNFl7kQT5b/huUIwAd9qcbxKTr0/NedU4Q==", "1234567890", false, "5bac4e16-f0bd-4ec0-82ab-8240796930e4", false, "st@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554823e9", 0, "24c2ac4c-3b62-441d-8932-0c0789f599c1", "ll@gmail.com", true, false, null, "LL@GMAIL.COM", "LL@GMAIL.COM", "AQAAAAEAACcQAAAAENuqnAVGGROxhfO46YyvVsyeZW6aRX0Aea/t+n8vl4KZ5cdaHnBoxWsmT4y1tFrBjA==", "1234567890", false, "5729e30d-cd92-49ad-adad-75d66b589da9", false, "ll@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554823f5", 0, "bae9ea84-b329-4fdf-8770-96161dd05a10", "cc@gmail.com", true, false, null, "CC@GMAIL.COM", "CC@GMAIL.COM", "AQAAAAEAACcQAAAAEDSx17o2YVuVL8AHrVrSqPxFsdXaJGL8+E0pRE3NDdJ7mh66E0Lve0rl/WM2VYwgXw==", "1234567890", false, "5434b527-6510-4893-978f-b266a3957768", false, "cc@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554843a5", 0, "3ad3ae0d-f193-4632-a3f9-1d9415e314d1", "vn@gmail.com", true, false, null, "VN@GMAIL.COM", "VN@GMAIL.COM", "AQAAAAEAACcQAAAAEBKU4+NNH40dUogytT/iy2VXFfN58l0454Gv8e7f5PdY9kL6k+wnNpCKzzCFlIdr0A==", "1234567890", false, "73ebf81b-2c91-4215-93a7-ad89a5ec6a76", false, "vn@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554843e1", 0, "3822de9e-7401-4061-af6c-e40859282ad9", "jp@gmail.com", true, false, null, "JP@GMAIL.COM", "JP@GMAIL.COM", "AQAAAAEAACcQAAAAEJkRNjbTd8eWi4A5KfasuB6IaBtZ/4e5Q2To3iVNWVRnoYGeHOpMItVsIzrnvdScag==", "1234567890", false, "95d1e978-a739-41ac-acde-a6c26f4916ad", false, "jp@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554843e2", 0, "70772739-31cd-4a21-8c44-3475ecab2069", "ga@gmail.com", true, false, null, "GA@GMAIL.COM", "GA@GMAIL.COM", "AQAAAAEAACcQAAAAEDh6pjYIadBTpwqJtmxSDaxYmyO2V6/oi8Midhj+QVJDxtUkISHLJjZHgBQNtg56jA==", "1234567890", false, "fa9dee45-97cd-4874-995b-45d2b12aa6c5", false, "ga@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "a9135649-6365-447a-9b2e-554e6a2a8a2d", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELfGUrQP2dJGIGxdT2Rwzz8xE2Bc1PrmIP5icxh5ZiBR8tx/eyVuslcWs1YTiZKkfg==", "1234567890", false, "8e32ee57-d0fb-4295-98a1-71afbbdd3f48", false, "admin@gmail.com" },
                    { "b74ddd14-6340-4840-95c2-db12555413e5", 0, "92c643d0-16aa-4ffd-80ab-2c5407ac4848", "br@gmail.com", true, false, null, "BR@GMAIL.COM", "BR@GMAIL.COM", "AQAAAAEAACcQAAAAEPwmRgTgUUJA11kJeCGXnP129gzElUX2SC/w5boivG3HAI8KaKgNqE9zwP4cekutRQ==", "1234567890", false, "316fa90e-1d48-4ce4-8d64-cfb7c9fc2460", false, "br@gmail.com" },
                    { "b74ddd23-6340-4840-95c2-db12554843e5", 0, "f16cdc17-ebf6-462f-8eb4-3aed6e203378", "tc@gmail.com", true, false, null, "TC@GMAIL.COM", "TC@GMAIL.COM", "AQAAAAEAACcQAAAAEPEe201DSM56hW8Gpnxh3LLWIILf+h9RjV3p7RVYURC851mTNvWRFervcnK/Dnruzg==", "1234567890", false, "b61049e6-757f-4409-834b-5b43f3dac748", false, "tc@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerIndex", "Body", "Choices", "QuestionType" },
                values: new object[,]
                {
                    { 1, null, "This is an essay.", null, "Essay" },
                    { 2, 1, "The answer is false.", "True`False", "TrueOrFalse" },
                    { 3, 6, "The Answer is choice number 6", "Choice 1`Choice 2`Choice 3`Choice 4`Choice 5`Choice 6", "ChooseOne" },
                    { 4, 3, "The answer is C.", "a. Answer A`b. Answer B`C. Answer C`d. Answer D", "MultipleChoice" },
                    { 5, null, "Upload a file.", null, "SubmitFile" },
                    { 6, 2, "The answer is true.", "True`False", "TrueOrFalse" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Description", "EndTime", "StartTime", "Title" },
                values: new object[] { 1, "Schedule to determine if u are worthy", new DateTime(2022, 6, 2, 10, 24, 53, 646, DateTimeKind.Local).AddTicks(6520), new DateTime(2022, 6, 2, 15, 24, 53, 646, DateTimeKind.Local).AddTicks(6476), "NAR Early Schedule" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "QuestionId", "ScheduleId", "UserId", "AnswerString" },
                values: new object[,]
                {
                    { 1, 1, "b74ddd14-6340-4840-95c2-db12554843e1", "1" },
                    { 2, 1, "b74ddd14-6340-4840-95c2-db12554843e1", "1" },
                    { 3, 1, "b74ddd14-6340-4840-95c2-db12554843e1", "1" }
                });

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
                table: "ScheduleQuestions",
                columns: new[] { "QuestionId", "ScheduleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ScheduleId",
                table: "Answers",
                column: "ScheduleId");

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
                name: "IX_ScheduleQuestions_QuestionId",
                table: "ScheduleQuestions",
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
                name: "ScheduleQuestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
