using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Applicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyJobs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    JobId = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    ApplicantId = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_Users_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_ApplicantId",
                table: "ApplyJobs",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobId",
                table: "ApplyJobs",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyJobs");
        }
    }
}
