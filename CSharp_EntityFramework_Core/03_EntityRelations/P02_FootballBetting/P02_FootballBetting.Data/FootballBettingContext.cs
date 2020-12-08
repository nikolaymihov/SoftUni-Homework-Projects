using Microsoft.EntityFrameworkCore;

using P02_FootballBetting.Data.Models;
using System.Dynamic;

namespace P02_FootballBetting.Data
{
    public partial class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions<FootballBettingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(t => t.LogoUrl)
                      .IsUnicode(false);

                entity.HasOne(t => t.PrimaryKitColor)
                      .WithMany(c => c.PrimaryKitTeams)
                      .HasForeignKey(t => t.PrimaryKitColorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SecondaryKitColor)
                      .WithMany(c => c.SecondaryKitTeams)
                      .HasForeignKey(t => t.SecondaryKitColorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(g => g.HomeTeam)
                      .WithMany(t => t.HomeGames)
                      .HasForeignKey(g => g.HomeTeamId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.AwayTeam)
                      .WithMany(t => t.AwayGames)
                      .HasForeignKey(g => g.AwayTeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Username)
                      .IsUnicode(false);

                entity.Property(u => u.Password)
                      .IsUnicode(false);

            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.GameId, ps.PlayerId });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
