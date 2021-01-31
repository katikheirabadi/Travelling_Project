using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.Model;

namespace TravellingEF.DataBase
{
    public class TravellingDBContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Turist_Place> Rates { get; set; }
        public DbSet<Turist_Place> Turist_PLaces { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }

        public TravellingDBContext()
        {

        }
        public TravellingDBContext(DbContextOptions<TravellingDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b => b.ToTable("user"));
            modelBuilder.Entity<Comment>(b => b.ToTable("Comment"));
            modelBuilder.Entity<Turist_Place>(b => b.ToTable("Rate"));
            modelBuilder.Entity<Turist_Place>(b => b.ToTable("Turist_PLace"));
            modelBuilder.Entity<UserLogin>(b => b.ToTable("UserLogin"));

        }
    }
    
}
