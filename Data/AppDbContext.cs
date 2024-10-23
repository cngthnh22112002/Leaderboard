using Microsoft.EntityFrameworkCore;
using Leaderboard.Models;

namespace Leaderboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRecord> GameRecords { get; set; }
        public DbSet<UserPlay> UserPlays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameRecord>()
                .HasKey(gr => gr.RecordId);

            modelBuilder.Entity<GameRecord>()
                .HasOne(gr => gr.User)
                .WithMany(u => u.GameRecords)
                .HasForeignKey(gr => gr.UserId);

            modelBuilder.Entity<GameRecord>()
                .HasOne(gr => gr.Game)
                .WithMany(g => g.GameRecords)
                .HasForeignKey(gr => gr.GameId);

            modelBuilder.Entity<UserPlay>()
                .HasKey(up => up.PlayId);

            modelBuilder.Entity<UserPlay>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPlays)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPlay>()
                .HasOne(up => up.Game)
                .WithMany(g => g.UserPlays)
                .HasForeignKey(up => up.GameId);
        }
    }
}
