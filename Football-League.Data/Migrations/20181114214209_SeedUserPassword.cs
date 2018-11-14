using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_League.Data.Migrations
{
    public partial class SeedUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8dd1f172-e07e-4511-ab52-ef0aebf17aae", "AQAAAAEAACcQAAAAEMnz1mM3f8mrMN3n/5aPSdB0gRFQd2+GEr6/+WfptLdU+frBA3DjqB9V+FwubO5TTg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
