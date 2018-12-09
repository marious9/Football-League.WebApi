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
                a => (Models.Enums.Action)Enum.Parse(typeof(Models.Enums.Action), a));

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

            //modelBuilder.Entity<Match>().HasData(
            //    new 
            //    {
            //        Id = id++,
            //        HostScore = 7,
            //        AwayScore = 1,
            //        LeagueId = 1,
            //        HostId = 11,
            //        AwayId = 2,
            //        Date = DateTime.Now,
            //        Round = 1,
            //    },
            //    new
            //    {
            //        Id = id++,
            //        HostScore = 1,
            //        AwayScore = 4,
            //        LeagueId = 1,
            //        HostId = 3,
            //        AwayId = 10,
            //        Date = DateTime.Now,
            //        Round = 1,
            //    },
            //    new
            //    {
            //        Id = id++,
            //        HostScore = 2,
            //        AwayScore = 3,
            //        LeagueId = 1,
            //        HostId = 4,
            //        AwayId = 9,
            //        Date = DateTime.Now,
            //        Round = 1,
            //    },
            //    new
            //    {
            //        Id = id++,
            //        HostScore = 3,
            //        AwayScore = 3,
            //        LeagueId = 1,
            //        HostId = 5,
            //        AwayId = 8,
            //        Date = DateTime.Now,
            //        Round = 1,
            //    },
            //    new
            //    {
            //        Id = id++,
            //        HostScore = 1,
            //        AwayScore = 8,
            //        LeagueId = 1,
            //        HostId = 6,
            //        AwayId = 7,
            //        Date = DateTime.Now,
            //        Round = 1,
            //    }
            //);

            var playerId = 1;

            var firstTeamPlayersFirstNames = new List<string>
            {
                    "Mariusz", "Damian", "Maciej", "Dawid", "Szymon", "Batman", "Maciej", "Krystian", "Patryk", "Piotr"
            };
            var firstTeamPlayersLastNames = new List<string>
            {
                    "Kaniecki", "Kwiecień", "Wasiłowski", "Duchna", "Jabłonowski", "Kurkiewicz", "Golubiński", "Czechowski", "Rutkowski", "Czaplicki"
            };
            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                },
                new
                {
                    Id = playerId++,
                    Firstname = firstTeamPlayersFirstNames[++id - 2],
                    Lastname = firstTeamPlayersLastNames[id - 2],
                    TeamId = 11,
                    BirthDate = DateTime.Parse("1996-12-11")
                }
            );

            var secondTeamPlayersFirstNames = new List<string>
            {
                    "Cristiano", "Paulo", "Wojciech", "Giorgio", "João", "Juan", "Miralem", "Leonardo", "Alex", "Sami"
            };
            var secondTeamPlayersLastNames = new List<string>
            {
                    "Ronaldo", "Dybala", "Szczęsny", "Chiellini", "Cancelo", "Cuadrado", "Pjanić", "Bonucci", "Sandro", "Khedira"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = secondTeamPlayersFirstNames[++id - 2],
                    Lastname = secondTeamPlayersLastNames[id - 2],
                    TeamId = 1,
                    BirthDate = DateTime.Parse("1988-01-01")
                }
            );

            var thirdTeamPlayersFirstNames = new List<string>
            {
                    "Thibaut", "Raphaël", "Sergio", "Daniel", "Marcelo", "Toni", "Luca", "Marco", "Gareth", "Karim"
            };
            var thirdTeamPlayersLastNames = new List<string>
            {
                    "Courtois", "Varane", "Ramos", "Carvajal", "", "Kroos", "Modrić", "Asensio", "Bale", "Benzema"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = thirdTeamPlayersFirstNames[++id - 2],
                    Lastname = thirdTeamPlayersLastNames[id - 2],
                    TeamId = 2,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );

            var forthTeamPlayersFirstNames = new List<string>
            {
                    "Marc-André", "Samuel", "Gerard", "Jordi", "Nélson", "Sergio", "Ivan", "Philippe", "Lionel", "Luis"
            };
            var forthTeamPlayersLastNames = new List<string>
            {
                    "ter Stegen", "Umtiti", "Piqué", "Alba", "Semedo", "Busquets", "Rakitic", "Coutinho", "Messi", "Suárez"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = forthTeamPlayersFirstNames[++id - 2],
                    Lastname = forthTeamPlayersLastNames[id - 2],
                    TeamId = 3,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );



            var fifthTeamPlayersFirstNames = new List<string>
            {
                    "Manuel", "Mats", "Jérôme", "David", "Joshua", "Arjen", "Leon", "James", "Thomas", "Robert"
            };
            var fifthTeamPlayersLastNames = new List<string>
            {
                    "Neuer", "Hummels", "Boateng", "Alaba", "Kimmich", "Robben", "Goretzka", "Rodriguez", "Müller", "Lewandowski"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = fifthTeamPlayersFirstNames[++id - 2],
                    Lastname = fifthTeamPlayersLastNames[id - 2],
                    TeamId = 4,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );

            var sixthTeamPlayersFirstNames = new List<string>
            {
                    "Ederson", "Nicolás", "Vincent", "Benjamin", "Kyle", "Ilkay", "Kevin", "David", "Leroy", "Sergio"
            };
            var sixthTeamPlayersLastNames = new List<string>
            {
                    "", "Otamendi", "Kompany", "Mendy", "Walker", "Gündogan", "De Bruyne", "Silva", "Sané", "Agüero"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = sixthTeamPlayersFirstNames[++id - 2],
                    Lastname = sixthTeamPlayersLastNames[id - 2],
                    TeamId = 5,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );

            var seventhTeamPlayersFirstNames = new List<string>
            {
                    "David", "Eric", "Chris", "Luke", "Antonio", "Paul", "Juan", "Anthony", "Alexis", "Romelu"
            };
            var seventhTeamPlayersLastNames = new List<string>
            {
                    "De Gea", "Bailly", "Smalling", "Shaw", "Valencia", "Pogba", "Mata", "Martial", "Sánchez", "Lukaku"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = seventhTeamPlayersFirstNames[++id - 2],
                    Lastname = seventhTeamPlayersLastNames[id - 2],
                    TeamId = 6,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );

            var eighthTeamPlayersFirstNames = new List<string>
            {
                    "Alisson", "Virgil", "Dejan", "Andrew", "Trent", "Jordan", "Sadio", "Mohamed", "Roberto", "Naby"
            };
            var eighthTeamPlayersLastNames = new List<string>
            {
                    "", "van Dijk", "Lovren", "Robertson", "Alexander-Arnold", "Henderson", "Mané", "Salah", "Firmino", "Keïta"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eighthTeamPlayersFirstNames[++id - 2],
                    Lastname = eighthTeamPlayersLastNames[id - 2],
                    TeamId = 7,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );

            var ninthTeamPlayersFirstNames = new List<string>
            {
                    "Gianluigi", "Presnel", "Thiago", "Layvin", "Thomas", "Marco", "Adrien", "Neymar", "Kylian", "Edinson"
            };
            var ninthTeamPlayersLastNames = new List<string>
            {
                    "Buffon", "Kimpembe", "Silva", "Kurzawa", "Meunier", "Verratti", "Rabiot", "", "Mbappé", "Cavani"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = ninthTeamPlayersFirstNames[++id - 2],
                    Lastname = ninthTeamPlayersLastNames[id - 2],
                    TeamId = 8,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );

            var tenthTeamPlayersFirstNames = new List<string>
            {
                    "Hugo", "Toby", "Davinson", "Kieran", "Ben", "Dele", "Christian", "Heung-min", "Lucas", "Harry"
            };
            var tenthTeamPlayersLastNames = new List<string>
            {
                    "Lloris", "Alderweireld", "Sánchez", "Trippier", "Davies", "Alli", "Eriksen", "Son", "Moura", "Kane"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = tenthTeamPlayersFirstNames[++id - 2],
                    Lastname = tenthTeamPlayersLastNames[id - 2],
                    TeamId = 9,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );

            var eleventhTeamPlayersFirstNames = new List<string>
            {
                    "David", "Kalidou", "Raúl", "Faouzi", "Elseid", "Allan", "Piotr", "Arkadiusz", "Dries", "Lorenzo"
            };
            var eleventhTeamPlayersLastNames = new List<string>
            {
                    "Ospina", "Koulibaly", "Albiol", "Ghoulam", "Hysaj", "", "Zieliński", "Milik", "Mertens", "Insigne"
            };

            id = 1;
            modelBuilder.Entity<Player>().HasData(
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                },
                new
                {
                    Id = playerId++,
                    Firstname = eleventhTeamPlayersFirstNames[++id - 2],
                    Lastname = eleventhTeamPlayersLastNames[id - 2],
                    TeamId = 10,
                    BirthDate = DateTime.Parse("1998-01-01")
                }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
