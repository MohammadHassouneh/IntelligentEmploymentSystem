using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentEmploymentSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    companyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    aboutUs = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ourService = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    webSite = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.companyId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "JobDescription",
                columns: table => new
                {
                    jobDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    jobBrief = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    responsibilities = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    requirements = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescription", x => x.jobDescriptionId);
                    table.ForeignKey(
                        name: "FK_JobDescription_Company",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId");
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    resumeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    experience = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    education = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    skills = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    summary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    picPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.resumeId);
                    table.ForeignKey(
                        name: "FK_Resume_User1",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    scoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    score = table.Column<int>(type: "int", nullable: false),
                    resumeId = table.Column<int>(type: "int", nullable: false),
                    jobDescriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.scoreId);
                    table.ForeignKey(
                        name: "FK_Score_JobDescription",
                        column: x => x.jobDescriptionId,
                        principalTable: "JobDescription",
                        principalColumn: "jobDescriptionId");
                    table.ForeignKey(
                        name: "FK_Score_Resume",
                        column: x => x.resumeId,
                        principalTable: "Resume",
                        principalColumn: "resumeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobDescription_companyId",
                table: "JobDescription",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_userId",
                table: "Resume",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_jobDescriptionId",
                table: "Score",
                column: "jobDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_resumeId",
                table: "Score",
                column: "resumeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "JobDescription");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
