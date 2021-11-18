using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class jobmig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployerUserId",
                table: "JobAdvertisements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisements_CityId",
                table: "JobAdvertisements",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisements_EmployerUserId",
                table: "JobAdvertisements",
                column: "EmployerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisements_JobTitleId",
                table: "JobAdvertisements",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_Cities_CityId",
                table: "JobAdvertisements",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_JobTitles_JobTitleId",
                table: "JobAdvertisements",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_Users_EmployerUserId",
                table: "JobAdvertisements",
                column: "EmployerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_Cities_CityId",
                table: "JobAdvertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_JobTitles_JobTitleId",
                table: "JobAdvertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_Users_EmployerUserId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_JobAdvertisements_CityId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_JobAdvertisements_EmployerUserId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_JobAdvertisements_JobTitleId",
                table: "JobAdvertisements");

            migrationBuilder.DropColumn(
                name: "EmployerUserId",
                table: "JobAdvertisements");
        }
    }
}
