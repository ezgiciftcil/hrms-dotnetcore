using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class jobmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_Cities_CityId",
                table: "JobAdvertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_JobTitles_JobTitleId",
                table: "JobAdvertisements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "JobAdvertisements");

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleId",
                table: "JobAdvertisements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "JobAdvertisements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_Cities_CityId",
                table: "JobAdvertisements",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_JobTitles_JobTitleId",
                table: "JobAdvertisements",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId",
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

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleId",
                table: "JobAdvertisements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "JobAdvertisements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "JobAdvertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
