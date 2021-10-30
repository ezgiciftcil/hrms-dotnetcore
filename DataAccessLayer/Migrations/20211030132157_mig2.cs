using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Users_JobSeekerUserId",
                table: "CVs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_Users_EmployerUserId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_JobAdvertisements_EmployerUserId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_CVs_JobSeekerUserId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyWebsite",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployerUserId",
                table: "JobAdvertisements");

            migrationBuilder.DropColumn(
                name: "JobSeekerUserId",
                table: "CVs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebsite",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Users",
                type: "int",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployerUserId",
                table: "JobAdvertisements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobSeekerUserId",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisements_EmployerUserId",
                table: "JobAdvertisements",
                column: "EmployerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_JobSeekerUserId",
                table: "CVs",
                column: "JobSeekerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Users_JobSeekerUserId",
                table: "CVs",
                column: "JobSeekerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_Users_EmployerUserId",
                table: "JobAdvertisements",
                column: "EmployerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
