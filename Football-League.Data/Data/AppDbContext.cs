﻿using System;
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
                .HasMany(l => l.Teams);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Leagues);


            modelBuilder.Entity<Team>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Team>()
                .HasMany(p => p.Players);
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Matches);

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


            base.OnModelCreating(modelBuilder);
        }
    }
}
