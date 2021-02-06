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
        public DbSet<Rate> Rates { get; set; }
        public DbSet<TuristPlace> TuristPLaces { get; set; }
        public DbSet<TuristPlaceCategory> TuristPlaceCategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }

        public TravellingDBContext()
        {

        }
        public TravellingDBContext(DbContextOptions<TravellingDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b => b.ToTable("User"));
            modelBuilder.Entity<Comment>(b => b.ToTable("Comment"));
            modelBuilder.Entity<Rate>(b => b.ToTable("Rate"));
            modelBuilder.Entity<TuristPlace>(b => b.ToTable("TuristPLace"));
            modelBuilder.Entity<Category>(b => b.ToTable("Category"));
            modelBuilder.Entity<City>(b => b.ToTable("City"));
            modelBuilder.Entity<Country>(b => b.ToTable("Country"));
            modelBuilder.Entity<TuristPlaceCategory>(b => b.ToTable("TuristPlaceCategory"));
            modelBuilder.Entity<UserLogin>(b => b.ToTable("UserLogin"));

        }
    }
    
}
