using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football_League.Data.Migrations
{
    public partial class SeedPlayersForTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Statistics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "Firstname", "Lastname", "TeamId" },
                values: new object[,]
                {
                    { 11, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristiano", "Ronaldo", 1 },
                    { 83, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiago", "Silva", 8 },
                    { 82, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Presnel", "Kimpembe", 8 },
                    { 81, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gianluigi", "Buffon", 8 },
                    { 80, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naby", "Keïta", 7 },
                    { 79, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", "Firmino", 7 },
                    { 78, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohamed", "Salah", 7 },
                    { 77, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sadio", "Mané", 7 },
                    { 76, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan", "Henderson", 7 },
                    { 75, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trent", "Alexander-Arnold", 7 },
                    { 74, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew", "Robertson", 7 },
                    { 73, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dejan", "Lovren", 7 },
                    { 72, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virgil", "van Dijk", 7 },
                    { 71, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alisson", "", 7 },
                    { 70, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romelu", "Lukaku", 6 },
                    { 69, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexis", "Sánchez", 6 },
                    { 68, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony", "Martial", 6 },
                    { 67, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Mata", 6 },
                    { 66, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul", "Pogba", 6 },
                    { 65, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonio", "Valencia", 6 },
                    { 64, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luke", "Shaw", 6 },
                    { 63, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "Smalling", 6 },
                    { 84, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Layvin", "Kurzawa", 8 },
                    { 85, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas", "Meunier", 8 },
                    { 86, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marco", "Verratti", 8 },
                    { 87, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrien", "Rabiot", 8 },
                    { 109, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dries", "Mertens", 10 },
                    { 108, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arkadiusz", "Milik", 10 },
                    { 107, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piotr", "Zieliński", 10 },
                    { 106, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allan", "", 10 },
                    { 105, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elseid", "Hysaj", 10 },
                    { 104, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faouzi", "Ghoulam", 10 },
                    { 103, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raúl", "Albiol", 10 },
                    { 102, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalidou", "Koulibaly", 10 },
                    { 101, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Ospina", 10 },
                    { 100, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry", "Kane", 9 },
                    { 62, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric", "Bailly", 6 },
                    { 99, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", "Moura", 9 },
                    { 97, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christian", "Eriksen", 9 },
                    { 96, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dele", "Alli", 9 },
                    { 95, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ben", "Davies", 9 },
                    { 94, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kieran", "Trippier", 9 },
                    { 93, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davinson", "Sánchez", 9 },
                    { 92, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toby", "Alderweireld", 9 },
                    { 91, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hugo", "Lloris", 9 },
                    { 90, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edinson", "Cavani", 8 },
                    { 89, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kylian", "Mbappé", 8 },
                    { 88, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neymar", "", 8 },
                    { 98, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heung-min", "Son", 9 },
                    { 110, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorenzo", "Insigne", 10 },
                    { 61, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "De Gea", 6 },
                    { 59, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leroy", "Sané", 5 },
                    { 32, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel", "Umtiti", 3 },
                    { 31, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marc-André", "ter Stegen", 3 },
                    { 30, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karim", "Benzema", 2 },
                    { 29, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gareth", "Bale", 2 },
                    { 28, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marco", "Asensio", 2 },
                    { 27, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luca", "Modrić", 2 },
                    { 26, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toni", "Kroos", 2 },
                    { 25, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcelo", "", 2 },
                    { 24, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Carvajal", 2 },
                    { 23, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergio", "Ramos", 2 },
                    { 22, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raphaël", "Varane", 2 },
                    { 21, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thibaut", "Courtois", 2 },
                    { 20, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sami", "Khedira", 1 },
                    { 19, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "Sandro", 1 },
                    { 18, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo", "Bonucci", 1 },
                    { 17, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miralem", "Pjanić", 1 },
                    { 16, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Cuadrado", 1 },
                    { 15, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "João", "Cancelo", 1 },
                    { 14, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giorgio", "Chiellini", 1 },
                    { 13, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wojciech", "Szczęsny", 1 },
                    { 12, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paulo", "Dybala", 1 },
                    { 33, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gerard", "Piqué", 3 },
                    { 34, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordi", "Alba", 3 },
                    { 35, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nélson", "Semedo", 3 },
                    { 36, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergio", "Busquets", 3 },
                    { 58, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Silva", 5 },
                    { 57, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", "De Bruyne", 5 },
                    { 56, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ilkay", "Gündogan", 5 },
                    { 55, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyle", "Walker", 5 },
                    { 54, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benjamin", "Mendy", 5 },
                    { 53, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vincent", "Kompany", 5 },
                    { 52, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicolás", "Otamendi", 5 },
                    { 51, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ederson", "", 5 },
                    { 50, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "Lewandowski", 4 },
                    { 49, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas", "Müller", 4 },
                    { 60, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergio", "Agüero", 5 },
                    { 48, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Rodriguez", 4 },
                    { 46, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arjen", "Robben", 4 },
                    { 45, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joshua", "Kimmich", 4 },
                    { 44, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Alaba", 4 },
                    { 43, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jérôme", "Boateng", 4 },
                    { 42, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mats", "Hummels", 4 },
                    { 41, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manuel", "Neuer", 4 },
                    { 40, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis", "Suárez", 3 },
                    { 39, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lionel", "Messi", 3 },
                    { 38, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippe", "Coutinho", 3 },
                    { 37, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "Rakitic", 3 },
                    { 47, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leon", "Goretzka", 4 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio",
                column: "ConcurrencyStamp",
                value: "4c017e16-b22d-48e0-8a0c-ec10d40dfc0e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Statistics",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayId", "AwayScore", "Date", "HostId", "HostScore", "LeagueId", "Round" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2018, 11, 16, 21, 2, 47, 196, DateTimeKind.Local), 11, 7, 1, 1 },
                    { 2, 10, 4, new DateTime(2018, 11, 16, 21, 2, 47, 198, DateTimeKind.Local), 3, 1, 1, 1 },
                    { 3, 9, 3, new DateTime(2018, 11, 16, 21, 2, 47, 198, DateTimeKind.Local), 4, 2, 1, 1 },
                    { 4, 8, 3, new DateTime(2018, 11, 16, 21, 2, 47, 198, DateTimeKind.Local), 5, 3, 1, 1 },
                    { 5, 7, 8, new DateTime(2018, 11, 16, 21, 2, 47, 198, DateTimeKind.Local), 6, 1, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "masensio",
                column: "ConcurrencyStamp",
                value: "b35ad38b-345a-4ba5-988b-a8ad9c0d372b");
        }
    }
}
