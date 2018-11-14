using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_League.Data.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "masensio", 0, "74f76a01-df93-40ac-9ec3-04a93e4f449a", "marco@asensio.pl", false, "Marco", "Asensio", false, null, null, null, "Asdf1234!", null, false, null, false, "marcoAsensio" });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Name", "Quantity", "UserId" },
                values: new object[] { 1, "II NHLPN", 11, "masensio" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LeagueId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "KTS Smolany" },
                    { 2, 1, "YoungBoys" },
                    { 3, 1, "RenegaciFC" },
                    { 4, 1, "Apotex" },
                    { 5, 1, "Źródlani Łyna" },
                    { 6, 1, "Młode Orły" },
                    { 7, 1, "Żelazno" },
                    { 8, 1, "Kram Nidzica" },
                    { 9, 1, "Polonia Muszaki" },
                    { 10, 1, "Skorpion Napiwoda" },
                    { 11, 1, "Zatorze" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio");
        }
    }
}
