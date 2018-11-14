using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_League.Data.Migrations
{
    public partial class SeededAlsoMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayId", "AwayScore", "Date", "HostId", "HostScore", "LeagueId", "Round" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2018, 11, 14, 21, 57, 5, 224, DateTimeKind.Local), 11, 7, 1, 1 },
                    { 2, 10, 4, new DateTime(2018, 11, 14, 21, 57, 5, 225, DateTimeKind.Local), 3, 1, 1, 1 },
                    { 3, 9, 3, new DateTime(2018, 11, 14, 21, 57, 5, 225, DateTimeKind.Local), 4, 2, 1, 1 },
                    { 4, 8, 3, new DateTime(2018, 11, 14, 21, 57, 5, 225, DateTimeKind.Local), 5, 3, 1, 1 },
                    { 5, 7, 8, new DateTime(2018, 11, 14, 21, 57, 5, 225, DateTimeKind.Local), 6, 1, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio",
                column: "ConcurrencyStamp",
                value: "e304d2ff-d757-4844-98c5-3eabf3f01f0c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio",
                column: "ConcurrencyStamp",
                value: "74f76a01-df93-40ac-9ec3-04a93e4f449a");
        }
    }
}
