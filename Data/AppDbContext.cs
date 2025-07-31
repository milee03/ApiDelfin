using ApiDelfin.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace ApiDelfin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<UsersPoints> UsersPoints { get; set; }
        public DbSet<UsersRewards> UsersRewards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaciones UsersPoints
            modelBuilder.Entity<UsersPoints>()
                .HasOne(up => up.User)
                .WithMany(u => u.UsersPoints)
                .HasForeignKey(up => up.IdUsers);

            modelBuilder.Entity<UsersPoints>()
                .HasOne(up => up.Point)
                .WithMany(p => p.UsersPoints)
                .HasForeignKey(up => up.IdPoints);

            // Relaciones UsersRewards
            modelBuilder.Entity<UsersRewards>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UsersRewards)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UsersRewards>()
                .HasOne(ur => ur.Reward)
                .WithMany(r => r.UsersRewards)
                .HasForeignKey(ur => ur.RewardId);
            modelBuilder.Entity<Point>()
                .Property(p => p.MoneyAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<UsersPoints>()
                .Property(up => up.PurchaseAmount)
                .HasPrecision(18, 2);
        }
    }
}
