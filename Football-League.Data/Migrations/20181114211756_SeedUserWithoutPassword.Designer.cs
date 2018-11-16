﻿// <auto-generated />
using System;
using Football_League.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Football_League.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181114211756_SeedUserWithoutPassword")]
    partial class SeedUserWithoutPassword
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new { Id = 1, AwayId = 2, AwayScore = 1, Date = new DateTime(2018, 11, 14, 22, 17, 56, 362, DateTimeKind.Local), HostId = 11, HostScore = 7, LeagueId = 1, Round = 1 },
                        new { Id = 2, AwayId = 10, AwayScore = 4, Date = new DateTime(2018, 11, 14, 22, 17, 56, 364, DateTimeKind.Local), HostId = 3, HostScore = 1, LeagueId = 1, Round = 1 },
                        new { Id = 3, AwayId = 9, AwayScore = 3, Date = new DateTime(2018, 11, 14, 22, 17, 56, 364, DateTimeKind.Local), HostId = 4, HostScore = 2, LeagueId = 1, Round = 1 },
                        new { Id = 4, AwayId = 8, AwayScore = 3, Date = new DateTime(2018, 11, 14, 22, 17, 56, 364, DateTimeKind.Local), HostId = 5, HostScore = 3, LeagueId = 1, Round = 1 },
                        new { Id = 5, AwayId = 7, AwayScore = 8, Date = new DateTime(2018, 11, 14, 22, 17, 56, 364, DateTimeKind.Local), HostId = 6, HostScore = 1, LeagueId = 1, Round = 1 }
                    );
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
                });

            modelBuilder.Entity("Football_League.Models.Domain.Statistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

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
                        new { Id = "masensio", AccessFailedCount = 0, ConcurrencyStamp = "f1e7ec08-1a1c-4246-91b8-c2ea1496f3d4", Email = "marco@asensio.pl", EmailConfirmed = false, Firstname = "Marco", Lastname = "Asensio", LockoutEnabled = false, PhoneNumberConfirmed = false, TwoFactorEnabled = false, UserName = "marcoAsensio" }
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