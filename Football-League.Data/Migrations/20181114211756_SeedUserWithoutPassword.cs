using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_League.Data.Migrations
{
    public partial class SeedUserWithoutPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 17, 56, 362, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 17, 56, 364, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 17, 56, 364, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 17, 56, 364, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 17, 56, 364, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1e7ec08-1a1c-4246-91b8-c2ea1496f3d4", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2018, 11, 14, 21, 57, 5, 224, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2018, 11, 14, 21, 57, 5, 225, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2018, 11, 14, 21, 57, 5, 225, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2018, 11, 14, 21, 57, 5, 225, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2018, 11, 14, 21, 57, 5, 225, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e304d2ff-d757-4844-98c5-3eabf3f01f0c", "Asdf1234!" });
        }
    }
}
