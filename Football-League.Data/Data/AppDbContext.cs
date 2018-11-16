using System;
using System.Collections.Generic;
using System.Text;
using Football_League.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace Football_League.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<MatchPlayer> MatchPlayers { get; set; }
        public DbSet<Match> Matches{ get; set; }
        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Statistic>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Statistic>()
               .Property(s => s.Action)
               .HasConversion(
                a => a.ToString(),
                a => (Action)Enum.Parse(typeof(Action), a));

            modelBuilder.Entity<Player>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Match>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<League>()
                .HasKey(le => le.Id);
            modelBuilder.Entity<League>()
                .HasMany(l => l.Teams)
                .WithOne(t => t.League);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Leagues)
                .WithOne(l => l.User);


            modelBuilder.Entity<Team>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Team>()
                .HasMany(p => p.Players)
                .WithOne(t => t.Team);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.HostMatches)
                .WithOne(m => m.Host);
            modelBuilder.Entity<Team>()
                .HasMany(t => t.AwayMatches)
                .WithOne(m => m.Away);

            modelBuilder.Entity<MatchPlayer>()
                .HasKey(mp => new { mp.MatchId, mp.PlayerId });
            modelBuilder.Entity<MatchPlayer>()
                .HasOne(mp => mp.Match)
                .WithMany(p => p.MatchPlayers)
                .HasForeignKey(mp => mp.MatchId);
            modelBuilder.Entity<MatchPlayer>()
                .HasOne(mp => mp.Player)
                .WithMany(m => m.MatchPlayers)
                .HasForeignKey(mp => mp.PlayerId);
            modelBuilder.Entity<MatchPlayer>()
                .HasMany(mp => mp.Statistics);


            var user = new User
            {
                Id = "masensio",
                Email = "marco@asensio.pl",
                Firstname = "Marco",
                Lastname = "Asensio",
                UserName = "marcoAsensio",
                PasswordHash = "AQAAAAEAACcQAAAAEMnz1mM3f8mrMN3n/5aPSdB0gRFQd2+GEr6/+WfptLdU+frBA3DjqB9V+FwubO5TTg=="
            };

            modelBuilder.Entity<User>().HasData(user);

            var teamsNames = new List<string>
            {
                    "KTS Smolany", "YoungBoys", "RenegaciFC", "Apotex", "Źródlani Łyna", "Młode Orły", "Żelazno", "Kram Nidzica", "Polonia Muszaki", "Skorpion Napiwoda", "Zatorze"
            };

            int id = 1;
            modelBuilder.Entity<Team>().HasData(
                new
                {
                    Id = id++,
                    Name = teamsNames[id-2],
                    LeagueId=1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id++,
                    Name = teamsNames[id - 2],
                    LeagueId = 1
                },
                new
                {
                    Id = id,
                    Name = teamsNames[id - 1],
                    LeagueId = 1
                }
            );

            modelBuilder.Entity<League>().HasData(
                new
                {
                    Id = 1,
                    Name = "II NHLPN",
                    Quantity = 11,
                    UserId = user.Id
            
                }
            );

            id = 1;

            modelBuilder.Entity<Match>().HasData(
                new 
                {
                    Id = id++,
                    HostScore = 7,
                    AwayScore = 1,
                    LeagueId = 1,
                    HostId = 11,
                    AwayId = 2,
                    Date = DateTime.Now,
                    Round = 1,
                },
                new
                {
                    Id = id++,
                    HostScore = 1,
                    AwayScore = 4,
                    LeagueId = 1,
                    HostId = 3,
                    AwayId = 10,
                    Date = DateTime.Now,
                    Round = 1,
                },
                new
                {
                    Id = id++,
                    HostScore = 2,
                    AwayScore = 3,
                    LeagueId = 1,
                    HostId = 4,
                    AwayId = 9,
                    Date = DateTime.Now,
                    Round = 1,
                },
                new
                {
                    Id = id++,
                    HostScore = 3,
                    AwayScore = 3,
                    LeagueId = 1,
                    HostId = 5,
                    AwayId = 8,
                    Date = DateTime.Now,
                    Round = 1,
                },
                new
                {
                    Id = id++,
                    HostScore = 1,
                    AwayScore = 8,
                    LeagueId = 1,
                    HostId = 6,
                    AwayId = 7,
                    Date = DateTime.Now,
                    Round = 1,
                }
            );

            var playersName = new List<string>
            {
                    "Mariusz", "Damian", "Maciej", "Dawid", "Szymon", "Batman", "Maciej", "Krystian", "Patryk", "Piotr"
            };
            var playerLastname = new List<string>
            {
                    "Kaniecki", "Kwiecień", "Wasiłowski", "Duchna", "Jabłonowski", "Kurkiewicz", "Golubiński", "Czechowski", "Rutkowski", "Czaplicki"
            };
            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new 
                {
                    Id = id++,
                    Firstname = playersName[id-2],
                    Lastname = playerLastname[id-2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = id++,
                    Firstname = playersName[id - 2],
                    Lastname = playerLastname[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
