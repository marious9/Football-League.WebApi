﻿// <auto-generated />
using System;
using Football_League.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Football_League.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Football_League.Models.Domain.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Leagues");

                    b.HasData(
                        new { Id = 1, Name = "II NHLPN", Quantity = 11, UserId = "masensio" }
                    );
                });

            modelBuilder.Entity("Football_League.Models.Domain.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AwayId");

                    b.Property<int>("AwayScore");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("HostId");

                    b.Property<int>("HostScore");

                    b.Property<int?>("LeagueId");

                    b.Property<int>("Round");

                    b.HasKey("Id");

                    b.HasIndex("AwayId");

                    b.HasIndex("HostId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Football_League.Models.Domain.MatchPlayer", b =>
                {
                    b.Property<int>("MatchId");

                    b.Property<int>("PlayerId");

                    b.Property<int>("DescentMinute");

                    b.Property<int>("EntryMinute");

                    b.HasKey("MatchId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("MatchPlayers");
                });

            modelBuilder.Entity("Football_League.Models.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new { Id = 1, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Mariusz", Lastname = "Kaniecki", TeamId = 11 },
                        new { Id = 2, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Damian", Lastname = "Kwiecień", TeamId = 11 },
                        new { Id = 3, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Maciej", Lastname = "Wasiłowski", TeamId = 11 },
                        new { Id = 4, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Dawid", Lastname = "Duchna", TeamId = 11 },
                        new { Id = 5, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Szymon", Lastname = "Jabłonowski", TeamId = 11 },
                        new { Id = 6, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Batman", Lastname = "Kurkiewicz", TeamId = 11 },
                        new { Id = 7, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Maciej", Lastname = "Golubiński", TeamId = 11 },
                        new { Id = 8, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Krystian", Lastname = "Czechowski", TeamId = 11 },
                        new { Id = 9, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Patryk", Lastname = "Rutkowski", TeamId = 11 },
                        new { Id = 10, BirthDate = new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Piotr", Lastname = "Czaplicki", TeamId = 11 },
                        new { Id = 11, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Cristiano", Lastname = "Ronaldo", TeamId = 1 },
                        new { Id = 12, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Paulo", Lastname = "Dybala", TeamId = 1 },
                        new { Id = 13, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Wojciech", Lastname = "Szczęsny", TeamId = 1 },
                        new { Id = 14, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Giorgio", Lastname = "Chiellini", TeamId = 1 },
                        new { Id = 15, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "João", Lastname = "Cancelo", TeamId = 1 },
                        new { Id = 16, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Juan", Lastname = "Cuadrado", TeamId = 1 },
                        new { Id = 17, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Miralem", Lastname = "Pjanić", TeamId = 1 },
                        new { Id = 18, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Leonardo", Lastname = "Bonucci", TeamId = 1 },
                        new { Id = 19, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Alex", Lastname = "Sandro", TeamId = 1 },
                        new { Id = 20, BirthDate = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Sami", Lastname = "Khedira", TeamId = 1 },
                        new { Id = 21, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Thibaut", Lastname = "Courtois", TeamId = 2 },
                        new { Id = 22, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Raphaël", Lastname = "Varane", TeamId = 2 },
                        new { Id = 23, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Sergio", Lastname = "Ramos", TeamId = 2 },
                        new { Id = 24, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Daniel", Lastname = "Carvajal", TeamId = 2 },
                        new { Id = 25, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Marcelo", Lastname = "", TeamId = 2 },
                        new { Id = 26, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Toni", Lastname = "Kroos", TeamId = 2 },
                        new { Id = 27, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Luca", Lastname = "Modrić", TeamId = 2 },
                        new { Id = 28, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Marco", Lastname = "Asensio", TeamId = 2 },
                        new { Id = 29, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Gareth", Lastname = "Bale", TeamId = 2 },
                        new { Id = 30, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Karim", Lastname = "Benzema", TeamId = 2 },
                        new { Id = 31, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Marc-André", Lastname = "ter Stegen", TeamId = 3 },
                        new { Id = 32, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Samuel", Lastname = "Umtiti", TeamId = 3 },
                        new { Id = 33, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Gerard", Lastname = "Piqué", TeamId = 3 },
                        new { Id = 34, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Jordi", Lastname = "Alba", TeamId = 3 },
                        new { Id = 35, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Nélson", Lastname = "Semedo", TeamId = 3 },
                        new { Id = 36, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Sergio", Lastname = "Busquets", TeamId = 3 },
                        new { Id = 37, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Ivan", Lastname = "Rakitic", TeamId = 3 },
                        new { Id = 38, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Philippe", Lastname = "Coutinho", TeamId = 3 },
                        new { Id = 39, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Lionel", Lastname = "Messi", TeamId = 3 },
                        new { Id = 40, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Luis", Lastname = "Suárez", TeamId = 3 },
                        new { Id = 41, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Manuel", Lastname = "Neuer", TeamId = 4 },
                        new { Id = 42, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Mats", Lastname = "Hummels", TeamId = 4 },
                        new { Id = 43, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Jérôme", Lastname = "Boateng", TeamId = 4 },
                        new { Id = 44, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "David", Lastname = "Alaba", TeamId = 4 },
                        new { Id = 45, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Joshua", Lastname = "Kimmich", TeamId = 4 },
                        new { Id = 46, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Arjen", Lastname = "Robben", TeamId = 4 },
                        new { Id = 47, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Leon", Lastname = "Goretzka", TeamId = 4 },
                        new { Id = 48, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "James", Lastname = "Rodriguez", TeamId = 4 },
                        new { Id = 49, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Thomas", Lastname = "Müller", TeamId = 4 },
                        new { Id = 50, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Robert", Lastname = "Lewandowski", TeamId = 4 },
                        new { Id = 51, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Ederson", Lastname = "", TeamId = 5 },
                        new { Id = 52, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Nicolás", Lastname = "Otamendi", TeamId = 5 },
                        new { Id = 53, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Vincent", Lastname = "Kompany", TeamId = 5 },
                        new { Id = 54, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Benjamin", Lastname = "Mendy", TeamId = 5 },
                        new { Id = 55, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Kyle", Lastname = "Walker", TeamId = 5 },
                        new { Id = 56, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Ilkay", Lastname = "Gündogan", TeamId = 5 },
                        new { Id = 57, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Kevin", Lastname = "De Bruyne", TeamId = 5 },
                        new { Id = 58, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "David", Lastname = "Silva", TeamId = 5 },
                        new { Id = 59, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Leroy", Lastname = "Sané", TeamId = 5 },
                        new { Id = 60, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Sergio", Lastname = "Agüero", TeamId = 5 },
                        new { Id = 61, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "David", Lastname = "De Gea", TeamId = 6 },
                        new { Id = 62, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Eric", Lastname = "Bailly", TeamId = 6 },
                        new { Id = 63, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Chris", Lastname = "Smalling", TeamId = 6 },
                        new { Id = 64, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Luke", Lastname = "Shaw", TeamId = 6 },
                        new { Id = 65, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Antonio", Lastname = "Valencia", TeamId = 6 },
                        new { Id = 66, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Paul", Lastname = "Pogba", TeamId = 6 },
                        new { Id = 67, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Juan", Lastname = "Mata", TeamId = 6 },
                        new { Id = 68, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Anthony", Lastname = "Martial", TeamId = 6 },
                        new { Id = 69, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Alexis", Lastname = "Sánchez", TeamId = 6 },
                        new { Id = 70, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Romelu", Lastname = "Lukaku", TeamId = 6 },
                        new { Id = 71, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Alisson", Lastname = "", TeamId = 7 },
                        new { Id = 72, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Virgil", Lastname = "van Dijk", TeamId = 7 },
                        new { Id = 73, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Dejan", Lastname = "Lovren", TeamId = 7 },
                        new { Id = 74, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Andrew", Lastname = "Robertson", TeamId = 7 },
                        new { Id = 75, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Trent", Lastname = "Alexander-Arnold", TeamId = 7 },
                        new { Id = 76, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Jordan", Lastname = "Henderson", TeamId = 7 },
                        new { Id = 77, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Sadio", Lastname = "Mané", TeamId = 7 },
                        new { Id = 78, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Mohamed", Lastname = "Salah", TeamId = 7 },
                        new { Id = 79, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Roberto", Lastname = "Firmino", TeamId = 7 },
                        new { Id = 80, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Naby", Lastname = "Keïta", TeamId = 7 },
                        new { Id = 81, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Gianluigi", Lastname = "Buffon", TeamId = 8 },
                        new { Id = 82, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Presnel", Lastname = "Kimpembe", TeamId = 8 },
                        new { Id = 83, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Thiago", Lastname = "Silva", TeamId = 8 },
                        new { Id = 84, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Layvin", Lastname = "Kurzawa", TeamId = 8 },
                        new { Id = 85, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Thomas", Lastname = "Meunier", TeamId = 8 },
                        new { Id = 86, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Marco", Lastname = "Verratti", TeamId = 8 },
                        new { Id = 87, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Adrien", Lastname = "Rabiot", TeamId = 8 },
                        new { Id = 88, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Neymar", Lastname = "", TeamId = 8 },
                        new { Id = 89, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Kylian", Lastname = "Mbappé", TeamId = 8 },
                        new { Id = 90, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Edinson", Lastname = "Cavani", TeamId = 8 },
                        new { Id = 91, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Hugo", Lastname = "Lloris", TeamId = 9 },
                        new { Id = 92, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Toby", Lastname = "Alderweireld", TeamId = 9 },
                        new { Id = 93, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Davinson", Lastname = "Sánchez", TeamId = 9 },
                        new { Id = 94, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Kieran", Lastname = "Trippier", TeamId = 9 },
                        new { Id = 95, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Ben", Lastname = "Davies", TeamId = 9 },
                        new { Id = 96, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Dele", Lastname = "Alli", TeamId = 9 },
                        new { Id = 97, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Christian", Lastname = "Eriksen", TeamId = 9 },
                        new { Id = 98, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Heung-min", Lastname = "Son", TeamId = 9 },
                        new { Id = 99, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Lucas", Lastname = "Moura", TeamId = 9 },
                        new { Id = 100, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Harry", Lastname = "Kane", TeamId = 9 },
                        new { Id = 101, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "David", Lastname = "Ospina", TeamId = 10 },
                        new { Id = 102, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Kalidou", Lastname = "Koulibaly", TeamId = 10 },
                        new { Id = 103, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Raúl", Lastname = "Albiol", TeamId = 10 },
                        new { Id = 104, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Faouzi", Lastname = "Ghoulam", TeamId = 10 },
                        new { Id = 105, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Elseid", Lastname = "Hysaj", TeamId = 10 },
                        new { Id = 106, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Allan", Lastname = "", TeamId = 10 },
                        new { Id = 107, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Piotr", Lastname = "Zieliński", TeamId = 10 },
                        new { Id = 108, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Arkadiusz", Lastname = "Milik", TeamId = 10 },
                        new { Id = 109, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Dries", Lastname = "Mertens", TeamId = 10 },
                        new { Id = 110, BirthDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Lorenzo", Lastname = "Insigne", TeamId = 10 }
                    );
                });

            modelBuilder.Entity("Football_League.Models.Domain.Statistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .IsRequired();

                    b.Property<int?>("MatchPlayerMatchId");

                    b.Property<int?>("MatchPlayerPlayerId");

                    b.Property<int>("Minute");

                    b.HasKey("Id");

                    b.HasIndex("MatchPlayerMatchId", "MatchPlayerPlayerId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("Football_League.Models.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LeagueId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");

                    b.HasData(
                        new { Id = 1, LeagueId = 1, Name = "KTS Smolany" },
                        new { Id = 2, LeagueId = 1, Name = "YoungBoys" },
                        new { Id = 3, LeagueId = 1, Name = "RenegaciFC" },
                        new { Id = 4, LeagueId = 1, Name = "Apotex" },
                        new { Id = 5, LeagueId = 1, Name = "Źródlani Łyna" },
                        new { Id = 6, LeagueId = 1, Name = "Młode Orły" },
                        new { Id = 7, LeagueId = 1, Name = "Żelazno" },
                        new { Id = 8, LeagueId = 1, Name = "Kram Nidzica" },
                        new { Id = 9, LeagueId = 1, Name = "Polonia Muszaki" },
                        new { Id = 10, LeagueId = 1, Name = "Skorpion Napiwoda" },
                        new { Id = 11, LeagueId = 1, Name = "Zatorze" }
                    );
                });

            modelBuilder.Entity("Football_League.Models.Domain.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = "masensio", AccessFailedCount = 0, ConcurrencyStamp = "4c017e16-b22d-48e0-8a0c-ec10d40dfc0e", Email = "marco@asensio.pl", EmailConfirmed = false, Firstname = "Marco", Lastname = "Asensio", LockoutEnabled = false, PasswordHash = "AQAAAAEAACcQAAAAEMnz1mM3f8mrMN3n/5aPSdB0gRFQd2+GEr6/+WfptLdU+frBA3DjqB9V+FwubO5TTg==", PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "marcoAsensio" }
                    );
                });

            modelBuilder.Entity("Football_League.Models.Domain.League", b =>
                {
                    b.HasOne("Football_League.Models.Domain.User", "User")
                        .WithMany("Leagues")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Football_League.Models.Domain.Match", b =>
                {
                    b.HasOne("Football_League.Models.Domain.Team", "Away")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayId");

                    b.HasOne("Football_League.Models.Domain.Team", "Host")
                        .WithMany("HostMatches")
                        .HasForeignKey("HostId");

                    b.HasOne("Football_League.Models.Domain.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId");
                });

            modelBuilder.Entity("Football_League.Models.Domain.MatchPlayer", b =>
                {
                    b.HasOne("Football_League.Models.Domain.Match", "Match")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Football_League.Models.Domain.Player", "Player")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Football_League.Models.Domain.Player", b =>
                {
                    b.HasOne("Football_League.Models.Domain.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Football_League.Models.Domain.Statistic", b =>
                {
                    b.HasOne("Football_League.Models.Domain.MatchPlayer", "MatchPlayer")
                        .WithMany("Statistics")
                        .HasForeignKey("MatchPlayerMatchId", "MatchPlayerPlayerId");
                });

            modelBuilder.Entity("Football_League.Models.Domain.Team", b =>
                {
                    b.HasOne("Football_League.Models.Domain.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId");
                });
#pragma warning restore 612, 618
        }
    }
}
