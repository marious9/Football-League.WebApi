using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_League.Data.Migrations
{
    public partial class SeededPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2018, 11, 16, 21, 2, 47, 196, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2018, 11, 16, 21, 2, 47, 198, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2018, 11, 16, 21, 2, 47, 198, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2018, 11, 16, 21, 2, 47, 198, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2018, 11, 16, 21, 2, 47, 198, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "Firstname", "Lastname", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariusz", "Kaniecki", 11 },
                    { 2, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damian", "Kwiecień", 11 },
                    { 3, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maciej", "Wasiłowski", 11 },
                    { 4, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dawid", "Duchna", 11 },
                    { 5, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szymon", "Jabłonowski", 11 },
                    { 6, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman", "Kurkiewicz", 11 },
                    { 7, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maciej", "Golubiński", 11 },
                    { 8, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krystian", "Czechowski", 11 },
                    { 9, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patryk", "Rutkowski", 11 },
                    { 10, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piotr", "Czaplicki", 11 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio",
                column: "ConcurrencyStamp",
                value: "b35ad38b-345a-4ba5-988b-a8ad9c0d372b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 42, 9, 140, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 42, 9, 141, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 42, 9, 141, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 42, 9, 141, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2018, 11, 14, 22, 42, 9, 141, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio",
                column: "ConcurrencyStamp",
                value: "8dd1f172-e07e-4511-ab52-ef0aebf17aae");
        }
    }
}
