using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_League.Data.Migrations
{
    public partial class AddedHostAndAwayFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_TeamId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Matches",
                newName: "HostId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TeamId",
                table: "Matches",
                newName: "IX_Matches_HostId");

            migrationBuilder.AddColumn<int>(
                name: "AwayId",
                table: "Matches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayId",
                table: "Matches",
                column: "AwayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_AwayId",
                table: "Matches",
                column: "AwayId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_HostId",
                table: "Matches",
                column: "HostId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_AwayId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_HostId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AwayId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "Matches",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_HostId",
                table: "Matches",
                newName: "IX_Matches_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_TeamId",
                table: "Matches",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
